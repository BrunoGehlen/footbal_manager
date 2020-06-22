using System;
using System.Drawing;
using Console = Colorful.Console;
using BetterConsoleTables;

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
            ConsoleWriter.TextArt("FOOTBAL MANAGER");
            var table = new Table("");
            table.AddRow("Hello Manager, please insert your information!");
            table.AddRow("Presse Enter to continue...");
            table.Config = TableConfiguration.MySqlSimple();

            ConsoleTables tables = new ConsoleTables(table);

            Console.Write(tables.ToString());

            string gb = "🇨🇳";

            Console.Write(gb);

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
