using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class City
    {
        public City()
        {
            //this.Lines = new HashSet<Line>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        public int? State_Id { get; set; }
        [ForeignKey("State_Id")]
        public State? State { set; get; }
        //public virtual ICollection<Line> Lines { get; set; }
    }
}
