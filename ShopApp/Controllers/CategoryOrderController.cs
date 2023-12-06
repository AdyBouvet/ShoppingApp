using Microsoft.AspNetCore.Mvc;
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
        

        [HttpGet("{shopName}/{categoryName}")]
        public ActionResult Get(string shopName, string categoryName) => 
            Ok(_service.Get(shopName, categoryName));


        [HttpPost]
        public IActionResult Create([FromBody] CategoryOrderDTO categoryOrder)
        {
            Output res = _service.Create(categoryOrder);
            if (res.Ok())
                return Ok(res.Message);
            else return BadRequest(res.Message);
        }

            [HttpDelete]
        public IActionResult Delete(string shopName, string categoryName)
        {
            Output res = _service.Delete(shopName, categoryName);
            if (res.Ok())
                return Ok(res.Message);
            else return BadRequest(res.Message);
        }
    }
}
