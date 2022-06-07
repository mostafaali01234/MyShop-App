using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class AccountTypes
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
