using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = await _repository.GetByIdAsync(request.SocialMediaId);
        socialMedia.Name = request.Name;
        socialMedia.Url = request.Url;
        socialMedia.ICon = request.ICon;
        await _repository.UpdateAsync(socialMedia);
    }
}