using Meta;

namespace Formula_1_Simulator
{
    class Program
    {
        static void Content(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
            Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
            Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
            Driver[] drivers, Driver[] rdrivers,
            Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
            Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20,
            Team[] chosenteam, Driver[] chosendrivers, Team currentteam, Driver currentdriver) 
        {

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

        static void Commandmode(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
            Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
            Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
            Driver[] drivers, Driver[] rdrivers,
            Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
            Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20,
            Team[] chosenteams, Driver[] chosendrivers, Team currentteam, Driver currentdriver)
        {
            static void TeamMode(Engine eRedBull, Engine eFerrari, Engine eMercedes, Engine eRenault,
                Team RedBull, Team Ferrari, Team Mercedes, Team Alpine, Team Mclaren, Team AlfaRomeo, Team AstonMartin, Team Haas, Team AlphaTauri, Team Williams,
                Driver ver, Driver per, Driver lec, Driver sai, Driver ham, Driver rus, Driver alo, Driver oco, Driver nor, Driver ric, Driver bot, Driver zho, Driver vet, Driver str, Driver mag, Driver msc, Driver gas, Driver tsu, Driver alb, Driver lat,
                Driver[] drivers, Driver[] rdrivers,
                Team car1, Team car2, Team car3, Team car4, Team car5, Team car6, Team car7, Team car8, Team car9, Team car10, Team car11, Team car12, Team car13, Team car14, Team car15, Team car16, Team car17, Team car18, Team car19, Team car20,
                Driver driver1, Driver driver2, Driver driver3, Driver driver4, Driver driver5, Driver driver6, Driver driver7, Driver driver8, Driver driver9, Driver driver10, Driver driver11, Driver driver12, Driver driver13, Driver driver14, Driver driver15, Driver driver16, Driver driver17, Driver driver18, Driver driver19, Driver driver20,
                Team[] chosenteams, Driver[] chosendrivers, Team currentteam, Driver currentdriver)
            {
                //loop2
                TeamMode:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What do you wish to learn about " + currentteam.name + "?");
                ConsoleKeyInfo help = Console.ReadKey(true);
                if (help.Key == ConsoleKey.Backspace)
                {
                    //break;
                }
                else if (help.Key == ConsoleKey.H)
                {
                    Console.WriteLine("Valid commands here are:");
                    Console.WriteLine("'info' - to learn more about them");
                    Console.WriteLine("'ratings' - displays the overall and in depth ratings of this teams car");
                    Console.WriteLine("'stats' - shows accumulated statistics since the season start");
                    Console.WriteLine("'Backspace' - to return to general command mode");
                    goto TeamMode;
                }
                var input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (input.ToLower() == "info")
                {
                    Console.WriteLine(currentteam.name + " is " + currentteam.prefix + " Formula 1 team based in " + currentteam.hq + ".");
                    Console.WriteLine("They have been in the sport for " + currentteam.age + " years.");
                    Console.WriteLine(currentteam.principal + " is currently the team principal of " + currentteam.name + ".");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (input.ToLower() == "ratings")
                {
                    Console.WriteLine(currentteam.name + " uses the " + currentteam.engine + " power unit as their internal combustion engine.");
                    Console.WriteLine("Ratings:");
                    Console.WriteLine("              Overall performance:   " + currentteam.performance);
                    Console.WriteLine("ICE Power:  " + currentteam.power + "     ICE Reliability: " + currentteam.reliability);
                    Console.WriteLine("Downforce:  " + currentteam.downforce + "     Drag:  " + currentteam.drag);
                    Console.WriteLine("Traction:  " + currentteam.traction + "     Grip:  " + currentteam.grip);
                    Console.WriteLine("Tyre degradation:  " + currentteam.degradation);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (input.ToLower() == "stats")
                {
                    Console.WriteLine(currentteam.name + " currently has " + currentteam.wins + " wins, " + currentteam.podiums + " podiums, and " + currentteam.points + " points this season.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(input + " is not a valid command, please try again");
                    Console.WriteLine();
                    Console.WriteLine();
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
                //loop2
                DriverMode:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What do you want to find out about " + currentdriver.name + "?");
                ConsoleKeyInfo help = Console.ReadKey(true);
                if (help.Key == ConsoleKey.Backspace)
                {
                    //break;
                }
                else if (help.Key == ConsoleKey.H)
                {
                    Console.WriteLine("Valid commands here are:");
                    Console.WriteLine("'info' - to learn more about him");
                    Console.WriteLine("'ratings' - displays the drivers overall and other detailed ratings");
                    Console.WriteLine("'stats' - shows different statistics since the season start");
                    Console.WriteLine("'Backspace' - to return to general command mode");
                    goto DriverMode;
                }
                var input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (input.ToLower() == "info")
                {
                    Console.WriteLine(currentdriver.name + " is a " + currentdriver.prefix + " Formula 1 driver.");
                    Console.WriteLine("He is " + currentdriver.age + " years of age.");
                    Console.WriteLine();
                    Console.WriteLine();
                    //andra alternativ när probabilites är fixat (50% chans till första 50% chans till denna): Console.WriteLine(currentdriver.name + " is a " + currentdriver.age + " year old Formula 1 driver from " + currentdriver.nationality);
                }
                else if (input.ToLower() == "ratings")
                {
                    Console.WriteLine(currentdriver.name + " ratings:");
                    Console.WriteLine("              Overall skill:   " + currentdriver.overall);
                    Console.WriteLine("Pace:       " + currentdriver.pace + "     Consistency: " + currentdriver.consistency);
                    Console.WriteLine("Racecraft:  " + currentdriver.racecraft + "     Experience:  " + currentdriver.experience);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (input.ToLower() == "stats")
                {
                    Console.WriteLine(currentdriver.name + " has accumulated " + currentdriver.wins + " wins, " + currentdriver.podiums + " podiums, and " + currentdriver.points + " points since the start of this season.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(input + " is not a valid command, please try again");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            //loop
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter a command or press 'Backspace' to exit command mode:");
            ConsoleKeyInfo exit = Console.ReadKey(true);
            if (exit.Key == ConsoleKey.Backspace)
            {
                //break;
            }
            else if (exit.Key == ConsoleKey.H)
            {
                Help();
            }
            var input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
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
                }
            }
            if (input.ToLower() == "driver standings")
            {
                /*
                Console.WriteLine("The standings in the F1 Drivers Championship:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Leader  " + driver + "  " + points);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("P2  " + driver + "  " + points);
                Console.WriteLine("P3  " + driver + "  " + points);
                Console.WriteLine("P4  " + driver + "  " + points);
                Console.WriteLine("P5  " + driver + "  " + points);
                Console.WriteLine("P6  " + driver + "  " + points);
                Console.WriteLine("P7  " + driver + "  " + points);
                Console.WriteLine("P8  " + driver + "  " + points);
                Console.WriteLine("P9  " + driver + "  " + points);
                Console.WriteLine("P10  " + driver + "  " + points);
                Console.WriteLine("P11  " + driver + "  " + points);
                Console.WriteLine("P12  " + driver + "  " + points);
                Console.WriteLine("P13  " + driver + "  " + points);
                Console.WriteLine("P14  " + driver + "  " + points);
                Console.WriteLine("P15  " + driver + "  " + points);
                Console.WriteLine("P16  " + driver + "  " + points);
                Console.WriteLine("P17  " + driver + "  " + points);
                Console.WriteLine("P18  " + driver + "  " + points);
                Console.WriteLine("P19  " + driver + "  " + points);
                Console.WriteLine("P20  " + driver + "  " + points);
                Console.WriteLine();
                Console.WriteLine();
            }
            else if (input.ToLower() == "constructor standings")
            {
                Console.WriteLine("The standings in the F1 Constructors Championship:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Leader  " + team + "  " + points);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("P2  " + team + "  " + points);
                Console.WriteLine("P3  " + team + "  " + points);
                Console.WriteLine("P4  " + team + "  " + points);
                Console.WriteLine("P5  " + team + "  " + points);
                Console.WriteLine("P6  " + team + "  " + points);
                Console.WriteLine("P7  " + team + "  " + points);
                Console.WriteLine("P8  " + team + "  " + points);
                Console.WriteLine("P9  " + team + "  " + points);
                Console.WriteLine("P10  " + team + "  " + points);
                Console.WriteLine();
                Console.WriteLine();
                */
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(input + " is not a valid command, please try again");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Main()
        {
            Engine eRedBull = new(90, 92);
            Engine eFerrari = new(95, 85);
            Engine eMercedes = new(85, 96);
            Engine eRenault = new(85, 85);

            Team RedBull = new("Red Bull", "Milton Keynes", 18, "Red Bull Powertrains", "an austrian", "Christian Horner", eRedBull.power, eRedBull.reliability, 1, 2, 3, 4, 5, 95, 0, 0, 0);
            Team Ferrari = new("Ferrari", "Maranello", 93, "Ferrari", "an italian", "Mattia Binotto", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 92, 0, 0, 0);
            Team Mercedes = new("Mercedes", "Brackley", 14, "Mercedes" ,"a german", "Toto Wolff", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 87, 0, 0, 0);
            Team Alpine = new("Alpine", "Enstone", 26, "Renault", "a french", "Otmar Szafnauer", eRenault.power, eRenault.reliability, 1, 2, 3, 4, 5, 80, 0, 0, 0);
            Team Mclaren = new("McLaren", "Woking", 56, "Mercedes", "a british", "Zak Brown", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 78, 0, 0, 0);
            Team AlfaRomeo = new("Alfa Romeo", "Hinwil", 44, "Ferrari", "a swiss", "Frédéric Vasseur", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 68, 0, 0, 0);
            Team AstonMartin = new("Aston Martin", "Silverstone", 4, "Mercedes", "a british", "Mike Krack", eMercedes.power, eMercedes.reliability, 1, 2, 3, 4, 5, 70, 0, 0, 0);
            Team Haas = new("Haas", "Kannapolis", 7, "Ferrari", "an american", "Günther Steiner", eFerrari.power, eFerrari.reliability, 1, 2, 3, 4, 5, 71, 0, 0, 0);
            Team AlphaTauri = new("Alpha Tauri", "Faenza", 37, "Ferrari", "an italian", "Franz Tost", eRedBull.power, eRedBull.reliability, 1, 2, 3, 4, 5, 70, 0, 0, 0);
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
            start:
            Console.WriteLine("To continue press Enter");
            Console.WriteLine();
            Console.WriteLine();
            ConsoleKeyInfo advance = Console.ReadKey(true);
            if (advance.Key == ConsoleKey.H)
            {
                Help();
                goto start;
            }
            else if (advance.Key == ConsoleKey.C)
            {
                Commandmode(eRedBull, eFerrari, eMercedes, eRenault,
                RedBull, Ferrari, Mercedes, Alpine, Mclaren, AlfaRomeo, AstonMartin, Haas, AlphaTauri, Williams,
                ver, per, lec, sai, ham, rus, alo, oco, nor, ric, bot, zho, vet, str, mag, msc, gas, tsu, alb, lat,
                drivers, rdrivers,
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8, driver9, driver10, driver11, driver12, driver13, driver14, driver15, driver16, driver17, driver18, driver19, driver20,
                chosenteams, chosendrivers, currentteam, currentdriver);
                goto start;
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