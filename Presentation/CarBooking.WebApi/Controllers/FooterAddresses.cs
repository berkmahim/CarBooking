using CarBooking.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBooking.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddresses : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddresses(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var footerAddresses = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(footerAddresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var footerAddress = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(footerAddress);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer address eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer address güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddress(RemoveFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer address silindi");
        }
    }
}
