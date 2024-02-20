using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Maze_Game.Menu.MenuMecs
{
    internal class MenuBuilder
    {
        private string PageTitle;
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public MenuBuilder(string pageTitle, string prompt, string[] options)
        {
            PageTitle = pageTitle;
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }
        private void DisplayOptions()
        {
            Console.WriteLine("The Maze Game.");
            Console.WriteLine(PageTitle + "\n");
            Console.WriteLine(Prompt + "\n");
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
                Console.SetCursorPosition(0, 0); ;
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
