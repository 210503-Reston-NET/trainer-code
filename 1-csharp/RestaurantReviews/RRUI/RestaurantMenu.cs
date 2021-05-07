using System;
using RRModels;
using RRBL;
using System.Collections.Generic;
namespace RRUI
{
    public class RestaurantMenu : IMenu
    {
        private IRestaurantBL _restaurantBL;
        private IValidationService _validate;
        public RestaurantMenu(IRestaurantBL restaurantBL, IValidationService validate)
        {
            _restaurantBL = restaurantBL;
            _validate = validate;
        }
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to my Restaurant Menu!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] View restaurants");
                Console.WriteLine("[1] Create a restaurant");
                Console.WriteLine("[2] Go back");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        ViewRestaurants();
                        break;
                    case "1":
                        AddARestaurant();
                        break;
                    case "2":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (repeat);
        }

        private void AddARestaurant()
        {
            Console.WriteLine("Enter the details of the restaurant you want to add");
            // I just want to make sure that my end user doesn't input nothing
            // Come up with some validation to validate the input I'm receiving. 
            // Set model specific validation rules within the properties of your models
            // But the standard validation gives you a way to initially "sanitize" your data 
            string name = _validate.ValidateString("Enter the restaurant name: ");
            string city = _validate.ValidateString("Enter the city where the restaurant is located");
            string state = _validate.ValidateString("Enter the state where the restaurant is located at");
            try
            {
                Restaurant newRestaurant = new Restaurant(name, city, state);
                Restaurant createdRestaurant = _restaurantBL.AddRestaurant(newRestaurant);
                Console.WriteLine("New restaurant created!");
                Console.WriteLine(createdRestaurant.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewRestaurants()
        {
            //TODO: Remove the hardcoded restaurant and refer to a stored restaurant that exists
            List<Restaurant> restaurants = _restaurantBL.GetAllRestaurants();
            if (restaurants.Count == 0) Console.WriteLine("No restaurants :< You should add some");
            else
            {
                foreach (Restaurant restaurant in restaurants)
                {
                    Console.WriteLine(restaurant.ToString());
                }
            }

        }
    }
}