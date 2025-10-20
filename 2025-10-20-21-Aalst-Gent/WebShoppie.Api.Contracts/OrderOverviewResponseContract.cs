namespace WebShoppie.Api.Contracts;

public class OrderOverviewResponseContract
{
    public int OrderId { get; set; }
    public DateTime OrderDateTimeUtc { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalPrice { get; set; }
}