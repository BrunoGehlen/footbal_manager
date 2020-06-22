using System;
namespace footbal_manager
{
    public enum CoachSpeciality { Defencive, Balanced, Agressive }
    
    public enum CoachCharims { Neutral, Hostile, Friendly }

    public class CoachModel : PersonModel
    {
        CoachCharims charims;
        int technique;
        int teamWork;
        
        public CoachModel() { }

        
        public CoachModel(string name) {

            this.name = name;
            
        }
        
    }

}
