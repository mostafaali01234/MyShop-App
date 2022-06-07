using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public Double Quantity { get; set; }
        public Double? Discount { get; set; }
        public DateTime? Discount_Start { get; set; }
        public DateTime? Discount_End { get; set; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Update { get; set; }
        public int? Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { set; get; }
    }
}
