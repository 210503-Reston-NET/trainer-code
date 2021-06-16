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
    [Route("restaurants")]
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
        public async Task<IActionResult> GetAllRestaurantsAsync()
        {
            // No more VMs yayyyyyy
            // But, you may have a need to still come up with some version of your data to send across
            // a network
            // You'd call this version of your model a DTO (data transfer object) 
            // You can use a DTO to aggregate data, leave out data that the client doesn't really need, etc
            return Ok(await _restaurantBL.GetAllRestaurantsAsync());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantByIdAsync(int id)
        {
            return Ok(await _restaurantBL.GetRestaurantByIdAsync(id));
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public async Task<IActionResult> AddNewRestaurantAsync([FromBody] Restaurant newRestaurant)
        {
            return Created("api/Restaurant", await _restaurantBL.AddRestaurantAsync(newRestaurant));
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurantAsync(int id, [FromBody] Restaurant updatedRestaurant)
        {
            await _restaurantBL.UpdateRestaurantAsync(updatedRestaurant);
            return NoContent();
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantAsync(int id)
        {
            await _restaurantBL.DeleteRestaurantAsync(await _restaurantBL.GetRestaurantByIdAsync(id));
            return NoContent();
        }
    }
}
