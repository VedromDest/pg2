namespace WebShop.Repositories;

using WebShop.Contracts;

public static class MappingExtensions
{
    public static ProductResponseContract Map(this ProductRequestContract product)
    {
        return new ProductResponseContract()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        };
    }
}