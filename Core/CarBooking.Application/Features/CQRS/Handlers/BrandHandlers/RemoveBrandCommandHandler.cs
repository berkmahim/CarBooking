using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.BrandCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.BrandHandlers;

public class RemoveBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;

    public RemoveBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveBrandCommand command)
    {
        var brand = await _repository.GetByIdAsync(command.Id);
        _repository.RemoveAsync(brand);
        
    }
}