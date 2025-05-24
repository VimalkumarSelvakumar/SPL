using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameleon
{
    public static class GameBot
    {
        public static void GetNextMove(string possibleMoves,string boardSize, string boardStatus)
        {
            int[] numbers = possibleMoves.Split(',')
                            .Select(int.Parse)
                            .ToArray();
           int[]rowColumns = boardSize.Split(',')
                            .Select(int.Parse)
                            .ToArray();


        }
    }
}
