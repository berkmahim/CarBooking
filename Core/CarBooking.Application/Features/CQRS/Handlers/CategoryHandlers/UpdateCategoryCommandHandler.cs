using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.CategoryCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        var category = await _repository.GetByIdAsync(command.CategoryId);
        category.Name = command.Name;
        await _repository.UpdateAsync(category);
    }
}