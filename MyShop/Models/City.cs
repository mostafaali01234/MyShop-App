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
        public string Name { get; set; }
        public int? State_Id { get; set; }
        [ForeignKey("State_Id")]
        public State? State { set; get; }
        //public virtual ICollection<Line> Lines { get; set; }
    }
}
