using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Results.CategoryResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly IRepository<Category> _repository;

    public GetCategoryQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var categories = await _repository.GetAllAsync();
        return categories.Select(x => new GetCategoryQueryResult
        {
            CategoryId = x.CategoryId,
            Name = x.Name,
        }).ToList();
    }
}