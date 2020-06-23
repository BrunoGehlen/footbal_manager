using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Console = Colorful.Console;
using BetterConsoleTables;

namespace footbal_manager
{

    public static class ConsoleHandler
    {

        private static readonly string defaultTitle = "FOOTBAL MANAGER";

        // public methods
        public static string Welcome()
        {
            Console.Clear();

            string[] descriptionLines = { "Welcome to Footbal Manager!", "Select your option:" };
            string[] options = { "[1] New Game", "[2] About" };

            int optionSelected = OptionChoice(false, descriptionLines, options);

            return options[optionSelected].Replace(" <<", "");
        }

        public static string CreateCoach()
        {
            Console.Clear();

            string[] descriptionLines = { "Hello coach!", "Before you continue, please insert your information" };
            var options = new List<string>();
            options.Add("[1] Name:");

            //coach properties
            int age = 0;
            string name = null;
            CoachSpeciality speciality = CoachSpeciality.Agressive;


            bool allDone = false;
            ConsoleKey key;
            Console.CursorVisible = true;

            do
            {
                Console.Clear();
                OptionMenuTableUnicodeAlt(descriptionLines, options.ToArray());

                string input = Console.ReadLine();
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Enter)
                {

                    // get manager name
                    if (name == null)
                    {
                        name = input;
                        string coachNameRow = " - Coach Name: " + name;
                        options.Add(coachNameRow);
                        Console.WriteLine(coachNameRow);

                    }
                    else if (age <= 0)
                    {
                        string ageString = input;

                        int ageValue = 0;
                        if (Int32.TryParse(ageString, out ageValue))
                        {
                            age = ageValue;
                            string ageRow = " - Coach Age: " + age;
                            options.Add("");
                            options.Add("[2] Age:");
                            options.Add(ageRow);
                            Console.WriteLine(ageRow);

                        }
                        else { break; }
                    }
                    else
                    {
                        string[] specialities = { "Aggressive, Defencive, Balanced" };
                        string[] emptyDescriptions = { "" };
                        OptionChoice(false, emptyDescriptions, specialities);
                    }


                    Console.ReadKey();
                }



            } while (!allDone);


            return "";

        }

        // private methods
        private static void DefaultTitile() => ConsoleHandler.TextArt(defaultTitle);

        private static void OptionMenuTableUnicodeAlt(string[] descriptionLines, string[] options)
        {

            ColumnHeader header = new ColumnHeader(defaultTitle, Alignment.Left, Alignment.Center);
            var table = new Table(header);

            foreach (string descriptionLine in descriptionLines) { table.AddRow(descriptionLine); }
            table.AddRow("                                                                      ");
            foreach (string option in options) { table.AddRow(option); }

            table.Config = TableConfiguration.UnicodeAlt();

            ConsoleTables tables = new ConsoleTables(table);

            DefaultTitile();
            Console.Write(tables.ToString());

            // test case
            Console.WriteLine(tables.ToString(), Color.Green); //with color
        }

        private static void TextArt(string text)
        {

            int red = 0;
            int green = 255;
            int blue = 0;

            Console.WriteAscii(text, Color.FromArgb(red, green, blue));

        }


        private static int OptionChoice(bool canCancel, string[] descriptionLines, string[] options)
        {

            //const int optionsPerLine = 1;
            //const int spacingPerLine = 1;

            int optinsRange = options.Length - 1;
            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                if (currentSelection < 0) { currentSelection = optinsRange; }
                if (currentSelection > optinsRange) { currentSelection = 0; }

                for (int i = 0; i < options.Length; i++)
                {
                    options[i] = options[i].Replace(" <<", "");
                    if (i == currentSelection) { options[i] = options[i] + " <<"; }
                }

                // print table
                OptionMenuTableUnicodeAlt(descriptionLines, options);

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.DownArrow:

                        currentSelection--;
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.UpArrow:

                        currentSelection++;
                        break;

                    case ConsoleKey.Escape:
                        if (canCancel) { return -1; }
                        break;
                }

            } while (key != ConsoleKey.Enter);

            //Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
