using System.ComponentModel.DataAnnotations.Schema;

namespace silentAPI.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string PanNumber { get; set; }
        public string AdharNumber { get; set; }
        public string Email { get; set; }
      
      

        public DateTime CurrentDate { get; set; } = DateTime.Now;

    }
}
