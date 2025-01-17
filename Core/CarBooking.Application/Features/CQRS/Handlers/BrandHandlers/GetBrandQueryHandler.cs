using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Results.BannerResults;
using CarBooking.Application.Features.CQRS.Results.BrandResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandQueryHandler
{
    private readonly IRepository<Brand> _repository;

    public GetBrandQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBrandQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetBrandQueryResult
        {
            BrandId = x.BrandId,
            Name = x.Name
        }).ToList();
    }
}