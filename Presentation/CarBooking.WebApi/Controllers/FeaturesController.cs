using CarBooking.Application.Features.Mediator.Commands.FeatureCommands;
using CarBooking.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Features : ControllerBase
    {
        private readonly IMediator _mediator;

        public Features(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var features = await _mediator.Send(new GetFeatureQuery());
            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var feature = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(feature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(RemoveFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature removed");
        }
    }
}
