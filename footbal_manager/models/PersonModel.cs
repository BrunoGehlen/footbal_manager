using System;
using System.Collections.Generic;
using System.Text;

namespace footbal_manager {

    public class PersonModel {

        public string name { get; protected set; }
        public string nationality; 
        public int age;
        public int moral;
        public int ability;

        public PersonModel() { }
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
