using Microsoft.AspNetCore.Mvc;
using ShopApp.Enums;
using ShopApp.Models.DTO;
using ShopApp.Services;
using ShopApp.Utils;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll() => 
            Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult Get(string name) => 
            Ok(_service.Get(name));

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDTO category)
        {
            Output res = _service.Create(category);
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
