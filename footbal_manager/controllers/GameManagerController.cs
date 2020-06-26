using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace footbal_manager
{
    public class GameManagerController
    {
        private CoachModel coach;
        private WorldCupController worldCup;

        // init
        public GameManagerController() { }

        public void StartGame() {
            StartNewWorldCup();

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
            List<TeamModel> teams = new List<TeamModel> { };

            using (StreamReader jsonFile = new StreamReader("teams.json"))
            {

                string json = jsonFile.ReadToEnd();
                var teamsDictionaryList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);

                foreach (Dictionary<string, string> teamDictionary in teamsDictionaryList)
                {
                    string teamName = teamDictionary["team_name"];
                    string fifaCode = teamDictionary["fifa_code"];
                    string flag = teamDictionary["flag"];

                    teams.Add(new TeamModel(teamName: teamName, fifaCode: fifaCode, flag: flag));
                }
            }


            worldCup = new WorldCupController(teams: teams);
            worldCup.StartNewWorldCup(this.coach);

            Console.ReadKey();
        }
    }
}
