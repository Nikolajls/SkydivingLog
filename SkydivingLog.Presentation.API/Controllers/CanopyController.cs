using Microsoft.AspNetCore.Mvc;
using SkydivingLog.Models.Gears;
using System.Collections.Generic;

namespace SkydivingLog.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CanopyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new List<Canopy>()
            {
                new Canopy() {SerialNumber = "12345"}
            };
            return Ok(data);
        }
    }
}