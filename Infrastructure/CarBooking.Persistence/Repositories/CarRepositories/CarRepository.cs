using CarBook.Domain.Entities;
using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBooking.Persistence.Repositories.CarRepository;

public class CarRepository : ICarRepository
{
    private readonly CarBookingContext _context;

    public CarRepository(CarBookingContext context)
    {
        _context = context;
    }

    public List<Car> GetCarsListWithBrand()
    {
        var values = _context.Cars.Include(x=>x.Brand).ToList();
        return values;
    }
}