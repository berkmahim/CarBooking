using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.AboutCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.AboutHandlers;

public class UpdateAboutCommandHandler
{
    private readonly IRepository<About> _repository;

    public UpdateAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var values = await _repository.GetByIdAsync(command.AboutId);
        values.Title = command.Title;
        values.Description = command.Description;
        values.ImageUrl = command.ImageUrl;
        await _repository.UpdateAsync(values);
    }
}