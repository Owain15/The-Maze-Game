using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Maze_Game.GameMechanics
{
    internal class SlideBlock
    {
        public int SlideBlockX;
        public int SlideBlockY;

        public bool BlockBeenPushed;
        ConsoleKey PlayersInput;
        public bool BlockFreeToMove;

        string SlideBlockMarker = "#";
        ConsoleColor SlideBlockColor = ConsoleColor.Red;

        public SlideBlock(int initialX, int initialY)
        {
            SlideBlockX = initialX;
            SlideBlockY = initialY;
        }

        public void Draw()
        {
            Console.ForegroundColor = SlideBlockColor;
            Console.SetCursorPosition(SlideBlockX, SlideBlockY);
            Console.WriteLine(SlideBlockMarker);
            Console.ResetColor();
        }

        public bool HasBlockBeenPushed(int PreposedPlayerX, int PreposedPlayerY)
        {
            if (SlideBlockX == PreposedPlayerX)
            {
                if (SlideBlockY == PreposedPlayerY) { return true; }
            }
            return false;
        }
        public bool IsBlockFreeToMove(LevelBuilderClass CurrentLevel, int[] MoveReff)
        {
            int PreposedX = SlideBlockX + MoveReff[0];
            int PreposedY = SlideBlockY + MoveReff[1];

            bool Result = CurrentLevel.IsPositionClear(PreposedX,PreposedY);

            if(Result == true ) { MoveSlideBlock(CurrentLevel,MoveReff); }

            return Result;
        }
        public void MoveSlideBlock(LevelBuilderClass CurrentLevel, int[] MoveMade)
        {
           
                int PreposedBlockX = SlideBlockX + MoveMade[0];
                int PreposedBlockY = SlideBlockY + MoveMade[1];

                if (PreposedBlockX < 0) { PreposedBlockX = CurrentLevel.GetCols() - 1; }
                if (PreposedBlockX > CurrentLevel.GetCols() - 1) { PreposedBlockX = 0; }

                if (PreposedBlockY < 0) { PreposedBlockY = CurrentLevel.GetRows() - 1; }
                if (PreposedBlockY > CurrentLevel.GetRows() - 1) { PreposedBlockY = 0; }

                if (CurrentLevel.IsPositionClear(PreposedBlockX, PreposedBlockY) == true)
                { SlideBlockX = PreposedBlockX; SlideBlockY = PreposedBlockY; }
                
        }
    }
}
