using System;
using RRModels;
namespace RRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant goodTaste = new Restaurant("Good Taste", "Baguio City", "Benguet");
            goodTaste.Review = new Review
            {
                Rating = 5,
                Description = "A M A Z I N G"
            };
            Console.WriteLine(goodTaste.ToString());
        }
    }
}
