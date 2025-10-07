namespace WebShop.Contracts;

public class OrderRequestContract
{
    public Guid CustomerId { get; set; }
    public List<OrderProductRequestContract> Products { get; set; }
}

public class OrderProductRequestContract
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}