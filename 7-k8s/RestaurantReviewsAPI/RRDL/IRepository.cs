using RRModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRDL
{
    public interface IRepository
    {
        Task<List<Restaurant>> GetAllRestaurantsAsync();

        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantByIdAsync(int id);

        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> DeleteRestaurantAsync(Restaurant restaurant);

        Task<Review> AddReviewAsync(Restaurant restaurant, Review review);

        Task<List<Review>> GetReviewsAsync(Restaurant restaurant);
    }
}