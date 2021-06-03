using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRREST.Controllers
{
    [Route("api/Restuarants")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantBL _restaurantBL;
        public RestaurantController(IRestaurantBL restaurantBL)
        {
            _restaurantBL = restaurantBL;
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            // No more VMs yayyyyyy
            // But, you may have a need to still come up with some version of your data to send across
            // a network
            // You'd call this version of your model a DTO (data transfer object) 
            // You can use a DTO to aggregate data, leave out data that the client doesn't really need, etc
            return Ok(_restaurantBL.GetAllRestaurants());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            return Ok(_restaurantBL.GetRestaurantById(id));
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult AddNewRestaurant([FromBody] Restaurant newRestaurant)
        {
            return Created("api/Restaurant", _restaurantBL.AddRestaurant(newRestaurant));
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, [FromBody] Restaurant updatedRestaurant)
        {
            _restaurantBL.UpdateRestaurant(updatedRestaurant);
            return NoContent();
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            _restaurantBL.DeleteRestaurant(_restaurantBL.GetRestaurantById(id));
            return NoContent();
        }
    }
}
