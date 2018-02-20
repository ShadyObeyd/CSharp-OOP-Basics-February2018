using System;
using System.Linq;

namespace _02.Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            room = new char[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();
            }

            string directions = Console.ReadLine();

            foreach (char direction in directions)
            {
                MoveEnemies();


                switch (direction)
                {
                    case 'U':
                        MoveUp();
                        break;
                    case 'D':
                        MoveDown();
                        break;
                    case 'L':
                        MoveLeft();
                        break;
                    case 'R':
                        MoveRight();
                        break;
                }
            }
        }

        static void MoveRight()
        {
            bool hasMoved = false;
            for (int row = 0; row < room.Length; row++)
            {
                char[] currentRow = room[row];

                for (int col = 0; col < currentRow.Length - 1; col++)
                {
                    if (currentRow[col] == 'S')
                    {
                        currentRow[col] = '.';
                        currentRow[col + 1] = 'S';
                        hasMoved = true;
                        break;
                    }
                }

                if (hasMoved)
                {
                    break;
                }
            }
        }

        static void MoveLeft()
        {
            bool hasMoved = false;
            for (int row = 0; row < room.Length; row++)
            {
                char[] currentRow = room[row];

                for (int col = 1; col < currentRow.Length; col++)
                {
                    if (currentRow[col] == 'S')
                    {
                        currentRow[col] = '.';
                        currentRow[col - 1] = 'S';
                        hasMoved = true;
                        break;
                    }
                }

                if (hasMoved)
                {
                    break;
                }
            }
        }

        static void MoveDown()
        {
            bool hasMoved = false;
            for (int row = 0; row < room.Length - 1; row++)
            {
                char[] currentRow = room[row];
                char[] nextRow = room[row + 1];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    if (currentRow[col] == 'S')
                    {
                        currentRow[col] = '.';
                        nextRow[col] = 'S';
                        hasMoved = true;
                        if (nextRow.Contains('N'))
                        {
                            int nikoIndex = Array.IndexOf(nextRow, 'N');
                            nextRow[nikoIndex] = 'X';
                            Console.WriteLine($"Nikoladze killed!");
                            PrintRoom();
                            Environment.Exit(0);
                        }
                        break;
                    }
                }

                if (hasMoved)
                {
                    break;
                }
            }
        }

        static void MoveUp()
        {
            bool hasMoved = false;
            for (int row = 1; row < room.Length; row++)
            {
                char[] previousRow = room[row - 1];
                char[] currentRow = room[row];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    if (currentRow[col] == 'S')
                    {
                        currentRow[col] = '.';
                        previousRow[col] = 'S';
                        hasMoved = true;
                        if (previousRow.Contains('N'))
                        {
                            int nikoIndex = Array.IndexOf(previousRow, 'N');
                            previousRow[nikoIndex] = 'X';
                            Console.WriteLine($"Nikoladze killed!");
                            PrintRoom();
                            Environment.Exit(0);
                        }
                        break;
                    }
                }

                if (hasMoved)
                {
                    break;
                }
            }
        }

        static void MoveEnemies()
        {
            bool hasDied = false;

            int samRow = 0;
            int samCol = 0;

            for (int row = 0; row < room.Length; row++)
            {
                char[] currentRow = room[row];
                for (int col = 0; col < currentRow.Length; col++)
                {

                    if (currentRow[col] == 'b')
                    {
                        if (col == currentRow.Length - 1)
                        {
                            currentRow[col] = 'd';
                        }
                        else
                        {
                            char currentEnemy = currentRow[col];
                            currentRow[col] = currentRow[col + 1];
                            currentRow[col + 1] = 'b';
                        }
                        break;
                    }
                    else if (currentRow[col] == 'd')
                    {
                        if (col == 0)
                        {
                            currentRow[col] = 'b';
                        }
                        else
                        {
                            char currentEnemy = currentRow[col];
                            currentRow[col] = currentRow[col - 1];
                            currentRow[col - 1] = currentEnemy;
                        }
                        break;
                    }
                }

                for (int col = 0; col < currentRow.Length; col++)
                {
                    if (currentRow.Contains('S') && currentRow.Contains('b'))
                    {
                        if (Array.IndexOf(currentRow, 'S') > Array.IndexOf(currentRow, 'b'))
                        {
                            samRow = row;
                            samCol = Array.IndexOf(currentRow, 'S');
                            currentRow[samCol] = 'X';
                            hasDied = true;
                        }
                    }
                    else if (currentRow.Contains('S') && currentRow.Contains('d'))
                    {
                        if (Array.IndexOf(currentRow, 'S') < Array.IndexOf(currentRow, 'd'))
                        {
                            samRow = row;
                            samCol = Array.IndexOf(currentRow, 'S');
                            currentRow[samCol] = 'X';
                            hasDied = true;
                        }
                    }
                }
            }

            if (hasDied)
            {
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                PrintRoom();
                Environment.Exit(0);
            }
        }

        static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                Console.WriteLine(room[row]);
            }
        }
    }
}