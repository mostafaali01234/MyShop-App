using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int? Cart_Id { get; set; }
        [ForeignKey("Cart_Id")]
        public Cart Cart { set; get; } 
        public int? Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { set; get; }
        public Double Price { get; set; }
        public Double Discount { get; set; }
        public Double Quantity { get; set; }
        public Double Total { get; set; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Update { get; set; }
       
    }
}
