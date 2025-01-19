using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.ContactCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers;

public class RemoveContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public RemoveContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveContactCommand command)
    {
        var contact = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(contact);
    }
}