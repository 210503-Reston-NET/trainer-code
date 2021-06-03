using RRModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRBL
{
    public interface IReviewBL
    {
        Task<Review> AddReviewAsync(Restaurant restaurant, Review review);

        Task<Tuple<List<Review>, int>> GetReviewsAsync(Restaurant restaurant);
    }
}