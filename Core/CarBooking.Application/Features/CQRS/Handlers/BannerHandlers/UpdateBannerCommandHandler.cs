using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Commands.BannerCommands;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    } 

    public async Task Handle(UpdateBannerCommand command)
    {
        var values = await _repository.GetByIdAsync(command.BannerId);
        values.Title = command.Title;
        values.Description = command.Description;
        values.VideoUrl = command.VideoUrl;
        values.Video = command.Video;
        await _repository.UpdateAsync(values);
    }
}