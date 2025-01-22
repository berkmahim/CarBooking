using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.PricingCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.PricingHandlers;

public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
{
    private readonly IRepository<Pricing> _repository;

    public UpdatePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
    {
        var pricing = await _repository.GetByIdAsync(request.PricingId);
        pricing.Name = request.Name;
        await _repository.UpdateAsync(pricing);
    }
}