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
            DefaultTitile();
            string[] descriptionLines = { "Welcome to Footbal Manager!", "Select your option:" };
            string[] options = { "1. New Game", "2. About" };

            OptionMenuTableUnicodeAlt(descriptionLines, options);

            //MultipleChoice(false, options);

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
            Console.Write(tables.ToString());

            Console.WriteLine(tables.ToString(), Color.Green); //with color
        }

        private static void TextArt(string text)
        {

            int red = 0;
            int green = 255;
            int blue = 0;

            Console.WriteAscii(text, Color.FromArgb(red, green, blue));

        }

        private static int MultipleChoice(bool canCancel, params string[] options)
        {
            const int startX = 1;
            const int startY = 1;
            const int optionsPerLine = 1;
            const int spacingPerLine = 1;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                string[] descriptionLines = { "Welcome to Footbal Manager!", "Select your option:" };
                OptionMenuTableUnicodeAlt(descriptionLines, options);

                for (int i = 0; i < options.Length; i++)
                {
                    //Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.BackgroundColor = Color.Red;

                    Console.Write(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
