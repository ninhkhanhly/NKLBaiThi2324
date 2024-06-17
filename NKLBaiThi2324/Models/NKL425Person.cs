using System.ComponentModel.DataAnnotations;

namespace NKLBaiThi2324.Models
{
    public class NKL425Persons
    {
        [Key]
        public string MALop { get; set; }
        public string TenLop { get; set; }
        public string MaSinhVien { get; set; }
    }
}