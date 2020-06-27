using System;

namespace footbal_manager
{
    public class TeamModel
    {
        //TODO: make private & public properties
        public string flag;
        public string name;
        public string fifaCode;
        //CoachModel coach;
        //PersonModel fans;
        //int moralAverage;


        /*- Player[] playerName
          - Stadium stadium*/

        public TeamModel(string teamName, string fifaCode, string flag)
        {
            this.name = teamName;
            this.fifaCode = fifaCode;
            this.flag = flag;
        }

        public string GetFlagName() => $"{this.flag} {this.name}";
        public string GetFlagFifaCode() => $"{this.flag} {this.fifaCode}";
    }
}
