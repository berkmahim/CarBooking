using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Results.BannerResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerQueryHandler
{
    private readonly IRepository<Banner> _repository;

    public GetBannerQueryHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async  Task<List<GetBannerQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetBannerQueryResult
        {
            Description = x.Description,
            BannerId = x.BannerId,
            Title = x.Title,
            Video = x.Video,
            VideoUrl = x.VideoUrl
        }).ToList();
    }
}