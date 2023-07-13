//Design
const int rows = 20;
const int cols = 40;       
const int speed = 500; //1000 = 1sekunda
const char live = '#';
const char dead = ' ';
bool[,] grid = new bool[rows, cols];

IntroBanner();
Meni1(ref grid);

while (true)
{
    PrintGrid(grid);

    bool[,] newGen = new bool[rows, cols];
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < cols; y++)
        {
            int liveNeighbors = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    bool inRange = (i >= 0 && i < rows && j >= 0 && j < cols);
                    bool currentCell = (i != x || j != y);

                    if (currentCell && inRange && grid[i, j])
                        liveNeighbors++;     
                }
            }
              //Rules:
              //1.st rule:  Vsaka živa (live) celica, ki ima manj kot 2 (liveNeighbors < 2) živa soseda, umre
              //2.nd rule:  Vsaka živa (live) celica, ki ima 2 ali 3 (liveNeighbors == 2||3) žive sosede, živi naprej.
              //3.rd rule:  Vsaka živa (live) celica, ki ima več, kot 3 (liveNeighbors > 3) žive sosede umre.
              //4.th rule:  Vsaka mrtva (dead) celica, ki ima natančno 3 (liveNeighbors == 3) žive sosede postane živa.
              newGen[x, y] = (grid[x, y]) ? (liveNeighbors == 2 || liveNeighbors == 3) : (liveNeighbors == 3);
        }
    }
    grid = newGen;
    Thread.Sleep(speed);
}
static void IntroBanner()
{
    Console.WriteLine("##############################################");
    Console.WriteLine("#                                            #");
    Console.WriteLine("#    Welcome to CONWAY’S GAME OF LIFE        #");
    Console.WriteLine("#                                            #");
    Console.WriteLine("#    This game is part of my seminar work!   #");
    Console.WriteLine("#                                            #");
    Console.WriteLine("#    Version 1.0, date 26/05/2023            #");
    Console.WriteLine("#                                            #");
    Console.WriteLine("##############################################");

    Console.WriteLine("\n\n##############################################################################");
    Console.WriteLine("#                                                                            #");
    Console.WriteLine("#    Rules of the game:                                                      #");
    Console.WriteLine("#    Any living cell with less than 2 living neighbors dies                  #");
    Console.WriteLine("#    Every living cell that has two or three living neighbors lives on.      #");
    Console.WriteLine("#    Any living cell with more than three living neighbors dies.             #");
    Console.WriteLine("#    Every dead cell that has exactly three living neighbors gets revived.   #");
    Console.WriteLine("#                                                                            #");
    Console.WriteLine("##############################################################################");

    Console.WriteLine("\nPress any key to continue!");
    Console.ReadKey();

}
static void Meni1(ref bool[,] grid)
{
    Console.Clear();
    Console.WriteLine("# # # # # # # # # # # # # # # # # # # # # # # ");
    Console.WriteLine(" # # # # # # # # # # # # # # # # # # # # # # #");
    Console.WriteLine("\n  Pick your starting format");
    Console.WriteLine("\tFormats created by developer press [0]");
    Console.WriteLine("\tRandom starting format press [1]");
    switch (int.Parse(Console.ReadLine()))
    {
        case 0:
            Meni2(ref grid);
            break;
        case 1:
            Random(ref grid);
            break;
        default:
            break;
    }
 

}
static void Meni2(ref bool[,] grid) 
{
    Console.Clear();
    Console.WriteLine("# # # # # # # # # # # # # # # # # # # # # # # ");
    Console.WriteLine(" # # # # # # # # # # # # # # # # # # # # # # #");
    Console.WriteLine("\n  Pick your starting format");
    Console.WriteLine("\tTop down roof press [0]");
    Console.WriteLine("\tHello World text press [1]");
    string filePath = @"";
    switch (int.Parse(Console.ReadLine()))
    {
        case 0:
            filePath = @"RoofTop.txt";
            break;
        case 1:
            filePath = @"HelloWorld.txt";
            break;
        default:
            break;
    }
    FileToBool(filePath, ref grid);
}
static void Random(ref bool[,] grid)
{
    Random rand = new Random();
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < cols; y++)
            grid[x, y] = rand.Next(2) == 0;
    }
}
static void FileToBool(string filePath, ref bool[,] grid)
{
    string line = File.ReadAllText(filePath);
    int index = 0;
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < cols; y++)
        {
            int input = (Convert.ToInt32(line[index]));
            if (input == 49)
                grid[x, y] = true;
            else if (input == 48)
                grid[x, y] = false;
            index++;
        }
    }
}
static void PrintGrid(bool[,] grid) 
{ 
    Console.Clear();
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < cols; y++)
        {
            if (grid[x, y] == true)
                Console.Write(live);
            else
                Console.Write(dead);
        }
        Console.WriteLine();
    }
}