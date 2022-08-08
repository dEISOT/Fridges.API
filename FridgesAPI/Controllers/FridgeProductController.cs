using AutoMapper;
using FridgesCore.Interfaces;
using FridgesModel.Request;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IFridgeProductService _fridgeproductService;
        private readonly IMapper _mapper;

        public FridgeProductController(IFridgeProductService fridgeProductService, IMapper mapper)
        {
            _fridgeproductService = fridgeProductService;
            _mapper = mapper;
        }

        [HttpGet("{fridgeId}")]
        public async Task<IActionResult> Get(Guid fridgeId)
        {
            var reslut = await _fridgeproductService.GetProductsAsync(fridgeId);
            return Ok(reslut);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AssortmentPutRequest model)
        {
            var id = await _fridgeproductService.AddAsync(model);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FridgeProductUpdateRequset model)
        {
            var newQuantity = model.NewQuantity;
            var assortmentId = model.FridgeProductId;
            var result = await _fridgeproductService.UpdateAsync(assortmentId, newQuantity);

            return Ok(result);
        }
        [HttpDelete("{assortmentId}")]
        public async Task<IActionResult> Delete(Guid assortmentId)
        {
            try
            {
                await _fridgeproductService.DeleteAsync(assortmentId);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{fridgeId}/deleteAll")]
        public async Task<IActionResult> DeleteAll(Guid fridgeId)
        {
            try
            {
                await _fridgeproductService.DeleteAllAsync(fridgeId);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("/filling-by-default")]
        public async Task<IActionResult> FillingByDefault()
        {
            await _fridgeproductService.FillingByDefault();
            return Ok();
        }

    }
}
