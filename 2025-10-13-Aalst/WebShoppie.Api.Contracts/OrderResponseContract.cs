namespace WebShop.Contracts;

public class OrderResponseContract
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }

    public OrderCustomerResponseContract Customer { get; set; }
    public List<OrderProductResponseContract> Products { get; set; }
}

public class OrderProductResponseContract
{
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class OrderCustomerResponseContract
{
    public Guid Id { get; set; }
    public string Country { get; set; } // Proxy voor adres
}