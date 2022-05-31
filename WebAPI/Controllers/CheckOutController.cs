using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        ICheckOutService _checkOutService;
        public CheckOutController(ICheckOutService checkOutService)
        {
            _checkOutService = checkOutService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _checkOutService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int entityid)
        {
            var result = _checkOutService.GetById(entityid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CheckOut checkOut)
        {
            var result = _checkOutService.Add(checkOut);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CheckOut checkOut)
        {
            var result = _checkOutService.Update(checkOut);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CheckOut checkOut)
        {
            var result = _checkOutService.Delete(checkOut);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

