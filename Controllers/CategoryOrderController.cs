using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Services;
using ShopApp.Utils;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryOrderController : Controller
    {

        private readonly CategoryOrderService _service;

        public CategoryOrderController(CategoryOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll() => Ok(_service.GetAll());
        

        [HttpGet("{id}")]
        public ActionResult Get(string name) => Ok(_service.Get(name));


        [HttpPost]
        public IActionResult Create([FromBody] CategoryOrderDTO categoryOrder)
        {
            Output res = _service.Create(categoryOrder);
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
