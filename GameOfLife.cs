/* About

Conway's Game of Life, also known as the Game of Life is actually a zero-player game,
meaning that its evolution is determined by its initial state, needing no input from human players.
One interacts with the Game of Life by creating an initial population and observing how it evolves.


Rules :
The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells,
each of which is in one of two possible states, live or dead.

Every cell interacts with its eight neighbors, which are the cells that are directly horizontally,
vertically, or diagonally adjacent. At each step in time, the following transitions occur:

1.Any live cell with fewer than two live neighbors dies (referred to as underpopulation).

2.Any live cell with more than three live neighbors dies (referred to as overpopulation).

3.Any live cell with two or three live neighbors lives, unchanged, to the next generation.

4.Any dead cell with exactly three live neighbors will come to life.

Objective:

For a universe whose grid-size is (25,25), assuming the initial population (Generation 0) is seeded
in the grid, write a program to find the population pattern in N-th generation.
For input, assume that line 1 is the generation we are interested in to know its population; followed
by positions of live cells in generation-0 seeded as input configuration.

*/


/* 

Conventions: 

 int[,] grid ;   // The game board is a 2D array.
 grid[4][5] = 1; // Means that the cell at (4,5) is live.
 grid[4][5] = 0; // Means that the cell at (4,5) is dead.

 */

using System;
using System.Linq;

public class GameOfLife
{

    public static void Main()
    {

        Console.WriteLine("Enter the No of rows:");
        int M = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the No of columns:");
        int N = int.Parse(Console.ReadLine());

        int generation = int.Parse(Console.ReadLine());

        // Initailising 2 Dimentional array

        int[,] grid = new int[M, N];
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                grid[i, j] = 0;
            }
        }

        for (int n = 0; n < generation; n++)
        {
            int[] rowCol = Console.ReadLine().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (rowCol[0] == i && rowCol[1] == j)
                    {
                        grid[i, j] = 1;
                    }
                }
            }
        }

        Living(grid, M, N);
    }

    // Function to List of living popualtion
    static void Living(int[,] grid,
                            int M, int N)
    {
        int[,] future = new int[M, N];

        // Loop through every cell
        for (int l = 1; l < M - 1; l++)
        {
            for (int m = 1; m < N - 1; m++)
            {

                // finding no of Neighbours that are alive
                int aliveNeighbours = 0;
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                        aliveNeighbours +=
                                grid[l + i, m + j];

                // The cell needs to be subtracted from its neighbours as it was counted before
                aliveNeighbours -= grid[l, m];

                // Implementing the Rules of Life

                // Any live cell with fewer than two live neighbours dies
                if ((grid[l, m] == 1) &&
                            (aliveNeighbours < 2))
                    future[l, m] = 0;

                // Any live cell with more than three live neighbours dies, as if by overcrowding
                else if ((grid[l, m] == 1) &&
                            (aliveNeighbours > 3))
                    future[l, m] = 0;

                // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction
                else if ((grid[l, m] == 0) &&
                            (aliveNeighbours == 3))
                    future[l, m] = 1;

                // Remains the same
                else
                    future[l, m] = grid[l, m];
            }
        }

        Console.WriteLine("Living Population");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (future[i, j] == 1)
                {
                    var index = i.ToString() + ","+ j.ToString() ;
                    Console.WriteLine(index);
                }
            }
            Console.WriteLine();
        }

    }
}
