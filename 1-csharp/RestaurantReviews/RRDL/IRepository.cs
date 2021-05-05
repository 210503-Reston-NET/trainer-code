using System.Collections.Generic;
using RRModels;
namespace RRDL
{
    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();
    }
}