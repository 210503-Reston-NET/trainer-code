using RRModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRBL
{
    public interface IRestaurantBL
    {
        Task<List<Restaurant>> GetAllRestaurantsAsync();

        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantByIdAsync(int id);

        Task<Restaurant> DeleteRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant);
    }
}