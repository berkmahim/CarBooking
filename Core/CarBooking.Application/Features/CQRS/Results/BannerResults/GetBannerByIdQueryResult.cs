namespace CarBooking.Application.Features.CQRS.Results.BannerResults;

public class GetBannerByIdQueryResult
{
    public int BannerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Video  { get; set; }
    public string VideoUrl { get; set; }
}