namespace WebShoppie.Api.Contracts;

public class OrderOverviewResponseContract
{
    public Guid OrderId { get; set; }
    public DateTime OrderDateTimeUtc { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalPrice { get; set; }
}