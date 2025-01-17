using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Queries.BannerQueries;
using CarBooking.Application.Features.CQRS.Results.BannerResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerByIdQueryHandler
{
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }
    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetBannerByIdQueryResult
        {
            Description = values.Description,
            Title = values.Title,
            Video = values.Video,
            BannerId = values.BannerId,
            VideoUrl = values.VideoUrl
        };
    }
}