using System;
using System.Drawing;

namespace footbal_manager
{
    public class GameManagerController
    {
        private CoachModel coach;

        // init
        public GameManagerController() { }

        public void StartGame() {

            string option = ConsoleHandler.Welcome();
            
            switch (option) {

                case "[1] New Game":
                    CreateNewCoach();
                    break;

                case "[2] About":
                    break;
                                       
            }
        }

        // public methods
        public void CreateNewCoach()
        { 
            coach = ConsoleHandler.CreateCoach();
            SelectGameOption();
        }

        private void SelectGameOption()
        {
            string[] descriptionLines = { "Hello " + coach.name , "Select your game option:" };
            string[] options = { "[1] World Cup" };

            int selectedOption = ConsoleHandler.OptionChoice(false, descriptionLines, options);

            switch (selectedOption) {
                case 0:
                    StartNewWorldCup();
                    break;
            };
        }

        private void StartNewWorldCup()
        {
            ConsoleHandler.TextArt("WORLD CUP");
            Console.ReadKey();
        }
    }
}
