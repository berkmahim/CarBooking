using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBooking.Application.Features.Mediator.Results.SocialMediaResults;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IRepository<SocialMedia> _repository;

    public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var socialMedia = await _repository.GetByIdAsync(request.Id);
        return new GetSocialMediaByIdQueryResult
        {
            Name = socialMedia.Name,
            Url = socialMedia.Url,
            ICon = socialMedia.ICon,
            SocialMediaId = socialMedia.SocialMediaId
        };
    }
}