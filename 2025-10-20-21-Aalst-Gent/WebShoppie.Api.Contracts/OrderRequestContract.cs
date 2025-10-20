namespace WebShoppie.Api.Contracts;

public class OrderRequestContract
{
    public int CustomerId { get; set; }
    public IEnumerable<OrderRequestProductContract> Products { get; set; } = [];
}

public class OrderRequestProductContract
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}