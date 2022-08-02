using FridgesCore.Interfaces;
using FridgesModel.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IFridgeProductService _fridgeproductService;

        public FridgeProductController(IFridgeProductService fridgeProductService)
        {
            _fridgeproductService = fridgeProductService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var reslut = await _fridgeproductService.GetProducts(id);
            return Ok(reslut);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FridgeProductUpdateRequset model)
        {
            var newQuantity = model.NewQuantity;
            var id = model.FridgeProductId;
            var result = await _fridgeproductService.Update(id, newQuantity);

            return Ok(result);
        }
    }
}
