using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.ContactCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers;

public class CreateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public CreateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateContactCommand command)
    {
        await _repository.CreateAsync(new Contact
        {
            Email = command.Email,
            Name = command.Name,
            Subject = command.Subject,
            Message = command.Message,
            SendDate = command.SendDate
        });
    }
}