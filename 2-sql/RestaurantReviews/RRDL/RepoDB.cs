using System.Collections.Generic;
using Model = RRModels;
using Entity = RRDL.Entities;
using System.Linq;
using RRModels;

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

        public Model.Review AddReview(Restaurant restaurant, Review review)
        {
            _context.Reviews.Add(
                new Entity.Review
                {
                    Rating = review.Rating,
                    Description = review.Description,
                    RestaurantId = _context.Restaurants.FirstOrDefault(resto => resto.Name == restaurant.Name && resto.City == restaurant.City && resto.State == restaurant.State).Id
                }
            );
            _context.SaveChanges();
            return review;
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

        public List<Review> GetReviews(Restaurant restaurant)
        {
            // We get the reviews such that, we find the restuarant that matches the restaurant being passed, 
            // we get the id of that specific restaurant, compare it to the FK references in the Reviews table
            // get the reviews that match the condition
            //  transform the entity type reviews to a model type review
            // Immediately execute the linq query by calling tolist, which takes the data from the db and puts it in 
            // a list

            //Finding the restaurant from the db, to be able to take advantage of the Id property the model doesn't have
            Entity.Restaurant foundResto = _context.Restaurants.FirstOrDefault(resto => resto.Name == restaurant.Name && resto.City == restaurant.City && resto.State == restaurant.State);
            return _context.Reviews.Where(
                review => review.RestaurantId == foundResto.Id
                ).Select(
                    review => new Model.Review
                    {
                        Rating = review.Rating,
                        Description = review.Description
                    }
                ).ToList();
        }
    }
}