using System.Collections.Generic;
using RRModels;
namespace RRDL
{
    //Implementation of the IRepository that stores data in a static collection
    public class RepoSC : IRepository
    {
        public List<Restaurant> GetAllRestaurants()
        {
            return RRSCStorage.Restaurants;
        }
    }
}