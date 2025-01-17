using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.BannerCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.BannerHandlers;

public class CreateBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public CreateBannerCommandHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBannerCommand command)
    {
        await _repository.CreateAsync(new Banner
        {
            Title = command.Title,
            Description = command.Description,
            VideoUrl = command.VideoUrl,
            Video = command.Video,
        });
    }
}