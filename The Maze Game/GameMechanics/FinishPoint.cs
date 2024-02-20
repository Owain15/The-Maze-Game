using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Maze_Game.GameMechanics
{
    internal class FinishPointClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string FinishMarker;
        private ConsoleColor FinishColor;

        public FinishPointClass(int x, int y)
        {
            X = x;
            Y = y;
            FinishMarker = "X";
            FinishColor = ConsoleColor.Green;
        }

        public void Draw()
        {

            Console.ForegroundColor = FinishColor;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(FinishMarker);
            Console.ResetColor();

        }
    }
}
