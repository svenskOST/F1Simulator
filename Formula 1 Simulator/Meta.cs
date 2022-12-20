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
        public Team? seat;
        public double form1;
        public double form2;
        public double form3;
        public double form4;
        public double form5;
        public double form6;
        public double form7;
        public double form8;

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
            Random rand = new();
            double n1 = rand.Next(45 + experience / 10, 105 - experience / 10);
            double n2 = rand.Next(45 + experience / 10, 105 - experience / 10);
            double n3 = rand.Next(45 + experience / 10, 105 - experience / 10);
            double n4 = rand.Next(45 + experience / 10, 105 - experience / 10);
            double n5 = rand.Next(45 + experience / 10, 105 - experience / 10);
            double n6 = rand.Next(45 + experience / 10, 105 - experience / 10);
            double n7 = rand.Next(45 + experience / 10, 105 - experience / 10);
            double n8 = rand.Next(45 + experience / 10, 105 - experience / 10);
            form1 = n1 / 100;
            form2 = n2 / 100;
            form3 = n3 / 100;
            form4 = n4 / 100;
            form5 = n5 / 100;
            form6 = n6 / 100;
            form7 = n7 / 100;
            form8 = n8 / 100;
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
        public static void Bahrain(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace + x.consistency * 0.9 + x.racecraft * 1.1) / 3 * x.form1;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction + y.drag * 1.1 + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.7;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Jeddah(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace + x.consistency + x.racecraft * 1.3) / 3 * x.form1;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.1 + y.traction + y.drag * 1.1 + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.7;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Australia(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.9 + x.racecraft) / 3 * x.form1;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction + y.drag * 0.8 + y.degradation * 0.9) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Imola(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace + x.consistency * 0.9 + x.racecraft * 0.9) / 3 * x.form2;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.1 + y.traction * 1.1 + y.drag * 0.9 + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Miami(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.2 + x.consistency * 0.8 + x.racecraft * 1.1) / 3 * x.form2;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction * 1.1 + y.drag * 1.2 + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.7;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Spain(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.9 + x.racecraft) / 3 * x.form2;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.1 + y.traction * 1.1 + y.drag + y.degradation * 1.2) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Monaco(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.4 + x.consistency * 1.3 + x.racecraft * 0.5) / 3 * x.form3;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power * 0.8 + y.downforce * 1.6 + y.traction * 1.1 + y.drag * 0.5 + y.degradation * 0.6) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.9;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Baku(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.2 + x.consistency + x.racecraft) / 3 * x.form3;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction * 1.1 + y.drag * 1.2 + y.degradation * 1.1) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.7;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Canada(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.9 + x.racecraft) / 3 * x.form4;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction * 1.4 + y.drag + y.degradation * 0.9) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Silverstone(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.3 + x.consistency * 0.7 + x.racecraft * 1.5) / 3 * x.form4;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.3 + y.traction + y.drag + y.degradation * 1.1) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Austria(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.6 + x.racecraft * 1.2) / 3 * x.form4;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction + y.drag + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Paulricard(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.9 + x.racecraft * 1.1) / 3 * x.form4;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction * 1.1 + y.drag * 1.2 + y.degradation * 1.2) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.7;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Hungaroring(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace + x.consistency * 0.9 + x.racecraft) / 3 * x.form2;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.2 + y.traction * 1.2 + y.drag + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Spa(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.8 + x.racecraft * 1.2) / 3 * x.form5;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.1 + y.traction * 1.2 + y.drag * 1.2 + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Zandvoort(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace + x.consistency + x.racecraft) / 3 * x.form5;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction + y.drag * 0.9 + y.degradation * 0.8) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Monza(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.7 + x.racecraft * 1.3) / 3 * x.form5;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power * 1.2 + y.downforce * 0.8 + y.traction * 1.1 + y.drag * 1.7 + y.degradation) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.6;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Singapore(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.2 + x.consistency * 1.2 + x.racecraft * 0.8) / 3 * x.form3;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.4 + y.traction + y.drag * 0.8 + y.degradation * 1.2) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.9;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Suzuka(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.9 + x.racecraft * 1.1) / 3 * x.form6;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 1.3 + y.traction * 1.2 + y.drag + y.degradation * 0.9) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Cota(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.4 + x.consistency * 0.8 + x.racecraft * 1.2) / 3 * x.form6;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce + y.traction * 1.1 + y.drag * 1.1 + y.degradation * 1.6) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Mexico(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.6 + x.racecraft * 1.1) / 3 * x.form6;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power * 1.1 + y.downforce * 0.8 + y.traction * 1.1 + y.drag * 1.1 + y.degradation * 0.9) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.7;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Interlagos(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.1 + x.consistency * 0.8 + x.racecraft * 1.4) / 3 * x.form7;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power * 1.1 + y.downforce * 1.1 + y.traction * 1.1 + y.drag * 1.2 + y.degradation * 0.8) / 5;
                if (prob > y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }

        public static void Abudhabi(Team[] chosenteams, Driver[] chosendrivers)
        {
            for (int i = 0; i < chosendrivers.Length; i++)
            {
                var x = chosendrivers[i];
                var y = chosenteams[i];
                double driver = (x.pace * 1.2 + x.consistency + x.racecraft * 1.1) / 3 * x.form8;
                Random rand = new();
                int prob = rand.Next(0, 100);
                double car = (y.power + y.downforce * 0.9 + y.traction * 1.1 + y.drag * 1.3 + y.degradation * 1.1) / 5;
                if (prob < y.reliability)
                {
                    Console.WriteLine(chosendrivers[i].color + chosendrivers[i].name + "\x1b[38;5;" + 15 + "m" + " seems to be having engine issues. He'll be vulnerable!");
                    car *= 0.8;
                }
                x.rating = (car + driver) / 2;
            }
        }
    }
}