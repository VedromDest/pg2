using System.ComponentModel.DataAnnotations;

namespace WebShoppie.DataModel.Entities;

public class Product
{
    public long Productid { get; set; }

    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    [Range(0,999)]
    public decimal Price { get; set; }

    [Range(0,999)]
    public int StockCount { get; set; }

    public ICollection<Orderproduct> OrderProducts { get; set; } = new List<Orderproduct>();
}
