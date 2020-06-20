using System;
namespace footbal_manager
{
    public class GameManagerController
    {
        // private variables
        private CoachModel coachModel;

        // init
        public GameManagerController() { }


        // public methods
        public void StartGame() //may return true to Main Method
        {
            Console.WriteLine("\nHello Manager, please insert your information!");
            Console.WriteLine("\n\nPresse Enter key to continue...");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key == ConsoleKey.Enter)
            {
                // clear console
                Console.Clear();

                // get manager name
                Console.WriteLine("1. Please begin with your name:");
                string name = Console.ReadLine();

                coachModel = new CoachModel(name);
                Console.WriteLine("Manager: " + coachModel.name);
                Console.ReadKey();
            }
        }
    }
}
