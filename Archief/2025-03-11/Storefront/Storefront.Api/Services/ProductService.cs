using Storefront.Api.Contracts;
using Storefront.Persistence;

namespace Storefront.Api.Services
{
    public class ProductService(StorefrontContext storefrontContext) : IProductService
    {
        public ProductResponseContract Create(ProductRequestContract request)
        {
            var product = new Product()
            {
                Name = request.Name,
                AgeRating = request.AgeRating,
                Description = request.Description,
                Price = (decimal)request.Price,
                StockCount = request.StockCount              
            };

            storefrontContext.Products.Add(product);
            storefrontContext.SaveChanges();

            return MapToContract(product);
        }

        public void Delete(int id)
        {
            var product = storefrontContext.Products.Find(id);

            if (product is null)
            {
                throw new Exception("Product does not exist");
            }

            storefrontContext.Products.Remove(product);
            storefrontContext.SaveChanges();
        }

        public List<ProductResponseContract> GetAll()
        {
            return storefrontContext.Products.Select(efp => MapToContract(efp)).ToList();
        }

        public ProductResponseContract? GetById(int id)
        {
            return MapToContract(storefrontContext.Products.Find(id));
        }

        public void Update(int id, ProductRequestContract contract)
        {
            var product = storefrontContext.Products.Find(id);

            product.Price = (decimal)contract.Price;
            //...

            storefrontContext.Update(product);
            storefrontContext.SaveChanges();
        }

        private static ProductResponseContract? MapToContract(Product? product)
        {
            if (product is null)
                return null;

            return new ProductResponseContract
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = (double)product.Price,
                AgeRating = product.AgeRating,
                StockCount = product.StockCount
            };
        }
    }
}
