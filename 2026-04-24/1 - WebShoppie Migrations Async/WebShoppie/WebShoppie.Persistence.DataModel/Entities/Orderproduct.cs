using System.ComponentModel.DataAnnotations;

namespace WebShoppie.DataModel.Entities;

public class Orderproduct
{
    public long OrderProductId { get; set; }

    public long OrderId { get; set; }

    public long Productid { get; set; }

    [Range(1,999)]
    public int Quantity { get; set; }

    [Range(0,999)]
    public decimal Price { get; set; }

    public Order Order { get; set; }

    public Product Product { get; set; }
}
