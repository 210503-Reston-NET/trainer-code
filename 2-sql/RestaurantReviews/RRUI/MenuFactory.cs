using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RRBL;
using RRDL;
using RRDL.Entities;

namespace RRUI
{
    /// <summary>
    /// Class to menufacture menus using factory dp
    /// </summary>
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType)
        {
            //getting configurations from a config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //setting up my db connections
            string connectionString = configuration.GetConnectionString("RestaurantDB");
            //we're building the dbcontext using the constructor that takes in options, we're setting the connection
            //string outside the context def'n
            DbContextOptions<RestaurantDBContext> options = new DbContextOptionsBuilder<RestaurantDBContext>()
            .UseSqlServer(connectionString)
            .Options;
            //passing the options we just built
            var context = new RestaurantDBContext(options);

            switch (menuType.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "restaurant":
                    return new RestaurantMenu(new RestaurantBL(new RepoDB(context)), new ValidationService());
                case "review":
                    return new ReviewMenu(new RestaurantBL(new RepoDB(context)), new ValidationService(), new ReviewBL(new RepoDB(context)));
                default:
                    return null;
            }
        }

    }
}