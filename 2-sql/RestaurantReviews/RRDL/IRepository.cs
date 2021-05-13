using System.Collections.Generic;
using RRModels;
namespace RRDL
{
    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurant(Restaurant restaurant);

        Restaurant DeleteRestaurant(Restaurant restaurant);
        Review AddReview(Restaurant restaurant, Review review);
        List<Review> GetReviews(Restaurant restaurant);
    }
}