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
        public int power;
        public int reliability;
        public int downforce;
        public int traction;
        public int drag;
        public int degradation;
        public int performance;
        public int wins;
        public int podiums;
        public int points;
        public string color;

        public Team(string name, string hq, int age, string engine, string prefix, string principal, int power, int reliability, int downforce, int traction, int drag, int degradation, int wins, int podiums, int points, string color)
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
            this.degradation = degradation;
            this.wins = wins;
            this.podiums = podiums;
            this.points = points;
            this.color = color;
            performance = (power + downforce + traction + drag + degradation) / 5;
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
        public int wins;
        public int podiums;
        public int points;
        public double overall;
        public double rating;
        public string? color;
        public Team seat;

        public Driver(string name, int age, string firstname, string lastname, string shortname, string nationality, string prefix, int pace, int consistency, int racecraft, int experience, int wins, int podiums, int points)
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
            this.wins = wins;
            this.podiums = podiums;
            this.points = points;
            overall = (pace + consistency + racecraft) / 3;
        }
    }

    internal class Track
    {
        public string name;
        public string gp;
        public string location;
        public string shortname;

        public Track(string name, string gp, string location, string shortname)
        {
            this.name = name;
            this.gp = gp;
            this.location = location;
            this.shortname = shortname;
        }
    }

    internal class Results
    {
        public static void Bahrain(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
            Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
            Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
            Driver[] drivers, Driver[] rdrivers,
            Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
            Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20,
            Team[] chosenteams, Driver[] chosendrivers, Team currentteam, Driver currentdriver,
            bool grid, bool specs)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace + x.consistency * 0.9 + x.racecraft * 1.1) / 3 + (x.experience / 100 * 3);
                Random rand = new();
                int prob = rand.Next(0, 100);
                double engine;
                if (prob < y.reliability)
                {
                    engine = y.power;
                }
                else
                {
                    engine = y.power * 0.8;
                }
                double car = (engine + y.downforce + y.traction + y.drag * 1.1 + y.degradation) / 5;
                x.rating = car * (driver / 100);
            }
        }
    }
}