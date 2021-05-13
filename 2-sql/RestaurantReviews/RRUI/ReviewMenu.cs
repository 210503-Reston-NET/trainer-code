using System;
using System.Collections.Generic;
using RRBL;
using RRModels;

namespace RRUI
{
    public class ReviewMenu : IMenu
    {
        private IRestaurantBL _restaurantBL;
        private IReviewBL _reviewBL;
        private IValidationService _validate;
        public ReviewMenu(IRestaurantBL restaurantBL, IValidationService validation, IReviewBL reviewBL)
        {
            _restaurantBL = restaurantBL;
            _validate = validation;
            _reviewBL = reviewBL;
        }
        public void Start()
        {
            bool repeat = true;
            // Add a review
            Restaurant reviewable = SearchRestaurant();
            if (reviewable != null)
            {
                do
                {
                    Console.WriteLine($"Welcome to the reviews menu of {reviewable.Name}! What would you like to do?");
                    Console.WriteLine("[0] Add a review");
                    Console.WriteLine("[1] View reviews");
                    Console.WriteLine("[2] Go back");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "0":
                            //Add review method
                            AddReview(reviewable);
                            break;
                        case "1":
                            ViewReviews(reviewable);
                            break;
                        case "2":
                            repeat = false;
                            Console.WriteLine("Going back to restaurant menu");
                            break;
                        default:
                            Console.WriteLine("Well, I don't know. Invalid input");
                            break;
                    }
                } while (repeat);

            }
            //if the restaurant was null just finish execution
        }

        private void ViewReviews(Restaurant reviewable)
        {
            Console.WriteLine($"Here are the reviews for the restaurant {reviewable.Name}");
            Tuple<List<Review>, int> reviewResult = _reviewBL.GetReviews(reviewable);
            reviewResult.Item1.ForEach(review => Console.WriteLine(review.ToString()));
            Console.WriteLine($"Overall rating of the restaurant: {reviewResult.Item2}");
        }

        private void AddReview(Restaurant reviewable)
        {
            int rating = _validate.ValidateInt("Enter the rating you'd give this restaurant");
            string description = _validate.ValidateString("Enter the overall description of the experience:");
            //call the BL method that attempts to add a review to a restaurant
            _reviewBL.AddReview(reviewable, new Review(rating, description));
        }

        private Restaurant SearchRestaurant()
        {
            Console.WriteLine("Enter the restaurant details of the restaurant you're looking for. Please note that this is a case sensitive app.");
            string name = _validate.ValidateString("Enter the restaurant name: ");
            string city = _validate.ValidateString("Enter the city where the restaurant is located");
            string state = _validate.ValidateString("Enter the state where the restaurant is located at");
            try
            {
                Restaurant foundRestaurant = _restaurantBL.GetRestaurant(new Restaurant(name, city, state));
                Console.WriteLine("Restaurant Found!");
                return foundRestaurant;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Restaurant not found :<. You can add it instead");
                return null;
            }
        }

    }
}