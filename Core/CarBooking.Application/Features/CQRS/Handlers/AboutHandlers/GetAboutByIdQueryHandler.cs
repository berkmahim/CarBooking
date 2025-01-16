using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Queries.AboutQueries;
using CarBooking.Application.Features.CQRS.Results.AboutResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutByIdQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetAboutByIdQueryResult
        {
            AboutId = values.AboutId,
            Description = values.Description,
            ImageUrl = values.ImageUrl,
            Title = values.Title,
        };
    }
}