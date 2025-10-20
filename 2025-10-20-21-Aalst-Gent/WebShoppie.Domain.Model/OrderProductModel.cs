namespace WebShoppie.Domain.Model
{
    public class OrderProductModel
    {
        public int Quantity { get; set; }
        public required ProductModel ProductModel { get; set; }
    }
}
