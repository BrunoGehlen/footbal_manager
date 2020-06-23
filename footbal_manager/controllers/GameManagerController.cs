using System;
using System.Drawing;

namespace footbal_manager
{
    public class GameManagerController
    {
        private CoachModel coachModel;


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
        public void CreateNewCoach() //may return true to Main Method
        {
            

            string coach = ConsoleHandler.CreateCoach();
            
        }


    }
}
