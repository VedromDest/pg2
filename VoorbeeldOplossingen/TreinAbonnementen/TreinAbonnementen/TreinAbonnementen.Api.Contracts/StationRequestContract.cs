namespace TreinAbonnementen.Api.Contracts;

public class StationRequestContract
{
    public required string Name { get; set; }
    public bool HasWaitingRoom { get; set; }
}