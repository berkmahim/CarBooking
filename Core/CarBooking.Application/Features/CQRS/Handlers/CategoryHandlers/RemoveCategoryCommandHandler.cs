using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.CategoryCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    private readonly IRepository<Category> _repository;

    public RemoveCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCategoryCommand command)
    {
        var category = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(category);
    }
}