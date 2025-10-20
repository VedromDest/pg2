namespace TreinAbonnementen.Api.Contracts;

public class SubscriptionResponseContract
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; }

    public int Station1Id { get; set; }

    public int Station2Id { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public int ComfortLevel { get; set; }

    public required string CustomerName { get; set; }
    public required string Station1Name { get; set; }
    public required string Station2Name { get; set; }
}