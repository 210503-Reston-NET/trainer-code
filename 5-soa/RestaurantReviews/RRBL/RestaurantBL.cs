using RRDL;
using RRModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRBL
{
    /// <summary>
    /// Business logic class for the restaurant model
    /// </summary>
    public class RestaurantBL: IRestaurantBL
    {
        // Some things to note:
        // BL classes are in charge of processing/ sanitizing/ further validating data
        // As the name suggests its in charge of processing logic. For example, how does the ordering process
        // work in a store app.
        // Any logic that is related to accessing the data stored somewhere, should be relegated to the DL
        private IRepository _repo;

        public RestaurantBL(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            // Todo: call a repo method that adds a restaurant
            if (await _repo.GetRestaurantAsync(restaurant) != null)
            {
                throw new Exception("Restaurant already exists :<");
            }
            return await _repo.AddRestaurantAsync(restaurant);
        }

        public async Task<Restaurant> DeleteRestaurantAsync(Restaurant restaurant)
        {
            Restaurant toBeDeleted = await _repo.GetRestaurantAsync(restaurant);
            if (toBeDeleted != null) return await _repo.DeleteRestaurantAsync(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            //Note that this method isn't really dependent on any inputs/parameters, I can just directly call the
            // DL method in charge of getting all restaurants
            return await _repo.GetAllRestaurantsAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(Restaurant restaurant)
        {
            return await _repo.GetRestaurantAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _repo.GetRestaurantByIdAsync(id);
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant)
        {
            return await _repo.UpdateRestaurantAsync(restaurant);
        }
    }
}