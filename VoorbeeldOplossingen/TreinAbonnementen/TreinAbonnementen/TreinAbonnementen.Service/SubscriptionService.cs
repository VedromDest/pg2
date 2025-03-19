using Microsoft.EntityFrameworkCore;
using TreinAbonnementen.Api.Contracts;
using TreinAbonnementen.Persistence;

namespace TreinAbonnementen.Service;

public interface ISubscriptionService
{
    SubscriptionResponseContract Create(SubscriptionRequestContract contract);
    SubscriptionResponseContract? GetById(int id);
    IEnumerable<SubscriptionResponseContract> GetAll();
}

public class OverlappingSubscriptionException(string message) : Exception(message);

public class SubscriptionService(TrainSubsDbContext context) : ISubscriptionService
{
    public SubscriptionResponseContract Create(SubscriptionRequestContract contract)
    {
        var entity = contract.AsEntity();

        var overlappingSubCount = context.Subscriptions.Count(s => 
                s.CustomerId == entity.CustomerId
             && s.Station1Id == entity.Station1Id
             && s.Station2Id == entity.Station2Id
             && s.ValidFrom <= entity.ValidTo && entity.ValidFrom <= s.ValidTo);

        if (overlappingSubCount > 0)
            throw new OverlappingSubscriptionException("Subscription overlaps are not allowed.");

        context.Subscriptions.Add(entity);
        context.SaveChanges();

        return GetById(entity.Id)!;
    }

    public SubscriptionResponseContract? GetById(int id)
    {
        var entity = context.Subscriptions
            .Include(a => a.Customer)
            .Include(a => a.Station1)
            .Include(a => a.Station2)
            .SingleOrDefault(a => a.Id == id);

        return entity?.AsContract();
    }

    public IEnumerable<SubscriptionResponseContract> GetAll()
    {
        return context.Subscriptions
            .Include(a => a.Customer)
            .Include(a => a.Station1)
            .Include(a => a.Station2)
            .Select(e => e.AsContract());
    }
}