using System.ComponentModel.DataAnnotations;

namespace Storefront.Api.Contracts;

public class ProductRequestContract
{
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
    [Range(0,10000)]
    public double Price { get; set; }
    [Range(0,21)]
    public int AgeRating { get; set; }
    [Range(0,100000)]
    public int StockCount { get; set; }
}