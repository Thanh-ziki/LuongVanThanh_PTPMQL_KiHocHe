using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    [Table("Employees")]
    public class Emloyee
    {
        [Key]
        public string? EmloyeeId { get; set; }
        public string? FullName { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Address chỉ được nhập số.")]
        public string? Address { get; set; }
    }
}