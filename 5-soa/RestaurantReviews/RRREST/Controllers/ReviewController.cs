using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRREST.Controllers
{
    [Route("api/Restaurants/{restaurantId}/Reviews")]
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
        public IActionResult GetAllReviews(int restaurantId)
        {
            return Ok(_reviewBL.GetReviews(_restaurantBL.GetRestaurantById(restaurantId)));
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult AddReview(int restaurantId, [FromBody] Review newReview)
        {
            return Created($"/api/Restaurants/{restaurantId}/Reviews",
                _reviewBL.AddReview(
                    _restaurantBL.GetRestaurantById(restaurantId),
                    new Review(newReview.Rating, newReview.Description
                    )));
        }
    }
}