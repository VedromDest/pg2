namespace WebShoppie.Domain.Model
{
    public class OrderModel
    {
        public int? Id { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public CustomerModel? CustomerModel { get; set; }

        public List<OrderProductModel> OrderProductModels { get; set; } = [];

        public decimal TotalPrice => OrderProductModels.Select(pm => pm.ProductModel.Price).Sum();

        // This would run more logic in a real world app, obviously.
        public bool IsValid()
        {
            return OrderProductModels.Count() > 0 
                && TotalPrice > 0 
                && CustomerModel is not null;
        }
    }
}
