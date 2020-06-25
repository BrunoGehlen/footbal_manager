using System;
namespace footbal_manager
{
    public enum CoachSpeciality { Defencive, Balanced, Agressive, DefaultNone }

    public enum CoachCharims { Neutral, Hostile, Friendly }

    public class CoachModel : PersonModel
    {
        public CoachCharims charims;
        public CoachSpeciality speciality;
        public int technique;
        public int teamWork;

        public CoachModel(string name, int age, CoachSpeciality speciality) {
            this.name = name;
            this.age = age;
            this.speciality = speciality;
        }

    }

}
