namespace WebShoppie.Domain.Model;

public class OrderModel
{
    public int? OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal? TotalPrice => OrderProducts?.Sum(op => op.Price);
    public int CustomerId { get; set; }
    public CustomerModel? Customer { get; set; }
    public List<OrderProductModel>? OrderProducts { get; set; }
}