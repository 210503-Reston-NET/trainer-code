using System.Collections.Generic;
using RRModels;
namespace RRDL
{
    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant AddRestaurant(Restaurant restaurant);

        Restaurant GetRestaurant(Restaurant restaurant);
    }
}