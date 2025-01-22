using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBooking.Application.Features.Mediator.Results.SocialMediaResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly IRepository<SocialMedia> _repository;

    public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var socialMedias = await _repository.GetAllAsync();
        return socialMedias.Select(x => new GetSocialMediaQueryResult
        {
            Name = x.Name,
            Url = x.Url,
            ICon = x.ICon,
            SocialMediaId = x.SocialMediaId
        }).ToList();
    }
}