using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBooking.Application.Features.Mediator.Results.FooterAddressResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    private readonly IRepository<FooterAddress> _repository;

    public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var footerAddresses = await _repository.GetAllAsync();
        return footerAddresses.Select(x => new GetFooterAddressQueryResult
        {
            Description = x.Description,
            Address = x.Address,
            Email = x.Email,
            Phone = x.Phone,
            FooterAddressId = x.FooterAddressId
        }).ToList();
    }
}