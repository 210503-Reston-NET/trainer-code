using System.Collections.Generic;
using RRModels;
using System.IO; // For the File IO
using System.Text.Json; // Json serialization (marshalling and unmarshalling)
using System;
using System.Linq;

namespace RRDL
{
    /// <summary>
    /// Repo implementation but i store it in a file
    /// </summary>
    public class RepoFile : IRepository
    {
        //the file path is relative to where you run the dotnet run command
        //since i run it in my RRUI project, the filepath is relative to how I navigate from RRUI to where I want
        // the file to be stored/found
        private const string filePath = "../RRDL/Restaurants.json";
        /// <summary>
        /// Hold string versions of my objects
        /// </summary>
        private string jsonString;

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            List<Restaurant> restaurantsFromFile = GetAllRestaurants();
            restaurantsFromFile.Add(restaurant);
            jsonString = JsonSerializer.Serialize(restaurantsFromFile);
            File.WriteAllText(filePath, jsonString);
            return restaurant;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Restaurant>();
            }
            return JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        }

        public Restaurant GetRestaurant(Restaurant restaurant)
        {
            return GetAllRestaurants().FirstOrDefault(resto => resto.Equals(restaurant));
        }
    }
}