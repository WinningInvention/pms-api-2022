using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("PMSPolicy")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet(nameof(GetHospital))]
        public IActionResult GetHospital(int id)
        {
            var result = _hospitalService.GetHospital(id);
            if(result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetAllHospital))]
        public IActionResult GetAllHospital()
        {
            var result = _hospitalService.GetAllHospital();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPost(nameof(InsertHospital))]
        public IActionResult InsertHospital(Hospital hospital)
        {
            _hospitalService.InsertHospital(hospital);
            return Ok("Data inserted");
        }

        [HttpPut(nameof(UpdateHospital))]
        public IActionResult UpdateHospital(Hospital hospital)
        {
            _hospitalService.UpdateHospital(hospital);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteHospital))]
        public IActionResult DeleteHospital(int id)
        {
            _hospitalService.DeleteHospital(id);
            return Ok("Data deleted");
        }
    }
}

