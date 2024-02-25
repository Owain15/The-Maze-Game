using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.GameMechanics;
using The_Maze_Game.Menu;

namespace The_Maze_Game.Levels
{
    internal class Level1
    {
        int LevelReff = 1;

            GameLoop GameMec = new GameLoop();
            LevelArrays Maze = new LevelArrays();
            
            LevelBuilderClass CurrentLevel;
            PlayerClass CurrentPlayer;
            FinishPointClass CurrentFinishPoint;

        public void Run()
        {
            CurrentLevel = new LevelBuilderClass(Maze.GetLevelArray(1));
            CurrentPlayer = new PlayerClass(1, 8);
            CurrentFinishPoint = new FinishPointClass(1, 5);

            GameLoop(CurrentLevel, CurrentPlayer, CurrentFinishPoint);

            Level2 NextLevel = new Level2();
            NextLevel.Run();

        }

        private void GameLoop(LevelBuilderClass CurrentLevel,PlayerClass CurrentPlayer,FinishPointClass CurrentFinishPoint)
        {
            bool HasPlayerReachedFinish = false;
              
            Console.Clear();
           
            DrawFrame();

            while (HasPlayerReachedFinish != true)
            {

                HandlePlayerInput(CurrentPlayer,CurrentLevel,GameMec.GetInput());

                

                HasPlayerReachedFinish = GameMec.HasPlayerReachedGoal(CurrentLevel, CurrentPlayer);

            }

            void DrawFrame()
            {

                Console.Clear();

                CurrentLevel.Draw();
                CurrentPlayer.Draw();
                CurrentFinishPoint.Draw();

            }

            void HandlePlayerInput(PlayerClass CurrentPlayer,LevelBuilderClass CurrentLevel, ConsoleKey Input)
            {
                GameMec.ExtraInputCheck( LevelReff, Input);

                bool CheckMoveIsFree = false;

                int[] MoveReff = new int[2];
               
                MoveReff = GameMec.ConvertMoveMade(Input);

                int[] PreposedPlayerMove = new int[2] { CurrentPlayer.x + MoveReff[0], CurrentPlayer.y + MoveReff[1] };

                if (CurrentLevel.IsPositionClear(PreposedPlayerMove[0], PreposedPlayerMove[1]))
                { CurrentPlayer.DrawMove(PreposedPlayerMove); }
                
            }


        }



    }
}
