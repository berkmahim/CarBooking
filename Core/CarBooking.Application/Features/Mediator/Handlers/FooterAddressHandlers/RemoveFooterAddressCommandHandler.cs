using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
{
    private readonly IRepository<FooterAddress> _repository;

    public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var footerAddress = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(footerAddress);
    }
}