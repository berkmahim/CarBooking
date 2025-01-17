using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.CarCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        var car = await _repository.GetByIdAsync(command.CarId);
        car.Fuel = command.Fuel;
        car.Km = command.Km;
        car.Luggage = command.Luggage;
        car.Model = command.Model;
        car.Seat = command.Seat;
        car.BigImageUrl = command.BigImageUrl;
        car.CoverImageUrl = command.CoverImageUrl;
        car.Transmission = command.Transmission;
        car.BrandId = command.BrandId;
        await _repository.UpdateAsync(car);
    }
}