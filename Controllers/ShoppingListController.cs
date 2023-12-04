using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Services;
using ShopApp.Utils;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : Controller
    {

        private readonly ShoppingListService _service;

        public ShoppingListController(ShoppingListService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(string name) => Ok(_service.Get(name));

        [HttpPost]
        public IActionResult Create(ShoppingListDTO shoppingList) 
        {
            Output res = _service.Create(shoppingList);
            if (res.Ok())
                return Ok(res.Message);
            else return BadRequest(res.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(string itemName, string listName, int amount, string comment) =>
            Ok(_service.Add(itemName, listName, amount, comment));

        [HttpDelete]
        public IActionResult Delete(string name)
        {
            Output res = _service.Delete(name);
            if (res.Ok())
                return Ok(res.Message);
            else return BadRequest(res.Message);
        }

        [HttpDelete("remove")]
        public IActionResult Remove(string itemName, string listName) => 
            Ok(_service.Remove(itemName, listName));
        
    }
}
