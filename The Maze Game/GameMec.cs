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
        public void DrawMove(ConsoleKey Input)
        {
            GameLoop Game = new GameLoop();
            int[] PlayerReff = Game.ConvertMoveMade(Input);

            ClearPlayer();

            x = x + PlayerReff[0];
            y = y + PlayerReff[1];

            Draw();
        }
        public  void ClearPlayer()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
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

    internal class LockAndKey
    {

        private int lockX { get; set; }
        private int lockY { get; set; }
        public int LockX { get { return lockX; } }
        public int LockY { get { return lockY; } }

        private int KeyX { get; set; }
        private int KeyY { get; set; }

        private string LockMarker;
        private string KeyMarker;

        private ConsoleColor LockAndKeyColor;

        public bool IsKeyPickedUp;
        private bool HasKeyBeenUsed;

        public LockAndKey(int InitialLockX, int InitialLockY, int InitialKeyX, int InitialKeyY, ConsoleColor color)
        {
            lockX = InitialLockX;
            lockY = InitialLockY;

            KeyX = InitialKeyX;
            KeyY = InitialKeyY;

            LockMarker = "$";
            KeyMarker = "~";
            LockAndKeyColor = color;

            IsKeyPickedUp = false;
            HasKeyBeenUsed = false;

        }

        public void Draw()
        {
            if (HasKeyBeenUsed == false)
            {
                Console.ForegroundColor = LockAndKeyColor;
                Console.SetCursorPosition(LockX, LockY);
                Console.WriteLine(LockMarker);
                Console.ResetColor();
            }
            if (IsKeyPickedUp == false)
            {
                Console.ForegroundColor = LockAndKeyColor;
                Console.SetCursorPosition(KeyX, KeyY);
                Console.WriteLine(KeyMarker);
                Console.ResetColor();
            }

        }

        public bool DoesPLayerHaveKey(LockAndKey CurrentLockAndKey, int CurrentPlayerX,int CurrentPlayerY)
        {
            if (CurrentPlayerX == KeyX) 
            { 
             if (CurrentPlayerY == KeyY) 
                { return CurrentLockAndKey.IsKeyPickedUp = true; }
                
            }

            return false;
        }
        
        public bool UseKeyOnDoor(LockAndKey CurrentLockAnKey, int CurrentPlayerX,int CurrentPlayerY)
        {
            if (CurrentPlayerX == LockX)
            {
                if (CurrentPlayerY == LockY)
                {
                    if (CurrentLockAnKey.IsKeyPickedUp == true)
                    { return CurrentLockAnKey.HasKeyBeenUsed = true; }
                }

            }

            return false;
        }

    }

    internal class SlideBlock
    {
        public int SlideBlockX;
        public int SlideBlockY;

        public bool BlockBeenPushed;
        ConsoleKey PlayersInput;
        public bool BlockFreeToMove;

        string SlideBlockMarker = "#";
        ConsoleColor SlideBlockColor = ConsoleColor.Red;

        public SlideBlock(int initialX, int initialY) 
        { 
         SlideBlockX = initialX;
         SlideBlockY = initialY;
        }

        public void Draw()
        {
            Console.ForegroundColor = SlideBlockColor;
            Console.SetCursorPosition(SlideBlockX, SlideBlockY);
            Console.WriteLine(SlideBlockMarker);
            Console.ResetColor();
        }

        public bool HasBlockBeenPushed(int PreposedPlayerX, int PreposedPlayerY) 
        {
            if (SlideBlockX == PreposedPlayerX )
            {
                if (SlideBlockY == PreposedPlayerY) { return true;}
            }
            return false;
        }
        public bool IsBlockFreeToMove()
        {

            return false;
        }


    }

    internal class Button
    {
        public int X;
        public int Y;
        public int[] ButtonPositon;

        public bool ButtonPressed;
        
        private string ButtonMarker = "*";
        private ConsoleColor ButtonColor = ConsoleColor.Blue;

        public Button( int ButtonX, int ButtonY) 
        {
            X = ButtonX;
            Y = ButtonY;
            ButtonPositon = new int[2] { X, Y };

            ButtonPressed = false;
        }
        public void Draw()
        {
            if (ButtonPressed == false)
            {
                Console.ForegroundColor = ButtonColor;
                Console.SetCursorPosition(X, Y);
                Console.WriteLine(ButtonMarker);
                Console.ResetColor();
            }
        }
        public bool ButtonPushedCheck( int ObjectX, int ObjectY )
        {

            if (ButtonPositon[0] == ObjectX)
            { if (ButtonPositon[1] == ObjectY)
                { ButtonPressed = true; } }
            else { ButtonPressed = false; }

            return ButtonPressed;
        }
    }
}



