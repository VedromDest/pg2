using System.ComponentModel.DataAnnotations;

namespace WebShoppie.DataModel.Entities;

public class Order
{
    public long OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public long CustomerId { get; set; }

    [Range(0, 10000)]
    public decimal TotalPrice { get; set; }

    public  Customer? Customer { get; set; } = null!;

    public  ICollection<Orderproduct> OrderProducts { get; set; } = new List<Orderproduct>();
}
