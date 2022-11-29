using Meta;
using System.Security.Cryptography.X509Certificates;

namespace Formula_1_Simulator
{
    class Program
    {
        static void content(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
            Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
            Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
            Driver[] drivers, Driver[] rdrivers,
            Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
            Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20) 
        {
            Console.WriteLine(Ferrari.principal + " signs " + driver1.name);
        }

        static void Help()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Valid commands are:");
            Console.WriteLine("driver standings");
            Console.WriteLine("constructor standings");
            Console.WriteLine("'driver' or 'team' to find stats and info on a certain driver or team");
            Console.WriteLine("'clear console' - clears up the console so you can stay focused on the present!");
            Console.WriteLine();
            Console.WriteLine();
        }

        

        static void Main()
        {
            Engine eRedBull = new Engine(90, 92);
            Engine eFerrari = new Engine(95, 85);
            Engine eMercedes = new Engine(85, 96);
            Engine eRenault = new Engine(85, 85);

            Team RedBull = new Team("Red Bull", "Milton Keynes", "austrian", "Christian Horner", eRedBull.power, eRedBull.reliability, 1, 2, 3, 4, 5, 95);
            Team Ferrari = new Team("Ferrari", "Maranello", "italian", "Mattia Binotto", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 92);
            Team Mercedes = new Team("Mercedes", "Brackley", "german", "Toto Wolff", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 87);
            Team Alpine = new Team("Alpine", "Enstone", "french", "Otmar Szafnauer", eRenault.power, eRenault.reliability, 1, 2, 3, 4, 5, 80);
            Team Mclaren = new Team("McLaren", "Woking", "british", "Zak Brown", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 78);
            Team AlfaRomeo = new Team("Alfa Romeo", "Hinwil", "swiss", "Frédéric Vasseur", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 68);
            Team AstonMartin = new Team("Aston Martin", "Silverstone", "british", "Mike Krack", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 70);
            Team Haas = new Team("Haas", "Kannapolis", "american", "Günther Steiner", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 71);
            Team AlphaTauri = new Team("Alpha Tauri", "Faenza", "italian", "Franz Tost", eRedBull.power, eRedBull.reliability, 1, 2, 3, 4, 5, 70);
            Team Williams = new Team("Williams", "Wantage", "british", "Jost Capito", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 66);

            Driver ver = new Driver("Max Verstappen", "the Netherlands", "dutch", 97, 92, 90, 78, (1 + 1));
            Driver per = new Driver("Sergio Peréz", "Mexicó", "mexican", 86, 89, 93, 88, (1 + 1));
            Driver lec = new Driver("Charles Leclerc", "Monaco", "monegasque", 94, 85, 97, 71, (1 + 1));
            Driver sai = new Driver("Carlos Sainz", "Spain", "spanish", 90, 83, 90, 79, (1 + 1));
            Driver ham = new Driver("Lewis Hamilton", "Great Britain", "british", 88, 95, 94, 95, (1 + 1));
            Driver rus = new Driver("George Russell", "Great Britain", "british", 89, 90, 87, 66, (1 + 1));
            Driver alo = new Driver("Fernando Alonso", "Spain", "spanish", 85, 87, 91, 100, (1 + 1));
            Driver oco = new Driver("Estéban Ocon", "France", "french", 81, 79, 80, 65, (1 + 1));
            Driver nor = new Driver("Lando Norris", "Great Britain", "british", 88, 82, 88, 67, (1 + 1));
            Driver ric = new Driver("Daniel Ricciardo", "Australia", "australian", 78, 80, 89, 90, (1 + 1));
            Driver bot = new Driver("Valterri Bottas", "Finland", "finnish", 83, 91, 75, 88, (1 + 1));
            Driver zho = new Driver("Zhou Guanyu", "China", "chinese", 83, 89, 79, 52, (1 + 1));
            Driver vet = new Driver("Sebastian Vettel", "Germany", "german", 82, 85, 82, 99, (1 + 1));
            Driver str = new Driver("Lance Stroll", "Canada", "canadian", 81, 83, 72, 62, (1 + 1));
            Driver mag = new Driver("Kevin Magnussen", "Denmark", "danish", 80, 80, 85, 84, (1 + 1));
            Driver msc = new Driver("Mick Schumacher", "Germany", "german", 79, 72, 86, 60, (1 + 1));
            Driver gas = new Driver("Pierre Gasly", "France", "french", 78, 83, 80, 65, (1 + 1));
            Driver tsu = new Driver("Yuki Tsunoda", "Japan", "japanese", 80, 82, 80, 55, (1 + 1));
            Driver alb = new Driver("Alexander Albon", "Thailand", "thai", 82, 90, 78, 68, (1 + 1));
            Driver lat = new Driver("Nicholas Latifi", "Canada", "canadian", 67, 71, 73, 61, (1 + 1));

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
                Random random = new Random();
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

            Console.WriteLine(driver5.overall);
            content(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                drivers, rdrivers,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\r\n  ______                              _               __         _____  _                    _         _               \r\n |  ____|                            | |             /_ |       / ____|(_)                  | |       | |              \r\n | |__  ___   _ __  _ __ ___   _   _ | |  __ _        | |      | (___   _  _ __ ___   _   _ | |  __ _ | |_  ___   _ __ \r\n |  __|/ _ \\ | '__|| '_ ` _ \\ | | | || | / _` |       | |       \\___ \\ | || '_ ` _ \\ | | | || | / _` || __|/ _ \\ | '__|\r\n | |  | (_) || |   | | | | | || |_| || || (_| |       | |       ____) || || | | | | || |_| || || (_| || |_| (_) || |   \r\n |_|   \\___/ |_|   |_| |_| |_| \\__,_||_| \\__,_|       |_|      |_____/ |_||_| |_| |_| \\__,_||_| \\__,_| \\__|\\___/ |_|   \r\n                                                                                                                       \r\n                                                                                                                       \r\n");
            Console.WriteLine("       .-----------,-.-----. \r\n       |:        //(_)\\    |:\r\n    ___||=======// ,--.\\===.|  ___\r\n  .'.\"\"'\\\\____.'/ | (__)\\__|\\.'.\"\"'.\r\n  | |\"\"\"||._       '---'__   `-|\"\"\"|\r\n  | |\"\"\"||. '-.___  ` -'--'     `-.| ___\r\n  | |\"\"\"|| '-.'.\"\"'.----._     .---:'.\"\"'.\r\n  `.'_\".'|   | |\"\"\"|_____ `. /\\ \\___||_\"\"|\r\n          '-.| |\"\"_/_____\\  \\ \\\\ \\_____\\_|\r\n             | |\"|____    ', '.__/   ____|\r\n             `.'__.'  `'---'-'---'-'.'__.'");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(3000);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the ultimate Formula 1 Simulator.");
            Console.WriteLine("Are you ready to write a new chapter in the sports history books?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("After the game has started, press 'C' to enter command mode.");
            Console.WriteLine("Press 'H' at any time to get a list of all available commands.");
            Console.WriteLine("To continue press Enter");
            Console.WriteLine();
            Console.WriteLine();
            ConsoleKeyInfo advance = Console.ReadKey(true);
            if (advance.Key == ConsoleKey.H)
            {
                Help();
            }
            else if (advance.Key == ConsoleKey.C)
            {
                //Commandmode();
            }
            else if (advance.Key == ConsoleKey.Enter)
            {
                goto seasonstart;
            }

            seasonstart:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Season starts (test)");
        }
    }
}