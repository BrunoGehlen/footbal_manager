using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Console = Colorful.Console;
using BetterConsoleTables;

namespace footbal_manager {
    
    public static class ConsoleWriter {
        
        private static void DefaultTitile() => ConsoleWriter.TextArt("FOOTBAL MANAGER");

        private static void MenuTable(string title, string[] values) {

            Table table = new Table(title);
            table.AddRow("Hello Manager, please insert your information!");
            table.AddRow("Presse Enter to continue...");
            table.Config = TableConfiguration.MySqlSimple();

        }

        public static void PrintWelcomeText() {
            DefaultTitile();
            
        }

        public static void TextArt(string text) {

            int red = 0;
            int green = 255;
            int blue = 0;

            Console.WriteAscii(text, Color.FromArgb(red, green, blue));

            }
        }
    }
