using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBasicApp.Data;
using WebApiBasicApp.ViewModel;

namespace WebApiBasicApp.Services
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly SanPhamDbContext _context;

        public SanPhamRepository(SanPhamDbContext context)
        {
            _context = context;
        }
        public SanPhamVM Add(SanPhamModel sp)
        {
            var sanPham = new SanPham
            {
                TenSanPham = sp.TenSanPham,
                Mota = sp.Mota,
                Dongia = sp.Dongia,
                GiamGia = sp.GiamGia
            };
            _context.Add(sanPham);
            _context.SaveChanges();

            return new SanPhamVM
            {
                MaSanPham = sanPham.MaSanPham,
                TenSanPham = sanPham.TenSanPham,
                Mota = sanPham.Mota,
                Dongia = sanPham.Dongia,
                GiamGia = sanPham.GiamGia
            };
        }

        public void Delete(Guid id)
        {
            var sanPham = _context.SanPhams.SingleOrDefault(lo => lo.MaSanPham == id);
            if (sanPham != null)
            {
                _context.Remove(sanPham);
                _context.SaveChanges();
            }
        }

        public List<SanPhamVM> GetAll()
        {
            var sanPhams = _context.SanPhams.Select(sp => new SanPhamVM
            {
                MaSanPham = sp.MaSanPham,
                TenSanPham = sp.TenSanPham,
                Mota = sp.Mota,
                Dongia = sp.Dongia,
                GiamGia = sp.GiamGia
            });
            return sanPhams.ToList();
        }

        public SanPhamVM GetById(Guid id)
        {
            var sanPham = _context.SanPhams.SingleOrDefault(sp => sp.MaSanPham == id);
            if (sanPham != null)
            {
                return new SanPhamVM
                {
                    MaSanPham = sanPham.MaSanPham,
                    TenSanPham = sanPham.TenSanPham,
                    Mota = sanPham.Mota,
                    Dongia = sanPham.Dongia,
                    GiamGia = sanPham.GiamGia
                };
            }
            return null;
        }

        public void Update(SanPhamVM sanPham)
        {
            var _sanPham = _context.SanPhams.SingleOrDefault(sp => sp.MaSanPham == sanPham.MaSanPham);
            if (_sanPham != null)
            {
                _sanPham.TenSanPham = sanPham.TenSanPham;
                _sanPham.Mota = sanPham.Mota;
                _sanPham.Dongia = sanPham.Dongia;
                _sanPham.GiamGia = sanPham.GiamGia;
                _context.SaveChanges();
            }

            
        }
    }
}
