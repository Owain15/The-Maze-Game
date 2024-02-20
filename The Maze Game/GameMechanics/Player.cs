using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.Levels;

namespace The_Maze_Game.GameMechanics
{
    internal class PlayerClass
    {

        public int x { get; set; }
        public int y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;


        public PlayerClass(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
            PlayerMarker = "0";
            PlayerColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(PlayerMarker);
            Console.ResetColor();
        }
        public void DrawMove(int[] PreposedMove)
        {

            ClearPlayer();

            x = PreposedMove[0];
            y = PreposedMove[1];

            Draw();
        }
        public void ClearPlayer()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }

    }
}
