namespace Storefront.Api.Contracts;

public class OrderResponseContract
{
    public int Id { get; set; }
    public OrderCustomerResponseContract Customer { get; set; }
    public List<OrderProductResponseContract> Products { get; set; }
}

public class OrderCustomerResponseContract
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
}

public class OrderProductResponseContract
{
    public int Id { get; set; }
    public string NaamAtOrder { get; set; }
    public double PriceAtOrder { get; set; }
    public int Quantity { get; set; }
}