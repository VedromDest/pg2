using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts;

public class ProductRequestContract
{
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
    [Range(0,10000)]
    public decimal Price { get; set; }
}