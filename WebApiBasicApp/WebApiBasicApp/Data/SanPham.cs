using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBasicApp.Data
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public Guid MaSanPham { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenSanPham { get; set; }

        public string Mota { get; set; }

        [Range(0, double.MaxValue)]
        public double Dongia { get; set; }

        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
