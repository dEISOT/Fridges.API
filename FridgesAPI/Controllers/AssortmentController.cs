using AutoMapper;
using FridgesCore.Interfaces;
using FridgesModel.Request;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssortmentController : ControllerBase
    {
        private readonly IAssortmentService _assortmentService;
        private readonly IMapper _mapper;

        public AssortmentController(IAssortmentService fridgeProductService, IMapper mapper)
        {
            _assortmentService = fridgeProductService;
            _mapper = mapper;
        }

        [HttpGet("{fridgeId}")]
        public async Task<IActionResult> Get(Guid fridgeId)
        {
            var reslut = await _assortmentService.GetProductsAsync(fridgeId);
            return Ok(reslut);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AssortmentPutRequest model)
        {
            var id = await _assortmentService.AddAsync(model);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AssortmentUpdateRequset model)
        {
            var newQuantity = model.NewQuantity;
            var assortmentId = model.FridgeProductId;
            var result = await _assortmentService.UpdateAsync(assortmentId, newQuantity);

            return Ok(result);
        }
        [HttpDelete("{assortmentId}")]
        public async Task<IActionResult> Delete(Guid assortmentId)
        {
            try
            {
                await _assortmentService.DeleteAsync(assortmentId);
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
                await _assortmentService.DeleteAllAsync(fridgeId);
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
            await _assortmentService.FillingByDefault();
            return Ok();
        }

    }
}
