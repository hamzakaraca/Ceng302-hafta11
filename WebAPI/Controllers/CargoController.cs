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
    public class CargoController : ControllerBase
    {
        ICargoService _cargoService;
        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cargoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")] 
        public IActionResult GetById(int entityId)
        {
            var result = _cargoService.GetById(entityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Cargo cargo)
        {
            var result = _cargoService.Add(cargo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Cargo cargo)
        {
            var result = _cargoService.Update(cargo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Cargo cargo)
        {
            var result = _cargoService.Delete(cargo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
