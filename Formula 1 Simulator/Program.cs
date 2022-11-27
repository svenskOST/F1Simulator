using Meta;

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

var car1 = RedBull;
var car2 = RedBull;
var car3 = Ferrari;
var car4 = Ferrari;
var car5 = Mercedes;
var car6 = Mercedes;
var car7 = Alpine;
var car8 = Alpine;
var car9 = Mclaren;
var car10 = Mclaren;
var car11 = AlfaRomeo;
var car12 = AlfaRomeo;
var car13 = AstonMartin;
var car14 = AstonMartin;
var car15 = Haas;
var car16 = Haas;
var car17 = AlphaTauri;
var car18 = AlphaTauri;
var car19 = Williams;
var car20 = Williams;

 var drivers = new[]
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

var rdrivers = new string[20];
for (int i = 0; i < 20; i++)
{
    Console.WriteLine("length = " + drivers.Length);
    Random random = new Random();
    int rindex = random.Next(drivers.Length);
    Console.WriteLine("rindex = " + rindex);
    rdrivers[i] = drivers[rindex].name.ToString();
    for (int y = rindex; y < drivers.Length - 1; y++)
    {
        drivers[y] = drivers[y + 1];
    }
    Array.Resize(ref drivers, drivers.Length - 1);
}

//if rindex 3 == rindex 1 or rindex 2 then rerun?
//randomize order of array and make driverN pre decided index

var driver1 = rdrivers[0];
var driver2 = rdrivers[1];
var driver3 = rdrivers[2];
var driver4 = rdrivers[3];
var driver5 = rdrivers[4];
var driver6 = rdrivers[5];
var driver7 = rdrivers[6];
var driver8 = rdrivers[7];
var driver9 = rdrivers[8];
var driver10 = rdrivers[9];
var driver11 = rdrivers[10];
var driver12 = rdrivers[11];
var driver13 = rdrivers[12];
var driver14 = rdrivers[13];
var driver15 = rdrivers[14];
var driver16 = rdrivers[15];
var driver17 = rdrivers[16];
var driver18 = rdrivers[17];
var driver19 = rdrivers[18];
var driver20 = rdrivers[19];


Console.WriteLine("3 = " + rdrivers[3]);
Console.WriteLine("20 = " + rdrivers[19]);
for (int i = 0; i < 20; i++)
{
    Console.WriteLine("array" + i + " = " + rdrivers[i]);
}

/*
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("\r\n______                                 _              __          _____                                               _                \r\n|  ___|                               | |            /  |        /  __ \\                                             | |               \r\n| |_     ___   _ __  _ __ ___   _   _ | |  __ _      `| |        | /  \\/  ___   _ __ ___   _ __    __ _  _ __   __ _ | |_   ___   _ __ \r\n|  _|   / _ \\ | '__|| '_ ` _ \\ | | | || | / _` |      | |        | |     / _ \\ | '_ ` _ \\ | '_ \\  / _` || '__| / _` || __| / _ \\ | '__|\r\n| |    | (_) || |   | | | | | || |_| || || (_| |     _| |_       | \\__/\\| (_) || | | | | || |_) || (_| || |   | (_| || |_ | (_) || |   \r\n\\_|     \\___/ |_|   |_| |_| |_| \\__,_||_| \\__,_|     \\___/        \\____/ \\___/ |_| |_| |_|| .__/  \\__,_||_|    \\__,_| \\__| \\___/ |_|   \r\n                                                                                          | |                                          \r\n                                                                                          |_|                                          \r\n");
Console.WriteLine("       .-----------,-.-----. \r\n       |:        //(_)\\    |:\r\n    ___||=======// ,--.\\===.|  ___\r\n  .'.\"\"'\\\\____.'/ | (__)\\__|\\.'.\"\"'.\r\n  | |\"\"\"||._       '---'__   `-|\"\"\"|\r\n  | |\"\"\"||. '-.___  ` -'--'     `-.| ___\r\n  | |\"\"\"|| '-.'.\"\"'.----._     .---:'.\"\"'.\r\n  `.'_\".'|   | |\"\"\"|_____ `. /\\ \\___||_\"\"|\r\n          '-.| |\"\"_/_____\\  \\ \\\\ \\_____\\_|\r\n             | |\"|____    ', '.__/   ____|\r\n             `.'__.'  `'---'-'---'-'.'__.'");
Console.WriteLine();
Console.WriteLine();
System.Threading.Thread.Sleep(3000);

var car1 = RedBull;
fallback1:
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Begin by choosing a car");
Console.ForegroundColor = ConsoleColor.Blue;
string input1 = Console.ReadLine();
if (input1.ToLower() == "car help")
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Valid cars are:");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Red Bull\r\nFerrari\r\nMercedes\r\nAlpine\r\nMcLaren\r\nAlfa Romeo\r\nAston Martin\r\nHaas\r\nAlpha Tauri\r\nWilliams");
    goto fallback1;
}
else if (input1.ToLower() == "red bull")
{
    car1 = RedBull;
}
else if (input1.ToLower() == "ferrari")
{
    car1 = Ferrari;
}
else if (input1.ToLower() == "mercedes")
{
    car1 = Mercedes;
}
else if (input1.ToLower() == "alpine")
{
    car1 = Alpine;
}
else if (input1.ToLower() == "mclaren")
{
    car1 = Mclaren;
}
else if (input1.ToLower() == "alfa romeo")
{
    car1 = AlfaRomeo;
}
else if (input1.ToLower() == "aston martin")
{
    car1 = AstonMartin;
}
else if (input1.ToLower() == "haas")
{
    car1 = Haas;
}
else if (input1.ToLower() == "alpha tauri")
{
    car1 = AlphaTauri;
}
else if (input1.ToLower() == "williams")
{
    car1 = Williams;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("'" + input1 + "'" + " is not a valid car, try again");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Type 'car help' to get a list of valid cars");
    goto fallback1;
}

var driver1 = ver;
fallback2:
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();
Console.WriteLine("And who will be piloting this car?");
Console.ForegroundColor = ConsoleColor.Blue;
string input2 = Console.ReadLine();
if (input2 == "driver help")
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Valid drivers are:");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Max Verstappen\r\nCharles Leclerc\r\nSergio Perez\r\nCarlos Sainz\r\nGeorge Russell\r\nLewis Hamilton\r\nFernando Alonso\r\nEsteban Ocon\r\nValterri Bottas\r\nGuanyu Zhou\r\nDaniel Ricciardo\r\nLando Norris\r\nSebastian Vettel\r\nLance Stroll\r\nKevin Magnussen\r\nMick Schumacher\r\nYuki Tsunoda\r\nPierre Gasly\r\nNicholas Latifi\r\nAlexander Albon");
    goto fallback2;
}
else if (input2.ToLower() == "max verstappen" || input2.ToLower() == "max" || input2.ToLower() == "verstappen" || input2.ToLower() == "ver")
{
    driver1 = ver;
}
else if (input2.ToLower() == "sergio perez" || input2.ToLower() == "sergio" || input2.ToLower() == "perez" || input2.ToLower() == "per" || input2.ToLower() == "checo")
{
    driver1 = per;
}
else if (input2.ToLower() == "charles leclerc" || input2.ToLower() == "charles" || input2.ToLower() == "leclerc" || input2.ToLower() == "lec")
{
    driver1 = lec;
}
else if (input2.ToLower() == "carlos sainz" || input2.ToLower() == "carlos" || input2.ToLower() == "sainz" || input2.ToLower() == "sai")
{
    driver1 = sai;
}
else if (input2.ToLower() == "lewis hamilton" || input2.ToLower() == "lewis" || input2.ToLower() == "hamilton" || input2.ToLower() == "ham")
{
    driver1 = ham;
}
else if (input2.ToLower() == "george russell" || input2.ToLower() == "george" || input2.ToLower() == "russell" || input2.ToLower() == "rus")
{
    driver1 = rus;
}
else if (input2.ToLower() == "fernando alonso" || input2.ToLower() == "fernando" || input2.ToLower() == "alonso" || input2.ToLower() == "alo")
{
    driver1 = alo;
}
else if (input2.ToLower() == "esteban ocon" || input2.ToLower() == "esteban" || input2.ToLower() == "ocon" || input2.ToLower() == "oco")
{
    driver1 = oco;
}
else if (input2.ToLower() == "lando norris" || input2.ToLower() == "lando" || input2.ToLower() == "norris" || input2.ToLower() == "nor")
{
    driver1 = nor;
}
else if (input2.ToLower() == "daniel ricciardo" || input2.ToLower() == "daniel" || input2.ToLower() == "ricciardo" || input2.ToLower() == "ric")
{
    driver1 = ric;
}
else if (input2.ToLower() == "valterri bottas" || input2.ToLower() == "valterri" || input2.ToLower() == "bottas" || input2.ToLower() == "bot")
{
    driver1 = bot;
}
else if (input2.ToLower() == "zhou guanyu" || input2.ToLower() == "zhou" || input2.ToLower() == "guanyu" || input2.ToLower() == "zho")
{
    driver1 = zho;
}
else if (input2.ToLower() == "sebastian vettel" || input2.ToLower() == "sebastian" || input2.ToLower() == "vettel" || input2.ToLower() == "vet" || input2.ToLower() == "seb")
{
    driver1 = vet;
}
else if (input2.ToLower() == "lance stroll" || input2.ToLower() == "lance" || input2.ToLower() == "stroll" || input2.ToLower() == "str")
{
    driver1 = str;
}
else if (input2.ToLower() == "kevin magnussen" || input2.ToLower() == "kevin" || input2.ToLower() == "magnussen" || input2.ToLower() == "mag" || input2.ToLower() == "kmag" || input2.ToLower() == "kev")
{
    driver1 = mag;
}
else if (input2.ToLower() == "mick schumacher" || input2.ToLower() == "mick" || input2.ToLower() == "schumacher" || input2.ToLower() == "msc" || input2.ToLower() == "schumi")
{
    driver1 = msc;
}
else if (input2.ToLower() == "pierre gasly" || input2.ToLower() == "pierre" || input2.ToLower() == "gasly" || input2.ToLower() == "gas")
{
    driver1 = gas;
}
else if (input2.ToLower() == "yuki tsunoda" || input2.ToLower() == "yuki" || input2.ToLower() == "tsunoda" || input2.ToLower() == "tsu")
{
    driver1 = tsu;
}
else if (input2.ToLower() == "alexander albon" || input2.ToLower() == "alexander" || input2.ToLower() == "albon" || input2.ToLower() == "alb" || input2.ToLower() == "alex")
{
    driver1 = alb;
}
else if (input2.ToLower() == "nicholas latifi" || input2.ToLower() == "nicholas" || input2.ToLower() == "latifi" || input2.ToLower() == "lat" || input2.ToLower() == "goat" || input2.ToLower() == "the goat")
{
    driver1 = lat;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("'" + input2 + "'" + " is not a valid driver, try again");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Type 'driver help' to get a list of valid drivers");
    goto fallback2;
}

var car2 = RedBull;
fallback3:
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();
Console.WriteLine("Now choose your second car");
Console.ForegroundColor = ConsoleColor.Yellow;
string input3 = Console.ReadLine();
if (input3.ToLower() == "car help")
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Valid cars are:");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Red Bull\r\nFerrari\r\nMercedes\r\nAlpine\r\nMcLaren\r\nAlfa Romeo\r\nAston Martin\r\nHaas\r\nAlpha Tauri\r\nWilliams");
    goto fallback3;
}
else if (input3.ToLower() == "red bull")
{
    car2 = RedBull;
}
else if (input3.ToLower() == "ferrari")
{
    car2 = Ferrari;
}
else if (input3.ToLower() == "mercedes")
{
    car2 = Mercedes;
}
else if (input3.ToLower() == "alpine")
{
    car2 = Alpine;
}
else if (input3.ToLower() == "mclaren")
{
    car2 = Mclaren;
}
else if (input3.ToLower() == "alfa romeo")
{
    car2 = AlfaRomeo;
}
else if (input3.ToLower() == "aston martin")
{
    car2 = AstonMartin;
}
else if (input3.ToLower() == "haas")
{
    car2 = Haas;
}
else if (input3.ToLower() == "alpha tauri")
{
    car2 = AlphaTauri;
}
else if (input3.ToLower() == "williams")
{
    car2 = Williams;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("'" + input3 + "'" + " is not a valid car, try again");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Type 'car help' to get a list of valid cars");
    goto fallback3;
}

var driver2 = ver;
fallback4:
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();
Console.WriteLine("And finally its driver");
Console.ForegroundColor = ConsoleColor.Yellow;
string input4 = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.White;
if (input4 == "driver help")
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Valid drivers are:");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Max Verstappen\r\nCharles Leclerc\r\nSergio Perez\r\nCarlos Sainz\r\nGeorge Russell\r\nLewis Hamilton\r\nFernando Alonso\r\nEsteban Ocon\r\nValterri Bottas\r\nGuanyu Zhou\r\nDaniel Ricciardo\r\nLando Norris\r\nSebastian Vettel\r\nLance Stroll\r\nKevin Magnussen\r\nMick Schumacher\r\nYuki Tsunoda\r\nPierre Gasly\r\nNicholas Latifi\r\nAlexander Albon");
    goto fallback4;
}
else if (input4.ToLower() == "max verstappen" || input4.ToLower() == "max" || input4.ToLower() == "verstappen" || input4.ToLower() == "ver")
{
    driver2 = ver;
}
else if (input4.ToLower() == "sergio perez" || input4.ToLower() == "sergio" || input4.ToLower() == "perez" || input4.ToLower() == "per" || input4.ToLower() == "checo")
{
    driver2 = per;
}
else if (input4.ToLower() == "charles leclerc" || input4.ToLower() == "charles" || input4.ToLower() == "leclerc" || input4.ToLower() == "lec")
{
    driver2 = lec;
}
else if (input4.ToLower() == "carlos sainz" || input4.ToLower() == "carlos" || input4.ToLower() == "sainz" || input4.ToLower() == "sai")
{
    driver2 = sai;
}
else if (input4.ToLower() == "lewis hamilton" || input4.ToLower() == "lewis" || input4.ToLower() == "hamilton" || input4.ToLower() == "ham")
{
    driver2 = ham;
}
else if (input4.ToLower() == "george russell" || input4.ToLower() == "george" || input4.ToLower() == "russell" || input4.ToLower() == "rus")
{
    driver2 = rus;
}
else if (input4.ToLower() == "fernando alonso" || input4.ToLower() == "fernando" || input4.ToLower() == "alonso" || input4.ToLower() == "alo")
{
    driver2 = alo;
}
else if (input4.ToLower() == "esteban ocon" || input4.ToLower() == "esteban" || input4.ToLower() == "ocon" || input4.ToLower() == "oco")
{
    driver2 = oco;
}
else if (input4.ToLower() == "lando norris" || input4.ToLower() == "lando" || input4.ToLower() == "norris" || input4.ToLower() == "nor")
{
    driver2 = nor;
}
else if (input4.ToLower() == "daniel ricciardo" || input4.ToLower() == "daniel" || input4.ToLower() == "ricciardo" || input4.ToLower() == "ric")
{
    driver2 = ric;
}
else if (input4.ToLower() == "valterri bottas" || input4.ToLower() == "valterri" || input4.ToLower() == "bottas" || input4.ToLower() == "bot")
{
    driver2 = bot;
}
else if (input4.ToLower() == "zhou guanyu" || input4.ToLower() == "zhou" || input4.ToLower() == "guanyu" || input4.ToLower() == "zho")
{
    driver2 = zho;
}
else if (input4.ToLower() == "sebastian vettel" || input4.ToLower() == "sebastian" || input4.ToLower() == "vettel" || input4.ToLower() == "vet" || input4.ToLower() == "seb")
{
    driver2 = vet;
}
else if (input4.ToLower() == "lance stroll" || input4.ToLower() == "lance" || input4.ToLower() == "stroll" || input4.ToLower() == "str")
{
    driver2 = str;
}
else if (input4.ToLower() == "kevin magnussen" || input4.ToLower() == "kevin" || input4.ToLower() == "magnussen" || input4.ToLower() == "mag" || input4.ToLower() == "kmag" || input4.ToLower() == "kev")
{
    driver2 = mag;
}
else if (input4.ToLower() == "mick schumacher" || input4.ToLower() == "mick" || input4.ToLower() == "schumacher" || input4.ToLower() == "msc" || input4.ToLower() == "schumi")
{
    driver2 = msc;
}
else if (input4.ToLower() == "pierre gasly" || input4.ToLower() == "pierre" || input4.ToLower() == "gasly" || input4.ToLower() == "gas")
{
    driver2 = gas;
}
else if (input4.ToLower() == "yuki tsunoda" || input4.ToLower() == "yuki" || input4.ToLower() == "tsunoda" || input4.ToLower() == "tsu")
{
    driver2 = tsu;
}
else if (input4.ToLower() == "alexander albon" || input4.ToLower() == "alexander" || input4.ToLower() == "albon" || input4.ToLower() == "alb" || input4.ToLower() == "alex")
{
    driver2 = alb;
}
else if (input4.ToLower() == "nicholas latifi" || input4.ToLower() == "nicholas" || input4.ToLower() == "latifi" || input4.ToLower() == "lat" || input4.ToLower() == "goat" || input4.ToLower() == "the goat")
{
    driver2 = lat;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("'" + input4 + "'" + " is not a valid driver, try again");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Type 'driver help' to get a list of valid drivers");
    goto fallback4;
}

decimal rating1 = car1.performance * (driver1.skill / 100m);
decimal rating2 = car2.performance * (driver2.skill / 100m);
System.Threading.Thread.Sleep(3000);

if (rating1 > rating2)
{
    Console.WriteLine("\r\n");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(driver1.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" in his ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(car1.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" gets an overall rating of ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(rating1);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(".");
    System.Threading.Thread.Sleep(3000);
    Console.Write("Therefore he beats ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(driver2.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" driving the ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(car2.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(", who sits at a rating of ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(rating2);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(".");
}
else
{
    Console.WriteLine("\r\n");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(driver2.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" in his ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(car2.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" gets an overall rating of ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(rating2);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(".");
    System.Threading.Thread.Sleep(3000);
    Console.Write("Therefore he beats ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(driver1.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" driving the ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(car1.name);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(", who sits at a rating of ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(rating1);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(".");
}
*/