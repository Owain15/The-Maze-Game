using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Maze_Game
{
   
    internal class LevelBilder
    {
        private string[,] CurrentLevel;
        private int Rows;
        private int Cols;

        

        public LevelBilder(string[,] maze)
        {
            CurrentLevel = maze;
            Rows = CurrentLevel.GetLength(0);
            Cols = CurrentLevel.GetLength(1);

        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = CurrentLevel[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(element);

                }

            }
        }

        public string GetElementAt(int x, int y)
        {
         
            return CurrentLevel[y, x];
        }
       
        public bool IsPositionClear(int x, int y)
        {
        if (x < 0)
            {
                x = Cols-1 ;

            }
        if (x+1 > Cols)
            {
                x = 0;

            }
        if (y < 0)
            {
                y = Rows-1;

            }
        if (y+1 > Rows)
            {
                y = 0;

            }

            return CurrentLevel[y, x] == " " || CurrentLevel[y, x] == "X";

        }

        public int GetRows()
        {
            return Rows;
        }

        public int GetCols()
        {
            return Cols;

        }









    }

}


  

        
           