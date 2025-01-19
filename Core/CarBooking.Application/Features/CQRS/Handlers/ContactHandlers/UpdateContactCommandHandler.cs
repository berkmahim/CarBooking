using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.ContactCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        var contact = await _repository.GetByIdAsync(command.ContactId);
        contact.Name = command.Name;
        contact.Message = command.Message;
        contact.SendDate = command.SendDate;
        contact.ContactId = command.ContactId;
        contact.Email = command.Email;
        contact.Subject = command.Subject;
        await _repository.UpdateAsync(contact);
    }
}