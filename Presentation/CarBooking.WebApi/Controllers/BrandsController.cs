using CarBooking.Application.Features.CQRS.Commands.BannerCommands;
using CarBooking.Application.Features.CQRS.Commands.BrandCommands;
using CarBooking.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBooking.Application.Features.CQRS.Queries.BannerQueries;
using CarBooking.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;

        public BrandsController(GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, CreateBrandCommandHandler createBrandCommandHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
        }

        [HttpGet]
        public async Task<ActionResult> BrandList()
        {
            var brands = await _getBrandQueryHandler.Handle();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBrand(int id)
        {
            var brand = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Marka oluşturuldu");
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Marka silindi");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("marka güncellendi");
        }
    }
}
