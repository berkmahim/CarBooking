using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Results.ContactResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactQueryHandler
{
    private readonly IRepository<Contact> _repository;

    public GetContactQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetContactQueryResult>> Handle()
    {
        
        var contacts = await _repository.GetAllAsync();
        return contacts.Select(x => new GetContactQueryResult
        {
            Email = x.Email,
            Message = x.Message,
            Name = x.Name,
            Subject = x.Subject,
            ContactId = x.ContactId,
            SendDate = x.SendDate,
        }).ToList();
    }
}