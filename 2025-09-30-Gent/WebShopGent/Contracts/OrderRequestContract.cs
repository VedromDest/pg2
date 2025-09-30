namespace WebShopGent.Contracts;

public class OrderRequestContract
{
    public Guid CustomerId { get; set; }
    public List<OrderRequestProductContract> Products { get; set; } = [];
}

public class OrderRequestProductContract
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}