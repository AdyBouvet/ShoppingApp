﻿using Microsoft.AspNetCore.Mvc;
using ShopApp.Models.DTO;
using ShopApp.Services;
using ShopApp.Utils;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : Controller
    {

        private readonly ShopService _service;

        public ShopController(ShopService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll() => 
            Ok(_service.GetAll());
        

        [HttpGet("{name}")]
        public ActionResult Get(string name) =>
            Ok(_service.Get(name));
        

        [HttpPost]
        public ActionResult Create([FromBody] ShopDTO shop) 
        {
            Output res = _service.Create(shop);
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
