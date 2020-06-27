using System;
using System.Collections.Generic;


namespace footbal_manager
{
    public class WorldCupController
    {

        internal struct Group
        {
            string name;
            List<TeamModel> teams;

        }

        List<TeamModel> teams;
        List<Group> teamGroups;

        public WorldCupController(List<TeamModel> teams)
        {
            this.teams = teams;
        }

        public void StartNewWorldCup(CoachModel coach)
        {
            string[] description = { "Welcome to World Cup " + "[COACH NAME]", "Please select your team:" };
            List<string> teamListToSelection = new List<string> { };

            foreach (TeamModel team in teams)
            {
                teamListToSelection.Add(team.name);
            }

            var optionSelected = ConsoleHandler.SelectWorldCupTeam(description, teamListToSelection.ToArray());

            Console.Clear();
            Console.Write("Selected Team2: " + teamListToSelection[optionSelected]);
            Console.ReadKey();
        }
    }
}
