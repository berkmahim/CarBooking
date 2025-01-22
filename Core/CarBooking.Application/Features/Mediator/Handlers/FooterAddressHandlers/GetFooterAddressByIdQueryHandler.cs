using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBooking.Application.Features.Mediator.Results.FooterAddressResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    private readonly IRepository<FooterAddress> _repository;

    public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var footerAddress = await _repository.GetByIdAsync(request.Id);
        return new GetFooterAddressByIdQueryResult
        {
            Address = footerAddress.Address,
            Description = footerAddress.Description,
            Email = footerAddress.Email,
            Phone = footerAddress.Phone,
            FooterAddressId = footerAddress.FooterAddressId
        };
    }
}