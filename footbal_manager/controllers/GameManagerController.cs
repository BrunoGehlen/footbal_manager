using System;
using System.Drawing;
using Console = Colorful.Console;

namespace footbal_manager
{
    public class GameManagerController
    {
        int DA = 244;
        int V = 212;
        int ID = 255;
        private CoachModel coachModel;

        // init
        public GameManagerController() { }


        // public methods
        public void StartGame() //may return true to Main Method
        {
            WriteArt("FOOTBAL MANAGER!");
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

        private void WriteArt(string text) {

            for (int i = 0; i < 3; i++) {
                Console.WriteAscii(text, Color.FromArgb(DA, V, ID));

                DA -= 18;
                V -= 36;
                }
            }
    }
}
