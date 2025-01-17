using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarQueryHandler
{
    private readonly IRepository<Car> _carRepository;

    public GetCarQueryHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values = await _carRepository.GetAllAsync();
        return values.Select(x => new GetCarQueryResult
        {
            Fuel = x.Fuel,
            BigImageUrl = x.BigImageUrl,
            CoverImageUrl = x.CoverImageUrl,
            Luggage = x.Luggage,
            Transmission = x.Transmission,
            BrandId = x.BrandId,
            Model = x.Model,
            CarId = x.CarId,
            Seat = x.Seat,
            Km = x.Km,
        }).ToList();
    }
}