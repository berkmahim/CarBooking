using CarBook.Domain.Entities;
using CarBooking.Application.Features.CQRS.Queries.CategoryQueries;
using CarBooking.Application.Features.CQRS.Results.CategoryResults;
using CarBooking.Application.Interfaces;

namespace CarBooking.Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        
        var category = await _repository.GetByIdAsync(query.Id);
        return new GetCategoryByIdQueryResult
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
        };
    }
}