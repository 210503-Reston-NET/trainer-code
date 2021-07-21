using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;
using RRREST.DTO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRREST.Controllers
{
    [Route("restaurants/{restaurantId}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewBL _reviewBL;
        private readonly IRestaurantBL _restaurantBL;

        public ReviewController(IReviewBL reviewBL, IRestaurantBL restaurantBL)
        {
            _reviewBL = reviewBL;
            _restaurantBL = restaurantBL;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public async Task<IActionResult> GetAllReviewsAsync(int restaurantId)
        {
            var result = await _reviewBL.GetReviewsAsync(await _restaurantBL.GetRestaurantByIdAsync(restaurantId));
            return Ok(new Rating
            {
                reviews = result.Item1,
                average = result.Item2
            });
        }

        // POST api/<ReviewController>
        [HttpPost]
        public async Task<IActionResult> AddReviewAsync(int restaurantId, [FromBody] Review newReview)
        {
            return Created($"/api/Restaurants/{restaurantId}/Reviews",
                await _reviewBL.AddReviewAsync(
                    await _restaurantBL.GetRestaurantByIdAsync(restaurantId),
                    new Review(newReview.Rating, newReview.Description
                    )));
        }
    }
}