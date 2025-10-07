namespace Storefront.Api.Contracts;

public class OrderResponseContract
{
    public required int Id { get; set; }
    public required OrderCustomerResponseContract Customer { get; set; }
    public required List<OrderProductResponseContract> Products { get; set; }
}

public class OrderCustomerResponseContract
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string Email { get; set; }
    public required string? Country { get; set; }
}

public class OrderProductResponseContract
{
    public required int Id { get; set; }
    public required string NaamAtOrder { get; set; }
    public required double PriceAtOrder { get; set; }
    public required int Quantity { get; set; }
}