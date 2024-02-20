using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.GameMechanics;

namespace The_Maze_Game.Levels
{
    internal class Level4
    {
        GameLoop GameMec = new GameLoop();
        LevelArrays Maze = new LevelArrays();

        LevelBuilderClass CurrentLevel;
        PlayerClass CurrentPlayer; 
        FinishPointClass CurrentFinishPoint;

        LockAndKey LockAndKeyBlue;
        LockAndKey LockAndKeyYellow;

        SlideBlock SlideBlockOne;
        SlideBlock SlideBlockTwo;

        public void Run()
        {
            CurrentLevel = new LevelBuilderClass(Maze.GetLevelArray(4));
            CurrentPlayer = new PlayerClass(2, 7);
            CurrentFinishPoint = new FinishPointClass(6, 11);

            LockAndKeyBlue = new LockAndKey(4, 9, 6, 7, ConsoleColor.Blue);
            LockAndKeyYellow = new LockAndKey(8, 5, 6, 3, ConsoleColor.Yellow);

            SlideBlockOne = new SlideBlock(6, 9);
            SlideBlockTwo = new SlideBlock(6, 5);

            Console.Clear();

            GameLoop();

            Level1 NextLevel = new Level1();
            NextLevel.Run();
        }
     
        private void GameLoop()

        {
            bool HasPlayerReachedFinish = false;

            Console.Clear();
            DrawOpeningFrame();


            while (HasPlayerReachedFinish != true)
            {

               
                HandlePlayerInput
                    (CurrentPlayer, CurrentLevel, LockAndKeyBlue,LockAndKeyYellow, SlideBlockOne,SlideBlockTwo, GameMec.GetInput());
               

                if (LockAndKeyBlue.IsKeyPickedUp != true) { LockAndKeyBlue.DoesPlayerHaveKey(CurrentPlayer.x,CurrentPlayer.y); }
                if (LockAndKeyYellow.IsKeyPickedUp != true) { LockAndKeyYellow.DoesPlayerHaveKey(CurrentPlayer.x, CurrentPlayer.y); }
                HasPlayerReachedFinish = GameMec.HasPlayerReachedGoal(CurrentLevel, CurrentPlayer);
            }

        }
        private void HandlePlayerInput
            (PlayerClass CurrentPlayer, LevelBuilderClass CurrentLevel, LockAndKey lockAndKeyOne,LockAndKey lockAndKeyTwo, 
            SlideBlock SlideBlockOne,SlideBlock SlideBlockTwo, ConsoleKey Input)
        {

            bool LockOneCheck = false; 
            bool LockTwoCheck = false;
            bool SlideBlockOneCheck = false;
            bool SlideBlockTwoCheck = false;

            int[] MoveReff = new int[2];

            MoveReff = GameMec.ConvertMoveMade(Input);

            int[] PreposedPlayerMove = new int[2];
            PreposedPlayerMove = GameMec.MoveLoopCheck(CurrentPlayer.x, CurrentPlayer.y, CurrentLevel, MoveReff);

            if (CurrentLevel.IsPositionClear(PreposedPlayerMove[0], PreposedPlayerMove[1]))
            {
                SlideBlockOneCheck = SlideBlockOne.HasBlockBeenPushed(PreposedPlayerMove[0], PreposedPlayerMove[1]);
                if(SlideBlockOneCheck==true)
                {   
                    // if Block is free to move.
                    SlideBlockOne.MoveSlideBlock(PreposedPlayerMove[0], PreposedPlayerMove[1],CurrentLevel, MoveReff);
                    SlideBlockOne.Draw();
                }
                SlideBlockTwoCheck = SlideBlockTwo.HasBlockBeenPushed(PreposedPlayerMove[0], PreposedPlayerMove[1]);
                if (SlideBlockTwoCheck == true)
                {
                    SlideBlockTwo.MoveSlideBlock(PreposedPlayerMove[0], PreposedPlayerMove[1], CurrentLevel, MoveReff);
                    SlideBlockTwo.Draw();
                }

                LockOneCheck = LockAndKeyBlue.LockCheck(PreposedPlayerMove[0], PreposedPlayerMove[1]);
                if (LockOneCheck == true)
                {
                    if (LockAndKeyBlue.IsKeyPickedUp != true)
                    {
                        PreposedPlayerMove[0] = CurrentPlayer.x;
                        PreposedPlayerMove[1] = CurrentPlayer.y;
                    }

                }
              
                LockTwoCheck = LockAndKeyYellow.LockCheck(PreposedPlayerMove[0], PreposedPlayerMove[1]);
                if (LockTwoCheck == true)
                {
                    PreposedPlayerMove[0] = CurrentPlayer.x;
                    PreposedPlayerMove[1] = CurrentPlayer.y;
                }
              
                CurrentPlayer.DrawMove(PreposedPlayerMove);
            }


        }
          private void DrawOpeningFrame() 
        {
        CurrentLevel.Draw();
        CurrentPlayer.Draw();
        CurrentFinishPoint.Draw();
        LockAndKeyBlue.Draw();
        LockAndKeyYellow.Draw();
        SlideBlockOne.Draw();
        SlideBlockTwo.Draw();
        }
    }
}
