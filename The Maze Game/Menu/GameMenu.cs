using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.Levels;
using The_Maze_Game.Menu.MenuMecs;

namespace The_Maze_Game.Menu
{
    internal class HomePage
    {
        public void RunMainMenu()
        {
            //// test shortcut. Delete
            //Level5 test = new Level5();
            //test.Run();

            //// run open page / logo?
            MainMenu();

        }

        private void MainMenu()
        {
            Console.Clear();

            string pageTitle = "Main Menu.";
            string prompt = "Use The Up And Down Arrow Keys To Make A Selection. Then Press Enter.";
            string[] options = { "Start Game", "Level Select", "Game Info", "Close Program" };

            MenuBuilder mainMenu = new MenuBuilder(pageTitle, prompt, options);
            int MenuSelection = mainMenu.MenuRun();

            switch (MenuSelection)
            {
                case 0:

                    StartGame();
                    break;
                case 1:
                    LevelSelect();
                    break;
                case 2:
                    GameInfo();
                    break;
                case 3:
                    ExitProgram();
                    break;

            }
        }
        private void StartGame()
        {
            Level1 LvOne = new Level1();
            LvOne.Run();

        }

        private void LevelSelect()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0); 


            string pageTitle = "Level Menu.";
            string prompt = "Use The Up And Down Arrow Keys To Make A Selection. Then Press Enter.";
            string[] options = { "Main Menu", "Level One", "Level Two", "Level Three", "Level Four", "Level Five" };

            MenuBuilder levelMenu = new MenuBuilder(pageTitle, prompt, options);
            int MenuSelection = levelMenu.MenuRun();

            switch (MenuSelection)
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    StartGame();
                    break;
                case 2:
                    Level2 LevelTwo = new Level2();
                        LevelTwo.Run(); 
                    break;
                case 3:
                    Level3 LevelThree = new Level3();
                    LevelThree.Run();
                    break;
                case 4:
                    Level4 LevelFour = new Level4();
                    LevelFour.Run();
                    break;
                case 5:
                    Level5 LevelFive = new Level5();
                    LevelFive.Run();
                    break;
            }
        }

        private void GameInfo()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0); ;
            Console.WriteLine("Game Info.");
            Console.WriteLine("");
            Console.WriteLine("Press Enter To Return To MainMenu.");

            ConsoleKey keypresed;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keypresed = keyInfo.Key;

            if (keypresed == ConsoleKey.Enter) ;
            {
                MainMenu();


            }
        }

        private void ExitProgram()
        {
            Console.Clear();
            //delete message befor building final program 
            Console.WriteLine("thanks for Paying");
            Console.WriteLine(" Press The Any Key To Exit.");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

    }


  
}




