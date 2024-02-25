using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.GameMechanics;

namespace The_Maze_Game.Levels
{
    internal class Level4
    {
        int LevelReff = 4;

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

            Level5 NextLevel = new Level5();
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
            bool SlideBlockOneCheck = true;
            bool SlideBlockTwoCheck = true;
            bool MoveEvaluation = false;

            GameMec.ExtraInputCheck(LevelReff, Input);

            int[] MoveReff = new int[2];

            MoveReff = GameMec.ConvertMoveMade(Input);

            int[] PreposedPlayerMove = new int[2];
            PreposedPlayerMove = GameMec.MoveLoopCheck(CurrentPlayer.x, CurrentPlayer.y, CurrentLevel, MoveReff);

            if (CurrentLevel.IsPositionClear(PreposedPlayerMove[0], PreposedPlayerMove[1]))
            {
                if (SlideBlockOne.HasBlockBeenPushed(PreposedPlayerMove[0], PreposedPlayerMove[1]) == true)
                {
                    SlideBlockOneCheck = SlideBlockOne.IsBlockFreeToMove(CurrentLevel, MoveReff);

                    if (SlideBlockOneCheck == true)
                    {
                        SlideBlockOne.Draw();
                    }
                }

                
                if (SlideBlockTwo.HasBlockBeenPushed(PreposedPlayerMove[0], PreposedPlayerMove[1]) )
                {
                    SlideBlockTwoCheck = SlideBlockTwo.IsBlockFreeToMove(CurrentLevel, MoveReff);

                    if (SlideBlockTwoCheck == true)
                    {
                        SlideBlockTwo.Draw();
                    }

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

                MoveEvaluation = EvaluateMove(LockOneCheck, LockTwoCheck, SlideBlockOneCheck, SlideBlockTwoCheck);
               
                if( MoveEvaluation == true) 
                {  CurrentPlayer.DrawMove(PreposedPlayerMove); }

              
               
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
        private bool EvaluateMove(bool LockOne,bool LockTwo,bool BlockOne,bool BlockTwo)
        {
            bool Result = true;

            if (LockOne != false)  { Result = false; }
            if (LockTwo != false)  { Result = false; }
            if (BlockOne == false) { Result = false; }
            if (BlockTwo == false) { Result = false; }

            return Result;
        }
    }
}
