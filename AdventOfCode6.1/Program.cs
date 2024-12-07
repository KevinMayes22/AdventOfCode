using System.Numerics;
namespace AdventOfCode6._1;



class Vector()
{
    public int Y { get; set; }
    public int X { get; set; }

    public Vector(int xinput = 0, int yinput = 0) : this()
    {
        X = xinput;
        Y = yinput;
    }
}

class Program
{
    
    
    static void Main()
    {
        
        // Need to find the guard | DONE
        // Need to 
        var input = File.ReadAllText(Environment.CurrentDirectory + "\\input.txt");
        var inputRows = input.Split("\r\n");
        char[,] grid = new char[inputRows.Length, inputRows[0].Length];

        Vector SheGuard = new Vector() {X = 0, Y = 0};
        
        Vector Up = new Vector() { X = 0, Y = -1};  
        Vector Right = new Vector() { X = +1, Y = 0};
        Vector Left = new Vector() { X = -1, Y = 0};
        Vector Down = new Vector() { X = 0, Y = +1};

        List<Vector> Vectors = new List<Vector>();
        Vectors.Add(Up);
        Vectors.Add(Right);
        Vectors.Add(Left);
        Vectors.Add(Down);
        
        Vector Direction = Up;
        
        char SheGuardSymbol = '^';
        char Obstacle = '#';
        char Space = '.';
        char Breadcrumb = 'B';
        
        // Buillding the Grid
        for (int yAxis = 0; yAxis < inputRows.Length; yAxis++)
        {
            for (int xAxis = 0; xAxis < inputRows[yAxis].Length; xAxis++)
            {
                grid[yAxis, xAxis] = inputRows[yAxis][xAxis];
            }
        }
        
        // Finding SheGuard
        for (int yAxis = 0; yAxis < grid.GetLength(0); yAxis++)
        {
            for (int xAxis = 0; xAxis < grid.GetLength(1); xAxis++)
            {
                if (grid[yAxis, xAxis] == SheGuardSymbol)
                {
                    SheGuard.X = xAxis;
                    SheGuard.Y = yAxis;
                }
            }
        }
        
        // Navigating Grid
        bool puzzleComplete = false;
        int DirectionCounter = 0;
        Direction = Vectors[DirectionCounter];

        while (!puzzleComplete)
        {
            int printCounter = 0;
            foreach (var character in grid)
            {
                if (printCounter == grid.GetLength(0)) { Console.WriteLine("");
                    printCounter = 0;
                }
                Console.Write(character);
                printCounter++;
            }

            Console.WriteLine("\n##############");
            if (((SheGuard.X + Direction.X) > grid.GetLength(0)) && ((SheGuard.Y + Direction.Y) > grid.GetLength(1)))
            {
                puzzleComplete = true;
            }
            
            if (grid[SheGuard.X + Direction.X, SheGuard.Y + Direction.Y] == Obstacle)
            {
                Console.WriteLine("TESTME");
                if (DirectionCounter <= 2)
                {
                    DirectionCounter++;
                }
                else
                {
                    DirectionCounter = 0;
                }
                Direction = Vectors[DirectionCounter];
            }
            else
            {
                
                grid[SheGuard.Y, SheGuard.X] = Breadcrumb;
                SheGuard.X += Direction.X;
                SheGuard.Y += Direction.Y;
                grid[SheGuard.Y, SheGuard.X] = SheGuardSymbol;
            }




            Thread.Sleep(2000);
        }
        Console.Write("Doing things");
    }
}