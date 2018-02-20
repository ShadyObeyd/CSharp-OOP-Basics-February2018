using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static int[,] matrix;
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = dimestions[0];
            int colsCount = dimestions[1];

            matrix = new int[rowsCount, colsCount];

            int matrixValue = 0;
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    matrix[i, j] = matrixValue++;
                }
            }

            string command = Console.ReadLine();

            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoCoords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilRow = evilCoords[0];
                int evilCol = evilCoords[1];

                while (IndexIsPositive(evilRow) && IndexIsPositive(evilCol))
                {
                    if (IsPositionValid(evilRow, evilCol))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                int ivoRow = ivoCoords[0];
                int ivoCol = ivoCoords[1];

                while (IndexIsPositive(ivoRow) && ivoCol < matrix.GetLength(1))
                {
                    if (IsPositionValid(ivoRow, ivoCol))
                    {
                        sum += matrix[ivoRow, ivoCol];
                    }

                    ivoCol++;
                    ivoRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static bool IsPositionValid(int row, int col)
        {
            bool rowIsValid = IndexIsPositive(row) && row < matrix.GetLength(0);
            bool colIsValid = IndexIsPositive(col) && col < matrix.GetLength(1);

            return rowIsValid && colIsValid;
        }

        private static bool IndexIsPositive(int index)
        {
            return index >= 0;
        }
    }
}