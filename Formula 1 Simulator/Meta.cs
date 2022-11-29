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

        public Team(string name, string hq, string prefix, string principal, object power, object reliability, int downforce, int traction, int drag, int grip, int degradation, int performance)
        {
            this.name = name;
            this.hq = hq;
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
        public int overall;

        public Driver(string name, string nationality, string prefix, int pace, int consistency, int racecraft, int experience, int overall)
        {
            this.name = name;
            this.nationality = nationality;
            this.prefix = prefix;
            this.pace = pace;
            this.consistency = consistency;
            this.racecraft = racecraft;
            this.experience = experience;
            this.overall = overall;
        }
    }
}