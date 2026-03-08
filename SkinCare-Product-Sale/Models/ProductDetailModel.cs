using Data_Access_Layer.Entities;

namespace SkinCare_Product_Sale.Models
{
    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
