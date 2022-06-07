using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int? type_Id { get; set; }
        [ForeignKey("type_Id")]
        public AccountTypes AccountTypes { set; get; }
        public DateTime Register_Date { get; set; }
        public DateTime? Last_Login { get; set; }
       
    }
}
