using MediatR;

namespace CarBooking.Application.Features.Mediator.Commands.SocialMediaCommands;

public class CreateSocialMediaCommand : IRequest
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string ICon { get; set; }
}