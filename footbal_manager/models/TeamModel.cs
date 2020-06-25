using System;
using System.Collections.Generic;
using System.Text;
using Json.Net;
using System.IO;

namespace footbal_manager {
    class TeamModel {

        string flag { get;  set; }
        string team_name;
        //CoachModel coach;
        //PersonModel fans;
        //int moralAverage;
        string fifa_code;


        /*- Player[] playerName
          - Stadium stadium*/

        TeamModel(string team_name, string fifa_code, string flag) {

            this.team_name = team_name;
            this.fifa_code = fifa_code;
            this.flag = flag;
        }

        static public TeamModel[] LoadTeams() {
            using (StreamReader r = new StreamReader("teams.json")) {
                string json = r.ReadToEnd();
                Console.WriteLine(json);
                Console.Read();
                //List<TeamModel> items = Json.DeserializeObject<List<TeamModel>>(json);
                
                return items.ToArray();
            }
        }

    }
}
