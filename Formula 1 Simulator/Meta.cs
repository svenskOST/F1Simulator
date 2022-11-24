using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meta
{
    internal class Car
    {
        public string name;
        public int performance;

        public Car(string name, int performance)
        {
            this.name = name;
            this.performance = performance;
        }
    } 

    internal class Driver
    {
        public string name;
        public string nationality;
        public string prefix;
        public int pace;
        public int consistency;
        public int racecraft;
        public int experience;
        public int skill;

        public Driver(string name, string nationality, string prefix, int pace, int consistency, int racecraft, int experience, int skill)
        {
            this.name = name;
            this.nationality = nationality;
            this.prefix = prefix;
            this.pace = pace;
            this.consistency = consistency;
            this.racecraft = racecraft;
            this.experience = experience;
            this.skill = skill;
        }
    }
}