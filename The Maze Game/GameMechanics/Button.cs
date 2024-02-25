using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Maze_Game.GameMechanics
{
    internal class Button
    {
        public int X;
        public int Y;
        public int[] ButtonPositon;

        public bool ButtonPressed;

        private string ButtonMarker = "*";
        private ConsoleColor ButtonColor = ConsoleColor.Blue;

        public Button(int ButtonX, int ButtonY)
        {
            X = ButtonX;
            Y = ButtonY;
            ButtonPositon = new int[2] { X, Y };

            ButtonPressed = false;
        }
        public void Draw()
        {
            if (ButtonPressed == false)
            {
                Console.ForegroundColor = ButtonColor;
                Console.SetCursorPosition(X, Y);
                Console.WriteLine(ButtonMarker);
                Console.ResetColor();
            }
        }
        public bool ButtonPushedCheck(int ObjectX, int ObjectY)
        {
             bool Result = false;
            if (ButtonPositon[0] == ObjectX)
            {
                if (ButtonPositon[1] == ObjectY)
                { Result = true; }
            }
            return Result;


        }
        
    }
}
