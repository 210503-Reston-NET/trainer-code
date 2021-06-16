using RRDL;
using RRModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRBL
{
    public class ReviewBL : IReviewBL
    {
        private IRepository _repo;

        public ReviewBL(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Review> AddReviewAsync(Restaurant restaurant, Review review)
        {
            //call repo method to add review;
            await _repo.AddReviewAsync(restaurant, review);
            return review;
        }

        public async Task<Tuple<List<Review>, int>> GetReviewsAsync(Restaurant restaurant)
        {
            //call get reviews from my repodb.
            List<Review> restaurantReviews = await _repo.GetReviewsAsync(restaurant);
            int averageRating = 0;
            if (restaurantReviews.Count > 0)
            {
                restaurantReviews.ForEach(review => averageRating += review.Rating);
                averageRating = averageRating / restaurantReviews.Count;
            }
            return new Tuple<List<Review>, int>(restaurantReviews, averageRating);
        }
    }
}