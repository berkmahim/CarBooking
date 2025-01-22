using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.ServiceQueries;
using CarBooking.Application.Features.Mediator.Results.ServiceResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.ServiceHandlers;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
{
    private readonly IRepository<Service> _repository;

    public GetServiceByIdQueryHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);
        return new GetServiceByIdQueryResult
        {
            Description = service.Description,
            Title = service.Title,
            IconUrl = service.IconUrl,
            ServiceId = service.ServiceId,
        };
    }
}