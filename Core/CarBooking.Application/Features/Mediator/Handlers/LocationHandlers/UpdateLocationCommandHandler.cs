using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.LocationCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.LocationHandlers;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public UpdateLocationCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _repository.GetByIdAsync(request.LocationId);
        location.Name = request.Name;
        await _repository.UpdateAsync(location);
    }
}