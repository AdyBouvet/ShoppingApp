using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Services;
using ShopApp.Utils;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {

        private readonly ItemService _service;

        public ItemController(ItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll(string? category)
        {
            return Ok(_service.GetAll(category));
        }
        

        [HttpGet("{name}")]
        public ActionResult Get(string name) => 
            Ok(_service.Get(name));


        [HttpPost]
        public ActionResult Create([FromBody] ItemDTO item)
        {
            Output res = _service.Create(item);
            if (res.Ok())
                return Ok(res.Message);
            else return BadRequest(res.Message);
        }

        [HttpDelete]
        public IActionResult Delete(string name)
        {
            Output res = _service.Delete(name);
            if (res.Ok())
                return Ok(res.Message);
            else return BadRequest(res.Message);
        }
    }
}
