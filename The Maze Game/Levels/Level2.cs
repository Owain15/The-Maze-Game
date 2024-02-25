using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.GameMechanics;

namespace The_Maze_Game.Levels
{
    internal class Level2
    {
        int LevelReff = 2;

            GameLoop GameMec = new GameLoop();
            LevelArrays Maze = new LevelArrays();
           
            LevelBuilderClass CurrentLevel;
            PlayerClass CurrentPlayer;
            FinishPointClass CurrentFinishPoint;

        public void Run()
        {
            CurrentLevel = new LevelBuilderClass(Maze.GetLevelArray(2));
            CurrentPlayer = new PlayerClass(5, 6);
            CurrentFinishPoint = new FinishPointClass(12, 7);
            
            Console.Clear();

            GameLoop();

            Level3 NextLevel = new Level3(); 
            NextLevel.Run();

        }

        private void GameLoop()
        {
            bool HasPlayerReachedFinish = false;

            Console.Clear();
            DrawOpeningFrame();


            while (HasPlayerReachedFinish != true)
            {

                HandlePlayerInput(CurrentPlayer, CurrentLevel, GameMec.GetInput());



                HasPlayerReachedFinish = GameMec.HasPlayerReachedGoal(CurrentLevel, CurrentPlayer);

            }
        }
        private void DrawOpeningFrame()
            {

                Console.Clear();

                CurrentLevel.Draw();
                CurrentPlayer.Draw();
                CurrentFinishPoint.Draw();

            }

        private void HandlePlayerInput(PlayerClass CurrentPlayer, LevelBuilderClass CurrentLevel, ConsoleKey Input)
            {
                GameMec.ExtraInputCheck(LevelReff, Input);

                bool CheckMoveIsFree = false;

                int[] MoveReff = new int[2];

                MoveReff = GameMec.ConvertMoveMade(Input);

                int[] PreposedPlayerMove = new int[2];
                PreposedPlayerMove = GameMec.MoveLoopCheck(CurrentPlayer.x,CurrentPlayer.y,CurrentLevel,MoveReff);
                
                //{ CurrentPlayer.x + Move[0], CurrentPlayer.y + Move[1] };


                if (CurrentLevel.IsPositionClear(PreposedPlayerMove[0], PreposedPlayerMove[1]))
                { CurrentPlayer.DrawMove(PreposedPlayerMove); }

            }


        
    }
}
