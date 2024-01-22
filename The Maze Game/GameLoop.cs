using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Maze_Game
{
    internal class GameLoop
    {
        private LevelBilder CurrentLevel;
        private Player CurrentPlayer;
        private FinishPoint CurrentFinishPoint;
        private Lock CurrentLockBlue;
        private Lock CurrentLockYellow;
        
        private LevelArray SelectedLever;
        

         
        public void LevelOne()
        {

            String[,] LvOne =
            {
                { "#", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "#" },
                { "|", " ", " ", " ", " ", " ", "#", "=", "#", " ", " ", " ", " ", "#", "=", "#", " ", " ", " ", "|" },
                { "|", " ", "#", " ", "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#", " ", "|" },
                { "|", " ", " ", " ", "|", "=", "=", "#", " ", "#", "|", " ", "#", "=", "=", "#", "=", "|", " ", "|" },
                { "|", "=", "#", " ", "|", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", "|", " ", "|", " ", "|" },
                { "|", "X", "|", " ", "|", "=", "#", " ", "#", "=", "|", " ", "=", "#", " ", "#", "=", "|", " ", "|" },
                { "|", " ", " ", " ", "|", " ", " ", " ", " ", " ", "|", " ", "|", " ", " ", " ", " ", "|", " ", "|" },
                { "|", "=", "=", "=", "#", " ", "#", "=", "#", " ", "#", "=", "#", " ", "#", "#", " ", "#", " ", "|" },
                { "|", " ", " ", " ", " ", " ", "|", " ", "|", " ", " ", " ", " ", " ", "#", "#", " ", " ", " ", "|" },
                { "#", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "#" },

            };

            CurrentLevel = new LevelBilder(LvOne);
            CurrentPlayer = new Player(1, 8);
            CurrentFinishPoint = new FinishPoint(1, 5);

            RunGameLoop();

            Console.Clear();

            LevelTwo();
            

        }

        public void LevelTwo()
        {

            String[,] LvTwo =
          {
                { " ", " ", " ", " ", "|", " ", "|", " ", " ", " ", " ", " ", " ", " ", "|", " ", "|", " ", " ", " " },
                { "=", "#", "=", "=", "#", " ", "#", "=", "=", "#", "#", "=", "=", "=", "#", " ", "#", "=", "#", "=" },
                { " ", " ", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                { "=", "#", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", "#", "=" },
                { " ", "#", "=", "=", "=", "=", "=", "=", "=", "#", "|", " ", " ", " ", " ", " ", " ", " ", "|", " " },
                { " ", "|", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", " ", " ", " ", " ", " ", " ", "|", " " },
                { " ", "#", " ", " ", " ", " ", " ", " ", " ", "|", "|", "=", "=", "=", "=", "=", "=", "=", "#", " " },
                { " ", "|", " ", " ", " ", " ", " ", " ", " ", "|", "|", " ", "X", " ", " ", " ", " ", " ", "|", " " },
                { " ", "#", "=", "=", "#", " ", "#", "=", "=", "#", "#", "=", "=", "=", "#", " ", "#", "=", "#", " " },
                { " ", " ", " ", " ", "|", " ", "|", " ", " ", " ", " ", " ", " ", " ", "|", " ", "|", " ", " ", " " },

            };

            CurrentLevel = new LevelBilder(LvTwo);
            CurrentPlayer = new Player(5, 6);
            CurrentFinishPoint = new FinishPoint(12, 7);

            RunGameLoop();

            Console.Clear();

            LevelThree();

        }

        public void LevelThree()
        {
            // colored gates opened by keys
           
            string[,] LvThree =
             {
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," ","#","=","#"," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," ","|"," ","|"," "," "," "," "," "," "," "," " },
                { " "," ","#","=","=","=","=","=","=","#"," ","#","=","=","=","=","#"," "," "," " },
                { " "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," ","|"," "," "," " },
                { " "," ","#","=","=","=","=","=","=","=","=","=","=","=","=","=","#"," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },

        };

            CurrentLevel = new LevelBilder(LvThree);
            CurrentPlayer = new Player(4, 4);
            CurrentFinishPoint = new FinishPoint(14, 4);
            CurrentLockBlue = new Lock(11, 4, ConsoleColor.Blue);
           

            RunGameLoop();

            Console.Clear();

            HomePage TheMazeGame = new HomePage();
            TheMazeGame.RunMainMenu();
        }
       
        public  void RunGameLoop()
        {
          
            while (true)
            {
         
                DrawFrame();
                
                HandlePlayerInput();
                
                string elimentAtPlayePos = CurrentLevel.GetElementAt(CurrentPlayer.x, CurrentPlayer.y);
                if (elimentAtPlayePos == "X")
                {
                    break;
                }

                //Give the console time to render
                System.Threading.Thread.Sleep(60);
                // play around with render time?

            }



        }

        public void RunLockAndKeyLoop()
        {
            while (true)
            {
                CurrentLockBlue.Draw();
                DrawFrame();

                HandlePlayerInput();

                string elimentAtPlayePos = CurrentLevel.GetElementAt(CurrentPlayer.x, CurrentPlayer.y);
                if (elimentAtPlayePos == "X")
                {
                    break;
                }

                //Give the console time to render
                System.Threading.Thread.Sleep(60);
                // play around with render time?

            }
            RunGameLoop();

        }
        private void DrawFrame()
        {

            Console.Clear();
            
            CurrentLevel.Draw();
            CurrentPlayer.Draw();
            CurrentFinishPoint.Draw();
           
        }

        private void HandlePlayerInput()
        {

            //get onley most recent key
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            } while (Console.KeyAvailable);

            switch (key)
            {
                case ConsoleKey.UpArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y - 1))
                    {

                        CurrentPlayer.y -= 1;

                    }
                    if (CurrentPlayer.y < 0)
                    {
                        CurrentPlayer.y = CurrentLevel.GetRows() - 1;

                    }

                    break;

                case ConsoleKey.DownArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y + 1))
                    {
                        CurrentPlayer.y++;

                    }
                    if (CurrentPlayer.y + 1 > CurrentLevel.GetRows())
                    {
                        CurrentPlayer.y = 0;

                    }
                    break;

                case ConsoleKey.LeftArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x - 1, CurrentPlayer.y))
                    {
                        CurrentPlayer.x -= 1;
                    }
                    if (CurrentPlayer.x < 0)
                    {
                        CurrentPlayer.x = CurrentLevel.GetCols() - 1;

                    }
                    break;

                case ConsoleKey.RightArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x + 1, CurrentPlayer.y))
                    {
                        CurrentPlayer.x += 1;

                    }
                    if (CurrentPlayer.x + 1 > CurrentLevel.GetCols())
                    {
                        CurrentPlayer.x = 0;
                    }
                    break;

                case ConsoleKey.Escape:

                    HomePage BackToMenu = new HomePage();

                    BackToMenu.RunMainMenu();
                    break;

                case ConsoleKey.Spacebar:
                    //Restart, Keep Count
                    

                    break;
            }
        }

        public void BlueDoor()
        {
            CurrentLockBlue.Draw();


        }
    }

}
