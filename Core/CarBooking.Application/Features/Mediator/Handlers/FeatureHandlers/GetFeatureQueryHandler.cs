using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.FeatureQueries;
using CarBooking.Application.Features.Mediator.Results;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{
    private readonly IRepository<Feature> _repository;

    public GetFeatureQueryHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var features = await _repository.GetAllAsync();
        return features.Select(x => new GetFeatureQueryResult
        {
            FeatureId = x.FeatureId,
            Name = x.Name,
        }).ToList();
    }
}