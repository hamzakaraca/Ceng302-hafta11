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
    public class CheckInController : ControllerBase
    {
        ICheckInService _checkInService;
        public CheckInController(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _checkInService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int entityid)
        {
            var result = _checkInService.GetById(entityid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CheckIn checkIn)
        {
            var result = _checkInService.Add(checkIn);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CheckIn checkIn)
        {
            var result = _checkInService.Update(checkIn);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CheckIn checkIn)
        {
            var result = _checkInService.Delete(checkIn);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
