namespace Meta
{
    internal class Engine
    {
        public int power;
        public int reliability;

        public Engine(int power, int reliability)
        {
            this.power = power;
            this.reliability = reliability;
        }
    }

    internal class Team
    {
        public string name;
        public string hq;
        public int age;
        public string engine;
        public string prefix;
        public string principal;
        public object power;
        public object reliability;
        public int downforce;
        public int traction;
        public int drag;
        public int grip;
        public int degradation;
        public int performance;
        public int wins;
        public int podiums;
        public int points;

        public Team(string name, string hq, int age, string engine, string prefix, string principal, object power, object reliability, int downforce, int traction, int drag, int grip, int degradation, int performance, int wins, int podiums, int points)
        {
            this.name = name;
            this.hq = hq;
            this.age = age;
            this.engine = engine;
            this.prefix = prefix;
            this.principal = principal;
            this.power = power;
            this.reliability = reliability;
            this.downforce = downforce;
            this.traction = traction;
            this.drag = drag;
            this.grip = grip;
            this.degradation = degradation;
            this.performance = performance;
            this.wins = wins;
            this.podiums = podiums;
            this.points = points;
        }
    }

    internal class Driver
    {
        public string name;
        public int age;
        public string firstname;
        public string lastname;
        public string shortname;
        public string nationality;
        public string prefix;
        public int pace;
        public int consistency;
        public int racecraft;
        public int experience;
        public int overall;
        public int wins;
        public int podiums;
        public int points;

        public Driver(string name, int age, string firstname, string lastname, string shortname, string nationality, string prefix, int pace, int consistency, int racecraft, int experience, int overall, int wins, int podiums, int points)
        {
            this.name = name;
            this.age = age;
            this.firstname = firstname;
            this.lastname = lastname;
            this.shortname = shortname;
            this.nationality = nationality;
            this.prefix = prefix;
            this.pace = pace;
            this.consistency = consistency;
            this.racecraft = racecraft;
            this.experience = experience;
            this.overall = overall;
            this.wins = wins;
            this.podiums = podiums;
            this.points = points;
        }
    }
}