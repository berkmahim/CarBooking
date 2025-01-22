using CarBooking.Application.Features.Mediator.Commands.LocationCommands;
using CarBooking.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var locations = await _mediator.Send(new GetLocationQuery());
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var location = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(RemoveLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location deleted");
        }
    }
}
