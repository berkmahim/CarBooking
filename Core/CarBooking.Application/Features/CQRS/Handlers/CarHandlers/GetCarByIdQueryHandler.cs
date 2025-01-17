using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Queries.CarQueries;
using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _carRepository;

    public GetCarByIdQueryHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var values = await _carRepository.GetByIdAsync(query.Id);
        return new GetCarByIdQueryResult
        {
            Transmission = values?.Transmission,
            CarId = values.CarId,
            Seat = values.Seat,
            Km = values.Km,
            CoverImageUrl = values.CoverImageUrl,
            BigImageUrl = values.BigImageUrl,
            Luggage = values.Luggage,
            BrandId = values.BrandId,
            Fuel = values.Fuel,
            Model = values?.Model,
        };
    }
}