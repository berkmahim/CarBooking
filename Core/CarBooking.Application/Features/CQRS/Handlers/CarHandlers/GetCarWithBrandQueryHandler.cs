using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Interfaces;
using CarBooking.Application.Interfaces.CarInterfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _carRepository;

    public GetCarWithBrandQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public List<GetCarWithBrandQueryResult> Handle()
    {
        var values = _carRepository.GetCarsListWithBrand();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            BrandName = x.Brand.Name,
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