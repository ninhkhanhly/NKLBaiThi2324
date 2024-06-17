using System.ComponentModel.DataAnnotations;

namespace NKLBaiThi2324.Models
{
    public class NKL425Employee
    {
        [Key]
        public string CCCD { get; set; }
        public string TenSinhVien { get; set; }
        public string GioiTinh { get; set; }
    }
}