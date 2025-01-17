using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.CarCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers;

public class RemoveCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public RemoveCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCarCommand command)
    {
        var car = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(car);
    }
}