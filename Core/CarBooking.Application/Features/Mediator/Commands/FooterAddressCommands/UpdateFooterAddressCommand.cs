using MediatR;

namespace CarBooking.Application.Features.Mediator.Commands.FooterAddressCommands;

public class UpdateFooterAddressCommand : IRequest
{
    public int FooterAddressId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}