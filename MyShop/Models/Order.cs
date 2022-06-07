using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { set; get; }
        public Double Items_Total { get; set; }
        public Double Items_Discount { get; set; }
        public Double Tax { get; set; }
        public Double Shipping { get; set; }
        public string Promo_Code { get; set; }
        public Double Discount { get; set; }
        public Double Total { get; set; }
        public int? City_Id { get; set; }
        [ForeignKey("City_Id")]
        public City City { set; get; }
        public int? State_Id { get; set; }
        [ForeignKey("State_Id")]
        public State State { set; get; }
        public string Address_description { get; set; }
        public string Line { get; set; }
        public string Status { get; set; }
        public int type_Id { get; set; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Update { get; set; }
       
    }
}
