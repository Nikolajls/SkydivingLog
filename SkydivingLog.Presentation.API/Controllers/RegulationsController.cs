using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkydivingLog.Infrastructure.Queries.Gear.Canopies;
using System.Threading.Tasks;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegulationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegulationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CanPersonJump")]
        public async Task<IActionResult> CanPersonJump([FromBody] CanPersonJumpCanopy.Query query)
        {
            var can = await _mediator.Send(query);
            return Ok(can);
        }
    }
}