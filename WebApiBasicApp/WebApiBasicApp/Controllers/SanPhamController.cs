using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBasicApp.Data;
using WebApiBasicApp.Services;
using WebApiBasicApp.ViewModel;

namespace WebApiBasicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepository _sanPhamRepository;

        public SanPhamController(ISanPhamRepository sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_sanPhamRepository.GetAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _sanPhamRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
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
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, SanPhamVM sp)
        {
            
            try
            {
                if (id != sp.MaSanPham)
                {
                    return NotFound();
                }
                else
                {
                    _sanPhamRepository.Update(sp);
                    return Ok();
                }              
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _sanPhamRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add(SanPhamModel sp)
        {
            try
            {
                var data = _sanPhamRepository.Add(sp);
                return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
