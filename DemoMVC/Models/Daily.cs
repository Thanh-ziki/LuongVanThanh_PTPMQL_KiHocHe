using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    [Table("Dailys")]
    public class Daily
    {
        [Key]
        public string? MaKhachHang { get; set; }
        public string? TenKhachHang { get; set; }
        public string? MaDonHang { get; set; }
        public string? HaHopDong {get; set;}
        public string? MaSoThue { get; set; }

    }
}