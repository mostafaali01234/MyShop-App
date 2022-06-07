using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class ProductsReviews
    {
        public int Id { get; set; }
        public int? Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { set; get; }
        public int? User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { set; get; }
        public string Title { get; set; }
        public string Cons { get; set; }
        public string Pros { get; set; }
        public float Rating { get; set; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Update { get; set; }
    }
}
