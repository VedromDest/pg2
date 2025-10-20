namespace WebShoppie.Api.Contracts;

public class OrderResponseContract
{
    public required int OrderId { get; set; }
    public required DateTime OrderDateUtc { get; set; }
    public required OrderCustomerResponseContract OrderCustomer { get; set; }
    public required List<OrderProductResponseContract> OrderProducts { get; set; }
}

public class OrderProductResponseContract
{
    public required int Id { get; set; }
    public required int Quantity { get; set; }
    public required string Name { get; set; }
    public required decimal PriceAtPurchase { get; set; }
    //...
}

public class OrderCustomerResponseContract
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    //...
}