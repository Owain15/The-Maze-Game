using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.GameMechanics;
using The_Maze_Game.Menu;

namespace The_Maze_Game.Levels
{
    internal class Level3
    {
        int LevelReff = 3;

        GameLoop GameMec = new GameLoop();
        LevelArrays Maze = new LevelArrays();

        LevelBuilderClass CurrentLevel;
        PlayerClass CurrentPlayer;
        LockAndKey LockAndKeyBlue;
        FinishPointClass CurrentFinishPoint;

        public void Run()
        {
            CurrentLevel = new LevelBuilderClass(Maze.GetLevelArray(3));
            CurrentPlayer = new PlayerClass(4, 4);
            LockAndKeyBlue = new LockAndKey(12,4,10,2, ConsoleColor.Blue);
            CurrentFinishPoint = new FinishPointClass(14,4);

            Console.Clear();

            GameLoop();

            Level4 NextLevel = new Level4();
            NextLevel.Run();

        }
        private void GameLoop()
            {
                bool HasPlayerReachedFinish = false;
               
                Console.Clear();
                DrawOpeningFrame();
            
            
                while (HasPlayerReachedFinish != true)
                {
                    
                    LockAndKeyBlue.Draw();
                    HandlePlayerInput(CurrentPlayer, CurrentLevel, LockAndKeyBlue, GameMec.GetInput());
                    GameMec.LockAndKeyCheck(LockAndKeyBlue, CurrentPlayer);

                    HasPlayerReachedFinish = GameMec.HasPlayerReachedGoal(CurrentLevel, CurrentPlayer);
                }

        }
        private void DrawOpeningFrame()
        {

         CurrentLevel.Draw();
         CurrentPlayer.Draw();
         LockAndKeyBlue.Draw();
         CurrentFinishPoint.Draw();
         
        }
        private void HandlePlayerInput(PlayerClass CurrentPlayer, LevelBuilderClass CurrentLevel, LockAndKey lockAndKey, ConsoleKey Input)
        {
            GameMec.ExtraInputCheck( LevelReff, Input);

            bool IsMoveBlocked = false;

            int[] MoveReff = new int[2];

            MoveReff = GameMec.ConvertMoveMade(Input);

            int[] PreposedPlayerMove = new int[2];
            PreposedPlayerMove = GameMec.MoveLoopCheck(CurrentPlayer.x, CurrentPlayer.y, CurrentLevel, MoveReff);

            if (CurrentLevel.IsPositionClear(PreposedPlayerMove[0], PreposedPlayerMove[1]))
            {
                IsMoveBlocked = LockAndKeyBlue.LockCheck(PreposedPlayerMove[0], PreposedPlayerMove[1]);
                if (IsMoveBlocked == true)
                {
                    PreposedPlayerMove[0] = CurrentPlayer.x;
                    PreposedPlayerMove[1] = CurrentPlayer.y;
                }
                CurrentPlayer.DrawMove(PreposedPlayerMove);
            }
            
            
        }

      


    }
}
