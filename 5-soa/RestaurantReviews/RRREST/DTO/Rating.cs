using System.Collections.Generic;
using RRModels;

namespace RRREST.DTO
{
    public class Rating
    {
        public int average { get; set; }
        public List<Review> reviews { get; set; }
    }
}