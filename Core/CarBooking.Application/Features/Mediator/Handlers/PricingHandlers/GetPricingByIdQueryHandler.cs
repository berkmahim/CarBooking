using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.PricingQueries;
using CarBooking.Application.Features.Mediator.Results.PricingResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.PricingHandlers;

public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
{
    private readonly IRepository<Pricing> _repository;

    public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
    {
        var pricing = await _repository.GetByIdAsync(request.Id);
        return new GetPricingByIdQueryResult
        {
            Name = pricing.Name,
            PricingId = pricing.PricingId,
        };
    }
}