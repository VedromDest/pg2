using System.ComponentModel.DataAnnotations;

namespace WebShoppie.Api.Contracts;

public class ProductRequestContract
{
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(300)]
    public required string Description { get; set; }
    [Range(0,10000)]
    public required decimal Price { get; set; }
}