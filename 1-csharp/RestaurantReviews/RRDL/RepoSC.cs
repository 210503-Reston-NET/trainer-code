using System.Collections.Generic;
using RRModels;
using System.Linq;
namespace RRDL
{
    /// <summary>
    /// Implementation of the IRepository that stores data in a static collection
    /// </summary>
    public class RepoSC : IRepository
    {
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            RRSCStorage.Restaurants.Add(restaurant);
            return restaurant;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return RRSCStorage.Restaurants;
        }

        public Restaurant GetRestaurant(Restaurant restaurant)
        {
            // Uses LINQ (Language Integrated Query) which allows you to query collections to get the neccessary 
            // data without having to traverse the collection manually in a foreach iteration
            return RRSCStorage.Restaurants.FirstOrDefault(resto => resto.Equals(restaurant));
        }
    }
}