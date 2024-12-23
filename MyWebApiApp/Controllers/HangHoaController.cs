﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id ) 
        {
            try
            {

            
            var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
            if (hanghoa == null)
            {
                return NotFound();
            }    
            return Ok(hanghoa);
            }
            catch { return BadRequest(); }

        }

        [HttpPost]
        public IActionResult Create (HangHoaVM hangHoaVM) 
        { 
            var hanghoa = new HangHoa
            {
                MaHangHoa =  Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,Data = hanghoa
            });

        }

        [HttpPut]
        public IActionResult Edit(string id ,HangHoa hangHoaEdit)
        {
            try
            {


                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if (id != hanghoa.MaHangHoa.ToString()){
                    return BadRequest();
                }
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia;
                return Ok();

            }
            catch { return BadRequest(); }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {


                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hangHoas.Remove(hanghoa);
                return Ok();
            }
            catch 
            { 
                return BadRequest(); 
            }
        }
    }
}
