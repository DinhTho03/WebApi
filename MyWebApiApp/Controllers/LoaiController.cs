using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try 
            {
                var dsLoai = _context.loais.ToList();
                return Ok(dsLoai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id )
        {
            var Loai = _context.loais.SingleOrDefault(lo =>lo.MaLoai ==id);
            if (Loai != null) 
            { 
                return Ok(Loai);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        /*[Authorize]*/ // text error 
        public IActionResult CreateNew(LoaiModel loaiModel)
        {
            try { 
            var loai = new Loai
            {
                TenLoai = loaiModel.TenLoai,
            };
            _context.Add(loai);
            _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id ,LoaiModel loaiModel)
        {
            var Loai = _context.loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (Loai != null)
            {   
                Loai.TenLoai = loaiModel.TenLoai;
                _context.SaveChanges();

                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(int id)
        {
            var Loai = _context.loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (Loai != null)
            {
                _context.Remove(Loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
