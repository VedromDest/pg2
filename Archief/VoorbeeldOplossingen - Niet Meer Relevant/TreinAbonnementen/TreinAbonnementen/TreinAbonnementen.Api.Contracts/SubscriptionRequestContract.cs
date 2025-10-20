namespace TreinAbonnementen.Api.Contracts;

public class SubscriptionRequestContract
{
    public required int CustomerId { get; set; }

    public required int Station1Id { get; set; }

    public required int Station2Id { get; set; }

    public required DateTime ValidFrom { get; set; }

    public required DateTime ValidTo { get; set; }

    public required int ComfortLevel { get; set; }
}