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
    public class WorkingController : ControllerBase
    {
        IWorkingService _workingService;
        public WorkingController(IWorkingService workingService)
        {
            _workingService = workingService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _workingService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int entityId)
        {
            var result = _workingService.GetById(entityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetWorkingsDetail()
        {
            var result = _workingService.GetWorkingsDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getsingledetail")]
        public IActionResult GetWorkingDetail(int entityId)
        {
            var result = _workingService.GetWorkingDetail(entityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Working working)
        {
            var result = _workingService.Add(working);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Working working)
        {
            var result = _workingService.Update(working);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Working working)
        {
            var result = _workingService.Delete(working);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
