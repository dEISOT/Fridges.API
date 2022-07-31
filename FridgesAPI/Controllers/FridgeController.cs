using FridgesCore.Interfaces;
using FridgesData.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FridgesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeService _fridgeService;

        public FridgeController(IFridgeService fridgeService)
        {
            _fridgeService = fridgeService;
        }

        // GET: api/<FridgesController>
        [HttpGet]
        public async Task<IEnumerable<FridgeEntity>> Get()
        {
        }

        // GET api/<FridgesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FridgesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FridgesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FridgesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
