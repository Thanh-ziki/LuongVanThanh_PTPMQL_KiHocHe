using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
