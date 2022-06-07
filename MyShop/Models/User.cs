using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int? type_Id { get; set; }
        [ForeignKey("type_Id")]
        public AccountTypes AccountTypes { set; get; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Login { get; set; }
       
    }
}
