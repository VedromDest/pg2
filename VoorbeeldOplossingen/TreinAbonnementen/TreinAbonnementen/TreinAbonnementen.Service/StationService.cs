using TreinAbonnementen.Api.Contracts;
using TreinAbonnementen.Persistence;

namespace TreinAbonnementen.Service;

public interface IStationService
{
    StationResponseContract Create(StationRequestContract contract);
    StationResponseContract? GetById(int id);
    void UpdateById(int id, StationRequestContract contract);
    IEnumerable<StationResponseContract> GetAll();
}

public class EntityNotFoundException(string message) : Exception(message);

public class StationService(TrainSubsDbContext context) : IStationService
{
    public StationResponseContract Create(StationRequestContract contract)
    {
        var entity = contract.AsEntity();

        context.Stations.Add(entity);
        context.SaveChanges();

        return entity.AsContract();
    }

    public StationResponseContract? GetById(int id)
    {
        return context.Stations.Find(id)?.AsContract();
    }

    public void UpdateById(int id, StationRequestContract contract)
    {
        var entity = context.Stations.Find(id);
        if (entity is null) throw new EntityNotFoundException($"Station {id} does not exists.");
        entity.HasWaitingRoom = contract.HasWaitingRoom;
        context.SaveChanges();
    }

    public IEnumerable<StationResponseContract> GetAll()
    {
        return context.Stations.Select(e => e.AsContract());
    }
}