using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBooking.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocailMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocailMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var socialMedias = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(socialMedias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var socialMedia = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(socialMedia);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Social media has been created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Social media has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(RemoveSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Social media has been deleted");
        }
    }
}
