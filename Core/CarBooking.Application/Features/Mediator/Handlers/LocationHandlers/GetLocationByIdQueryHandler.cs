using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.LocationQueries;
using CarBooking.Application.Features.Mediator.Results.LocationResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IRepository<Location> _repository;

    public GetLocationByIdQueryHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _repository.GetByIdAsync(request.Id);
        return new GetLocationByIdQueryResult
        {
            LocationId = location.LocationId,
            Name = location.Name
        };
    }
}