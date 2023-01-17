using Meta;
using System.Runtime.InteropServices;

namespace Game
{
    class Program
    {
        static bool Autorun = false;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        public static void ClearCurrentConsoleLine(int x)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(x, currentLineCursor);
        }

        public class DriverComparer : IComparer<Driver>
        {
            public int Compare(Driver x, Driver y)
            {
                return y.rating.CompareTo(x.rating);
            }
        }

        public static void Racing(int x)
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
                if (Autorun == false)
                {
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                    Thread.Sleep(200);
                }
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                }
            }
            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine(x);
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
                if (Autorun == false)
                {
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                    Thread.Sleep(200);
                }
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                }
            }
            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine(x);
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
                if (Autorun == false)
                {
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                    Thread.Sleep(200);
                }
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                }
            }
            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine(x);
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
                if (Autorun == false)
                {
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(100);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                    Thread.Sleep(200);
                }
                else
                {
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.Write(" .");
                    Console.SetCursorPosition(x, Console.CursorTop);
                    ClearCurrentConsoleLine(x);
                }
            }
            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine(x);
        }

        public static void Result(Driver[] resultdrivers, string resulttitle, string currentgp)
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

        public static void Race(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
            Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
            Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
            Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
            string racestart, string startornext, string currentrace, string CurrentRace, int x, bool grid, bool specs, Team[] chosenteams, Driver[] chosendrivers, Team currentteam, Driver currentdriver, Driver[] drivers, Driver[] rdrivers,
            Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20,
            Track bahrain, Track jeddah, Track australia, Track imola, Track miami, Track spain, Track monaco, Track baku, Track canada, Track silverstone, Track austria, Track paulricard, Track hungaroring, Track spa, Track zandvoort, Track monza, Track singapore, Track suzuka, Track cota, Track mexico, Track interlagos, Track abudhabi)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(racestart);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(startornext);
            if (Autorun == true)
            {
                goto checkpoint;
            }
        fallback:
            ConsoleKeyInfo advance = Console.ReadKey(true);
            if (advance.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                goto checkpoint;
            }
            goto fallback;
        checkpoint:
            Racing(x);
            string currentgp = bahrain.gp;

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

            Driver[] resultdrivers = new[]
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

            string resulttitle = currentrace;

            Result(resultdrivers, resulttitle, currentgp);

            if (Autorun == false)
            {
                Thread.Sleep(2000);
            }
        checkpoint2:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Use commands or press 'Enter' to exit race weekend.");
            if (Autorun == true)
            {
                goto endresults;
            }
        fallback2:
            ConsoleKeyInfo advance2 = Console.ReadKey(true);
            if (advance2.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.Help();
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.CommandMode(eRedBull, eFerrari, eMercedes, eRenault,
                    RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                    ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                    drivers, rdrivers,
                    car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                    driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                    chosenteams, chosendrivers, currentteam, currentdriver,
                    grid, specs, Autorun);
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.Enter)
            {
                goto endresults;
            }
            goto fallback2;

        endresults:
            Console.SetCursorPosition(x, Console.CursorTop - 1);
            ClearCurrentConsoleLine(x);
        }

        public static void StopAutorun(object? sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Stopped");
            Autorun = false;
        }

        static void Main()
        {
            Console.Title = "Formula 1 Simulator";

            Console.CancelKeyPress += new ConsoleCancelEventHandler(StopAutorun);

            Engine eRedBull = new(90, 92);
            Engine eFerrari = new(95, 85);
            Engine eMercedes = new(85, 96);
            Engine eRenault = new(85, 85);

            Team RedBull = new("Red Bull", "Milton Keynes", 18, "Red Bull Powertrains", "an austrian", "Christian Horner", eRedBull.power, eRedBull.reliability, 93, 90, 95, 91, 0, 0, 0, "\x1b[38;5;" + 4 + "m");
            Team Ferrari = new("Ferrari", "Maranello", 93, "Ferrari", "an italian", "Mattia Binotto", eFerrari.power, eFerrari.reliability, 97, 95, 90, 88, 0, 0, 0, "\x1b[38;5;" + 196 + "m");
            Team Mercedes = new("Mercedes", "Brackley", 14, "Mercedes", "a german", "Toto Wolff", eMercedes.power, eMercedes.reliability, 89, 90, 86, 90, 0, 0, 0, "\x1b[38;5;" + 50 + "m");
            Team Alpine = new("Alpine", "Enstone", 26, "Renault", "a french", "Otmar Szafnauer", eRenault.power, eRenault.reliability, 86, 89, 87, 88, 0, 0, 0, "\x1b[38;5;" + 39 + "m");
            Team Mclaren = new("McLaren", "Woking", 56, "Mercedes", "a british", "Zak Brown", eMercedes.power, eMercedes.reliability, 80, 79, 83, 85, 0, 0, 0, "\x1b[38;5;" + 208 + "m");
            Team AlfaRomeo = new("Alfa Romeo", "Hinwil", 44, "Ferrari", "a swiss", "Frédéric Vasseur", eFerrari.power - 9, eFerrari.reliability, 78, 81, 75, 82, 0, 0, 0, "\x1b[38;5;" + 124 + "m");
            Team AstonMartin = new("Aston Martin", "Silverstone", 4, "Mercedes", "a british", "Mike Krack", eMercedes.power, eMercedes.reliability, 78, 80, 76, 78, 0, 0, 0, "\x1b[38;5;" + 30 + "m");
            Team Haas = new("Haas", "Kannapolis", 7, "Ferrari", "an american", "Günther Steiner", eFerrari.power - 9, eFerrari.reliability, 77, 76, 79, 85, 0, 0, 0, "\x1b[38;5;" + 11 + "m");
            Team AlphaTauri = new("AlphaTauri", "Faenza", 37, "Ferrari", "an italian", "Franz Tost", eRedBull.power - 9, eRedBull.reliability, 75, 74, 79, 78, 0, 0, 0, "\x1b[38;5;" + 240 + "m");
            Team Williams = new("Williams", "Wantage", 53, "Mercedes", "a british", "Jost Capito", eMercedes.power - 3, eMercedes.reliability, 68, 72, 98, 75, 0, 0, 0, "\x1b[38;5;" + 26 + "m");

            Driver ver = new("Max Verstappen", 24, "Max", "Verstappen", "VER", "the Netherlands", "dutch", 97, 92, 90, 78, 0, 0, 0);
            Driver per = new("Sergio Perez", 32, "Sergio", "Perez", "PER", "Mexicó", "mexican", 86, 89, 93, 88, 0, 0, 0);
            Driver lec = new("Charles Leclerc", 24, "Charles", "Leclerc", "LEC", "Monaco", "monegasque", 94, 85, 97, 71, 0, 0, 0);
            Driver sai = new("Carlos Sainz", 27, "Carlos", "Sainz", "SAI", "Spain", "spanish", 90, 83, 90, 79, 0, 0, 0);
            Driver ham = new("Lewis Hamilton", 37, "Lewis", "Hamilton", "HAM", "Great Britain", "british", 85, 92, 94, 95, 0, 0, 0);
            Driver rus = new("George Russell", 24, "George", "Russell", "RUS", "Great Britain", "british", 90, 90, 88, 66, 0, 0, 0);
            Driver alo = new("Fernando Alonso", 40, "Fernando", "Alonso", "ALO", "Spain", "spanish", 85, 91, 91, 99, 0, 0, 0);
            Driver oco = new("Esteban Ocon", 25, "Esteban", "Ocon", "OCO", "France", "french", 81, 84, 80, 65, 0, 0, 0);
            Driver nor = new("Lando Norris", 22, "Lando", "Norris", "NOR", "Great Britain", "british", 88, 82, 88, 67, 0, 0, 0);
            Driver ric = new("Daniel Ricciardo", 32, "Daniel", "Ricciardo", "RIC", "Australia", "australian", 78, 80, 89, 90, 0, 0, 0);
            Driver bot = new("Valterri Bottas", 32, "Valterri", "Bottas", "BOT", "Finland", "finnish", 83, 91, 75, 88, 0, 0, 0);
            Driver zho = new("Zhou Guanyu", 22, "Zhou", "Guanyu", "ZHO", "China", "chinese", 78, 84, 78, 52, 0, 0, 0);
            Driver vet = new("Sebastian Vettel", 34, "Sebastian", "Vettel", "VET", "Germany", "german", 82, 85, 82, 99, 0, 0, 0);
            Driver str = new("Lance Stroll", 23, "Lance", "Stroll", "STR", "Canada", "canadian", 81, 83, 75, 62, 0, 0, 0);
            Driver mag = new("Kevin Magnussen", 29, "Kevin", "Magnussen", "MAG", "Denmark", "danish", 80, 83, 82, 84, 0, 0, 0);
            Driver msc = new("Mick Schumacher", 23, "Mick", "Schumacher", "MSC", "Germany", "german", 78, 72, 80, 60, 0, 0, 0);
            Driver gas = new("Pierre Gasly", 26, "Pierre", "Gasly", "GAS", "France", "french", 72, 83, 80, 65, 0, 0, 0); ;
            Driver tsu = new("Yuki Tsunoda", 21, "Yuki", "Tsunoda", "TSU", "Japan", "japanese", 80, 79, 80, 55, 0, 0, 0);
            Driver alb = new("Alexander Albon", 26, "Alexander", "Albon", "ALB", "Thailand", "thai", 81, 84, 75, 68, 0, 0, 0);
            Driver lat = new("Nicholas Latifi", 26, "Nicholas", "Latifi", "LAT", "Canada", "canadian", 67, 71, 73, 61, 0, 0, 0);

            Track bahrain = new("Bahrain International Circuit", "BAHRAIN GRAND PRIX", "Sakhir, Bahrain", "Bahrain");
            Track jeddah = new("Jeddah Corniche Circuit", "SAUDI ARABIAN GRAND PRIX", "Jeddah, Saudi Arabia", "Jeddah");
            Track australia = new("Albert Park Circuit", "AUSTRALIAN GRAND PRIX", "Melbourne, Australia", "Australia");
            Track imola = new("Autodromo Enzo e Dino Ferrari", "EMILIA-ROMAGNA GRAND PRIX", "Imola, Italy", "Imola");
            Track miami = new("Miami International Autodrome", "MIAMI GRAND PRIX", "Miami, United States", "Miami");
            Track spain = new("Circuit de Barcelona-Catalunya", "SPANISH GRAND PRIX", "Catalunya, Spain", "Spain");
            Track monaco = new("Circuit de Monaco", "MONACO GRAND PRIX", "Monaco", "Monaco");
            Track baku = new("Baku City Circuit", "AZERBAIJAN GRAND PRIX", "Baku, Azerbaijan", "Baku");
            Track canada = new("Circuit Gilles-Villeneuve", "CANADIAN GRAND PRIX", "Montreal, Canada", "Canada");
            Track silverstone = new("Silverstone Circuit", "BRITISH GRAND PRIX", "Silverstone, Great Britain", "Silverstone");
            Track austria = new("Red Bull Ring", "AUSTRIAN GRAND PRIX", "Spielberg, Austria", "Austria");
            Track paulricard = new("Circuit Paul Ricard", "FRENCH GRAND PRIX", "Le Castellet, France", "Paul Ricard");
            Track hungaroring = new("Hungaroring", "HUNGARIAN GRAND PRIX", "Budapest, Hungary", "Hungaroring");
            Track spa = new("Circuit de Spa-Francorchamps", "BELGIAN GRAND PRIX", "Spa-Francorchamps, Belgium", "Spa");
            Track zandvoort = new("Circuit Zandvoort", "DUTCH GRAND PRIX", "Zandvoort, Netherlands", "Zandvoort");
            Track monza = new("Autodromo Nazionale Monza", "ITALIAN GRAND PRIX", "Milan, Italy", "Monza");
            Track singapore = new("Marina Bay Street Circuit", "SINGAPORE GRAND PRIX", "Singapore", "Singapore");
            Track suzuka = new("Suzuka International Racing Course", "JAPANESE GRAND PRIX", "Suzuka, Japan", "Suzuka");
            Track cota = new("Circuit of The Americas", "UNITED STATES GRAND PRIX", "Austin, United States", "Circuit of The Americas");
            Track mexico = new("Autodromo Hermanos Rodriguez", "MEXICAN GRAND PRIX", "Mexico City", "Mexico City");
            Track interlagos = new("Autodromo Jose Carlos Pace", "SÃO PAULO GRAND PRIX", "São Paulo, Brazil", "Interlagos");
            Track abudhabi = new("Yas Marina Circuit", "ABU DHABI GRAND PRIX", "Abu Dhabi, United Arab Emirates", "Abu Dhabi");

            Driver[] drivers = new[]
            {
                ver,
                per,
                lec,
                sai,
                ham,
                rus,
                alo,
                oco,
                nor,
                ric,
                bot,
                zho,
                vet,
                str,
                mag,
                msc,
                gas,
                tsu,
                alb,
                lat
            };

            Driver[] rdrivers = new[]
            {
                ver,
                per,
                lec,
                sai,
                ham,
                rus,
                alo,
                oco,
                nor,
                ric,
                bot,
                zho,
                vet,
                str,
                mag,
                msc,
                gas,
                tsu,
                alb,
                lat
            };

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

            Team car1 = RedBull;
            Team car2 = RedBull;
            Team car3 = Ferrari;
            Team car4 = Ferrari;
            Team car5 = Mercedes;
            Team car6 = Mercedes;
            Team car7 = Alpine;
            Team car8 = Alpine;
            Team car9 = Mclaren;
            Team car10 = Mclaren;
            Team car11 = AlfaRomeo;
            Team car12 = AlfaRomeo;
            Team car13 = AstonMartin;
            Team car14 = AstonMartin;
            Team car15 = Haas;
            Team car16 = Haas;
            Team car17 = AlphaTauri;
            Team car18 = AlphaTauri;
            Team car19 = Williams;
            Team car20 = Williams;

            Driver driver1 = rdrivers[0];
            Driver driver2 = rdrivers[1];
            Driver driver3 = rdrivers[2];
            Driver driver4 = rdrivers[3];
            Driver driver5 = rdrivers[4];
            Driver driver6 = rdrivers[5];
            Driver driver7 = rdrivers[6];
            Driver driver8 = rdrivers[7];
            Driver driver9 = rdrivers[8];
            Driver driver10 = rdrivers[9];
            Driver driver11 = rdrivers[10];
            Driver driver12 = rdrivers[11];
            Driver driver13 = rdrivers[12];
            Driver driver14 = rdrivers[13];
            Driver driver15 = rdrivers[14];
            Driver driver16 = rdrivers[15];
            Driver driver17 = rdrivers[16];
            Driver driver18 = rdrivers[17];
            Driver driver19 = rdrivers[18];
            Driver driver20 = rdrivers[19];

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

            Team[] chosenteams = new[]
            {
                car1,
                car2,
                car3,
                car4,
                car5,
                car6,
                car7,
                car8,
                car9,
                car10,
                car11,
                car12,
                car13,
                car14,
                car15,
                car16,
                car17,
                car18,
                car19,
                car20
            };

            Driver[] chosendrivers = new[]
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

            Team currentteam = car1;

            Driver currentdriver = driver1;

            bool grid = false;
            bool specs = false;

            int x = 0;

            string[] intro = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Formula 1 Simulator\Formula 1 Simulator\intro.txt");
            string[] image = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Formula 1 Simulator\Formula 1 Simulator\image.txt");
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
        checkpoint1:
            Console.WriteLine("Start new season...");
        fallback1:
            ConsoleKeyInfo advance = Console.ReadKey(true);
            if (advance.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.Help();
                goto checkpoint1;
            }
            else if (advance.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.CommandMode(eRedBull, eFerrari, eMercedes, eRenault,
                    RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                    ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                    drivers, rdrivers,
                    car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                    driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                    chosenteams, chosendrivers, currentteam, currentdriver,
                    grid, specs, Autorun);
                goto checkpoint1;
            }
            else if (advance.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
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
                ClearCurrentConsoleLine(x);
                Thread.Sleep(200);
            }
            x = 0;
            Console.SetCursorPosition(x, Console.CursorTop);
            ClearCurrentConsoleLine(x);
            if (Autorun == false)
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
            if (Autorun == true)
            {
                goto grid1;
            }
        fallback2:
            ConsoleKeyInfo advance2 = Console.ReadKey(true);
            if (advance2.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.Help();
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.CommandMode(eRedBull, eFerrari, eMercedes, eRenault,
                    RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                    ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                    drivers, rdrivers,
                    car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                    driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                    chosenteams, chosendrivers, currentteam, currentdriver,
                    grid, specs, Autorun);
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
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
            Console.Write("\x1b[38;5;" + 4 + "m" + driver1.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.Write("\x1b[38;5;" + 4 + "m" + driver2.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" for the upcoming season.");
            Console.WriteLine();
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == true)
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
            if (Autorun == false)
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
            if (Autorun == true)
            {
                goto races;
            }
        fallback12:
            ConsoleKeyInfo advance12 = Console.ReadKey(true);
            if (advance12.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.Help();
                goto checkpoint3;
            }
            else if (advance12.Key == ConsoleKey.C)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                Plugins.Program.CommandMode(eRedBull, eFerrari, eMercedes, eRenault,
                    RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                    ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                    drivers, rdrivers,
                    car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                    driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                    chosenteams, chosendrivers, currentteam, currentdriver,
                    grid, specs, Autorun);
                goto checkpoint3;
            }
            else if (advance12.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(x, Console.CursorTop - 1);
                ClearCurrentConsoleLine(x);
                goto races;
            }
            goto fallback12;
        races:
            string racestart = "Round 1 of 22 begins with the " + bahrain.gp + ".";
            string startornext = "Start race...";
            string currentrace = "        BAHRAIN GRAND PRIX RACE RESULTS       ";
            string CurrentRace = "Bahrain";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "After that dramatic start of the season, it's time to race at " + jeddah.name + ".";
            startornext = "Next race...";
            currentrace = "    SAUDI ARABIAN GRAND PRIX RACE RESULTS     ";
            CurrentRace = "Jeddah";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Round 3 brings us to " + australia.location + ".";
            currentrace = "      AUSTRALIAN GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Australia";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "This weekend the drivers will fight it out at " + imola.name + ".";
            currentrace = "    EMILIA-ROMAGNA GRAND PRIX RACE RESULTS    ";
            CurrentRace = "Imola";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Brace yourself, it's time for the " + miami.gp + ".";
            currentrace = "         MIAMI GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Miami";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = spain.location + " will host this weekends race.";
            currentrace = "        SPANISH GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Spain";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = monaco.shortname + " is no stranger to Formula 1, it's time for the " + monaco.gp + ".";
            currentrace = "        MONACO GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Monaco";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Round 8 of 22 comes to " + baku.location + " at the " + baku.name + ".";
            currentrace = "       AZERBAIJAN GRAND PRIX RACE RESULTS     ";
            CurrentRace = "Baku";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "This weekend, we fly across the Atlantic for the " + canada.gp + ".";
            currentrace = "       CANADIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Canada";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Let's race at the legendary " + silverstone.name + "!";
            currentrace = "       BRITISH GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Silverstone";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = austria.name + " hosts the upcoming race.";
            currentrace = "       AUSTRIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Austria";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "The " + paulricard.gp + " at " + paulricard.name + " marks the halfpoint of the season.";
            currentrace = "        FRENCH GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Paulricard";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "It's time to race at the " + hungaroring.name + " in " + hungaroring.location + ".";
            currentrace = "       HUNGARIAN GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Hungaroring";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "After the summer break, we continue at the fan favorite " + spa.name + ".";
            currentrace = "        BELGIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Spa";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Round 14 brings us to " + zandvoort.location + " for the " + zandvoort.gp + ".";
            currentrace = "         DUTCH GRAND PRIX RACE RESULTS        ";
            CurrentRace = "Zandvoort";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "With 8 races to go we visit the temple of speed. " + monza.name + "!";
            currentrace = "        ITALIAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Monza";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Not many circuits can compare with the narrow streets of Monaco. " + singapore.name + " however, might be one of them." ;
            currentrace = "       SINGAPORE GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Singapore";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "We're in " + suzuka.location + " for another fan favorite. Let's race at " + suzuka.shortname + "!";
            currentrace = "       JAPANESE GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Suzuka";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Welcome to " + cota.location + ". We're racing at " + cota.name + ".";
            currentrace = "     UNITED STATES GRAND PRIX RACE RESULTS    ";
            CurrentRace = "Cota";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "This race weekend takes place at an altidude of 2280 meters, at " + mexico.name + ".";
            currentrace = "        MEXICAN GRAND PRIX RACE RESULTS       ";
            CurrentRace = "Mexico";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Welcome to Brazil, where the drivers and teams will be racing for the win at " + interlagos.shortname + ".";
            currentrace = "       SÃO PAULO GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Interlagos";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            racestart = "Who will be crowned as world champion at the last race, in " + abudhabi.shortname + " today?";
            currentrace = "       ABU DHABI GRAND PRIX RACE RESULTS      ";
            CurrentRace = "Abudhabi";

            Race(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                racestart, startornext, currentrace, CurrentRace, x, grid, specs, chosenteams, chosendrivers, currentteam, currentdriver, drivers, rdrivers,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                bahrain, jeddah, australia, imola, miami, spain, monaco, baku, canada, silverstone, austria, paulricard, hungaroring, spa, zandvoort, monza, singapore, suzuka, cota, mexico, interlagos, abudhabi);

            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("Season finished!");
            Console.ReadLine();
        }
    }
}
