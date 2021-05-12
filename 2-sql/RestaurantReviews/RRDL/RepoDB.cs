using System.Collections.Generic;
using Model = RRModels;
using Entity = RRDL.Entities;
using System.Linq;

namespace RRDL
{
    public class RepoDB : IRepository
    {
        private Entity.RestaurantDBContext _context;
        public RepoDB(Entity.RestaurantDBContext context)
        {
            _context = context;
        }
        public Model.Restaurant AddRestaurant(Model.Restaurant restaurant)
        {
            //This records a change in the context change tracker that we want to add this particular entity to the 
            // db
            _context.Restaurants.Add(
                new Entity.Restaurant
                {
                    Name = restaurant.Name,
                    City = restaurant.City,
                    State = restaurant.State
                }
            );
            //This persists the change to the db
            // Note: you can create a separate method that persists the changes so that you can execute repo commands in
            //the BL and save changes only when all the operations return no exceptions
            _context.SaveChanges();
            return restaurant;
        }

        public List<Model.Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants
            .Select(
                restaurant => new Model.Restaurant(restaurant.Name, restaurant.City, restaurant.State)
            ).ToList();
        }

        public Model.Restaurant GetRestaurant(Model.Restaurant restaurant)
        {
            //find me a restaurant from the db that is equal to the input restaurant
            Entity.Restaurant found = _context.Restaurants.FirstOrDefault(resto => resto.Name == restaurant.Name && resto.City == restaurant.City && resto.State == restaurant.State);
            // we get the results and return null if nothing is found, otherwise return a Model.Restaurant that was found
            if (found == null) return null;
            return new Model.Restaurant(found.Name, found.City, found.State);
        }
    }
}