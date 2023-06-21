using Meta;
using System.Runtime.InteropServices;

namespace Game
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        readonly static string[] intro = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Formula 1 Simulator\Formula 1 Simulator\intro.txt");
        readonly static string[] image = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Formula 1 Simulator\Formula 1 Simulator\image.txt");
        static string[]? colTitle;
        static string[]? leftCol;
        static string[]? chassis;
        static string[]? powerUnit;
        static string? racestart;
        static string? startornext;
        static string? currentrace;
        static string? CurrentRace;
        static string? currentgp;
        static string? resulttitle;
        static string? tableTitle;

        static int x = 0;
        static int season = 2021;
        readonly static int gameSpeed = 200;

        static bool autorun = false;
        static bool seasonSim = false;
        static bool grid = false;
        static bool specs = false;
        static bool gameFinished = false;
        static bool allDriversDead = false;
        static bool seasonResults = false;

        readonly static Engine eRedBull = new(90, 92);
        readonly static Engine eFerrari = new(95, 85);
        readonly static Engine eMercedes = new(85, 96);
        readonly static Engine eRenault = new(85, 85);

        readonly static Team RedBull = new("Red Bull", "Milton Keynes", 18, "Red Bull Powertrains", "an austrian", "Christian Horner", eRedBull.power, eRedBull.reliability, 93, 90, 95, 91, 0, 0, 0, 85, 206, 5619, 4, 5, "\x1b[38;5;" + 4 + "m");
        readonly static Team Ferrari = new("Ferrari", "Maranello", 93, "Ferrari", "an italian", "Mattia Binotto", eFerrari.power, eFerrari.reliability, 97, 95, 90, 88, 0, 0, 0, 238, 778, 8712, 16, 15, "\x1b[38;5;" + 196 + "m");
        readonly static Team Mercedes = new("Mercedes", "Brackley", 14, "Mercedes", "a german", "Toto Wolff", eMercedes.power, eMercedes.reliability, 89, 90, 86, 90, 0, 0, 0, 124, 265, 6299, 8, 9, "\x1b[38;5;" + 50 + "m");
        readonly static Team Alpine = new("Alpine", "Enstone", 26, "Renault", "a french", "Otmar Szafnauer", eRenault.power, eRenault.reliability, 86, 89, 87, 88, 0, 0, 0, 1, 2, 155, 0, 0, "\x1b[38;5;" + 39 + "m");
        readonly static Team Mclaren = new("McLaren", "Woking", 56, "Mercedes", "a british", "Zak Brown", eMercedes.power, eMercedes.reliability, 80, 79, 83, 85, 0, 0, 0, 183, 493, 5831, 8, 12, "\x1b[38;5;" + 208 + "m");
        readonly static Team AlfaRomeo = new("Alfa Romeo", "Hinwil", 44, "Ferrari", "a swiss", "Frédéric Vasseur", eFerrari.power - 9, eFerrari.reliability, 78, 81, 75, 82, 0, 0, 0, 10, 26, 128, 0, 2, "\x1b[38;5;" + 124 + "m");
        readonly static Team AstonMartin = new("Aston Martin", "Silverstone", 4, "Mercedes", "a british", "Mike Krack", eMercedes.power, eMercedes.reliability, 78, 80, 76, 78, 0, 0, 0, 0, 1, 61, 0, 0, "\x1b[38;5;" + 30 + "m");
        readonly static Team Haas = new("Haas", "Kannapolis", 7, "Ferrari", "an american", "Günther Steiner", eFerrari.power - 9, eFerrari.reliability, 77, 76, 79, 85, 0, 0, 0, 0, 0, 200, 0, 0, "\x1b[38;5;" + 11 + "m");
        readonly static Team AlphaTauri = new("AlphaTauri", "Faenza", 37, "Ferrari", "an italian", "Franz Tost", eRedBull.power - 9, eRedBull.reliability, 75, 74, 79, 78, 0, 0, 0, 1, 2, 249, 0, 0, "\x1b[38;5;" + 240 + "m");
        readonly static Team Williams = new("Williams", "Wantage", 53, "Mercedes", "a british", "Jost Capito", eMercedes.power - 3, eMercedes.reliability, 68, 72, 98, 75, 0, 0, 0, 114, 313, 3584, 9, 7, "\x1b[38;5;" + 26 + "m");

        readonly static Team[] teams = new[]
        {
            RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams
        };

        readonly static Team[] seats = new[]
        {
            RedBull, RedBull, Ferrari, Ferrari, Mercedes, Mercedes, Alpine, Alpine, Mclaren, Mclaren, AlfaRomeo, AlfaRomeo, AstonMartin, AstonMartin, Haas, Haas, AlphaTauri, AlphaTauri, Williams, Williams
        };

        static Team[]? standingTeams;

        static Team? currentteam;

        readonly static Team[] allTeams = new[]
        {
            RedBull,
            Ferrari,
            Mercedes,
            Alpine,
            Mclaren,
            AlfaRomeo,
            AstonMartin,
            Haas,
            AlphaTauri,
            Williams
        };

        readonly static Driver ver = new("Max Verstappen", 24, "Max", "Verstappen", "VER", "the Netherlands", "dutch", 97, 92, 90, 78, 0, 0, 0, 20, 60, 1558, 1);
        readonly static Driver per = new("Sergio Perez", 32, "Sergio", "Perez", "PER", "Mexicó", "mexican", 86, 89, 93, 88, 0, 0, 0, 2, 14, 893, 0);
        readonly static Driver lec = new("Charles Leclerc", 24, "Charles", "Leclerc", "LEC", "Monaco", "monegasque", 94, 85, 97, 71, 0, 0, 0, 2, 13, 560, 0);
        readonly static Driver sai = new("Carlos Sainz", 27, "Carlos", "Sainz", "SAI", "Spain", "spanish", 90, 83, 90, 79, 0, 0, 0, 0, 6, 537, 0);
        readonly static Driver ham = new("Lewis Hamilton", 37, "Lewis", "Hamilton", "HAM", "Great Britain", "british", 85, 92, 94, 95, 0, 0, 0, 103, 183, 4164, 7);
        readonly static Driver rus = new("George Russell", 24, "George", "Russell", "RUS", "Great Britain", "british", 90, 90, 88, 66, 0, 0, 0, 0, 1, 19, 0);
        readonly static Driver alo = new("Fernando Alonso", 40, "Fernando", "Alonso", "ALO", "Spain", "spanish", 85, 91, 91, 99, 0, 0, 0, 32, 98, 1785, 2);
        readonly static Driver oco = new("Esteban Ocon", 25, "Esteban", "Ocon", "OCO", "France", "french", 81, 84, 80, 65, 0, 0, 0, 1, 2, 272, 0);
        readonly static Driver nor = new("Lando Norris", 22, "Lando", "Norris", "NOR", "Great Britain", "british", 88, 82, 88, 67, 0, 0, 0, 0, 5, 316, 0);
        readonly static Driver ric = new("Daniel Ricciardo", 32, "Daniel", "Ricciardo", "RIC", "Australia", "australian", 78, 80, 89, 90, 0, 0, 0, 8, 32, 1274, 0);
        readonly static Driver bot = new("Valterri Bottas", 32, "Valterri", "Bottas", "BOT", "Finland", "finnish", 83, 91, 75, 88, 0, 0, 0, 10, 67, 1748, 0);
        readonly static Driver zho = new("Zhou Guanyu", 22, "Zhou", "Guanyu", "ZHO", "China", "chinese", 78, 84, 78, 52, 0, 0, 0, 0, 0, 0, 0);
        readonly static Driver vet = new("Sebastian Vettel", 34, "Sebastian", "Vettel", "VET", "Germany", "german", 82, 85, 82, 99, 0, 0, 0, 53, 122, 3061, 4);
        readonly static Driver str = new("Lance Stroll", 23, "Lance", "Stroll", "STR", "Canada", "canadian", 81, 83, 75, 62, 0, 0, 0, 0, 3, 196, 0);
        readonly static Driver mag = new("Kevin Magnussen", 29, "Kevin", "Magnussen", "MAG", "Denmark", "danish", 80, 83, 82, 84, 0, 0, 0, 0, 1, 161, 0);
        readonly static Driver msc = new("Mick Schumacher", 23, "Mick", "Schumacher", "MSC", "Germany", "german", 78, 72, 80, 60, 0, 0, 0, 0, 0, 0, 0);
        readonly static Driver gas = new("Pierre Gasly", 26, "Pierre", "Gasly", "GAS", "France", "french", 72, 83, 80, 65, 0, 0, 0, 1, 3, 313, 0);
        readonly static Driver tsu = new("Yuki Tsunoda", 21, "Yuki", "Tsunoda", "TSU", "Japan", "japanese", 80, 79, 80, 55, 0, 0, 0, 0, 0, 33, 0);
        readonly static Driver alb = new("Alexander Albon", 26, "Alexander", "Albon", "ALB", "Thailand", "thai", 81, 84, 75, 68, 0, 0, 0, 0, 2, 198, 0);
        readonly static Driver lat = new("Nicholas Latifi", 26, "Nicholas", "Latifi", "LAT", "Canada", "canadian", 67, 71, 73, 61, 0, 0, 0, 0, 0, 7, 0);

        readonly static Driver[] drivers = new[]
        {
            ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat
        };

        static Driver[] sortedDrivers = drivers;

        static Driver[]? driverPool;

        static Driver[]? selectedDrivers;

        static Driver? currentdriver;

        readonly static Track bahrain = new("Bahrain International Circuit", "BAHRAIN GRAND PRIX", "Sakhir, Bahrain", "Bahrain");
        readonly static Track jeddah = new("Jeddah Corniche Circuit", "SAUDI ARABIAN GRAND PRIX", "Jeddah, Saudi Arabia", "Jeddah");
        readonly static Track australia = new("Albert Park Circuit", "AUSTRALIAN GRAND PRIX", "Melbourne, Australia", "Australia");
        readonly static Track imola = new("Autodromo Enzo e Dino Ferrari", "EMILIA-ROMAGNA GRAND PRIX", "Imola, Italy", "Imola");
        readonly static Track miami = new("Miami International Autodrome", "MIAMI GRAND PRIX", "Miami, United States", "Miami");
        readonly static Track spain = new("Circuit de Barcelona-Catalunya", "SPANISH GRAND PRIX", "Catalunya, Spain", "Spain");
        readonly static Track monaco = new("Circuit de Monaco", "MONACO GRAND PRIX", "Monaco", "Monaco");
        readonly static Track baku = new("Baku City Circuit", "AZERBAIJAN GRAND PRIX", "Baku, Azerbaijan", "Baku");
        readonly static Track canada = new("Circuit Gilles-Villeneuve", "CANADIAN GRAND PRIX", "Montreal, Canada", "Canada");
        readonly static Track silverstone = new("Silverstone Circuit", "BRITISH GRAND PRIX", "Silverstone, Great Britain", "Silverstone");
        readonly static Track austria = new("Red Bull Ring", "AUSTRIAN GRAND PRIX", "Spielberg, Austria", "Austria");
        readonly static Track paulricard = new("Circuit Paul Ricard", "FRENCH GRAND PRIX", "Le Castellet, France", "Paul Ricard");
        readonly static Track hungaroring = new("Hungaroring", "HUNGARIAN GRAND PRIX", "Budapest, Hungary", "Hungaroring");
        readonly static Track spa = new("Circuit de Spa-Francorchamps", "BELGIAN GRAND PRIX", "Spa-Francorchamps, Belgium", "Spa");
        readonly static Track zandvoort = new("Circuit Zandvoort", "DUTCH GRAND PRIX", "Zandvoort, Netherlands", "Zandvoort");
        readonly static Track monza = new("Autodromo Nazionale Monza", "ITALIAN GRAND PRIX", "Milan, Italy", "Monza");
        readonly static Track singapore = new("Marina Bay Street Circuit", "SINGAPORE GRAND PRIX", "Singapore", "Singapore");
        readonly static Track suzuka = new("Suzuka International Racing Course", "JAPANESE GRAND PRIX", "Suzuka, Japan", "Suzuka");
        readonly static Track cota = new("Circuit of The Americas", "UNITED STATES GRAND PRIX", "Austin, United States", "Circuit of The Americas");
        readonly static Track mexico = new("Autodromo Hermanos Rodriguez", "MEXICAN GRAND PRIX", "Mexico City", "Mexico City");
        readonly static Track interlagos = new("Autodromo Jose Carlos Pace", "SÃO PAULO GRAND PRIX", "São Paulo, Brazil", "Interlagos");
        readonly static Track abudhabi = new("Yas Marina Circuit", "ABU DHABI GRAND PRIX", "Abu Dhabi, United Arab Emirates", "Abu Dhabi");

        public class DriverComparer : IComparer<Driver>
        {
            public int Compare(Driver? x, Driver? y)
            {
                return y!.rating.CompareTo(x!.rating);
            }
        }

        public class DStandingComparer : IComparer<Driver>
        {
            public int Compare(Driver? x, Driver? y)
            {
                return y!.points.CompareTo(x!.points);
            }
        }

        public class TStandingComparer : IComparer<Team>
        {
            public int Compare(Team? x, Team? y)
            {
                return y!.points.CompareTo(x!.points);
            }
        }

        public class DAllTimeStandingComparer : IComparer<Driver>
        {
            public int Compare(Driver? x, Driver? y)
            {
                if (y!.totChampionships != x!.totChampionships)
                {
                    return y!.totChampionships.CompareTo(x!.totChampionships);
                }
                else if (y!.totWins != x!.totWins)
                {
                    return y!.totWins.CompareTo(x!.totWins);
                }
                else if (y!.totPodiums != x!.totPodiums)
                {
                    return y!.totPodiums.CompareTo(x!.totPodiums);
                }
                else
                {
                    return y!.totPoints.CompareTo(x!.totPoints);
                }
            }
        }

        public class TAllTimeStandingComparer : IComparer<Team>
        {
            public int Compare(Team? x, Team? y)
            {
                if (y!.totChampionships != x!.totChampionships)
                {
                    return y!.totChampionships.CompareTo(x!.totChampionships);
                }
                else if (y!.totWins != x!.totWins)
                {
                    return y!.totWins.CompareTo(x!.totWins);
                }
                else if (y!.totPodiums != x!.totPodiums)
                {
                    return y!.totPodiums.CompareTo(x!.totPodiums);
                }
                else
                {
                    return y!.totPoints.CompareTo(x!.totPoints);
                }
            }
        }

        static void Main()
        {
            Console.Title = "Formula 1 Simulator";
            Console.CancelKeyPress += new ConsoleCancelEventHandler(StopAutorun);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (string ln in intro)
            {
                Console.WriteLine(ln);
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (string ln in image)
            {
                Console.WriteLine(ln);
            }
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(3000);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the ultimate Formula 1 Simulator.");
            Thread.Sleep(400);
            Console.WriteLine("Are you ready to write a new chapter in the sports history books?");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("After the game has started, press 'C' to enter command mode.");
            Thread.Sleep(400);
            Console.WriteLine("Press 'H' at any time to get help or a list of all available commands.");
            Thread.Sleep(400);
            Console.WriteLine("To continue press 'Enter'.");
            Thread.Sleep(400);

            GameLoop();

            Console.WriteLine("Thank you for playing Formula 1 Simulator!");
        }

        public static void GameLoop()
        {
            if (!allDriversDead)
            {
                NewSeason();
                if (gameFinished == false)
                {
                    Reset();
                    Randomizer();
                    if (seasonSim == true)
                    {
                        grid = true;
                        specs = true;
                    }
                    else
                    {
                        tableTitle = season + " Grid Lineup";
                        Grid();
                    }
                    if (seasonSim == false)
                    {
                        StartSeason();
                    }
                    SimulateRaces();
                    EndSeason();
                    GameLoop();
                }
            }
            else
            {
                GameOver();
            }
        }

        public static void NewSeason()
        {
        checkpoint:
            Console.WriteLine("Start a new season or press 'E' to exit game...");
        fallback:
            if (autorun == false)
            {
                ConsoleKeyInfo advance = Console.ReadKey(true);
                if (advance.Key == ConsoleKey.H)
                {
                    Console.SetCursorPosition(x, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    Help();
                    goto checkpoint;
                }
                else if (advance.Key == ConsoleKey.C)
                {
                    Console.SetCursorPosition(x, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    CommandMode();
                    goto checkpoint;
                }
                else if (advance.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(x, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                }
                else if (advance.Key == ConsoleKey.E)
                {
                    Console.SetCursorPosition(x, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    gameFinished = true;
                }
                else
                {
                    goto fallback;
                }
            }
            else
            {
                Thread.Sleep(gameSpeed);
            }

            season += 1;

            Console.WriteLine();
            Console.WriteLine();
            if (gameFinished == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Initializing new season");
                x = 23;
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine();
                    Thread.Sleep(200);
                }
                x = 0;
                Console.SetCursorPosition(x, Console.CursorTop);
                ClearCurrentConsoleLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Reset()
        {
            x = 0;
            grid = false;
            specs = false;
            gameFinished = false;

            for (int i = 0; i < teams.Length; i++)
            {
                teams[i].age += 1;
                teams[i].points = 0;
                teams[i].wins = 0;
                teams[i].podiums = 0;
            }

            for (int i = 0; i < drivers.Length; i++)
            {
                drivers[i].points = 0;
                drivers[i].wins = 0;
                drivers[i].podiums = 0;
                if (!drivers[i].dead)
                {
                    drivers[i].age += 1;
                }
            }
        }

        public static void Randomizer()
        {
            driverPool = drivers;

            selectedDrivers = new Driver[20];

            for (int i = 0; i < 20; i++)
            {
                Random random = new();
                int rindex = random.Next(driverPool.Length);
                selectedDrivers[i] = driverPool[rindex];
                for (int y = rindex; y < driverPool.Length - 1; y++)
                {
                    driverPool[y] = driverPool[y + 1];
                }
                Array.Resize(ref driverPool, driverPool.Length - 1);
            }

            for (int i = 0; i < selectedDrivers.Length; i++)
            {
                selectedDrivers[i].seat = seats[i];
                selectedDrivers[i].color = seats[i].color;
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(selectedDrivers[i].name);
            }
        }

        public static void Grid()
        {
            colTitle = new[]
            {
                "             Team              ",
                "    1st Driver    ",
                "    2nd Driver    "
            };

            leftCol = new[]
            {
                "\x1b[38;5;" + 4 + "m" + "Oracle Red Bull Racing",
                "\x1b[38;5;" + 196 + "m" + "Scuderia Ferrari",
                "\x1b[38;5;" + 50 + "m" + "Mercedes-AMG Petronas",
                "\x1b[38;5;" + 39 + "m" + "BWT ALpine",
                "\x1b[38;5;" + 208 + "m" + "McLaren",
                "\x1b[38;5;" + 124 + "m" + "Alfa Romeo Orlen",
                "\x1b[38;5;" + 30 + "m" + "Aston Martin Aramco Cognizant",
                "\x1b[38;5;" + 11 + "m" + "Haas",
                "\x1b[38;5;" + 240 + "m" + "Scuderia AlphaTauri",
                "\x1b[38;5;" + 26 + "m" + "Williams Racing"
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TableGenerator(5, 69, 10, 3));

            //nu kommer säkert denna tabell bli fel för att den använder selectedDrivers, som sorteras och ändras av andra - måste skapa en oberoende array där deras index matchar deras seat i stallen
        }

        public static void StartSeason()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now that the teams have annouced their lineups and unveiled their cars, it's time for Formula 1 " + season + "!");
        checkpoint:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Go to first race...");
        fallback:
            if (autorun == false)
            {
                ConsoleKeyInfo advance = Console.ReadKey(true);
                if (advance.Key == ConsoleKey.H)
                {
                    Console.SetCursorPosition(x, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    Help();
                    goto checkpoint;
                }
                else if (advance.Key == ConsoleKey.C)
                {
                    Console.SetCursorPosition(x, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    CommandMode();
                    goto checkpoint;
                }
                else if (advance.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(x, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                }
                else
                {
                    goto fallback;
                }
            }
            else
            {
                Thread.Sleep(gameSpeed);
            }
        }

        public static void SimulateRaces()
        {
            racestart = "Round 1 of 22 begins with the " + bahrain.gp + ".";
            startornext = "Start race...";
            currentrace = "        BAHRAIN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Bahrain";
            Race();

            racestart = "After that dramatic start of the season, it's time to race at " + jeddah.name + ".";
            startornext = "Next race...";
            currentrace = "    SAUDI ARABIAN GRAND PRIX RACE RESULTS     ";
            CurrentRace = "Jeddah";
            Race();

            racestart = "Round 3 brings us to " + australia.location + ".";
            currentrace = "      AUSTRALIAN GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Australia";
            Race();

            racestart = "This weekend the drivers will fight it out at " + imola.name + ".";
            currentrace = "    EMILIA-ROMAGNA GRAND PRIX RACE RESULTS    ";
            CurrentRace = "Imola";
            Race();

            racestart = "Brace yourself, it's time for the " + miami.gp + ".";
            currentrace = "         MIAMI GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Miami";
            Race();

            racestart = spain.location + " will host this weekends race.";
            currentrace = "        SPANISH GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Spain";
            Race();

            racestart = monaco.shortname + " is no stranger to Formula 1, it's time for the " + monaco.gp + ".";
            currentrace = "        MONACO GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Monaco";
            Race();

            racestart = "Round 8 of 22 comes to " + baku.location + " at the " + baku.name + ".";
            currentrace = "       AZERBAIJAN GRAND PRIX RACE RESULTS     ";
            CurrentRace = "Baku";
            Race();

            racestart = "This weekend, we fly across the Atlantic for the " + canada.gp + ".";
            currentrace = "       CANADIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Canada";
            Race();

            racestart = "Let's race at the legendary " + silverstone.name + "!";
            currentrace = "       BRITISH GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Silverstone";
            Race();

            racestart = austria.name + " hosts the upcoming race.";
            currentrace = "       AUSTRIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Austria";
            Race();

            racestart = "The " + paulricard.gp + " at " + paulricard.name + " marks the halfpoint of the season.";
            currentrace = "        FRENCH GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Paulricard";
            Race();

            racestart = "It's time to race at the " + hungaroring.name + " in " + hungaroring.location + ".";
            currentrace = "       HUNGARIAN GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Hungaroring";
            Race();

            racestart = "After the summer break, we continue at the fan favorite " + spa.name + ".";
            currentrace = "        BELGIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Spa";
            Race();

            racestart = "Round 14 brings us to " + zandvoort.location + " for the " + zandvoort.gp + ".";
            currentrace = "         DUTCH GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Zandvoort";
            Race();

            racestart = "With 8 races to go we visit the temple of speed. " + monza.name + "!";
            currentrace = "        ITALIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Monza";
            Race();

            racestart = "Not many circuits can compare with the narrow streets of Monaco. " + singapore.name + " however, might be one of them.";
            currentrace = "       SINGAPORE GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Singapore";
            Race();

            racestart = "We're in " + suzuka.location + " for another fan favorite. Let's race at " + suzuka.shortname + "!";
            currentrace = "       JAPANESE GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Suzuka";
            Race();
            racestart = "Welcome to " + cota.location + ". We're racing at " + cota.name + ".";
            currentrace = "     UNITED STATES GRAND PRIX RACE RESULTS    ";
            CurrentRace = "Cota";
            Race();

            racestart = "This race weekend takes place at an altidude of 2280 meters, at " + mexico.name + ".";
            currentrace = "        MEXICAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Mexico";
            Race();

            racestart = "Welcome to Brazil, where the drivers and teams will be racing for the win at " + interlagos.shortname + ".";
            currentrace = "       SÃO PAULO GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Interlagos";
            Race();

            racestart = "Who will be crowned as world champion at the last race, in " + abudhabi.shortname + " today?";
            currentrace = "       ABU DHABI GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Abudhabi";
            Race();
        }

        public static void EndSeason()
        {
            Array.Sort(selectedDrivers!, new DStandingComparer()!);

            Team[] standingteams = new[]
            {
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
            };

            Array.Sort(standingteams, new TStandingComparer());

            selectedDrivers![0].totChampionships += 1;
            selectedDrivers[0].seat!.totDChampionships += 1;
            standingteams[0]!.totChampionships += 1;

            Console.WriteLine();
            Console.WriteLine("\x1b[38;5;" + 178 + "m" + selectedDrivers[0].name + " is crowned World Champion!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Full " + season + " season results:");
            Console.WriteLine();

            seasonResults = true;
            tableTitle = "Drivers";
            DriverStandings();
            tableTitle = "Constructors";
            TeamStandings();
            seasonResults = false;

            Console.WriteLine();
            Console.WriteLine();

            DriverSurvival();

            allDriversDead = true;
            for (int i = 0; i < drivers.Length; i++)
            {
                if (drivers[i].dead == false)
                {
                    allDriversDead = false;
                }
            }
        }

        public static void GameOver()
        {
            //visa all time stats och avgöra vinnaren
        }

        public static void Help()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Valid general commands are:");
            Console.WriteLine("'grid'");
            Console.WriteLine("'specs'");
            Console.WriteLine("'driver standings'");
            Console.WriteLine("'team standings'");
            Console.WriteLine("'all time driver standings'");
            Console.WriteLine("'all time team standings'");
            Console.WriteLine("'(driver)' or '(team)' to find stats and info on a certain driver or team");
            Console.WriteLine("'clear' - clears up the console so you can stay focused on the present!");
            Console.WriteLine("'autorun' - let the simulation run continuosly, press 'Ctrl' + 'C' to stop");
            Console.WriteLine("'simulate season' and 'simulate races' to switch between modes");
        }

        public static void CommandMode()
        {
            static void TeamMode()
            {
                bool loop = true;

                Console.ForegroundColor = ConsoleColor.Green;
            checkpoint2:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("What do you wish to learn about " + currentteam!.name + "?");
            fallback2:
                ConsoleKeyInfo cmd = Console.ReadKey(true);
                if (cmd.Key == ConsoleKey.Backspace)
                {
                    loop = false;
                    goto endcmd2;
                }
                else if (cmd.Key == ConsoleKey.H)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Valid commands here are:");
                    Console.WriteLine("'info' - to learn more about them");
                    Console.WriteLine("'ratings' - displays the overall and in depth ratings of this teams car");
                    Console.WriteLine("'stats' - shows accumulated statistics since the season start");
                    Console.WriteLine("'all time stats' - shows the all-time stats in this teams existence");
                    Console.WriteLine("'Backspace' - to return to general command mode");
                    goto checkpoint2;
                }
                else if (cmd.Key != ConsoleKey.Enter)
                {
                    goto fallback2;
                }

                Console.Write(">");
                string input = Console.ReadLine()!;
                Console.ForegroundColor = ConsoleColor.White;
                if (input.ToLower() == "info")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentteam.name + " is " + currentteam.prefix + " Formula 1 team based in " + currentteam.hq + ".");
                    Console.WriteLine("They have been in the sport for " + currentteam.age + " years.");
                    Console.WriteLine(currentteam.principal + " is currently the team principal of " + currentteam.name + ".");
                }
                else if (input.ToLower() == "ratings" || input.ToLower() == "rating")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentteam.name + " ratings:");
                    Console.WriteLine();
                    Console.WriteLine("      Overall performance: " + currentteam.performance);
                    Console.WriteLine("ICE Power: " + currentteam.power + "     ICE Reliability:  " + currentteam.reliability);
                    Console.WriteLine("Downforce: " + currentteam.downforce + "     Aerodynamics:    " + currentteam.drag);
                    Console.WriteLine("Traction:  " + currentteam.traction + "     Tyre degradation: " + currentteam.degradation);
                }
                else if (input.ToLower() == "stats")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentteam.name + " currently has " + currentteam.wins + " wins, " + currentteam.podiums + " podiums, and " + currentteam.points + " points this season.");
                }
                else if (input.ToLower() == "all time stats")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentteam.name + " has a total of " + currentteam.totWins + " wins, " + currentteam.totPodiums + " podiums, and " + currentteam.totPoints + " points.");
                    Console.WriteLine("They have also won " + currentteam.totChampionships + " constructors championships, and " + currentteam.totDChampionships + " drivers championships.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'" + input + "'" + " is not a valid command, please try again");
                }

            endcmd2:
                if (loop == true)
                {
                    TeamMode();
                }
                else
                {
                    Console.WriteLine("Returned to command mode");
                }
            }

            static void DriverMode()
            {
                bool loop = true;

                Console.ForegroundColor = ConsoleColor.Green;
            checkpoint3:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("What do you want to find out about " + currentdriver!.name + "?");
            fallback3:
                ConsoleKeyInfo cmd = Console.ReadKey(true);
                if (cmd.Key == ConsoleKey.Backspace)
                {
                    loop = false;
                    goto endcmd3;
                }
                else if (cmd.Key == ConsoleKey.H)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Valid commands here are:");
                    Console.WriteLine("'info' - to learn more about him");
                    Console.WriteLine("'ratings' - displays the drivers overall and other detailed ratings");
                    Console.WriteLine("'stats' - shows different statistics since the season start");
                    Console.WriteLine("'all time stats' - shows the all-time stats in this drivers career");
                    Console.WriteLine("'Backspace' - to return to general command mode");
                    goto checkpoint3;
                }
                else if (cmd.Key != ConsoleKey.Enter)
                {
                    goto fallback3;
                }

                Console.Write(">");
                string input = Console.ReadLine()!;
                Console.ForegroundColor = ConsoleColor.White;
                if (input.ToLower() == "info")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentdriver.name + " is a " + currentdriver.prefix + " Formula 1 driver.");
                    Console.WriteLine("He is " + currentdriver.age + " years of age.");
                }
                else if (input.ToLower() == "ratings" || input.ToLower() == "rating")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentdriver.name + " ratings:");
                    Console.WriteLine();
                    Console.WriteLine("       Overall skill: " + currentdriver.overall);
                    Console.WriteLine("Pace:      " + currentdriver.pace + "     Consistency: " + currentdriver.consistency);
                    Console.WriteLine("Racecraft: " + currentdriver.racecraft + "     Experience:  " + currentdriver.experience);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.ToLower() == "stats")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentdriver.name + " has accumulated " + currentdriver.wins + " wins, " + currentdriver.podiums + " podiums, and " + currentdriver.points + " points since the start of this season.");
                }
                else if (input.ToLower() == "all time stats")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("During his career, " + currentdriver.name + " have gotten " + currentdriver.totWins + " wins, " + currentdriver.totPodiums + " podiums, and " + currentdriver.totPoints + " points.");
                    Console.WriteLine("He is a " + currentdriver.totChampionships + "x time world champion.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(input + " is not a valid command, please try again");
                }

            endcmd3:
                if (loop == true)
                {
                    DriverMode();
                }
                else
                {
                    Console.WriteLine("Returned to command mode");
                }
            }

            bool loop = true;

            Console.ForegroundColor = ConsoleColor.Green;
        checkpoint:
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to enter a command or 'Backspace' to exit command mode:");
        fallback:
            ConsoleKeyInfo cmd = Console.ReadKey(true);
            if (cmd.Key == ConsoleKey.Backspace)
            {
                loop = false;
                goto endcmd;
            }
            else if (cmd.Key == ConsoleKey.H)
            {
                Help();
                goto checkpoint;
            }
            else if (cmd.Key != ConsoleKey.Enter)
            {
                goto fallback;
            }

            Console.Write(">");
            string input = Console.ReadLine()!;
            if (selectedDrivers != null)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (input.ToLower() == selectedDrivers![i].name.ToString().ToLower() || input.ToLower() == selectedDrivers[i].firstname.ToString().ToLower() || input.ToLower() == selectedDrivers[i].lastname.ToString().ToLower() || input.ToLower() == selectedDrivers[i].shortname.ToString().ToLower())
                    {
                        currentdriver = selectedDrivers[i];
                        DriverMode();
                        goto checkpoint;
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (input.ToLower() == teams[i].name.ToString().ToLower())
                    {
                        currentteam = teams[i];
                        TeamMode();
                        goto checkpoint;
                    }
                }
            }

            if (input.ToLower() == "simulate season")
            {
                Console.WriteLine("Now simulating whole championship, enter command 'simulate races' to revert");
                seasonSim = true;
            }
            else if (input.ToLower() == "simulate races" && seasonSim == true)
            {
                Console.WriteLine("Reverted to race simulation");
                seasonSim = false;
            }
            else if (input.ToLower() == "autorun")
            {
                Console.WriteLine("The game will now run automatically, press 'Ctrl' + 'C' to stop");
                autorun = true;
            }
            else if (input.ToLower() == "grid")
            {
                if (grid == true)
                {
                    tableTitle = "Current Grid Lineup";
                    Grid();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This seasons grid has not been revealed yet!");
                }
            }
            else if (input.ToLower() == "specs")
            {
                if (specs == true)
                {
                    tableTitle = "Technical Specifications";
                    Specs();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The teams haven't announced this years cars yet!");
                }
            }
            else if (input.ToLower() == "driver standings")
            {
                tableTitle = "Drivers Championship";
                DriverStandings();
            }
            else if (input.ToLower() == "team standings")
            {
                tableTitle = "Constructors Championship";
                TeamStandings();
            }
            else if (input.ToLower() == "all time driver standings")
            {
                tableTitle = "All-Time Drivers";
                AllTimeDStandings();
            }
            else if (input.ToLower() == "all time team standings")
            {
                tableTitle = "All-Time Constructors";
                AllTimeTStandings();
            }
            else if (input.ToLower() == "clear")
            {
                Console.Clear();
                Console.WriteLine("Cleared console");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("'" + input + "'" + " is not a valid command, please try again");
            }

        endcmd:
            if (loop == true)
            {
                CommandMode();
            }
            else
            {
                Console.WriteLine("Exited command mode");
            }
        }

        public static void StopAutorun(object? sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Stopped");
            autorun = false;
            //gå till senaste stället programmet var på, så den fortsätter
        }

        public static void Specs()
        {
            colTitle = new[]
            {
                "     Team     ",
                " Chassis ",
                "      Power Unit      "
            };

            chassis = new[]
            {
                "\x1b[38;5;" + 4 + "m" + "RB18",
                "\x1b[38;5;" + 196 + "m" + "F1-75",
                "\x1b[38;5;" + 50 + "m" + "W13",
                "\x1b[38;5;" + 39 + "m" + "A522",
                "\x1b[38;5;" + 208 + "m" + "MCL36",
                "\x1b[38;5;" + 124 + "m" + "C41",
                "\x1b[38;5;" + 30 + "m" + "AMR22",
                "\x1b[38;5;" + 11 + "m" + "VF-22",
                "\x1b[38;5;" + 240 + "m" + "AT03",
                "\x1b[38;5;" + 26 + "m" + "FW44"
            };

            powerUnit = new[]
            {
                "\x1b[38;5;" + 4 + "m" + "Red Bull Powertrains",
                "\x1b[38;5;" + 196 + "m" + "Ferrari",
                "\x1b[38;5;" + 50 + "m" + "Mercedes",
                "\x1b[38;5;" + 39 + "m" + "Renault",
                "\x1b[38;5;" + 50 + "m" + "Mercedes",
                "\x1b[38;5;" + 196 + "m" + "Ferrari",
                "\x1b[38;5;" + 50 + "m" + "Mercedes",
                "\x1b[38;5;" + 196 + "m" + "Ferrari",
                "\x1b[38;5;" + 21 + "m" + "Red Bull Powertrains",
                "\x1b[38;5;" + 50 + "m" + "Mercedes"
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TableGenerator(6, 45, 10, 3));
        }

        public static void DriverStandings()
        {
            Array.Sort(selectedDrivers!, new DStandingComparer()!);

            colTitle = new[]
            {
                " Pos.   ",
                "      Driver       ",
                " Pts "
            };

            leftCol = new string[selectedDrivers!.Length];

            for (int i = 0; i < selectedDrivers.Length; i++)
            {
                if (i == 0)
                {
                    if (seasonResults)
                    {
                        leftCol[i] = "\x1b[38;5;" + 178 + "m" + " C     " + "\x1b[38;5;" + 15 + "m";
                    }
                    else
                    {
                        leftCol[i] = " Leader";
                    }
                }
                else
                {
                    leftCol[i] = " P" + (i + 1).ToString();
                    for (int n = 0; n < 6 - (i + 1).ToString().Length; n++)
                    {
                        leftCol[i] += " ";
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TableGenerator(2, 34, selectedDrivers!.Length, 3));
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void AllTimeDStandings()
        {
            Array.Sort(sortedDrivers, new DAllTimeStandingComparer()!);

            colTitle = new[]
            {
                " Pos. ",
                "      Driver      ",
                " Championships ",
                " Wins ",
                " Podiums ",
                " Points "
            };

            leftCol = new string[sortedDrivers!.Length];

            for (int i = 0; i < sortedDrivers.Length; i++)
            {
                if (i == 0)
                {
                    leftCol[i] = " GOAT ";
                }
                else
                {
                    leftCol[i] = " P" + (i + 1).ToString();
                    for (int n = 0; n < 4 - (i + 1).ToString().Length; n++)
                    {
                        leftCol[i] += " ";
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TableGenerator(4, 67, 20, 6));
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void TeamStandings()
        {
            standingTeams = new[]
            {
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
            };

            Array.Sort(standingTeams, new TStandingComparer());

            colTitle = new[]
            {
                " Pos.   ",
                "     Team      ",
                " Pts "
            };

            leftCol = new string[standingTeams.Length];

            for (int i = 0; i < standingTeams.Length; i++)
            {
                if (i == 0)
                {
                    if (seasonResults)
                    {
                        leftCol[i] = "\x1b[38;5;" + 178 + "m" + " C     " + "\x1b[38;5;" + 15 + "m";
                    }
                    else
                    {
                        leftCol[i] = " Leader";
                    }
                }
                else
                {
                    leftCol[i] = " P" + (i + 1).ToString();
                    for (int n = 0; n < 6 - (i + 1).ToString().Length; n++)
                    {
                        leftCol[i] += " ";
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TableGenerator(1, 30, 10, 3));
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void AllTimeTStandings()
        {
            standingTeams = new[]
            {
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
            };

            Array.Sort(standingTeams, new TAllTimeStandingComparer());

            colTitle = new[]
{
                " Pos. ",
                "     Team      ",
                " Championships (Drivers) ",
                " Wins ",
                " Podiums ",
                " Points "
            };

            leftCol = new string[standingTeams!.Length];

            for (int i = 0; i < standingTeams.Length; i++)
            {
                if (i == 0)
                {
                    leftCol[i] = " Best ";
                }
                else
                {
                    leftCol[i] = " P" + (i + 1).ToString();
                    for (int n = 0; n < 4 - (i + 1).ToString().Length; n++)
                    {
                        leftCol[i] += " ";
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TableGenerator(3, 74, 10, 6));
            Console.WriteLine();
            Console.WriteLine();
        }

        public static string TableGenerator(int type, int width, int rows, int columns)
        {
            string table = "╔";
            string titleSpace = "";

            for (int i = 0; i < width; i++)
            {
                table += "═";
            }
            table += "╗\r\n║";

            for (int i = 0; i < (width - tableTitle!.Length) / 2; i++)
            {
                titleSpace += " ";
            }
            table += titleSpace + tableTitle;
            if (tableTitle.Length % 2 == 1 || type == 4)
            {
                table += titleSpace + " ║\r\n╠";
            }
            else
            {
                table += titleSpace + "║\r\n╠";
            }

            for (int i = 0; i < columns; i++)
            {
                for (int y = 0; y < colTitle![i].Length; y++)
                {
                    table += "═";
                }
                if (i == columns - 1)
                {
                    table += "╣\r\n║";
                }
                else
                {
                    table += "╦";
                }
            }

            for (int i = 0; i < columns; i++)
            {
                table += colTitle![i] + "║";
            }
            table += "\r\n╠";

            for (int i = 0; i < columns; i++)
            {
                for (int y = 0; y < colTitle![i].Length; y++)
                {
                    table += "═";
                }
                if (i == columns - 1)
                {
                    table += "╣";
                }
                else
                {
                    table += "╬";
                }
            }

            if (type == 1)
            {
                string[] t = new string[standingTeams!.Length];
                string[] u = new string[standingTeams.Length];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = "  ║ ";
                    for (int y = 0; y < 12 - standingTeams[i].name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    u[i] = " ║ ";
                    for (int y = 0; y < 3 - standingTeams[i].points.ToString().Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    table += "\r\n║" + leftCol![i] + "║ " + standingTeams[i].color + standingTeams[i].name + "\x1b[38;5;" + 15 + "m" + t[i] + standingTeams[i].points + u[i];
                }
            }
            else if (type == 2)
            {
                string[] t = new string[selectedDrivers!.Length];
                string[] u = new string[selectedDrivers.Length];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = "  ║ ";
                    for (int y = 0; y < 16 - selectedDrivers[i].name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    u[i] = " ║ ";
                    for (int y = 0; y < 3 - selectedDrivers[i].points.ToString().Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    table += "\r\n║" + leftCol![i] + "║ " + selectedDrivers[i].color + selectedDrivers[i].name + "\x1b[38;5;" + 15 + "m" + t[i] + selectedDrivers[i].points + u[i];
                }
            }
            else if (type == 3)
            {
                string[] t = new string[10];
                string[] u = new string[10];
                string[] w = new string[10];
                string[] p = new string[10];
                string[] s = new string[10];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = "  ║ ";
                    for (int y = 0; y < 12 - standingTeams![i].name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    u[i] = "         ║ ";
                    for (int y = 0; y < 4 - standingTeams![i].totChampionships.ToString().Length - standingTeams[i].totDChampionships.ToString().Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    w[i] = " ║ ";
                    for (int y = 0; y < 4 - standingTeams![i].totWins.ToString().Length; y++)
                    {
                        w[i] = " " + w[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    p[i] = " ║ ";
                    for (int y = 0; y < 7 - standingTeams![i].totPodiums.ToString().Length; y++)
                    {
                        p[i] = " " + p[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    s[i] = " ║ ";
                    for (int y = 0; y < 6 - standingTeams![i].totPoints.ToString().Length; y++)
                    {
                        s[i] = " " + s[i];
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    table += "\r\n║" + leftCol![i] + "║ " + standingTeams![i].color + standingTeams[i].name + "\x1b[38;5;" + 15 + "m" + t[i] + "        " + standingTeams[i].totChampionships + " (" + standingTeams[i].totDChampionships + ")" + u[i] + standingTeams[i].totWins + w[i] + standingTeams[i].totPodiums + p[i] + standingTeams[i].totPoints + s[i];
                }
            }
            else if (type == 4)
            {
                string[] t = new string[20];
                string[] u = new string[20];
                string[] w = new string[20];
                string[] p = new string[20];
                string[] s = new string[20];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = " ║ ";
                    for (int y = 0; y < 16 - sortedDrivers[i].name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    u[i] = "      ║ ";
                    for (int y = 0; y < 2 - sortedDrivers[i]!.totChampionships.ToString().Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    w[i] = " ║ ";
                    for (int y = 0; y < 4 - sortedDrivers[i]!.totWins.ToString().Length; y++)
                    {
                        w[i] = " " + w[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    p[i] = " ║ ";
                    for (int y = 0; y < 7 - sortedDrivers[i]!.totPodiums.ToString().Length; y++)
                    {
                        p[i] = " " + p[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    s[i] = " ║ ";
                    for (int y = 0; y < 6 - sortedDrivers[i]!.totPoints.ToString().Length; y++)
                    {
                        s[i] = " " + s[i];
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    table += "\r\n║" + leftCol![i] + "║ " + sortedDrivers[i].color + sortedDrivers[i].name + "\x1b[38;5;" + 15 + "m" + t[i] + "      " + sortedDrivers[i].totChampionships + u[i] + sortedDrivers[i].totWins + w[i] + sortedDrivers[i].totPodiums + p[i] + sortedDrivers[i].totPoints + s[i];
                }
            }
            else if (type == 5)
            {
                string[] t = new string[10];
                string[] u = new string[20];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = " ║ ";
                    for (int y = 0; y < 29 - leftCol![i].Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < u.Length; i++)
                {
                    u[i] = " ║ ";
                    for (int y = 0; y < 16 - selectedDrivers![i].name.Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                int a = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (i != 0)
                    {
                        table += "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣";
                    }
                    table += "\r\n║ " + leftCol![i] + "\x1b[38;5;" + 15 + "m" + t[i];
                    for (int n = 0; n < 2; n++)
                    {
                        table += selectedDrivers![a].color + selectedDrivers[a].name + "\x1b[38;5;" + 15 + "m" + u[a];
                        a++;
                    }
                }
            }
            else if (type == 6)
            {
                string[] t = new string[10];
                string[] u = new string[10];
                string[] w = new string[10];

                for (int i = 0; i < u.Length; i++)
                {
                    t[i] = " ║ ";
                    for (int y = 0; y < 12 - allTeams[i].name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < u.Length; i++)
                {
                    u[i] = " ║ ";
                    for (int y = 0; y < 5 - chassis![i].Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                for (int i = 0; i < w.Length; i++)
                {
                    w[i] = " ║ ";
                    for (int y = 0; y < 20 - powerUnit![i].Length; y++)
                    {
                        w[i] = " " + w[i];
                    }
                }

                //chassis och powerUnit kanske blir fel ifall den tar med stringen för färg och de eftersom de blir längre då - isåfall göra separata arrays för färgerna till allt (chassis, powerUnit, leftCol i grid) och lägga till i for loopen för raderna i tabellen

                for (int i = 0; i < rows; i++)
                {
                    if (i != 0)
                    {
                        table += "\r\n╠══════════════╬═════════╬══════════════════════╣";
                    }
                    table += "\r\n║ " + allTeams[i].color + allTeams[i].name + "\x1b[38;5;" + 15 + "m" + t[i] + chassis![i] + "\x1b[38;5;" + 15 + "m" + u[i] + powerUnit![i] + "\x1b[38;5;" + 15 + "m" + w[i];
                }
            }

            table += "\r\n╚";
            for (int i = 0; i < columns; i++)
            {
                for (int y = 0; y < colTitle![i].Length; y++)
                {
                    table += "═";
                }
                if (i == columns - 1)
                {
                    table += "╝";
                }
                else
                {
                    table += "╩";
                }
            }

            return table;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(x, currentLineCursor);
        }

        public static void DotAnimation()
        {
            if (autorun == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine();
                    Thread.Sleep(200);
                }
            }
            else
            {
                Console.Write(" .");
                Console.Write(" .");
                Console.Write(" .");
                Console.SetCursorPosition(x, Console.CursorTop);
                ClearCurrentConsoleLine();
            }
        }

        public static void DriverSurvival()
        {
            for (int i = 0; i < drivers.Length; i++)
            {
                int index = i;
                int survivalChance = 100;
                switch (drivers[i].age)
                {
                    case < 31:
                        survivalChance = 95;
                        break;
                    case < 41:
                        survivalChance = 90;
                        break;
                    case < 51:
                        survivalChance = 85;
                        break;
                    case < 61:
                        survivalChance = 75;
                        break;
                    case < 71:
                        survivalChance = 60;
                        break;
                    case < 81:
                        survivalChance = 45;
                        break;
                    case < 91:
                        survivalChance = 30;
                        break;
                    case < 101:
                        survivalChance = 15;
                        break;
                    case < 111:
                        survivalChance = 5;
                        break;
                }

                Random rand = new();
                int r = rand.Next(100);

                if (survivalChance - r! >= 0 && drivers[i].dead == false)
                {
                    Die(index);
                }
            }

            static void Die(int index)
            {
                string? verb;
                string cause = "old age";
                Random rand = new();
                int r = rand.Next(100);

                if (r < 50)
                {
                    verb = "died";
                }
                else
                {
                    verb = "passed away";
                }

                switch (r)
                {
                    case < 40:
                        if (drivers[index].age > 60)
                        {
                            cause = "old age";
                        }
                        else
                        {
                            cause = "a crash";
                        }
                        break;
                    case < 60:
                        cause = "cancer";
                        break;
                    case < 80:
                        cause = "a skiing accident";
                        break;
                    case < 100:
                        cause = "a heart attack";
                        break;
                }

                Console.WriteLine(drivers[index].name + " " + verb + " from " + cause);

                drivers[index].dead = true;
            }
        }

        public static void Race()
        {
            if (seasonSim == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(racestart);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(startornext);
            fallback:
                if (autorun == false)
                {
                    ConsoleKeyInfo advance = Console.ReadKey(true);
                    if (advance.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(x, Console.CursorTop - 1);
                        ClearCurrentConsoleLine();
                    }
                    else
                    {
                        goto fallback;
                    }
                }
                else
                {
                    Thread.Sleep(gameSpeed);
                }

                Racing();
            }

            switch (CurrentRace)
            {
                case "Bahrain":
                    Results.Bahrain(seats, selectedDrivers!, seasonSim);
                    currentgp = bahrain.gp;
                    break;
                case "Jeddah":
                    Results.Jeddah(seats, selectedDrivers!, seasonSim);
                    currentgp = jeddah.gp;
                    break;
                case "Australia":
                    Results.Australia(seats, selectedDrivers!, seasonSim);
                    currentgp = australia.gp;
                    break;
                case "Imola":
                    Results.Imola(seats, selectedDrivers!, seasonSim);
                    currentgp = imola.gp;
                    break;
                case "Miami":
                    Results.Miami(seats, selectedDrivers!, seasonSim);
                    currentgp = miami.gp;
                    break;
                case "Spain":
                    Results.Spain(seats, selectedDrivers!, seasonSim);
                    currentgp = spain.gp;
                    break;
                case "Monaco":
                    Results.Monaco(seats, selectedDrivers!, seasonSim);
                    currentgp = monaco.gp;
                    break;
                case "Baku":
                    Results.Baku(seats, selectedDrivers!, seasonSim);
                    currentgp = baku.gp;
                    break;
                case "Canada":
                    Results.Canada(seats, selectedDrivers!, seasonSim);
                    currentgp = canada.gp;
                    break;
                case "Silverstone":
                    Results.Silverstone(seats, selectedDrivers!, seasonSim);
                    currentgp = silverstone.gp;
                    break;
                case "Austria":
                    Results.Austria(seats, selectedDrivers!, seasonSim);
                    currentgp = austria.gp;
                    break;
                case "Paulricard":
                    Results.Paulricard(seats, selectedDrivers!, seasonSim);
                    currentgp = paulricard.gp;
                    break;
                case "Hungaroring":
                    Results.Hungaroring(seats, selectedDrivers!, seasonSim);
                    currentgp = hungaroring.gp;
                    break;
                case "Spa":
                    Results.Spa(seats, selectedDrivers!, seasonSim);
                    currentgp = spa.gp;
                    break;
                case "Zandvoort":
                    Results.Zandvoort(seats, selectedDrivers!, seasonSim);
                    currentgp = zandvoort.gp;
                    break;
                case "Monza":
                    Results.Monza(seats, selectedDrivers!, seasonSim);
                    currentgp = monza.gp;
                    break;
                case "Singapore":
                    Results.Singapore(seats, selectedDrivers!, seasonSim);
                    currentgp = singapore.gp;
                    break;
                case "Suzuka":
                    Results.Suzuka(seats, selectedDrivers!, seasonSim);
                    currentgp = suzuka.gp;
                    break;
                case "Cota":
                    Results.Cota(seats, selectedDrivers!, seasonSim);
                    currentgp = cota.gp;
                    break;
                case "Mexico":
                    Results.Mexico(seats, selectedDrivers!, seasonSim);
                    currentgp = mexico.gp;
                    break;
                case "Interlagos":
                    Results.Interlagos(seats, selectedDrivers!, seasonSim);
                    currentgp = interlagos.gp;
                    break;
                case "Abudhabi":
                    Results.Abudhabi(seats, selectedDrivers!, seasonSim);
                    currentgp = abudhabi.gp;
                    break;
            }

            resulttitle = currentrace;

            Result();

            if (seasonSim == false)
            {
                if (autorun == false)
                {
                    Thread.Sleep(1000);
                }
                else
                {
                    Thread.Sleep(gameSpeed / 2);
                }
            checkpoint:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Use commands or press 'Enter' to exit race weekend.");
            fallback2:
                if (autorun == false)
                {
                    ConsoleKeyInfo advance = Console.ReadKey(true);
                    if (advance.Key == ConsoleKey.H)
                    {
                        Console.SetCursorPosition(x, Console.CursorTop - 1);
                        ClearCurrentConsoleLine();
                        Help();
                        goto checkpoint;
                    }
                    else if (advance.Key == ConsoleKey.C)
                    {
                        Console.SetCursorPosition(x, Console.CursorTop - 1);
                        ClearCurrentConsoleLine();
                        CommandMode();
                        goto checkpoint;
                    }
                    else if (advance.Key != ConsoleKey.Enter)
                    {
                        goto fallback2;
                    }
                }
                else
                {
                    Thread.Sleep(gameSpeed);
                }

                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
        }

        public static void Racing()
        {
            Console.WriteLine();
            Console.WriteLine();
            Random random = new();
            int rand = random.Next(0, 10);
            if (rand < 5)
            {
                Console.Write("Racing");
                x = 6;
            }
            else
            {
                Console.Write("It's lights out and away we go!");
                x = 31;
            }
            DotAnimation();

            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine();
            rand = random.Next(0, 10);
            if (rand < 5)
            {
                Console.Write("Calculating strategies");
                x = 22;
            }
            else
            {
                Console.Write("Pacing");
                x = 6;
            }
            DotAnimation();

            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine();
            rand = random.Next(0, 10);
            if (rand < 5)
            {
                Console.Write("Performing pit stops");
                x = 20;
            }
            else
            {
                Console.Write("Box box, box box");
                x = 16;
            }
            DotAnimation();

            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine();
            rand = random.Next(0, 10);
            if (rand < 5)
            {
                Console.Write("Fighting for the win");
                x = 20;
            }
            else
            {
                Console.Write("Racing wheel to wheel");
                x = 21;
            }
            DotAnimation();

            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine();
        }

        public static void Result()
        {
            Array.Sort(selectedDrivers!, new DriverComparer()!);

            Team[] resultteams = new[]
            {
                selectedDrivers![0].seat,
                selectedDrivers[1].seat,
                selectedDrivers[2].seat,
                selectedDrivers[3].seat,
                selectedDrivers[4].seat,
                selectedDrivers[5].seat,
                selectedDrivers[6].seat,
                selectedDrivers[7].seat,
                selectedDrivers[8].seat,
                selectedDrivers[9].seat,
                selectedDrivers[10].seat,
                selectedDrivers[11].seat,
                selectedDrivers[12].seat,
                selectedDrivers[13].seat,
                selectedDrivers[14].seat,
                selectedDrivers[15].seat,
                selectedDrivers[16].seat,
                selectedDrivers[17].seat,
                selectedDrivers[18].seat,
                selectedDrivers[19].seat,
            }!;

            resultteams[0].wins = resultteams[0].wins + 1;
            resultteams[0].totWins = resultteams[0].totWins + 1;

            resultteams[0].podiums = resultteams[0].podiums + 1;
            resultteams[1].podiums = resultteams[1].podiums + 1;
            resultteams[2].podiums = resultteams[2].podiums + 1;
            resultteams[0].totPodiums = resultteams[0].totPodiums + 1;
            resultteams[1].totPodiums = resultteams[1].totPodiums + 1;
            resultteams[2].totPodiums = resultteams[2].totPodiums + 1;

            resultteams[0].points = resultteams[0].points + 25;
            resultteams[1].points = resultteams[1].points + 18;
            resultteams[2].points = resultteams[2].points + 15;
            resultteams[3].points = resultteams[3].points + 12;
            resultteams[4].points = resultteams[4].points + 10;
            resultteams[5].points = resultteams[5].points + 8;
            resultteams[6].points = resultteams[6].points + 6;
            resultteams[7].points = resultteams[7].points + 4;
            resultteams[8].points = resultteams[8].points + 2;
            resultteams[9].points = resultteams[9].points + 1;
            resultteams[0].totPoints = resultteams[0].totPoints + 25;
            resultteams[1].totPoints = resultteams[1].totPoints + 18;
            resultteams[2].totPoints = resultteams[2].totPoints + 15;
            resultteams[3].totPoints = resultteams[3].totPoints + 12;
            resultteams[4].totPoints = resultteams[4].totPoints + 10;
            resultteams[5].totPoints = resultteams[5].totPoints + 8;
            resultteams[6].totPoints = resultteams[6].totPoints + 6;
            resultteams[7].totPoints = resultteams[7].totPoints + 4;
            resultteams[8].totPoints = resultteams[8].totPoints + 2;
            resultteams[9].totPoints = resultteams[9].totPoints + 1;

            selectedDrivers[0]!.wins = selectedDrivers[0]!.wins + 1;
            selectedDrivers[0]!.totWins = selectedDrivers[0]!.totWins + 1;

            selectedDrivers[0]!.podiums = selectedDrivers[0]!.podiums + 1;
            selectedDrivers[1]!.podiums = selectedDrivers[1]!.podiums + 1;
            selectedDrivers[2]!.podiums = selectedDrivers[2]!.podiums + 1;
            selectedDrivers[0]!.totPodiums = selectedDrivers[0]!.totPodiums + 1;
            selectedDrivers[1]!.totPodiums = selectedDrivers[1]!.totPodiums + 1;
            selectedDrivers[2]!.totPodiums = selectedDrivers[2]!.totPodiums + 1;

            selectedDrivers[0]!.points = selectedDrivers[0]!.points + 25;
            selectedDrivers[1]!.points = selectedDrivers[1]!.points + 18;
            selectedDrivers[2]!.points = selectedDrivers[2]!.points + 15;
            selectedDrivers[3]!.points = selectedDrivers[3]!.points + 12;
            selectedDrivers[4]!.points = selectedDrivers[4]!.points + 10;
            selectedDrivers[5]!.points = selectedDrivers[5]!.points + 8;
            selectedDrivers[6]!.points = selectedDrivers[6]!.points + 6;
            selectedDrivers[7]!.points = selectedDrivers[7]!.points + 4;
            selectedDrivers[8]!.points = selectedDrivers[8]!.points + 2;
            selectedDrivers[9]!.points = selectedDrivers[9]!.points + 1;
            selectedDrivers[0]!.totPoints = selectedDrivers[0]!.totPoints + 25;
            selectedDrivers[1]!.totPoints = selectedDrivers[1]!.totPoints + 18;
            selectedDrivers[2]!.totPoints = selectedDrivers[2]!.totPoints + 15;
            selectedDrivers[3]!.totPoints = selectedDrivers[3]!.totPoints + 12;
            selectedDrivers[4]!.totPoints = selectedDrivers[4]!.totPoints + 10;
            selectedDrivers[5]!.totPoints = selectedDrivers[5]!.totPoints + 8;
            selectedDrivers[6]!.totPoints = selectedDrivers[6]!.totPoints + 6;
            selectedDrivers[7]!.totPoints = selectedDrivers[7]!.totPoints + 4;
            selectedDrivers[8]!.totPoints = selectedDrivers[8]!.totPoints + 2;
            selectedDrivers[9]!.totPoints = selectedDrivers[9]!.totPoints + 1;

            if (seasonSim == false)
            {
                string[] t = new string[20];
                string[] u = new string[20];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = " ║ ";
                    for (int y = 0; y < 16 - selectedDrivers[i]!.name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    u[i] = " ║ ";
                    for (int y = 0; y < 12 - resultteams[i].name.Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine(selectedDrivers[0]!.color + selectedDrivers[0]!.name + "\x1b[38;5;" + 15 + "m" + " wins the " + currentgp + "!");
                Console.WriteLine();
                Console.WriteLine("╔══════════════════════════════════════════════╗" +
                              "\r\n║" + resulttitle + "║" +
                              "\r\n╠══════╦══════════════════╦══════════════╦═════╣" +
                              "\r\n║ Pos. ║      Driver      ║     Team     ║ Pts ║" +
                              "\r\n╠══════╬══════════════════╬══════════════╬═════╣" +
                              "\r\n║ P1   ║ " + selectedDrivers[0]!.color + selectedDrivers[0]!.name + "\x1b[38;5;" + 15 + "m" + t[0] + resultteams[0].color + resultteams[0].name + "\x1b[38;5;" + 15 + "m" + u[0] + "25  ║" +
                              "\r\n║ P2   ║ " + selectedDrivers[1]!.color + selectedDrivers[1]!.name + "\x1b[38;5;" + 15 + "m" + t[1] + resultteams[1].color + resultteams[1].name + "\x1b[38;5;" + 15 + "m" + u[1] + "18  ║" +
                              "\r\n║ P3   ║ " + selectedDrivers[2]!.color + selectedDrivers[2]!.name + "\x1b[38;5;" + 15 + "m" + t[2] + resultteams[2].color + resultteams[2].name + "\x1b[38;5;" + 15 + "m" + u[2] + "15  ║" +
                              "\r\n║ P4   ║ " + selectedDrivers[3]!.color + selectedDrivers[3]!.name + "\x1b[38;5;" + 15 + "m" + t[3] + resultteams[3].color + resultteams[3].name + "\x1b[38;5;" + 15 + "m" + u[3] + "12  ║" +
                              "\r\n║ P5   ║ " + selectedDrivers[4]!.color + selectedDrivers[4]!.name + "\x1b[38;5;" + 15 + "m" + t[4] + resultteams[4].color + resultteams[4].name + "\x1b[38;5;" + 15 + "m" + u[4] + "10  ║" +
                              "\r\n║ P6   ║ " + selectedDrivers[5]!.color + selectedDrivers[5]!.name + "\x1b[38;5;" + 15 + "m" + t[5] + resultteams[5].color + resultteams[5].name + "\x1b[38;5;" + 15 + "m" + u[5] + "8   ║" +
                              "\r\n║ P7   ║ " + selectedDrivers[6]!.color + selectedDrivers[6]!.name + "\x1b[38;5;" + 15 + "m" + t[6] + resultteams[6].color + resultteams[6].name + "\x1b[38;5;" + 15 + "m" + u[6] + "6   ║" +
                              "\r\n║ P8   ║ " + selectedDrivers[7]!.color + selectedDrivers[7]!.name + "\x1b[38;5;" + 15 + "m" + t[7] + resultteams[7].color + resultteams[7].name + "\x1b[38;5;" + 15 + "m" + u[7] + "4   ║" +
                              "\r\n║ P9   ║ " + selectedDrivers[8]!.color + selectedDrivers[8]!.name + "\x1b[38;5;" + 15 + "m" + t[8] + resultteams[8].color + resultteams[8].name + "\x1b[38;5;" + 15 + "m" + u[8] + "2   ║" +
                              "\r\n║ P10  ║ " + selectedDrivers[9]!.color + selectedDrivers[9]!.name + "\x1b[38;5;" + 15 + "m" + t[9] + resultteams[9].color + resultteams[9].name + "\x1b[38;5;" + 15 + "m" + u[9] + "1   ║" +
                              "\r\n║ P11  ║ " + selectedDrivers[10]!.color + selectedDrivers[10]!.name + "\x1b[38;5;" + 15 + "m" + t[10] + resultteams[10].color + resultteams[10].name + "\x1b[38;5;" + 15 + "m" + u[10] + "0   ║" +
                              "\r\n║ P12  ║ " + selectedDrivers[11]!.color + selectedDrivers[11]!.name + "\x1b[38;5;" + 15 + "m" + t[11] + resultteams[11].color + resultteams[11].name + "\x1b[38;5;" + 15 + "m" + u[11] + "0   ║" +
                              "\r\n║ P13  ║ " + selectedDrivers[12]!.color + selectedDrivers[12]!.name + "\x1b[38;5;" + 15 + "m" + t[12] + resultteams[12].color + resultteams[12].name + "\x1b[38;5;" + 15 + "m" + u[12] + "0   ║" +
                              "\r\n║ P14  ║ " + selectedDrivers[13]!.color + selectedDrivers[13]!.name + "\x1b[38;5;" + 15 + "m" + t[13] + resultteams[13].color + resultteams[13].name + "\x1b[38;5;" + 15 + "m" + u[13] + "0   ║" +
                              "\r\n║ P15  ║ " + selectedDrivers[14]!.color + selectedDrivers[14]!.name + "\x1b[38;5;" + 15 + "m" + t[14] + resultteams[14].color + resultteams[14].name + "\x1b[38;5;" + 15 + "m" + u[14] + "0   ║" +
                              "\r\n║ P16  ║ " + selectedDrivers[15]!.color + selectedDrivers[15]!.name + "\x1b[38;5;" + 15 + "m" + t[15] + resultteams[15].color + resultteams[15].name + "\x1b[38;5;" + 15 + "m" + u[15] + "0   ║" +
                              "\r\n║ P17  ║ " + selectedDrivers[16]!.color + selectedDrivers[16]!.name + "\x1b[38;5;" + 15 + "m" + t[16] + resultteams[16].color + resultteams[16].name + "\x1b[38;5;" + 15 + "m" + u[16] + "0   ║" +
                              "\r\n║ P18  ║ " + selectedDrivers[17]!.color + selectedDrivers[17]!.name + "\x1b[38;5;" + 15 + "m" + t[17] + resultteams[17].color + resultteams[17].name + "\x1b[38;5;" + 15 + "m" + u[17] + "0   ║" +
                              "\r\n║ P19  ║ " + selectedDrivers[18]!.color + selectedDrivers[18]!.name + "\x1b[38;5;" + 15 + "m" + t[18] + resultteams[18].color + resultteams[18].name + "\x1b[38;5;" + 15 + "m" + u[18] + "0   ║" +
                              "\r\n║ P20  ║ " + selectedDrivers[19]!.color + selectedDrivers[19]!.name + "\x1b[38;5;" + 15 + "m" + t[19] + resultteams[19].color + resultteams[19].name + "\x1b[38;5;" + 15 + "m" + u[19] + "0   ║" +
                              "\r\n╚══════╩══════════════════╩══════════════╩═════╝");
            }
        }
    }
}


//göra så när tex 15 förare är kvar så är det random varje säsong vilka team som får förare, eller göra så de blir som vanligt och alla får förare men en del då är döda

//göra algorithm skit för tabellerna så det funkar med antal förare

//lägga till så om man kollar info om föraren så ser man om han är död eller ej

//fixa så autorun vet vart den ska återuppta, med variablar/checkpoints/labels nåt sånt

//fixa buggen där typ alla får engine issues i sista racet

//skapa custom drivers?

//göra så främst stallens och lite förarnas egenskaper ändras lite randomly (+= random, -= random osv.)