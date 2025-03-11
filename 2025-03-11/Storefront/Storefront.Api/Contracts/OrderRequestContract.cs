namespace Storefront.Api.Contracts;

public class OrderRequestContract
{
    public int CustomerId { get; set; }
    public List<OrderProductRequestContract> Products { get; set; }
}

public class OrderProductRequestContract
{
    public int Id { get; set; }
    public int Quantity { get; set; }
}