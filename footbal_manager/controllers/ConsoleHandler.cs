using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
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

        public static CoachModel CreateCoach()
        {
            Console.Clear();

            string[] descriptionLines = { "Hello coach!", "Before you continue, please insert your information" };
            var options = new List<string>();
            options.Add("[1] Name: ");

            //coach properties
            CoachSpeciality speciality = CoachSpeciality.DefaultNone;
            var nameInput = (name: "", done: false);
            var ageInput = (ageString: "", done: false);
            var specialityInput = (speciality: speciality, done: false);

            bool allInfoDone = false;
            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                OptionMenuTableUnicodeAlt(descriptionLines, options.ToArray());
                ConsoleKey input = Console.ReadKey(true).Key;

                // update table options
                if (input == ConsoleKey.Enter)
                {

                    // age
                    if (!nameInput.done && nameInput.name.Length > 2)
                    {
                        options.Add("[2] Age: ");
                        nameInput.done = true;
                    }

                    // speciality
                    else if (!ageInput.done && ageInput.ageString.Length > 1)
                    {
                        options.Add("[3] Speciality: ");
                        ageInput.done = true;

                        string[] title = { "Please select your Speciality:" };
                        string[] specialities = { "AGRESSIVE", "DEFENCIVE", "BALANCED" };
                        int especialityChoiceIndex = OptionChoice(false, title, specialities);

                        options[2] = "[3] Speciality: " + specialities[especialityChoiceIndex].Replace(" <<", "");
                        options.Add("");
                        options.Add("Press Enter to continue...");

                        switch (especialityChoiceIndex)
                        {
                            case 0:
                                specialityInput.speciality = CoachSpeciality.Agressive;
                                break;
                            case 1:
                                specialityInput.speciality = CoachSpeciality.Defencive;
                                break;
                            case 2:
                                specialityInput.speciality = CoachSpeciality.Balanced;
                                break;
                        };

                    }

                    // all info
                    else if (!specialityInput.done && specialityInput.speciality != CoachSpeciality.DefaultNone)
                    {
                        allInfoDone = true;
                    }
                }

                // get input values
                else
                {
                    // name
                    if (!nameInput.done)
                    {
                        switch (input)
                        {
                            case ConsoleKey.Backspace:
                                if (String.IsNullOrEmpty(nameInput.name)) { break; }
                                nameInput.name = nameInput.name.Remove(nameInput.name.Length - 1);
                                break;
                            case ConsoleKey.Spacebar:
                                nameInput.name += " ";
                                break;
                            default:
                                nameInput.name += input.ToString();
                                break;
                        };

                        options[0] = "[1] Name: " + nameInput.name;
                    }

                    // Age
                    else if (!ageInput.done)
                    {
                        switch (input)
                        {
                            case ConsoleKey.Backspace:
                                if (String.IsNullOrEmpty(ageInput.ageString)) { break; }
                                ageInput.ageString = ageInput.ageString.Remove(ageInput.ageString.Length - 1);
                                break;

                            default:
                                string inputValueString = input.ToString().Replace("D", "");

                                if (int.TryParse(inputValueString, out _))
                                {
                                    if (ageInput.ageString.Length == 2) { break; }
                                    ageInput.ageString += inputValueString;
                                }
                                else
                                {
                                    //TODO TABLE WARNING 
                                }
                                break;
                        };

                        options[1] = "[2] Age: " + ageInput.ageString;
                    }
                }

            } while (!allInfoDone);

            int ageInt = Int32.Parse(ageInput.ageString);

            return new CoachModel(
                name: nameInput.name,
                age: ageInt,
                speciality:
                specialityInput.speciality);
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
            //Console.WriteLine(tables.ToString(), Color.Green); //with color
        }

        public static void TextArt(string text)
        {
            Console.Clear();
            int red = 0;
            int green = 255;
            int blue = 0;

            Console.WriteAscii(text, Color.FromArgb(red, green, blue));
        }


        public static int OptionChoice(bool canCancel, string[] descriptionLines, string[] options)
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

                        currentSelection++;
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.UpArrow:

                        currentSelection--;
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
