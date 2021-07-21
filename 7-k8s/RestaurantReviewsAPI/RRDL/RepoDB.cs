using Microsoft.EntityFrameworkCore;
using RRModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = RRModels;

namespace RRDL
{
    public class RepoDB : IRepository
    {
        private RestaurantDBContext _context;

        public RepoDB(RestaurantDBContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> AddRestaurantAsync(Model.Restaurant restaurant)
        {
            //This records a change in the context change tracker that we want to add this particular entity to the
            // db
            await _context.Restaurants.AddAsync(
                restaurant
            );
            //This persists the change to the db
            // Note: you can create a separate method that persists the changes so that you can execute repo commands in
            //the BL and save changes only when all the operations return no exceptions
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<Review> AddReviewAsync(Restaurant restaurant, Review review)
        {
            await _context.Reviews.AddAsync(
                new Review
                {
                    Rating = review.Rating,
                    Description = review.Description,
                    RestaurantId = restaurant.Id
                }
            );
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Restaurant> DeleteRestaurantAsync(Restaurant restaurant)
        {
            Restaurant toBeDeleted = _context.Restaurants.AsNoTracking().First(resto => resto.Id == restaurant.Id);
            _context.Restaurants.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.AsNoTracking()
            .Select(
                restaurant => restaurant
            ).ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(Model.Restaurant restaurant)
        {
            //find me a restaurant from the db that is equal to the input restaurant
            Restaurant found = await _context.Restaurants.AsNoTracking().FirstOrDefaultAsync(resto => resto.Name == restaurant.Name && resto.City == restaurant.City && resto.State == restaurant.State);
            // we get the results and return null if nothing is found, otherwise return a Model.Restaurant that was found
            if (found == null) return null;
            return new Model.Restaurant(found.Id, found.Name, found.City, found.State);
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _context.Restaurants.AsNoTracking().FirstAsync(restaurant => restaurant.Id == id);
        }

        public async Task<List<Review>> GetReviewsAsync(Restaurant restaurant)
        {
            // We get the reviews such that, we find the restuarant that matches the restaurant being passed,
            // we get the id of that specific restaurant, compare it to the FK references in the Reviews table
            // get the reviews that match the condition
            //  transform the entity type reviews to a model type review
            // Immediately execute the linq query by calling tolist, which takes the data from the db and puts it in
            // a list

            //Finding the restaurant from the db, to be able to take advantage of the Id property the model doesn't have (well now it does)
            //Entity.Restaurant foundResto = _context.Restaurants.FirstOrDefault(resto => resto.Name == restaurant.Name && resto.City == restaurant.City && resto.State == restaurant.State);

            return await _context.Reviews.AsNoTracking().Where(
                review => review.RestaurantId == restaurant.Id
                ).Select(
                    review => review
                ).ToListAsync();
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }
    }
}