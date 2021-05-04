namespace RRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setting a parent type to an instance of a subtype is called covariance
            IMenu menu = new MainMenu();
            menu.Start();
        }
    }
}
