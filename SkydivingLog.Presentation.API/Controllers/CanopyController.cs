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
        [Route("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            var canopy = await _mediator.Send(new FindCanopyById.Query()
            {
                Id = Id
            });
            return Ok(canopy);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allCanopies = await _mediator.Send(new FindAllCanopies.Query());
            return Ok(allCanopies);
        }
    }
}