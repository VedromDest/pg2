namespace TreinAbonnementen.Api.Contracts;

public class StationResponseContract
{
    public required string Name { get; set; }
    public int Id { get; set; }
    public bool HasWaitingRoom { get; set; }
}