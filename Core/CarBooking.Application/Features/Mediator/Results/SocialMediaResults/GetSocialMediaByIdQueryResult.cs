namespace CarBooking.Application.Features.Mediator.Results.SocialMediaResults;

public class GetSocialMediaByIdQueryResult
{
    public int SocialMediaId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string ICon { get; set; }
}