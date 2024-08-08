using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters;
using WebAPIDemo.Filters.ActionFilters;
using WebAPIDemo.Filters.ExceptionFilters;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok (ShirtRepository.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtidFilter]
        public IActionResult GetShirtById(int id)
        {
           return Ok(ShirtRepository.GetShirtById(id));
        }


        [HttpPost]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            if (shirt == null) return BadRequest();
            var existingShirt = ShirtRepository.GetShirtByProperties( shirt.Brand,shirt.Gender, shirt.Color, shirt.Size);
            if (existingShirt != null) return BadRequest();
            ShirtRepository.AddShirt(shirt);
          return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId }, shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtidFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionFilter]
        public IActionResult UpdateShirt(int id,Shirt shirt)
        {
      
           ShirtRepository.UpdateShirt(id, shirt);
   
            return NoContent();
        }


   public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);
            return Ok(shirt);
        }

    }
}
