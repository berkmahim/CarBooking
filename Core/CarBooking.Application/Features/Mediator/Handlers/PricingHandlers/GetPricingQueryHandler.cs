using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.PricingQueries;
using CarBooking.Application.Features.Mediator.Results.PricingResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.PricingHandlers;

public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
{
    private readonly IRepository<Pricing> _repository;

    public GetPricingQueryHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
    {
        var pricings = await _repository.GetAllAsync();
        return pricings.Select(x => new GetPricingQueryResult
        {
            Name = x.Name,
            PricingId = x.PricingId,
        }).ToList();
    }
}