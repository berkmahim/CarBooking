using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.CarCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            Fuel = command.Fuel,
            Model = command.Model,
            BrandId = command.BrandId,
            Transmission = command.Transmission,
            BigImageUrl = command.BigImageUrl,
            Km = command.Km,
            CoverImageUrl = command.CoverImageUrl,
            Luggage = command.Luggage,
            Seat = command.Seat,
        });
    }
}