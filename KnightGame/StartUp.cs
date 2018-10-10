using System;

namespace KnightGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[rows][];

            GetJaggedArray(jaggedArray);

            var tempRow = 0;
            var tempCol = 0;
            var removeKnights = 0;

            while (true)
            {
                var maxAtacked = 0;

                for (int row = 0; row < jaggedArray.Length; row++)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        var atacker = 0;

                        if (jaggedArray[row][col] == 'K')
                        {
                            if (IsInside(jaggedArray, row-2, col-1)&& jaggedArray[row-2][col-1] == 'K')
                            {
                                atacker++;
                            }
                            if (IsInside(jaggedArray, row - 2, col + 1) && jaggedArray[row - 2][col + 1] == 'K')
                            {
                                atacker++;
                            }
                            if (IsInside(jaggedArray, row+ 2, col - 1) && jaggedArray[row + 2][col - 1] == 'K')
                            {                          
                                atacker++;             
                            }                          
                            if (IsInside(jaggedArray, row+ 2, col + 1) && jaggedArray[row + 2][col + 1] == 'K')
                            {
                                atacker++;
                            }
                            //
                            if (IsInside(jaggedArray, row - 1, col - 2) && jaggedArray[row - 1][col - 2] == 'K')
                            {
                                atacker++;
                            }
                            if (IsInside(jaggedArray, row - 1, col + 2) && jaggedArray[row - 1][col + 2] == 'K')
                            {
                                atacker++;
                            }
                            if (IsInside(jaggedArray, row + 1, col - 2) && jaggedArray[row + 1][col - 2] == 'K')
                            {
                                atacker++;
                            }
                            if (IsInside(jaggedArray, row + 1, col + 2) && jaggedArray[row + 1][col + 2] == 'K')
                            {
                                atacker++;
                            }

                        }
                        if (atacker > maxAtacked)
                        {
                            maxAtacked = atacker;
                            tempCol = col;
                            tempRow = row;

                        }
                    }
                }
                if (maxAtacked > 0)
                {
                    jaggedArray[tempRow][tempCol] = '0';
                    removeKnights++;
                }
                else
                {
                    Console.WriteLine(removeKnights);
                    break;
                }
            }

        }

        private static bool IsInside(char[][] jaggedArray, int row, int col)
        {
            return row>=0 && row< jaggedArray.Length && col>=0 && col<jaggedArray.Length;
        }

        private static void GetJaggedArray(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
