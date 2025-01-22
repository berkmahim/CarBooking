using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new SocialMedia
        {
            Name = request.Name,
            Url = request.Url,
            ICon = request.ICon,
        });
    }
}