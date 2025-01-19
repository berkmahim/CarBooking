using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Queries.ContactQueries;
using CarBooking.Application.Features.CQRS.Results.ContactResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactByIdQueryHandler
{
    private readonly IRepository<Contact> _repository;

    public GetContactByIdQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
    {
        var contact = await _repository.GetByIdAsync(query.Id);
        return new GetContactByIdQueryResult
        {
            ContactId = contact.ContactId,
            Email = contact.Email,
            SendDate = contact.SendDate,
            Message = contact.Message,
            Subject = contact.Subject,
            Name = contact.Name,
        };
    }
}