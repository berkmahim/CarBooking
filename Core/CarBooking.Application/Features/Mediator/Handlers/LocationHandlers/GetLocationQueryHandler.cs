using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.LocationQueries;
using CarBooking.Application.Features.Mediator.Results.LocationResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    private readonly IRepository<Location> _repository;

    public GetLocationQueryHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var locations = await _repository.GetAllAsync();
        return locations.Select(x => new GetLocationQueryResult
        {
            Name = x.Name,
            LocationId = x.LocationId
        }).ToList();
    }
}