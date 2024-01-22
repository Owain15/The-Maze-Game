using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game;

namespace The_Maze_Game
{
    internal class HomePage
    {
        public void RunMainMenu()
        {
           //test shortcut. Delete
           GameLoop test = new GameLoop();
           // test.LevelThree();
            
            // run open page / logo?
            MainMenu();

        }

        private void MainMenu()
        {
            string pageTitle = "Main Menu.";
            string prompt = "Use The Up And Down Arrow Keys To Make A Selection. Then Press Enter.";
            string[] options = { "Start Game", "Level Select", "Game Info", "Close Program" };

            MenuBuilder mainMenu = new MenuBuilder(pageTitle,prompt, options);
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
            GameLoop LvOne = new GameLoop();
            LvOne.LevelOne();

        }

        private void LevelSelect()
        {
            Console.Clear();


            string pageTitle = "Level Menu.";
            string prompt = "Use The Up And Down Arrow Keys To Make A Selection. Then Press Enter.";
            string[] options = { "Main Menu", "Level One", "Level Two","Level Three"};

            MenuBuilder levelMenu = new MenuBuilder(pageTitle ,prompt, options);
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
                    GameLoop LvTwo = new GameLoop();
                    LvTwo.LevelTwo();
                    break;
                case 3:
                    GameLoop LvThree = new GameLoop();
                    LvThree.LevelThree();
                    break;
            }
        }
    
        private void GameInfo()
    {
           
        Console.Clear();
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
         //delete message befor building final program 
            Console.WriteLine("thanks for Paying");
        Console.WriteLine(" Press The Any Key To Exit.");
        Console.ReadKey(true);
        Environment.Exit(0);
         }

}   
        
    
    internal class MenuBuilder
    {
            private string PageTitle;
            private int SelectedIndex;
            private string[] Options;
            private string Prompt;

            public MenuBuilder(string pageTitle, string prompt, String[] options)
            {
                PageTitle = pageTitle;
                Prompt = prompt;
                Options = options;
                SelectedIndex = 0;
            }
            private void DisplayOptions()
            {
            Console.WriteLine("The Maze Game.");
                Console.WriteLine(PageTitle+"\n");
                Console.WriteLine(Prompt+"\n");
                for (int i = 0; i < Options.Length; i++)
                {
                    string currentOption = Options[i];
                    string prefix;
                    if (i == SelectedIndex)
                    {
                        prefix = "*";

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        prefix = " ";

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{prefix}>>{currentOption}<<{prefix}");
                }
                Console.ResetColor();
            }
            public int MenuRun()
            {
                ConsoleKey keypressed;
                do
                {
                    Console.Clear();
                    DisplayOptions();

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    keypressed = keyInfo.Key;

                    //update selected index baced on arrow keys
                    if (keypressed == ConsoleKey.UpArrow)
                    {
                        SelectedIndex--;
                        if (SelectedIndex == -1)
                        {
                            SelectedIndex = Options.Length - 1;
                        }
                    }
                    else if (keypressed == ConsoleKey.DownArrow)
                    {
                        SelectedIndex++;
                        if (SelectedIndex == Options.Length)
                        {
                            SelectedIndex = 0;
                        }
                    }
                }
                while (keypressed != ConsoleKey.Enter);

                return SelectedIndex;
            }
        }

}
    



