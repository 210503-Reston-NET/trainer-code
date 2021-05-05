using System.Collections.Generic;
using RRModels;
namespace RRBL
{
    public interface IRestaurantBL
    {
        List<Restaurant> GetAllRestaurants();
    }
}