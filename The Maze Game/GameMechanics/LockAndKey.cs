using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Maze_Game.GameMechanics
{
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
        private void DrawLock() 
        {
            Console.ForegroundColor = LockAndKeyColor;
            Console.SetCursorPosition(lockX, lockY);
            Console.WriteLine(LockMarker);
            Console.ResetColor();
        }
        private void DrawKey() 
        {
            Console.ForegroundColor = LockAndKeyColor;
            Console.SetCursorPosition(KeyX, KeyY);
            Console.WriteLine(KeyMarker);
            Console.ResetColor();
        }
        public void Draw()
        {
            if(IsKeyPickedUp!=true) {DrawKey();}
            if(HasKeyBeenUsed!=true){DrawLock();}
        }
        public void DoesPlayerHaveKey(int PlayerX, int PlayerY)
        {
            if(PlayerX == KeyX)
            {
                if(PlayerY == KeyY) 
                {IsKeyPickedUp = true; }
            }
        
        }
        public bool LockCheck(int ObjectX, int ObjectY)
        {
            bool Result = false;
            if (ObjectX == LockX)
            {
                if (ObjectY == LockY)
                {
                    Result = true;
                    if (IsKeyPickedUp == true)
                    {
                        HasKeyBeenUsed = true;
                        Result = false;
                    }
                }
            }
            return Result;

        }
        public bool IsDoorLocked(int ObjectX, int ObjectY)
        {
            bool Result;
             
            if(ObjectX == LockX)
            {
                if(ObjectY == LockY) 
                {
                    if(IsKeyPickedUp==true)
                    {
                        HasKeyBeenUsed = true;
                    }
                }
            }
            Result = HasKeyBeenUsed;

            return Result;
        }


    }
}
