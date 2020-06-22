using System;
using System.Drawing;

namespace footbal_manager
{
    public class GameManagerController
    {
        private CoachModel coachModel;


        // init
        public GameManagerController() { }

        public void StartGame()
        {
            string option = ConsoleHandler.Welcome();
            Console.Write(option);
        }

        // public methods
        public void CreateCoach() //may return true to Main Method
        {
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
