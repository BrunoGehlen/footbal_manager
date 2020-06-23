using System;
namespace footbal_manager
{
    public enum CoachSpeciality { Defencive, Balanced, Agressive }

    public enum CoachCharims { Neutral, Hostile, Friendly }

    public class CoachModel : PersonModel
    {
        public CoachCharims charims;
        public CoachSpeciality speciality;
        public int technique;
        public int teamWork;

        public CoachModel() { }


        public CoachModel(string name)
        {

            this.name = name;

        }

    }

}
