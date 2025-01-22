using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.ServiceCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.ServiceHandlers;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public UpdateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.ServiceId);
        service.Description = request.Description;
        service.Title = request.Title;
        service.IconUrl = request.IconUrl;
        await _repository.UpdateAsync(service);
    }
}