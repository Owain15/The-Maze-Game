using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace The_Maze_Game
{
    internal class Player
    {
        public int x { get; set; }
        public int y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;


        public Player(int initialX, int initialY)
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

    }

    internal class FinishPoint
    {
        public int X { get;  set;}
        public int Y { get; set; }
        private string FinishMarker;
        private ConsoleColor FinishColor;

        public FinishPoint(int x, int y)
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

    internal class Lock
    {

        public int LockX { get; set; }
        public int LockY { get; set; }

        private string LockMarker;

        private ConsoleColor LockColor;

        public Lock(int InitialLockX, int InitialLockY, ConsoleColor color)
        {
            LockX = InitialLockX;
            LockY = InitialLockY;

            LockMarker = "$";
            LockColor = color;
        }

        public void Draw()
        {

            Console.ForegroundColor = LockColor;
            Console.SetCursorPosition(LockX , LockY);
            Console.WriteLine(LockMarker);
            Console.ResetColor();

        }

        private bool doesPLayerHavekey()
        {
            

            return false;
        }
        
     

    }
}



