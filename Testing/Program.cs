using System;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int rows = 20;        //visina
            const int cols = 40;        //sirina
            const char live = '#';      //prikazane
            const char dead = ' ';      //praznina
            bool[,] grid = new bool[rows, cols];

            Random rand = new Random();             // kreiramo generator ki nam bo v nadaljevanju pomagal pri kreaciji zacethih vrednosti
            for (int x = 0; x < rows; x++)    // odpremo vrsto
            {
                for (int y = 0; y < cols; y++)    //odpira pozicije v vrsti 
                {
                    grid[x, y] = rand.Next(2) == 0; //random.Next(2) 2 je za dolocitev max vrednosti rand   // ==0 je za bool=true  //tukaj uporabimo rand generator za kreiranje 1 in 0 vrednosti, ki se prevedejo v true false z ==0
                }
            }
        }    
    }
}