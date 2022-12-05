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

        public static void ClearCurrentConsoleLine(int x)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(x, currentLineCursor);
        }

        static void Main()
        {
            Console.Title = "Formula 1 Simulator";

            Engine eRedBull = new(90, 92);
            Engine eFerrari = new(95, 85);
            Engine eMercedes = new(85, 96);
            Engine eRenault = new(85, 85);

            Team RedBull = new("Red Bull", "Milton Keynes", 18, "Red Bull Powertrains", "an austrian", "Christian Horner", eRedBull.power, eRedBull.reliability, 1, 2, 3, 4, 5, 95, 0, 0, 0);
            Team Ferrari = new("Ferrari", "Maranello", 93, "Ferrari", "an italian", "Mattia Binotto", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 92, 0, 0, 0);
            Team Mercedes = new("Mercedes", "Brackley", 14, "Mercedes", "a german", "Toto Wolff", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 87, 0, 0, 0);
            Team Alpine = new("Alpine", "Enstone", 26, "Renault", "a french", "Otmar Szafnauer", eRenault.power, eRenault.reliability, 1, 2, 3, 4, 5, 80, 0, 0, 0);
            Team Mclaren = new("McLaren", "Woking", 56, "Mercedes", "a british", "Zak Brown", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 78, 0, 0, 0);
            Team AlfaRomeo = new("Alfa Romeo", "Hinwil", 44, "Ferrari", "a swiss", "Frédéric Vasseur", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 68, 0, 0, 0);
            Team AstonMartin = new("Aston Martin", "Silverstone", 4, "Mercedes", "a british", "Mike Krack", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 70, 0, 0, 0);
            Team Haas = new("Haas", "Kannapolis", 7, "Ferrari", "an american", "Günther Steiner", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 71, 0, 0, 0);
            Team AlphaTauri = new("AlphaTauri", "Faenza", 37, "Ferrari", "an italian", "Franz Tost", eRedBull.power, eRedBull.reliability, 1, 2, 3, 4, 5, 70, 0, 0, 0);
            Team Williams = new("Williams", "Wantage", 53, "Mercedes", "a british", "Jost Capito", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 66, 0, 0, 0);

            Driver ver = new("Max Verstappen", 24, "Max", "Verstappen", "VER", "the Netherlands", "dutch", 97, 92, 90, 78, (1 + 1), 0, 0, 0);
            Driver per = new("Sergio Perez", 32, "Sergio", "Perez", "PER", "Mexicó", "mexican", 86, 89, 93, 88, (1 + 1), 0, 0, 0);
            Driver lec = new("Charles Leclerc", 24, "Charles", "Leclerc", "LEC", "Monaco", "monegasque", 94, 85, 97, 71, (1 + 1), 0, 0, 0);
            Driver sai = new("Carlos Sainz", 27, "Carlos", "Sainz", "SAI", "Spain", "spanish", 90, 83, 90, 79, (1 + 1), 0, 0, 0);
            Driver ham = new("Lewis Hamilton", 37, "Lewis", "Hamilton", "HAM", "Great Britain", "british", 88, 95, 94, 95, (1 + 1), 0, 0, 0);
            Driver rus = new("George Russell", 24, "George", "Russell", "RUS", "Great Britain", "british", 89, 90, 87, 66, (1 + 1), 0, 0, 0);
            Driver alo = new("Fernando Alonso", 40, "Fernando", "Alonso", "ALO", "Spain", "spanish", 85, 87, 91, 100, (1 + 1), 0, 0, 0);
            Driver oco = new("Esteban Ocon", 25, "Esteban", "Ocon", "OCO", "France", "french", 81, 79, 80, 65, (1 + 1), 0, 0, 0);
            Driver nor = new("Lando Norris", 22, "Lando", "Norris", "NOR", "Great Britain", "british", 88, 82, 88, 67, (1 + 1), 0, 0, 0);
            Driver ric = new("Daniel Ricciardo", 32, "Daniel", "Ricciardo", "RIC", "Australia", "australian", 78, 80, 89, 90, (1 + 1), 0, 0, 0);
            Driver bot = new("Valterri Bottas", 32, "Valterri", "Bottas", "BOT", "Finland", "finnish", 83, 91, 75, 88, (1 + 1), 0, 0, 0);
            Driver zho = new("Zhou Guanyu", 22, "Zhou", "Guanyu", "ZHO", "China", "chinese", 83, 89, 79, 52, (1 + 1), 0, 0, 0);
            Driver vet = new("Sebastian Vettel", 34, "Sebastian", "Vettel", "VET", "Germany", "german", 82, 85, 82, 99, (1 + 1), 0, 0, 0);
            Driver str = new("Lance Stroll", 23, "Lance", "Stroll", "STR", "Canada", "canadian", 81, 83, 72, 62, (1 + 1), 0, 0, 0);
            Driver mag = new("Kevin Magnussen", 29, "Kevin", "Magnussen", "MAG", "Denmark", "danish", 80, 80, 85, 84, (1 + 1), 0, 0, 0);
            Driver msc = new("Mick Schumacher", 23, "Mick", "Schumacher", "MSC", "Germany", "german", 79, 72, 86, 60, (1 + 1), 0, 0, 0);
            Driver gas = new("Pierre Gasly", 26, "Pierre", "Gasly", "GAS", "France", "french", 78, 83, 80, 65, (1 + 1), 0, 0, 0); ;
            Driver tsu = new("Yuki Tsunoda", 21, "Yuki", "Tsunoda", "TSU", "Japan", "japanese", 80, 82, 80, 55, (1 + 1), 0, 0, 0);
            Driver alb = new("Alexander Albon", 26, "Alexander", "Albon", "ALB", "Thailand", "thai", 82, 90, 78, 68, (1 + 1), 0, 0, 0);
            Driver lat = new("Nicholas Latifi", 26, "Nicholas", "Latifi", "LAT", "Canada", "canadian", 67, 71, 73, 61, (1 + 1), 0, 0, 0);

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

            Team currentteam = car1;

            Driver currentdriver = driver1;

            bool grid = false;
            bool specs = false;

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
                Plugins.Program.Help();
                goto checkpoint1;
            }
            else if (advance.Key == ConsoleKey.C)
            {
                Plugins.Program.CommandMode(eRedBull, eFerrari, eMercedes, eRenault,
                    RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                    ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                    drivers, rdrivers,
                    car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                    driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                    chosenteams, chosendrivers, currentteam, currentdriver,
                    grid, specs);
                goto checkpoint1;
            }
            else if (advance.Key == ConsoleKey.Enter)
            {
                goto seasonstart;
            }
            goto fallback1;

        seasonstart:
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Initializing new season");
            int x = 23;
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
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Winter break is over and the first round of the Formula 1 2023 season is just around the corner.");
            Thread.Sleep(400);
            Console.WriteLine("As the teams are preparing to unveil this years cars, lets take a look at the new grid lineup in the paddock.");
            Thread.Sleep(400);
        checkpoint2:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Show new grid...");
        fallback2:
            ConsoleKeyInfo advance2 = Console.ReadKey(true);
            if (advance2.Key == ConsoleKey.H)
            {
                Plugins.Program.Help();
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.C)
            {
                Plugins.Program.CommandMode(eRedBull, eFerrari, eMercedes, eRenault,
                    RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                    ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                    drivers, rdrivers,
                    car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                    driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                    chosenteams, chosendrivers, currentteam, currentdriver,
                    grid, specs);
                goto checkpoint2;
            }
            else if (advance2.Key == ConsoleKey.Enter)
            {
                goto grid;
            }
            goto fallback2;

        grid:
            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
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
            Console.WriteLine();

            grid = true;
            specs = true;
        }
    }
}