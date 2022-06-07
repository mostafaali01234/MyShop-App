using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class OrdersTransaction
    {
        public int Id { get; set; }
        public int? Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { set; get; }
        public int? User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { set; get; }
        public string Status { get; set; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Update { get; set; }
    }
}
