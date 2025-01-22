using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.ServiceQueries;
using CarBooking.Application.Features.Mediator.Results.ServiceResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.ServiceHandlers;

public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
{
    private readonly IRepository<Service> _repository;

    public GetServiceQueryHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var services = await _repository.GetAllAsync();
        return services.Select(x => new GetServiceQueryResult
        {
            IconUrl = x.IconUrl,
            Description = x.Description,
            Title = x.Title,
            ServiceId = x.ServiceId
        }).ToList();
    }
}