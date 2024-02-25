using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.GameMechanics;
using The_Maze_Game.Menu;

namespace The_Maze_Game.Levels
{
    internal class GameLoop
    {
       
        public ConsoleKey GetInput()
        {
            ConsoleKey Move;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Move = keyInfo.Key;
            } while (Console.KeyAvailable);

            return Move;
        }
        public void LockAndKeyCheck(LockAndKey CurrentLockAndKey, PlayerClass CurrentPlayer)
        {
            CurrentLockAndKey.DoesPlayerHaveKey( CurrentPlayer.x, CurrentPlayer.y);
            CurrentLockAndKey.IsDoorLocked(CurrentPlayer.x, CurrentPlayer.y);
        }
        public bool HasPlayerReachedGoal(LevelBuilderClass Level, PlayerClass Player)
        {
            string elimentAtPlayePos = Level.GetElementAt(Player.x, Player.y);
            if (elimentAtPlayePos == "X")
            {
                return true;
            }
            return false;
        }
        public int[] ConvertMoveMade(ConsoleKey MoveMade)
        {
            int[] Reff = new int[2] { 0, 0 };

            switch (MoveMade)
            {
                case ConsoleKey.UpArrow:
                    { Reff[1] = -1; }
                    break;
                case ConsoleKey.DownArrow:
                    { Reff[1] = +1; }
                    break;
                case ConsoleKey.LeftArrow:
                    { Reff[0] = -1; }
                    break;
                case ConsoleKey.RightArrow:
                    { Reff[0] = +1; }
                    break;
            }

            return Reff;
        }
        public int[] MoveLoopCheck(int ObjectX, int ObjectY, LevelBuilderClass CurrentLevel, int[] MoveReff)
        {
           
            int X = ObjectX + MoveReff[0];
            int Y = ObjectY + MoveReff[1];

            if(X < 0) { X = CurrentLevel.GetCols() - 1; }
            if (X > CurrentLevel.GetCols() - 1) { X = 0; }

            if(Y < 0) { Y = CurrentLevel.GetRows() - 1; }
            if (Y > CurrentLevel.GetRows()-1) { Y = 0; }

            int[] Result = new int[2] {X,Y};

            return Result;

        }
        public bool ButtonWallCheck(int[] ButtonWallReff, int ObjectX, int ObjectY, int[] MoveReff)
        {
            bool Result = false;

            int PreposedX = ObjectX + MoveReff[0];
            int PreposedY = ObjectY + MoveReff[1];

            if(PreposedX == ButtonWallReff[0])
            { if(PreposedY == ButtonWallReff[1]) { Result = true; } }

            return Result;

        }
        public void ExtraInputCheck(int LevelReff, ConsoleKey Input)
        {
            HomePage ManinMenu = new HomePage();

            Level1 LevelOne = new Level1();
            Level2 levelTwo = new Level2();
            Level3 LevelThree = new Level3();
            Level4 LevelFour = new Level4();
            Level5 LevelFive = new Level5();

            switch (Input) 
            {
             case ConsoleKey.Escape:
                    { ManinMenu.RunMainMenu(); } break;
             case ConsoleKey.Backspace: 
                    { 
                     switch (LevelReff)
                        {
                            case 1:{ LevelOne.Run(); }
                                break;
                            case 2:{ levelTwo.Run(); }
                                break;
                            case 3:{ LevelThree.Run(); }
                                break;
                            case 4: { LevelFour.Run(); }
                                break;
                            case 5: { LevelFive.Run(); }
                                break;

                        }
                    } break;
            }
        }





    }


}


