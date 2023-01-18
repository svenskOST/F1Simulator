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

        static string[] intro = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Formula 1 Simulator\Formula 1 Simulator\intro.txt");
        static string[] image = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Formula 1 Simulator\Formula 1 Simulator\image.txt");
        static string racestart = "Round 1 of 22 begins with the " + bahrain.gp + ".";
        static string startornext = "Start race...";
        static string currentrace = "        BAHRAIN GRAND PRIX RACE RESULTS       ";
        static string CurrentRace = "Bahrain";
        static string currentgp = bahrain.gp;
        static string resulttitle = currentrace;

        static int x = 0;

        static bool autorun = false;
        static bool grid = false;
        static bool specs = false;
        static bool gameFinished = false;

        static Engine eRedBull = new(90, 92);
        static Engine eFerrari = new(95, 85);
        static Engine eMercedes = new(85, 96);
        static Engine eRenault = new(85, 85);

        static Team RedBull = new("Red Bull", "Milton Keynes", 18, "Red Bull Powertrains", "an austrian", "Christian Horner", eRedBull.power, eRedBull.reliability, 93, 90, 95, 91, 0, 0, 0, "\x1b[38;5;" + 4 + "m");
        static Team Ferrari = new("Ferrari", "Maranello", 93, "Ferrari", "an italian", "Mattia Binotto", eFerrari.power, eFerrari.reliability, 97, 95, 90, 88, 0, 0, 0, "\x1b[38;5;" + 196 + "m");
        static Team Mercedes = new("Mercedes", "Brackley", 14, "Mercedes", "a german", "Toto Wolff", eMercedes.power, eMercedes.reliability, 89, 90, 86, 90, 0, 0, 0, "\x1b[38;5;" + 50 + "m");
        static Team Alpine = new("Alpine", "Enstone", 26, "Renault", "a french", "Otmar Szafnauer", eRenault.power, eRenault.reliability, 86, 89, 87, 88, 0, 0, 0, "\x1b[38;5;" + 39 + "m");
        static Team Mclaren = new("McLaren", "Woking", 56, "Mercedes", "a british", "Zak Brown", eMercedes.power, eMercedes.reliability, 80, 79, 83, 85, 0, 0, 0, "\x1b[38;5;" + 208 + "m");
        static Team AlfaRomeo = new("Alfa Romeo", "Hinwil", 44, "Ferrari", "a swiss", "Frédéric Vasseur", eFerrari.power - 9, eFerrari.reliability, 78, 81, 75, 82, 0, 0, 0, "\x1b[38;5;" + 124 + "m");
        static Team AstonMartin = new("Aston Martin", "Silverstone", 4, "Mercedes", "a british", "Mike Krack", eMercedes.power, eMercedes.reliability, 78, 80, 76, 78, 0, 0, 0, "\x1b[38;5;" + 30 + "m");
        static Team Haas = new("Haas", "Kannapolis", 7, "Ferrari", "an american", "Günther Steiner", eFerrari.power - 9, eFerrari.reliability, 77, 76, 79, 85, 0, 0, 0, "\x1b[38;5;" + 11 + "m");
        static Team AlphaTauri = new("AlphaTauri", "Faenza", 37, "Ferrari", "an italian", "Franz Tost", eRedBull.power - 9, eRedBull.reliability, 75, 74, 79, 78, 0, 0, 0, "\x1b[38;5;" + 240 + "m");
        static Team Williams = new("Williams", "Wantage", 53, "Mercedes", "a british", "Jost Capito", eMercedes.power - 3, eMercedes.reliability, 68, 72, 98, 75, 0, 0, 0, "\x1b[38;5;" + 26 + "m");

        static Team car1 = RedBull;
        static Team car2 = RedBull;
        static Team car3 = Ferrari;
        static Team car4 = Ferrari;
        static Team car5 = Mercedes;
        static Team car6 = Mercedes;
        static Team car7 = Alpine;
        static Team car8 = Alpine;
        static Team car9 = Mclaren;
        static Team car10 = Mclaren;
        static Team car11 = AlfaRomeo;
        static Team car12 = AlfaRomeo;
        static Team car13 = AstonMartin;
        static Team car14 = AstonMartin;
        static Team car15 = Haas;
        static Team car16 = Haas;
        static Team car17 = AlphaTauri;
        static Team car18 = AlphaTauri;
        static Team car19 = Williams;
        static Team car20 = Williams;

        static Team[] chosenteams = new[]
        {
            car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20
        };

        static Team? currentteam;

        static Driver ver = new("Max Verstappen", 24, "Max", "Verstappen", "VER", "the Netherlands", "dutch", 97, 92, 90, 78, 0, 0, 0);
        static Driver per = new("Sergio Perez", 32, "Sergio", "Perez", "PER", "Mexicó", "mexican", 86, 89, 93, 88, 0, 0, 0);
        static Driver lec = new("Charles Leclerc", 24, "Charles", "Leclerc", "LEC", "Monaco", "monegasque", 94, 85, 97, 71, 0, 0, 0);
        static Driver sai = new("Carlos Sainz", 27, "Carlos", "Sainz", "SAI", "Spain", "spanish", 90, 83, 90, 79, 0, 0, 0);
        static Driver ham = new("Lewis Hamilton", 37, "Lewis", "Hamilton", "HAM", "Great Britain", "british", 85, 92, 94, 95, 0, 0, 0);
        static Driver rus = new("George Russell", 24, "George", "Russell", "RUS", "Great Britain", "british", 90, 90, 88, 66, 0, 0, 0);
        static Driver alo = new("Fernando Alonso", 40, "Fernando", "Alonso", "ALO", "Spain", "spanish", 85, 91, 91, 99, 0, 0, 0);
        static Driver oco = new("Esteban Ocon", 25, "Esteban", "Ocon", "OCO", "France", "french", 81, 84, 80, 65, 0, 0, 0);
        static Driver nor = new("Lando Norris", 22, "Lando", "Norris", "NOR", "Great Britain", "british", 88, 82, 88, 67, 0, 0, 0);
        static Driver ric = new("Daniel Ricciardo", 32, "Daniel", "Ricciardo", "RIC", "Australia", "australian", 78, 80, 89, 90, 0, 0, 0);
        static Driver bot = new("Valterri Bottas", 32, "Valterri", "Bottas", "BOT", "Finland", "finnish", 83, 91, 75, 88, 0, 0, 0);
        static Driver zho = new("Zhou Guanyu", 22, "Zhou", "Guanyu", "ZHO", "China", "chinese", 78, 84, 78, 52, 0, 0, 0);
        static Driver vet = new("Sebastian Vettel", 34, "Sebastian", "Vettel", "VET", "Germany", "german", 82, 85, 82, 99, 0, 0, 0);
        static Driver str = new("Lance Stroll", 23, "Lance", "Stroll", "STR", "Canada", "canadian", 81, 83, 75, 62, 0, 0, 0);
        static Driver mag = new("Kevin Magnussen", 29, "Kevin", "Magnussen", "MAG", "Denmark", "danish", 80, 83, 82, 84, 0, 0, 0);
        static Driver msc = new("Mick Schumacher", 23, "Mick", "Schumacher", "MSC", "Germany", "german", 78, 72, 80, 60, 0, 0, 0);
        static Driver gas = new("Pierre Gasly", 26, "Pierre", "Gasly", "GAS", "France", "french", 72, 83, 80, 65, 0, 0, 0);
        static Driver tsu = new("Yuki Tsunoda", 21, "Yuki", "Tsunoda", "TSU", "Japan", "japanese", 80, 79, 80, 55, 0, 0, 0);
        static Driver alb = new("Alexander Albon", 26, "Alexander", "Albon", "ALB", "Thailand", "thai", 81, 84, 75, 68, 0, 0, 0);
        static Driver lat = new("Nicholas Latifi", 26, "Nicholas", "Latifi", "LAT", "Canada", "canadian", 67, 71, 73, 61, 0, 0, 0);

        static Track bahrain = new("Bahrain International Circuit", "BAHRAIN GRAND PRIX", "Sakhir, Bahrain", "Bahrain");
        static Track jeddah = new("Jeddah Corniche Circuit", "SAUDI ARABIAN GRAND PRIX", "Jeddah, Saudi Arabia", "Jeddah");
        static Track australia = new("Albert Park Circuit", "AUSTRALIAN GRAND PRIX", "Melbourne, Australia", "Australia");
        static Track imola = new("Autodromo Enzo e Dino Ferrari", "EMILIA-ROMAGNA GRAND PRIX", "Imola, Italy", "Imola");
        static Track miami = new("Miami International Autodrome", "MIAMI GRAND PRIX", "Miami, United States", "Miami");
        static Track spain = new("Circuit de Barcelona-Catalunya", "SPANISH GRAND PRIX", "Catalunya, Spain", "Spain");
        static Track monaco = new("Circuit de Monaco", "MONACO GRAND PRIX", "Monaco", "Monaco");
        static Track baku = new("Baku City Circuit", "AZERBAIJAN GRAND PRIX", "Baku, Azerbaijan", "Baku");
        static Track canada = new("Circuit Gilles-Villeneuve", "CANADIAN GRAND PRIX", "Montreal, Canada", "Canada");
        static Track silverstone = new("Silverstone Circuit", "BRITISH GRAND PRIX", "Silverstone, Great Britain", "Silverstone");
        static Track austria = new("Red Bull Ring", "AUSTRIAN GRAND PRIX", "Spielberg, Austria", "Austria");
        static Track paulricard = new("Circuit Paul Ricard", "FRENCH GRAND PRIX", "Le Castellet, France", "Paul Ricard");
        static Track hungaroring = new("Hungaroring", "HUNGARIAN GRAND PRIX", "Budapest, Hungary", "Hungaroring");
        static Track spa = new("Circuit de Spa-Francorchamps", "BELGIAN GRAND PRIX", "Spa-Francorchamps, Belgium", "Spa");
        static Track zandvoort = new("Circuit Zandvoort", "DUTCH GRAND PRIX", "Zandvoort, Netherlands", "Zandvoort");
        static Track monza = new("Autodromo Nazionale Monza", "ITALIAN GRAND PRIX", "Milan, Italy", "Monza");
        static Track singapore = new("Marina Bay Street Circuit", "SINGAPORE GRAND PRIX", "Singapore", "Singapore");
        static Track suzuka = new("Suzuka International Racing Course", "JAPANESE GRAND PRIX", "Suzuka, Japan", "Suzuka");
        static Track cota = new("Circuit of The Americas", "UNITED STATES GRAND PRIX", "Austin, United States", "Circuit of The Americas");
        static Track mexico = new("Autodromo Hermanos Rodriguez", "MEXICAN GRAND PRIX", "Mexico City", "Mexico City");
        static Track interlagos = new("Autodromo Jose Carlos Pace", "SÃO PAULO GRAND PRIX", "São Paulo, Brazil", "Interlagos");
        static Track abudhabi = new("Yas Marina Circuit", "ABU DHABI GRAND PRIX", "Abu Dhabi, United Arab Emirates", "Abu Dhabi");

        static Driver[] drivers = new[]
        {
            ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat
        };

        static Driver[] rdrivers = new[]
        {
            ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat
        };

        static Driver?[] resultdrivers = new[]
        {
            driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20
        };

        static Driver? driver1;
        static Driver? driver2;
        static Driver? driver3;
        static Driver? driver4;
        static Driver? driver5;
        static Driver? driver6;
        static Driver? driver7;
        static Driver? driver8;
        static Driver? driver9;
        static Driver? driver10;
        static Driver? driver11;
        static Driver? driver12;
        static Driver? driver13;
        static Driver? driver14;
        static Driver? driver15;
        static Driver? driver16;
        static Driver? driver17;
        static Driver? driver18;
        static Driver? driver19;
        static Driver? driver20;

        static Driver[]? chosendrivers;

        static Driver? currentdriver;

        public class DriverComparer : IComparer<Driver>
        {
            public int Compare(Driver x, Driver y)
            {
                return y.rating.CompareTo(x.rating);
            }
        }

        public class DStandingComparer : IComparer<Driver>
        {
            public int Compare(Driver x, Driver y)
            {
                return y.points.CompareTo(x.points);
            }
        }

        public class TStandingComparer : IComparer<Team>
        {
            public int Compare(Team x, Team y)
            {
                return y.points.CompareTo(x.points);
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(x, currentLineCursor);
        }

        public static void StopAutorun(object? sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Stopped");
            autorun = false;
        }

        public static void Randomizer()
        {
            for (int i = 0; i < 20; i++)
            {
                Random random = new();
                int rindex = random.Next(drivers.Length);
                rdrivers[i] = drivers[rindex];
                for (int y = rindex; y < drivers.Length - 1; y++)
                {
                    drivers[y] = drivers[y + 1];
                }
                Array.Resize(ref drivers, drivers.Length - 1);
            }

            driver1 = rdrivers[0];
            driver2 = rdrivers[1];
            driver3 = rdrivers[2];
            driver4 = rdrivers[3];
            driver5 = rdrivers[4];
            driver6 = rdrivers[5];
            driver7 = rdrivers[6];
            driver8 = rdrivers[7];
            driver9 = rdrivers[8];
            driver10 = rdrivers[9];
            driver11 = rdrivers[10];
            driver12 = rdrivers[11];
            driver13 = rdrivers[12];
            driver14 = rdrivers[13];
            driver15 = rdrivers[14];
            driver16 = rdrivers[15];
            driver17 = rdrivers[16];
            driver18 = rdrivers[17];
            driver19 = rdrivers[18];
            driver20 = rdrivers[19];

            driver1.seat = RedBull;
            driver2.seat = RedBull;
            driver3.seat = Ferrari;
            driver4.seat = Ferrari;
            driver5.seat = Mercedes;
            driver6.seat = Mercedes;
            driver7.seat = Alpine;
            driver8.seat = Alpine;
            driver9.seat = Mclaren;
            driver10.seat = Mclaren;
            driver11.seat = AlfaRomeo;
            driver12.seat = AlfaRomeo;
            driver13.seat = AstonMartin;
            driver14.seat = AstonMartin;
            driver15.seat = Haas;
            driver16.seat = Haas;
            driver17.seat = AlphaTauri;
            driver18.seat = AlphaTauri;
            driver19.seat = Williams;
            driver20.seat = Williams;

            chosendrivers = new[]
            {
                driver1,
                driver2,
                driver3,
                driver4,
                driver5,
                driver6,
                driver7,
                driver8,
                driver9,
                driver10,
                driver11,
                driver12,
                driver13,
                driver14,
                driver15,
                driver16,
                driver17,
                driver18,
                driver19,
                driver20
            };

            for (int i = 0; i < chosendrivers.Length; i++)
            {
                chosendrivers[i].color = chosenteams[i].color;
            }
        }

        public static void Race()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(racestart);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(startornext);
            if (autorun == true)
            {
                goto checkpoint;
            }
        fallback:
            ConsoleKeyInfo advance = Console.ReadKey(true);
            if (advance.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                goto checkpoint;
            }
            goto fallback;
        checkpoint:
            Racing();

            switch (CurrentRace)
            {
                case "Bahrain":
                    Results.Bahrain(chosenteams, chosendrivers);
                    currentgp = bahrain.gp;
                    break;
                case "Jeddah":
                    Results.Jeddah(chosenteams, chosendrivers);
                    currentgp = jeddah.gp;
                    break;
                case "Australia":
                    Results.Australia(chosenteams, chosendrivers);
                    currentgp = australia.gp;
                    break;
                case "Imola":
                    Results.Imola(chosenteams, chosendrivers);
                    currentgp = imola.gp;
                    break;
                case "Miami":
                    Results.Miami(chosenteams, chosendrivers);
                    currentgp = miami.gp;
                    break;
                case "Spain":
                    Results.Spain(chosenteams, chosendrivers);
                    currentgp = spain.gp;
                    break;
                case "Monaco":
                    Results.Monaco(chosenteams, chosendrivers);
                    currentgp = monaco.gp;
                    break;
                case "Baku":
                    Results.Baku(chosenteams, chosendrivers);
                    currentgp = baku.gp;
                    break;
                case "Canada":
                    Results.Canada(chosenteams, chosendrivers);
                    currentgp = canada.gp;
                    break;
                case "Silverstone":
                    Results.Silverstone(chosenteams, chosendrivers);
                    currentgp = silverstone.gp;
                    break;
                case "Austria":
                    Results.Austria(chosenteams, chosendrivers);
                    currentgp = austria.gp;
                    break;
                case "Paulricard":
                    Results.Paulricard(chosenteams, chosendrivers);
                    currentgp = paulricard.gp;
                    break;
                case "Hungaroring":
                    Results.Hungaroring(chosenteams, chosendrivers);
                    currentgp = hungaroring.gp;
                    break;
                case "Spa":
                    Results.Spa(chosenteams, chosendrivers);
                    currentgp = spa.gp;
                    break;
                case "Zandvoort":
                    Results.Zandvoort(chosenteams, chosendrivers);
                    currentgp = zandvoort.gp;
                    break;
                case "Monza":
                    Results.Monza(chosenteams, chosendrivers);
                    currentgp = monza.gp;
                    break;
                case "Singapore":
                    Results.Singapore(chosenteams, chosendrivers);
                    currentgp = singapore.gp;
                    break;
                case "Suzuka":
                    Results.Suzuka(chosenteams, chosendrivers);
                    currentgp = suzuka.gp;
                    break;
                case "Cota":
                    Results.Cota(chosenteams, chosendrivers);
                    currentgp = cota.gp;
                    break;
                case "Mexico":
                    Results.Mexico(chosenteams, chosendrivers);
                    currentgp = mexico.gp;
                    break;
                case "Interlagos":
                    Results.Interlagos(chosenteams, chosendrivers);
                    currentgp = interlagos.gp;
                    break;
                case "Abudhabi":
                    Results.Abudhabi(chosenteams, chosendrivers);
                    currentgp = abudhabi.gp;
                    break;
            }

            resulttitle = currentrace;

            Result();

            if (autorun == false)
            {
                Thread.Sleep(2000);
            }
        checkpoint2:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Use commands or press 'Enter' to exit race weekend.");
            if (autorun == true)
            {
                goto endresults;
            }
        fallback2:
            ConsoleKeyInfo advance2 = Console.ReadKey(true);
            if (advance2.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Help();
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                CommandMode();
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.Enter)
            {
                goto endresults;
            }
            goto fallback2;

        endresults:
            Console.SetCursorPosition(x, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
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
            for (int i = 0; i < 3; i++)
            {
                if (autorun == false)
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
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine();
                }
            }
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
            for (int i = 0; i < 4; i++)
            {
                if (autorun == false)
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
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine();
                }
            }
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
            for (int i = 0; i < 4; i++)
            {
                if (autorun == false)
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
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine();
                }
            }
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
            for (int i = 0; i < 3; i++)
            {
                if (autorun == false)
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
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine();
                }
            }
            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine();
        }

        public static void Result()
        {
            Array.Sort(resultdrivers, new DriverComparer());

            Team[] resultteams = new[]
            {
                resultdrivers[0].seat,
                resultdrivers[1].seat,
                resultdrivers[2].seat,
                resultdrivers[3].seat,
                resultdrivers[4].seat,
                resultdrivers[5].seat,
                resultdrivers[6].seat,
                resultdrivers[7].seat,
                resultdrivers[8].seat,
                resultdrivers[9].seat,
                resultdrivers[10].seat,
                resultdrivers[11].seat,
                resultdrivers[12].seat,
                resultdrivers[13].seat,
                resultdrivers[14].seat,
                resultdrivers[15].seat,
                resultdrivers[16].seat,
                resultdrivers[17].seat,
                resultdrivers[18].seat,
                resultdrivers[19].seat,
            }!;

            resultteams[0].wins = resultteams[0].wins + 1;

            resultteams[0].podiums = resultteams[0].podiums + 1;
            resultteams[1].podiums = resultteams[1].podiums + 1;
            resultteams[2].podiums = resultteams[2].podiums + 1;

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

            resultdrivers[0].wins = resultdrivers[0].wins + 1;

            resultdrivers[0].podiums = resultdrivers[0].podiums + 1;
            resultdrivers[1].podiums = resultdrivers[1].podiums + 1;
            resultdrivers[2].podiums = resultdrivers[2].podiums + 1;

            resultdrivers[0].points = resultdrivers[0].points + 25;
            resultdrivers[1].points = resultdrivers[1].points + 18;
            resultdrivers[2].points = resultdrivers[2].points + 15;
            resultdrivers[3].points = resultdrivers[3].points + 12;
            resultdrivers[4].points = resultdrivers[4].points + 10;
            resultdrivers[5].points = resultdrivers[5].points + 8;
            resultdrivers[6].points = resultdrivers[6].points + 6;
            resultdrivers[7].points = resultdrivers[7].points + 4;
            resultdrivers[8].points = resultdrivers[8].points + 2;
            resultdrivers[9].points = resultdrivers[9].points + 1;

            string[] t = new string[20];
            string[] u = new string[20];

            for (int i = 0; i < t.Length; i++)
            {
                t[i] = " ║ ";
                for (int y = 0; y < 16 - resultdrivers[i].name.Length; y++)
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
            Console.WriteLine(resultdrivers[0].color + resultdrivers[0].name + "\x1b[38;5;" + 15 + "m" + " wins the " + currentgp + "!");
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════╗" +
                          "\r\n║" + resulttitle + "║" +
                          "\r\n╠══════╦══════════════════╦══════════════╦═════╣" +
                          "\r\n║ Pos. ║      Driver      ║     Team     ║ Pts ║" +
                          "\r\n╠══════╬══════════════════╬══════════════╬═════╣" +
                          "\r\n║ P1   ║ " + resultdrivers[0].color + resultdrivers[0].name + "\x1b[38;5;" + 15 + "m" + t[0] + resultteams[0].color + resultteams[0].name + "\x1b[38;5;" + 15 + "m" + u[0] + "25  ║" +
                          "\r\n║ P2   ║ " + resultdrivers[1].color + resultdrivers[1].name + "\x1b[38;5;" + 15 + "m" + t[1] + resultteams[1].color + resultteams[1].name + "\x1b[38;5;" + 15 + "m" + u[1] + "18  ║" +
                          "\r\n║ P3   ║ " + resultdrivers[2].color + resultdrivers[2].name + "\x1b[38;5;" + 15 + "m" + t[2] + resultteams[2].color + resultteams[2].name + "\x1b[38;5;" + 15 + "m" + u[2] + "15  ║" +
                          "\r\n║ P4   ║ " + resultdrivers[3].color + resultdrivers[3].name + "\x1b[38;5;" + 15 + "m" + t[3] + resultteams[3].color + resultteams[3].name + "\x1b[38;5;" + 15 + "m" + u[3] + "12  ║" +
                          "\r\n║ P5   ║ " + resultdrivers[4].color + resultdrivers[4].name + "\x1b[38;5;" + 15 + "m" + t[4] + resultteams[4].color + resultteams[4].name + "\x1b[38;5;" + 15 + "m" + u[4] + "10  ║" +
                          "\r\n║ P6   ║ " + resultdrivers[5].color + resultdrivers[5].name + "\x1b[38;5;" + 15 + "m" + t[5] + resultteams[5].color + resultteams[5].name + "\x1b[38;5;" + 15 + "m" + u[5] + "8   ║" +
                          "\r\n║ P7   ║ " + resultdrivers[6].color + resultdrivers[6].name + "\x1b[38;5;" + 15 + "m" + t[6] + resultteams[6].color + resultteams[6].name + "\x1b[38;5;" + 15 + "m" + u[6] + "6   ║" +
                          "\r\n║ P8   ║ " + resultdrivers[7].color + resultdrivers[7].name + "\x1b[38;5;" + 15 + "m" + t[7] + resultteams[7].color + resultteams[7].name + "\x1b[38;5;" + 15 + "m" + u[7] + "4   ║" +
                          "\r\n║ P9   ║ " + resultdrivers[8].color + resultdrivers[8].name + "\x1b[38;5;" + 15 + "m" + t[8] + resultteams[8].color + resultteams[8].name + "\x1b[38;5;" + 15 + "m" + u[8] + "2   ║" +
                          "\r\n║ P10  ║ " + resultdrivers[9].color + resultdrivers[9].name + "\x1b[38;5;" + 15 + "m" + t[9] + resultteams[9].color + resultteams[9].name + "\x1b[38;5;" + 15 + "m" + u[9] + "1   ║" +
                          "\r\n║ P11  ║ " + resultdrivers[10].color + resultdrivers[10].name + "\x1b[38;5;" + 15 + "m" + t[10] + resultteams[10].color + resultteams[10].name + "\x1b[38;5;" + 15 + "m" + u[10] + "0   ║" +
                          "\r\n║ P12  ║ " + resultdrivers[11].color + resultdrivers[11].name + "\x1b[38;5;" + 15 + "m" + t[11] + resultteams[11].color + resultteams[11].name + "\x1b[38;5;" + 15 + "m" + u[11] + "0   ║" +
                          "\r\n║ P13  ║ " + resultdrivers[12].color + resultdrivers[12].name + "\x1b[38;5;" + 15 + "m" + t[12] + resultteams[12].color + resultteams[12].name + "\x1b[38;5;" + 15 + "m" + u[12] + "0   ║" +
                          "\r\n║ P14  ║ " + resultdrivers[13].color + resultdrivers[13].name + "\x1b[38;5;" + 15 + "m" + t[13] + resultteams[13].color + resultteams[13].name + "\x1b[38;5;" + 15 + "m" + u[13] + "0   ║" +
                          "\r\n║ P15  ║ " + resultdrivers[14].color + resultdrivers[14].name + "\x1b[38;5;" + 15 + "m" + t[14] + resultteams[14].color + resultteams[14].name + "\x1b[38;5;" + 15 + "m" + u[14] + "0   ║" +
                          "\r\n║ P16  ║ " + resultdrivers[15].color + resultdrivers[15].name + "\x1b[38;5;" + 15 + "m" + t[15] + resultteams[15].color + resultteams[15].name + "\x1b[38;5;" + 15 + "m" + u[15] + "0   ║" +
                          "\r\n║ P17  ║ " + resultdrivers[16].color + resultdrivers[16].name + "\x1b[38;5;" + 15 + "m" + t[16] + resultteams[16].color + resultteams[16].name + "\x1b[38;5;" + 15 + "m" + u[16] + "0   ║" +
                          "\r\n║ P18  ║ " + resultdrivers[17].color + resultdrivers[17].name + "\x1b[38;5;" + 15 + "m" + t[17] + resultteams[17].color + resultteams[17].name + "\x1b[38;5;" + 15 + "m" + u[17] + "0   ║" +
                          "\r\n║ P19  ║ " + resultdrivers[18].color + resultdrivers[18].name + "\x1b[38;5;" + 15 + "m" + t[18] + resultteams[18].color + resultteams[18].name + "\x1b[38;5;" + 15 + "m" + u[18] + "0   ║" +
                          "\r\n║ P20  ║ " + resultdrivers[19].color + resultdrivers[19].name + "\x1b[38;5;" + 15 + "m" + t[19] + resultteams[19].color + resultteams[19].name + "\x1b[38;5;" + 15 + "m" + u[19] + "0   ║" +
                          "\r\n╚══════╩══════════════════╩══════════════╩═════╝");
        }

        static void Main()
        {
            Console.Title = "Formula 1 Simulator";
            Console.CancelKeyPress += new ConsoleCancelEventHandler(StopAutorun);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (string ln in intro)
            Console.WriteLine(ln);
            Console.WriteLine();
            Console.WriteLine();
            foreach (string ln in image)
            Console.WriteLine(ln);
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

        checkpoint1:
            Console.WriteLine("Start new season...");
        fallback1:
            ConsoleKeyInfo advance = Console.ReadKey(true);
            if (advance.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Help();
                goto checkpoint1;
            }
            else if (advance.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                CommandMode();
                goto checkpoint1;
            }
            else if (advance.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                goto seasonstart;
            }
            goto fallback1;

        seasonstart:
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Initializing new season");
            x = 23;
            for (int i = 0; i < 10; i++)
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
            if (autorun == false)
            {
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Winter break is over and the first round of the Formula 1 2023 season is just around the corner.");
                Thread.Sleep(400);
                Console.WriteLine("As the teams are preparing to unveil this years cars, lets take a look at the new grid lineup in the paddock.");
                Thread.Sleep(400);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Winter break is over and the first round of the Formula 1 2023 season is just around the corner.");
                Console.WriteLine("As the teams are preparing to unveil this years cars, lets take a look at the new grid lineup in the paddock.");
            }
        checkpoint2:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Go trough new grid...");
            if (autorun == true)
            {
                goto grid1;
            }
        fallback2:
            ConsoleKeyInfo advance2 = Console.ReadKey(true);
            if (advance2.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Help();
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                CommandMode();
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                goto grid1;
            }
            goto fallback2;

        grid1:
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out int mode);
            SetConsoleMode(handle, mode | 0x4);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\x1b[38;5;" + 4 + "m" + car1.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" has signed ");
            Console.Write("\x1b[38;5;" + 4 + "m" + driver1!.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 4 + "m" + driver2!.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" for the upcoming season.");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid2;
            }
        fallback3:
            ConsoleKeyInfo advance3 = Console.ReadKey(true);
            if (advance3.Key == ConsoleKey.Enter)
            {
                goto grid2;
            }
            goto fallback3;

        grid2:
            Console.Write("Meanwhile, " + car3.principal + " has chosen ");
            Console.Write("\x1b[38;5;" + 196 + "m" + driver3.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 196 + "m" + driver4.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" to drive for the " + car3.hq + " based team.");
            Console.Write("I am very excited to drive for ");
            Console.Write("\x1b[38;5;" + 196 + "m" + car3.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(", says " + driver4.lastname + " in an interview.");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid3;
            }
        fallback4:
            ConsoleKeyInfo advance4 = Console.ReadKey(true);
            if (advance4.Key == ConsoleKey.Enter)
            {
                goto grid3;
            }
            goto fallback4;

        grid3:
            Console.Write("\x1b[38;5;" + 50 + "m" + driver5.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 50 + "m" + driver6.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" will be driving for ");
            Console.Write("\x1b[38;5;" + 50 + "m" + car5.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid4;
            }
        fallback5:
            ConsoleKeyInfo advance5 = Console.ReadKey(true);
            if (advance5.Key == ConsoleKey.Enter)
            {
                goto grid4;
            }
            goto fallback5;

        grid4:
            Console.Write("\x1b[38;5;" + 39 + "m" + car7.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" principal " + car7.principal + " is reported to have held negotiations with several drivers.");
            Console.Write("The team have settled for ");
            Console.Write("\x1b[38;5;" + 39 + "m" + driver7.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 39 + "m" + driver8.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid5;
            }
        fallback6:
            ConsoleKeyInfo advance6 = Console.ReadKey(true);
            if (advance6.Key == ConsoleKey.Enter)
            {
                goto grid5;
            }
            goto fallback6;

        grid5:
            Console.Write("\x1b[38;5;" + 208 + "m" + car9.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" has surprised the whole paddock by signing ");
            Console.Write("\x1b[38;5;" + 208 + "m" + driver9.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 208 + "m" + driver10.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid6;
            }
        fallback7:
            ConsoleKeyInfo advance7 = Console.ReadKey(true);
            if (advance7.Key == ConsoleKey.Enter)
            {
                goto grid6;
            }
            goto fallback7;

        grid6:
            Console.Write("\x1b[38;5;" + 124 + "m" + driver11.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(", who says he has never driven for " + car11.prefix + " team before will be the first driver for ");
            Console.Write("\x1b[38;5;" + 124 + "m" + car11.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(". He will be accompanied by ");
            Console.Write("\x1b[38;5;" + 124 + "m" + driver12.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid7;
            }
        fallback8:
            ConsoleKeyInfo advance8 = Console.ReadKey(true);
            if (advance8.Key == ConsoleKey.Enter)
            {
                goto grid7;
            }
            goto fallback8;

        grid7:
            Console.Write("\x1b[38;5;" + 30 + "m" + car13.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" chooses ");
            Console.Write("\x1b[38;5;" + 30 + "m" + driver13.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 30 + "m" + driver14.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" for their lineup.");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid8;
            }
        fallback9:
            ConsoleKeyInfo advance9 = Console.ReadKey(true);
            if (advance9.Key == ConsoleKey.Enter)
            {
                goto grid8;
            }
            goto fallback9;

        grid8:
            Console.Write("Initial reports suggested that " + driver5.name + " would drive for ");
            Console.Write("\x1b[38;5;" + 11 + "m" + car15.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" this season. ");
            Console.Write("However it seems that " + car15.principal + " had something else in mind, as he signed ");
            Console.Write("\x1b[38;5;" + 11 + "m" + driver15.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" along with ");
            Console.Write("\x1b[38;5;" + 11 + "m" + driver16.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid9;
            }
        fallback10:
            ConsoleKeyInfo advance10 = Console.ReadKey(true);
            if (advance10.Key == ConsoleKey.Enter)
            {
                goto grid9;
            }
            goto fallback10;

        grid9:
            Console.Write("\x1b[38;5;" + 240 + "m" + car17.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" signs ");
            Console.Write("\x1b[38;5;" + 240 + "m" + driver17.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 240 + "m" + driver18.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            Console.WriteLine();
            if (autorun == true)
            {
                goto grid10;
            }
        fallback11:
            ConsoleKeyInfo advance11 = Console.ReadKey(true);
            if (advance11.Key == ConsoleKey.Enter)
            {
                goto grid10;
            }
            goto fallback11;

        grid10:
            Console.Write("And finally, ");
            Console.Write("\x1b[38;5;" + 26 + "m" + car19.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" has landed on the decision to involve ");
            Console.Write("\x1b[38;5;" + 26 + "m" + driver19.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 26 + "m" + driver20.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" in this years lineup.");
            if (autorun == false)
            {
                Thread.Sleep(1000);
            }

            grid = true;
            specs = true;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now that the teams have annouced their lineups and unveiled their cars, it's time for Formula 1 2023!");
        checkpoint3:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Go to first race...");
            if (autorun == true)
            {
                goto races;
            }
        fallback12:
            ConsoleKeyInfo advance12 = Console.ReadKey(true);
            if (advance12.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Help();
                goto checkpoint3;
            }
            else if (advance12.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                CommandMode();
                goto checkpoint3;
            }
            else if (advance12.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                goto races;
            }
            goto fallback12;
        races:

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

            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("Season finished!");
            Console.ReadLine();
        }

        public static void GameLoop()
        {
            Randomizer();

            if (gameFinished == true)
            {
                goto finnishGame;
            }
            GameLoop();
        finnishGame:
            Console.WriteLine("Thank you for playing Formula 1 Simulator!");
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
            Console.WriteLine("'(driver)' or '(team)' to find stats and info on a certain driver or team");
            Console.WriteLine("'clear' - clears up the console so you can stay focused on the present!");
            Console.Write("'autorun' - let the simulation run continuosly, press 'Ctrl' + 'C' to stop");
        }

        public static void CommandMode()
        {
            static void TeamMode(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
                Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
                Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
                Driver[] drivers, Driver[] rdrivers,
                Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
                Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20,
                Team[] chosenteams, Driver[] chosendrivers, Team currentteam, Driver currentdriver)
            {
                bool loop = true;

                Console.ForegroundColor = ConsoleColor.Green;
            checkpoint2:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("What do you wish to learn about " + currentteam.name + "?");
            fallback2:
                ConsoleKeyInfo cmd = Console.ReadKey(true);
                if (cmd.Key == ConsoleKey.Backspace)
                {
                    loop = false;
                    goto endcmd2;
                }
                else if (cmd.Key == ConsoleKey.Enter)
                {
                    goto entercmd2;
                }
                else if (cmd.Key == ConsoleKey.H)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Valid commands here are:");
                    Console.WriteLine("'info' - to learn more about them");
                    Console.WriteLine("'ratings' - displays the overall and in depth ratings of this teams car");
                    Console.WriteLine("'stats' - shows accumulated statistics since the season start");
                    Console.WriteLine("'Backspace' - to return to general command mode");
                    goto checkpoint2;
                }
                goto fallback2;

            entercmd2:
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
                    TeamMode(eRedBull, eFerrari, eMercedes, eRenault,
                        RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                        ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                        drivers, rdrivers,
                        car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                        driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                        chosenteams, chosendrivers, currentteam, currentdriver);
                }
                else
                {
                    Console.WriteLine("Returned to command mode");
                }
            }

            static void DriverMode(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
                Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
                Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
                Driver[] drivers, Driver[] rdrivers,
                Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
                Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20,
                Team[] chosenteams, Driver[] chosendrivers, Team currentteam, Driver currentdriver)
            {
                bool loop = true;

                Console.ForegroundColor = ConsoleColor.Green;
            checkpoint3:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("What do you want to find out about " + currentdriver.name + "?");
            fallback3:
                ConsoleKeyInfo cmd = Console.ReadKey(true);
                if (cmd.Key == ConsoleKey.Backspace)
                {
                    loop = false;
                    goto endcmd3;
                }
                else if (cmd.Key == ConsoleKey.Enter)
                {
                    goto entercmd3;
                }
                else if (cmd.Key == ConsoleKey.H)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Valid commands here are:");
                    Console.WriteLine("'info' - to learn more about him");
                    Console.WriteLine("'ratings' - displays the drivers overall and other detailed ratings");
                    Console.WriteLine("'stats' - shows different statistics since the season start");
                    Console.WriteLine("'Backspace' - to return to general command mode");
                    goto checkpoint3;
                }
                goto fallback3;

            entercmd3:
                Console.Write(">");
                string input = Console.ReadLine()!;
                Console.ForegroundColor = ConsoleColor.White;
                if (input.ToLower() == "info")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(currentdriver.name + " is a " + currentdriver.prefix + " Formula 1 driver.");
                    Console.WriteLine("He is " + currentdriver.age + " years of age.");
                    //andra alternativ när probabilites är fixat (50% chans till första 50% chans till denna): Console.WriteLine(currentdriver.name + " is a " + currentdriver.age + " year old Formula 1 driver from " + currentdriver.nationality);
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
                    DriverMode(eRedBull, eFerrari, eMercedes, eRenault,
                        RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                        ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                        drivers, rdrivers,
                        car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                        driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                        chosenteams, chosendrivers, currentteam, currentdriver);
                }
                else
                {
                    Console.WriteLine("Returned to command mode");
                }
            }

            bool loop = true;

            Console.ForegroundColor = ConsoleColor.Green;
        checkpoint1:
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to enter a command or 'Backspace' to exit command mode:");
        fallback1:
            ConsoleKeyInfo cmd = Console.ReadKey(true);
            if (cmd.Key == ConsoleKey.Backspace)
            {
                loop = false;
                goto endcmd1;
            }
            else if (cmd.Key == ConsoleKey.Enter)
            {
                goto entercmd1;
            }
            else if (cmd.Key == ConsoleKey.H)
            {
                Help();
                goto checkpoint1;
            }
            goto fallback1;

        entercmd1:
            Console.Write(">");
            string input = Console.ReadLine()!;
            for (int i = 0; i < 20; i++)
            {
                if (input.ToLower() == chosendrivers[i].name.ToString().ToLower() || input.ToLower() == chosendrivers[i].firstname.ToString().ToLower() || input.ToLower() == chosendrivers[i].lastname.ToString().ToLower() || input.ToLower() == chosendrivers[i].shortname.ToString().ToLower())
                {
                    currentdriver = chosendrivers[i];
                    DriverMode(eRedBull, eFerrari, eMercedes, eRenault,
                        RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                        ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                        drivers, rdrivers,
                        car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                        driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                        chosenteams, chosendrivers, currentteam, currentdriver);
                    goto checkpoint1;
                }
                else if (input.ToLower() == chosenteams[i].name.ToString().ToLower())
                {
                    currentteam = chosenteams[i];
                    TeamMode(eRedBull, eFerrari, eMercedes, eRenault,
                        RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                        ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                        drivers, rdrivers,
                        car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                        driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                        chosenteams, chosendrivers, currentteam, currentdriver);
                    goto checkpoint1;
                }
            }
            if (input.ToLower() == "autorun")
            {
                Console.WriteLine("The game will now run automatically, press 'Ctrl' + 'C' to stop");
                autorun = true;
            }
            else if (input == "test")
            {
                Console.WriteLine(autorun.ToString());
            }
            else if (input.ToLower() == "grid")
            {
                if (grid == true)
                {
                    string[] t = new string[20];

                    for (int i = 0; i < t.Length; i++)
                    {
                        t[i] = " ║ ";
                        for (int y = 0; y < 16 - chosendrivers[i].name.Length; y++)
                        {
                            t[i] = " " + t[i];
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("╔═════════════════════════════════════════════════════════════════════╗" +
                                  "\r\n║                         Current grid lineup                         ║" +
                                  "\r\n╠═══════════════════════════════╦══════════════════╦══════════════════╣" +
                                  "\r\n║             Team              ║    1st Driver    ║    2nd Driver    ║" +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 4 + "m" + "Oracle Red Bull Racing" + "\x1b[38;5;" + 15 + "m" + "        ║ " + "\x1b[38;5;" + 4 + "m" + driver1.name + "\x1b[38;5;" + 15 + "m" + t[0] + "\x1b[38;5;" + 4 + "m" + driver2.name + "\x1b[38;5;" + 15 + "m" + t[1] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 196 + "m" + "Scuderia Ferrari" + "\x1b[38;5;" + 15 + "m" + "              ║ " + "\x1b[38;5;" + 196 + "m" + driver3.name + "\x1b[38;5;" + 15 + "m" + t[2] + "\x1b[38;5;" + 196 + "m" + driver4.name + "\x1b[38;5;" + 15 + "m" + t[3] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 50 + "m" + "Mercedes-AMG Petronas" + "\x1b[38;5;" + 15 + "m" + "         ║ " + "\x1b[38;5;" + 50 + "m" + driver5.name + "\x1b[38;5;" + 15 + "m" + t[4] + "\x1b[38;5;" + 50 + "m" + driver6.name + "\x1b[38;5;" + 15 + "m" + t[5] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 39 + "m" + "BWT Alpine" + "\x1b[38;5;" + 15 + "m" + "                    ║ " + "\x1b[38;5;" + 39 + "m" + driver7.name + "\x1b[38;5;" + 15 + "m" + t[6] + "\x1b[38;5;" + 39 + "m" + driver8.name + "\x1b[38;5;" + 15 + "m" + t[7] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 208 + "m" + "McLaren" + "\x1b[38;5;" + 15 + "m" + "                       ║ " + "\x1b[38;5;" + 208 + "m" + driver9.name + "\x1b[38;5;" + 15 + "m" + t[8] + "\x1b[38;5;" + 208 + "m" + driver10.name + "\x1b[38;5;" + 15 + "m" + t[9] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 124 + "m" + "Alfa Romeo Orlen" + "\x1b[38;5;" + 15 + "m" + "              ║ " + "\x1b[38;5;" + 124 + "m" + driver11.name + "\x1b[38;5;" + 15 + "m" + t[10] + "\x1b[38;5;" + 124 + "m" + driver12.name + "\x1b[38;5;" + 15 + "m" + t[11] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 30 + "m" + "Aston Martin Aramco Cognizant" + "\x1b[38;5;" + 15 + "m" + " ║ " + "\x1b[38;5;" + 30 + "m" + driver13.name + "\x1b[38;5;" + 15 + "m" + t[12] + "\x1b[38;5;" + 30 + "m" + driver14.name + "\x1b[38;5;" + 15 + "m" + t[13] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 11 + "m" + "Haas" + "\x1b[38;5;" + 15 + "m" + "                          ║ " + "\x1b[38;5;" + 11 + "m" + driver15.name + "\x1b[38;5;" + 15 + "m" + t[14] + "\x1b[38;5;" + 11 + "m" + driver16.name + "\x1b[38;5;" + 15 + "m" + t[15] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 240 + "m" + "Scuderia AlphaTauri" + "\x1b[38;5;" + 15 + "m" + "           ║ " + "\x1b[38;5;" + 240 + "m" + driver17.name + "\x1b[38;5;" + 15 + "m" + t[16] + "\x1b[38;5;" + 240 + "m" + driver18.name + "\x1b[38;5;" + 15 + "m" + t[17] +
                                  "\r\n╠═══════════════════════════════╬══════════════════╬══════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 26 + "m" + "Williams Racing" + "\x1b[38;5;" + 15 + "m" + "               ║ " + "\x1b[38;5;" + 26 + "m" + driver19.name + "\x1b[38;5;" + 15 + "m" + t[18] + "\x1b[38;5;" + 26 + "m" + driver20.name + "\x1b[38;5;" + 15 + "m" + t[19] +
                                  "\r\n╚═══════════════════════════════╩══════════════════╩══════════════════╝");
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
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("╔═══════════════════════════════════════════════╗" +
                                  "\r\n║            Technical specifications           ║" +
                                  "\r\n╠══════════════╦═════════╦══════════════════════╣" +
                                  "\r\n║     Team     ║ Chassis ║      Power unit      ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 4 + "m" + "Red Bull" + "\x1b[38;5;" + 15 + "m" + "     ║ " + "\x1b[38;5;" + 4 + "m" + "RB18" + "\x1b[38;5;" + 15 + "m" + "    ║ " + "\x1b[38;5;" + 4 + "m" + "Red Bull Powertrains" + "\x1b[38;5;" + 15 + "m" + " ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 196 + "m" + "Ferrari" + "\x1b[38;5;" + 15 + "m" + "      ║ " + "\x1b[38;5;" + 196 + "m" + "F1-75" + "\x1b[38;5;" + 15 + "m" + "   ║ " + "\x1b[38;5;" + 196 + "m" + "Ferrari" + "\x1b[38;5;" + 15 + "m" + "              ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 50 + "m" + "Mercedes" + "\x1b[38;5;" + 15 + "m" + "     ║ " + "\x1b[38;5;" + 50 + "m" + "W13" + "\x1b[38;5;" + 15 + "m" + "     ║ " + "\x1b[38;5;" + 50 + "m" + "Mercedes" + "\x1b[38;5;" + 15 + "m" + "             ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 39 + "m" + "Alpine" + "\x1b[38;5;" + 15 + "m" + "       ║ " + "\x1b[38;5;" + 39 + "m" + "A522" + "\x1b[38;5;" + 15 + "m" + "    ║ " + "\x1b[38;5;" + 39 + "m" + "Renault" + "\x1b[38;5;" + 15 + "m" + "              ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 208 + "m" + "McLaren" + "\x1b[38;5;" + 15 + "m" + "      ║ " + "\x1b[38;5;" + 208 + "m" + "MCL36" + "\x1b[38;5;" + 15 + "m" + "   ║ " + "\x1b[38;5;" + 50 + "m" + "Mercedes" + "\x1b[38;5;" + 15 + "m" + "             ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 124 + "m" + "Alfa Romeo" + "\x1b[38;5;" + 15 + "m" + "   ║ " + "\x1b[38;5;" + 124 + "m" + "C41" + "\x1b[38;5;" + 15 + "m" + "     ║ " + "\x1b[38;5;" + 196 + "m" + "Ferrari" + "\x1b[38;5;" + 15 + "m" + "              ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 30 + "m" + "Aston Martin" + "\x1b[38;5;" + 15 + "m" + " ║ " + "\x1b[38;5;" + 30 + "m" + "AMR22" + "\x1b[38;5;" + 15 + "m" + "   ║ " + "\x1b[38;5;" + 50 + "m" + "Mercedes" + "\x1b[38;5;" + 15 + "m" + "             ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 11 + "m" + "Haas" + "\x1b[38;5;" + 15 + "m" + "         ║ " + "\x1b[38;5;" + 11 + "m" + "VF-22" + "\x1b[38;5;" + 15 + "m" + "   ║ " + "\x1b[38;5;" + 196 + "m" + "Ferrari" + "\x1b[38;5;" + 15 + "m" + "              ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 240 + "m" + "AlphaTauri" + "\x1b[38;5;" + 15 + "m" + "   ║ " + "\x1b[38;5;" + 240 + "m" + "AT03" + "\x1b[38;5;" + 15 + "m" + "    ║ " + "\x1b[38;5;" + 21 + "m" + "Red Bull Powertrains" + "\x1b[38;5;" + 15 + "m" + " ║" +
                                  "\r\n╠══════════════╬═════════╬══════════════════════╣" +
                                  "\r\n║ " + "\x1b[38;5;" + 26 + "m" + "Williams" + "\x1b[38;5;" + 15 + "m" + "     ║ " + "\x1b[38;5;" + 26 + "m" + "FW44" + "\x1b[38;5;" + 15 + "m" + "    ║ " + "\x1b[38;5;" + 50 + "m" + "Mercedes" + "\x1b[38;5;" + 15 + "m" + "             ║" +
                                  "\r\n╚══════════════╩═════════╩══════════════════════╝");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The teams haven't announced this years cars yet!");
                }
            }
            else if (input.ToLower() == "driver standings")
            {
                Driver[] standingdrivers = new[]
                {
                    driver1,
                    driver2,
                    driver3,
                    driver4,
                    driver5,
                    driver6,
                    driver7,
                    driver8,
                    driver9,
                    driver10,
                    driver11,
                    driver12,
                    driver13,
                    driver14,
                    driver15,
                    driver16,
                    driver17,
                    driver18,
                    driver19,
                    driver20
                };

                Array.Sort(standingdrivers, new DStandingComparer());

                string[] t = new string[20];
                string[] u = new string[20];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = " ║ ";
                    for (int y = 0; y < 16 - standingdrivers[i].name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    u[i] = " ║ ";
                    for (int y = 0; y < 3 - standingdrivers[i].points.ToString().Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("╔═════════════════════════════════╗" +
                              "\r\n║     F1 Drivers Championship     ║" +
                              "\r\n╠════════╦══════════════════╦═════╣" +
                              "\r\n║ Pos.   ║      Driver      ║ Pts ║" +
                              "\r\n╠════════╬══════════════════╬═════╣" +
                              "\r\n║ Leader ║ " + standingdrivers[0].color + standingdrivers[0].name + "\x1b[38;5;" + 15 + "m" + t[0] + standingdrivers[0].points + u[0] +
                              "\r\n║ P2     ║ " + standingdrivers[1].color + standingdrivers[1].name + "\x1b[38;5;" + 15 + "m" + t[1] + standingdrivers[1].points + u[1] +
                              "\r\n║ P3     ║ " + standingdrivers[2].color + standingdrivers[2].name + "\x1b[38;5;" + 15 + "m" + t[2] + standingdrivers[2].points + u[2] +
                              "\r\n║ P4     ║ " + standingdrivers[3].color + standingdrivers[3].name + "\x1b[38;5;" + 15 + "m" + t[3] + standingdrivers[3].points + u[3] +
                              "\r\n║ P5     ║ " + standingdrivers[4].color + standingdrivers[4].name + "\x1b[38;5;" + 15 + "m" + t[4] + standingdrivers[4].points + u[4] +
                              "\r\n║ P6     ║ " + standingdrivers[5].color + standingdrivers[5].name + "\x1b[38;5;" + 15 + "m" + t[5] + standingdrivers[5].points + u[5] +
                              "\r\n║ P7     ║ " + standingdrivers[6].color + standingdrivers[6].name + "\x1b[38;5;" + 15 + "m" + t[6] + standingdrivers[6].points + u[6] +
                              "\r\n║ P8     ║ " + standingdrivers[7].color + standingdrivers[7].name + "\x1b[38;5;" + 15 + "m" + t[7] + standingdrivers[7].points + u[7] +
                              "\r\n║ P9     ║ " + standingdrivers[8].color + standingdrivers[8].name + "\x1b[38;5;" + 15 + "m" + t[8] + standingdrivers[8].points + u[8] +
                              "\r\n║ P10    ║ " + standingdrivers[9].color + standingdrivers[9].name + "\x1b[38;5;" + 15 + "m" + t[9] + standingdrivers[9].points + u[9] +
                              "\r\n║ P11    ║ " + standingdrivers[10].color + standingdrivers[10].name + "\x1b[38;5;" + 15 + "m" + t[10] + standingdrivers[10].points + u[10] +
                              "\r\n║ P12    ║ " + standingdrivers[11].color + standingdrivers[11].name + "\x1b[38;5;" + 15 + "m" + t[11] + standingdrivers[11].points + u[11] +
                              "\r\n║ P13    ║ " + standingdrivers[12].color + standingdrivers[12].name + "\x1b[38;5;" + 15 + "m" + t[12] + standingdrivers[12].points + u[12] +
                              "\r\n║ P14    ║ " + standingdrivers[13].color + standingdrivers[13].name + "\x1b[38;5;" + 15 + "m" + t[13] + standingdrivers[13].points + u[13] +
                              "\r\n║ P15    ║ " + standingdrivers[14].color + standingdrivers[14].name + "\x1b[38;5;" + 15 + "m" + t[14] + standingdrivers[14].points + u[14] +
                              "\r\n║ P16    ║ " + standingdrivers[15].color + standingdrivers[15].name + "\x1b[38;5;" + 15 + "m" + t[15] + standingdrivers[15].points + u[15] +
                              "\r\n║ P17    ║ " + standingdrivers[16].color + standingdrivers[16].name + "\x1b[38;5;" + 15 + "m" + t[16] + standingdrivers[16].points + u[16] +
                              "\r\n║ P18    ║ " + standingdrivers[17].color + standingdrivers[17].name + "\x1b[38;5;" + 15 + "m" + t[17] + standingdrivers[17].points + u[17] +
                              "\r\n║ P19    ║ " + standingdrivers[18].color + standingdrivers[18].name + "\x1b[38;5;" + 15 + "m" + t[18] + standingdrivers[18].points + u[18] +
                              "\r\n║ P20    ║ " + standingdrivers[19].color + standingdrivers[19].name + "\x1b[38;5;" + 15 + "m" + t[19] + standingdrivers[19].points + u[19] +
                              "\r\n╚════════╩══════════════════╩═════╝");
                Console.WriteLine();
                Console.WriteLine();
            }
            else if (input.ToLower() == "team standings")
            {
                Team[] standingteams = new[]
                {
                    car1,
                    car3,
                    car5,
                    car7,
                    car9,
                    car11,
                    car13,
                    car15,
                    car17,
                    car19,
                };

                Array.Sort(standingteams, new TStandingComparer());

                string[] t = new string[10];
                string[] u = new string[10];

                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = "  ║ ";
                    for (int y = 0; y < 12 - standingteams[i].name.Length; y++)
                    {
                        t[i] = " " + t[i];
                    }
                }

                for (int i = 0; i < t.Length; i++)
                {
                    u[i] = " ║ ";
                    for (int y = 0; y < 3 - standingteams[i].points.ToString().Length; y++)
                    {
                        u[i] = " " + u[i];
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("╔══════════════════════════════╗" +
                              "\r\n║ F1 Constructors Championship ║" +
                              "\r\n╠════════╦═══════════════╦═════╣" +
                              "\r\n║ Pos.   ║     Team      ║ Pts ║" +
                              "\r\n╠════════╬═══════════════╬═════╣" +
                              "\r\n║ Leader ║ " + standingteams[0].color + standingteams[0].name + "\x1b[38;5;" + 15 + "m" + t[0] + standingteams[0].points + u[0] +
                              "\r\n║ P2     ║ " + standingteams[1].color + standingteams[1].name + "\x1b[38;5;" + 15 + "m" + t[1] + standingteams[1].points + u[1] +
                              "\r\n║ P3     ║ " + standingteams[2].color + standingteams[2].name + "\x1b[38;5;" + 15 + "m" + t[2] + standingteams[2].points + u[2] +
                              "\r\n║ P4     ║ " + standingteams[3].color + standingteams[3].name + "\x1b[38;5;" + 15 + "m" + t[3] + standingteams[3].points + u[3] +
                              "\r\n║ P5     ║ " + standingteams[4].color + standingteams[4].name + "\x1b[38;5;" + 15 + "m" + t[4] + standingteams[4].points + u[4] +
                              "\r\n║ P6     ║ " + standingteams[5].color + standingteams[5].name + "\x1b[38;5;" + 15 + "m" + t[5] + standingteams[5].points + u[5] +
                              "\r\n║ P7     ║ " + standingteams[6].color + standingteams[6].name + "\x1b[38;5;" + 15 + "m" + t[6] + standingteams[6].points + u[6] +
                              "\r\n║ P8     ║ " + standingteams[7].color + standingteams[7].name + "\x1b[38;5;" + 15 + "m" + t[7] + standingteams[7].points + u[7] +
                              "\r\n║ P9     ║ " + standingteams[8].color + standingteams[8].name + "\x1b[38;5;" + 15 + "m" + t[8] + standingteams[8].points + u[8] +
                              "\r\n║ P10    ║ " + standingteams[9].color + standingteams[9].name + "\x1b[38;5;" + 15 + "m" + t[9] + standingteams[9].points + u[9] +
                              "\r\n╚════════╩═══════════════╩═════╝");
                Console.WriteLine();
                Console.WriteLine();
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

        endcmd1:
            if (loop == true)
            {
                CommandMode();
            }
            else
            {
                Console.WriteLine("Exited command mode");
            }
        }
    }
}

//fortsätt med uppdelning och strukturering av programmet, göra så man kan köra flera seasons, ändra autorun till ett mode som kör en säsong i taget och ett mode som är typ lika men lite thread sleep iallafall för annars blev det för snabbt