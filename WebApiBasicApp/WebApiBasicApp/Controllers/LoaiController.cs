using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBasicApp.Data;
using WebApiBasicApp.ViewModel;

namespace WebApiBasicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly SanPhamDbContext _context;

        public LoaiController(SanPhamDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(LoaiVM loaiVM)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = loaiVM.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public IActionResult Update(int id, LoaiVM loaiVM)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
                if (loai != null)
                {
                    loai.TenLoai = loaiVM.TenLoai;
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
                if (loai != null)
                {
                    _context.Remove(loai);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
