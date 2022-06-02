using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBasicApp.ViewModel
{
    public class SanPhamVM
    {
        public Guid MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Mota { get; set; }
        public double Dongia { get; set; }
        public byte GiamGia { get; set; }
    }
}
