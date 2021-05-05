using System;
using RRDL;
using RRBL;
namespace RRUI
{
    public class MainMenu : IMenu
    {
        private IMenu submenu;
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to my Restaurant Reviews Application!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] CRUD Restaurants");
                Console.WriteLine("[1] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        //TODO: Fix this
                        submenu = new RestaurantMenu(new RestaurantBL(new RepoSC()));
                        submenu.Start();
                        break;
                    case "1":
                        //exit
                        Console.WriteLine("Goodbye cruel world.");
                        repeat = false;
                        break;
                    default:
                        //invalid input
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } while (repeat);
        }
    }
}