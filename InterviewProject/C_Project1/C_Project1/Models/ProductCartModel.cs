namespace C_Project1.Models
{
    public class ProductCartModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public ProductInfoModel Product { get; set; }

    }
}
