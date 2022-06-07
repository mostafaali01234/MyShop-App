using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int? User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { set; get; } 
        public Double ItemsTotal { get; set; }
        public Double Discount { get; set; }
        public Double Total { get; set; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Update { get; set; }
       
    }
}
