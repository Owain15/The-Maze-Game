﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Maze_Game.GameMechanics
{

    internal class LevelArrays
    {
        private string[,] LvZero  =
             {
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },

        };
        private string[,] LvOne   =
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
        private string[,] LvTwo   =
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
        private string[,] LvThree =
                 {
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," ","#","=","#"," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," ","|"," ","|"," "," "," "," "," "," "," "," " },
                { " "," ","#","=","=","=","=","=","=","#"," ","#","=","=","=","=","#"," "," "," " },
                { " "," ","|"," "," "," "," "," "," "," "," "," "," "," ","X"," ","|"," "," "," " },
                { " "," ","#","=","=","=","=","=","=","=","=","=","=","=","=","=","#"," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },

        };
        private string[,] LvFour  =
              {

                { " "," "," "," "," "," "," "," "," "," "," "," "," " },
                { " ","#","=","=","=","=","=","#","=","=","=","#"," " },
                { " ","|"," "," "," "," "," ","|"," "," "," ","|"," " },
                { " ","|"," "," ","#","#"," ","|"," "," "," ","|"," " },
                { " ","|"," "," ","#","#","#","#","=","#"," ","|"," " },
                { " ","|"," "," ","|"," "," "," "," "," "," ","|"," " },
                { "=","#"," "," ","#","#"," ","#","=","#"," ","#","=" },
                { " "," "," "," "," ","|"," ","|"," "," "," "," "," " },
                { "=","#"," ","#","=","#","=","#","#"," "," ","#","=" },
                { " ","|"," "," "," "," "," "," ","|"," "," ","|"," " },
                { " ","|"," ","#","=","#"," ","#","#"," "," ","|"," " },
                { " ","|"," "," "," ","|","X","|"," "," "," ","|"," " },
                { " ","#","=","=","=","#","=","#","=","=","=","#"," " },
                { " "," "," "," "," "," "," "," "," "," "," "," "," " },

        };
        private string[,] LvFive  =
               {
                { " "," "," "," ","|"," ","|"," "," "," "," "," "," "," " },
                { " "," "," ","#","="," ","=","#"," "," "," "," "," "," " },
                { " "," "," ","|"," "," "," ","|"," "," "," "," "," "," " },
                { " ","#","=","#","=","#"," ","|"," "," "," "," "," "," " },
                { " ","|"," "," "," ","|"," ","|"," "," "," "," "," "," " },
                { " ","|"," ","#"," ","#"," ","#","=","#","=","=","=","#" },
                { " ","|"," ","#"," "," "," "," "," "," "," "," "," ","|" },
                { " ","|"," "," "," "," "," "," "," ","#","=","#"," ","|" },
                { " ","|"," "," "," "," "," "," "," ","|"," ","|"," ","|" },
                { " ","|"," "," "," "," "," "," "," ","#","=","#"," ","|" },
                { " ","|"," "," "," "," "," "," "," "," "," "," "," ","|" },
                { " ","#","=","#","=","=","=","#","=","#","=","=","=","#" },
                { " "," "," ","|"," ","X"," ","|"," "," "," "," "," "," " },
                { " "," "," ","#","="," ","=","#"," "," "," "," "," "," " },
                { " "," "," "," ","|"," ","|"," "," "," "," "," "," "," " },

        };


        public string[,] GetLevelArray(int LevelNumber)
        {
            string[,] Result = LvZero;
            switch(LevelNumber) 
            {
             case 0: { Result = LvZero; }break;
             case 1: { Result = LvOne;  }break;
             case 2: {  Result = LvTwo; }break;
             case 3: {Result = LvThree; }break;
             case 4: { Result = LvFour; }break;
             case 5: { Result = LvFive; }break;
            }
            return Result;

        }
    }
  








}