using System;
using System.Collections.Generic;
using System.Text;

namespace footbal_manager {

    public class PersonModel {
        //Variables
        //Strings
        public string name;
        public string nationality;
        //ints
        public int age;
        public int moral;
        public int ability;

        // Person's constructor
        public PersonModel(string name, string nationality, int age, int moral, int ability) {

            this.name = name;
            this.nationality = nationality;
            this.age = age;
            this.moral = moral;
            this.ability = ability;

            }
        }
    }
