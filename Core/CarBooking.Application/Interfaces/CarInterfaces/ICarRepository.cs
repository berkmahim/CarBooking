using CarBook.Domain.Entities;

namespace CarBooking.Application.Interfaces.CarInterfaces;

public interface ICarRepository
{
    List<Car> GetCarsListWithBrand();
}