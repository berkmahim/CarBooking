using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.ServiceCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.ServiceHandlers;

public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public RemoveServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(service);
    }
}