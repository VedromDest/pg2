namespace WebShoppie.Api.Contracts.Orders;

public class OrderResponseContract
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string Email { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderResponseProductContract> OrderItems { get; set; }
}

public class OrderResponseProductContract
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPriceAtPurchase { get; set; }
}