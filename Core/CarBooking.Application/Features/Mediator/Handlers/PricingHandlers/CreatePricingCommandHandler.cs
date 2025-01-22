using CarBook.Domain.Entities;
using CarBooking.Application.Features.Mediator.Commands.PricingCommands;
using CarBooking.Application.Interfaces;
using MediatR;

namespace CarBooking.Application.Features.Mediator.Handlers.PricingHandlers;

public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
{
    private readonly IRepository<Pricing> _repository;

    public CreatePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Pricing
        {
            Name = request.Name,
        });
    }
}