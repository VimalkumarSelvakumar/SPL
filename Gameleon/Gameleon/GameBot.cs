using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameleon
{
    public static class GameBot
    {
        public static void GetNextMove(string possibleMoves,string boardSize, string boardStatus, string currentPlayer,)
        {
            int[] numbers = possibleMoves.Split(',')
                            .Select(int.Parse)
                            .ToArray();
            int[] rowColumns = boardSize.Split(',')
                             .Select(int.Parse)
                             .ToArray();
            string[] board = boardStatus.Split(',');
            foreach(int number in numbers)
            {
                if (board[number] == )
                {

                }
            }
            

        }

        private static string[,] ExtractBoardStatus(string input, int rows, int cols)
        {
           
            string[] flatArray = input.Split(',');

           
            string[,] grid = new string[rows, cols];

            for (int i = 0; i < flatArray.Length; i++)
            {
                int r = i / cols;
                int c = i % cols;
                grid[r, c] = flatArray[i];
            }
            return grid;
        }
    }
}
