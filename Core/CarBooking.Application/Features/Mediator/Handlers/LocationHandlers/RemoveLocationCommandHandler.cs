using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.LocationCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.LocationHandlers;

public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public RemoveLocationCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(location);
    }
}