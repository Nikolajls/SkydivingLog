using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkydivingLog.Infrastructure.Queries.Gear.Canopies;
using System.Threading.Tasks;

namespace SkydivingLog.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CanopyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CanopyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allCanopies = await _mediator.Send(new FindAllCanopies.Query());
            return Ok(allCanopies);
        }
    }
}