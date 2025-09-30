namespace WebShopGent.Contracts;

public class OrderResponseContract
{
    public Guid OrderId { get; set; }
    public DateTime OrderDateUtc { get; set; }
    public OrderCustomerResponseContract OrderCustomer { get; set; }
    public List<OrderProductResponseContract> OrderProducts { get; set; }
}

public class OrderProductResponseContract
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; }
    public decimal PriceAtPurchase { get; set; }
    //...
}

public class OrderCustomerResponseContract
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    //...
}