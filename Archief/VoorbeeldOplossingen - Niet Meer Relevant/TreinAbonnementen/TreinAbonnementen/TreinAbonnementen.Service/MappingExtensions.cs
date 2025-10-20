using TreinAbonnementen.Api.Contracts;
using TreinAbonnementen.Persistence;

namespace TreinAbonnementen.Service;

public static class MappingExtensions
{
    public static CustomerResponseContract AsContract(this Customer entity)
    {
        return new CustomerResponseContract
        {
            Id = entity.Id,
            Email = entity.Email,
            FirstName = entity.FirstName,
            LastName = entity.LastName
        };
    }
    
    public static Customer AsEntity(this CustomerRequestContract contract)
    {
        return new Customer
        {
            FirstName = contract.FirstName,
            LastName = contract.LastName,
            Email = contract.Email
        };
    }

    public static StationResponseContract AsContract(this Station entity)
    {
        return new StationResponseContract
        {
            Id = entity.Id,
            Name = entity.Name,
            HasWaitingRoom = entity.HasWaitingRoom
        };
    }

    public static Station AsEntity(this StationRequestContract contract)
    {
        return new Station
        {
            Name = contract.Name,
            HasWaitingRoom = contract.HasWaitingRoom
        };
    }
    
    public static SubscriptionResponseContract AsContract(this Subscription entity)
    {
        return new SubscriptionResponseContract()
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            Station1Id = entity.Station1Id,
            Station2Id = entity.Station2Id,
            ValidFrom = entity.ValidFrom,
            ValidTo = entity.ValidTo,
            ComfortLevel = entity.ComfortLevel,
            Station1Name = entity.Station1.Name,
            Station2Name = entity.Station2.Name,
            CustomerName = entity.Customer.FirstName + " " + entity.Customer.LastName
        };
    }

    public static Subscription AsEntity(this SubscriptionRequestContract contract)
    {
        return new Subscription()
        {
            ValidFrom = contract.ValidFrom,
            ValidTo = contract.ValidTo,
            Station1Id = contract.Station1Id,
            Station2Id = contract.Station2Id,
            CustomerId = contract.CustomerId,
            ComfortLevel = contract.ComfortLevel
        };
    }

}