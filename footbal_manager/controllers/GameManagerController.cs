using System;
using System.Drawing;
using Console = Colorful.Console;
using ConsoleTables;

namespace footbal_manager
{
    public class GameManagerController
    {

        private CoachModel coachModel;

        // init
        public GameManagerController() { }


        // public methods
        public void StartGame() //may return true to Main Method
        {
            WriteArt("FOOTBAL MANAGER!");
            var table = new ConsoleTable("Hello Manager, please insert your information!");
            table.AddRow("Presse Enter to continue...");
            table.Write();
            Console.WriteLine();

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

            int DA = 244;
            int V = 212;
            int ID = 255;

            Console.WriteAscii(text, Color.FromArgb(DA, V, ID));

        }
        /*private void TableTest() {
                {
                var table = new ConsoleTable("one", "two", "three");
                table.AddRow(1, 2, 3)
                     .AddRow("this line should be longer", "yes it is", "oh");

                table.Write();
                Console.WriteLine();

                var rows = Enumerable.Repeat(new Something(), 10);

                ConsoleTable
                    .From<Something>(rows)
                    .Configure(o => o.NumberAlignment = Alignment.Right)
                    .Write(Format.Alternative);

                Console.ReadKey();
                }
            }*/
    }
}
