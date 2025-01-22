using CarBooking.Application.Features.Mediator.Commands.PricingCommands;
using CarBooking.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pricings = await _mediator.Send(new GetPricingQuery());
            return Ok(pricings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var pricing = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(pricing);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePricing(RemovePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing deleted");
        }
    }
}
