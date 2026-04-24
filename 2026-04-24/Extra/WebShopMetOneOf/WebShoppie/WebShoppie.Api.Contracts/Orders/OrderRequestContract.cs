namespace WebShoppie.Api.Contracts.Orders;

public class OrderRequestContract
{
    public int CustomerId { get; set; }
    public List<OrderProductRequestContract> OrderProducts { get; set; }
}

public class OrderProductRequestContract
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}