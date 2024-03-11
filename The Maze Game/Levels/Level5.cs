using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Maze_Game.GameMechanics;
using The_Maze_Game.Menu;

namespace The_Maze_Game.Levels
{
    internal class Level5
    {
        int LevelReff = 5;

        GameLoop GameMec = new GameLoop();
        LevelArrays Maze = new LevelArrays();

        LevelBuilderClass CurrentLevel;
        PlayerClass CurrentPlayer;
        FinishPointClass CurrentFinishPoint;

        LockAndKey LockAndKeyBlue;
        LockAndKey LockAndKeyBlueTwo;
        LockAndKey LockAndKeyYellow;

        SlideBlock SlideBlockOne;
        SlideBlock SlideBlockTwo;

        Button ButtonOne;
        Button ButtonTwo;
        Button ButtonThree;
        Button ButtonFour;
        Button ButtonFive;
        Button ButtonSix;

        public void Run()
        {
            CurrentLevel = new LevelBuilderClass(Maze.GetLevelArray(5));
            CurrentPlayer = new PlayerClass(6, 2);
            CurrentFinishPoint = new FinishPointClass(7, 12);

            LockAndKeyBlue = new LockAndKey(6, 5, 14, 8, ConsoleColor.Blue);
            LockAndKeyBlueTwo = new LockAndKey(4, 3, 14, 8, ConsoleColor.Blue);
            LockAndKeyYellow = new LockAndKey(4, 10 ,2 ,2,ConsoleColor.Yellow);

            SlideBlockOne = new SlideBlock(13, 6);
            SlideBlockTwo = new SlideBlock(4, 11);

            ButtonOne = new Button(8, 4);

            ButtonTwo = new Button(6, 7);
            ButtonThree = new Button(6, 7);

            ButtonFour = new Button(10, 10);
            ButtonFive = new Button(12, 6);

            ButtonSix = new Button(4, 2);

            Console.Clear();

            GameLoop();

            HomePage NextLevel = new HomePage();
            NextLevel.RunMainMenu();
        }

        private void GameLoop()
        {
            bool HasPlayerReachedFinish = false;

            Console.Clear();
            
            DrawOpeningFrame();

            while (HasPlayerReachedFinish != true)
            {

                DrawFrame();

                ConsoleKey Input = GameMec.GetInput();

                GameMec.ExtraInputCheck( LevelReff, Input);
               
                HandlePlayerInput(Input);

                SetAllLockLogics();

                SetAllButtonLogics();
                
                HasPlayerReachedFinish = GameMec.HasPlayerReachedGoal(CurrentLevel, CurrentPlayer);
            }


        }
        private void DrawOpeningFrame()
        {
            CurrentLevel.Draw();
            CurrentPlayer.Draw();
            CurrentFinishPoint.Draw();
            LockAndKeyBlue.Draw();
            LockAndKeyBlueTwo.Draw();
            LockAndKeyYellow.Draw();
            SlideBlockOne.Draw();
            SlideBlockTwo.Draw();
           
        }
        private void DrawFrame()
        {
            DrawAllButtons();
            DrawAllButtonLogics();
            CurrentPlayer.Draw();
            DrawSlideBlocks();

        }
        private void DrawSlideBlocks()
        {
            SlideBlockOne.Draw();
            SlideBlockTwo.Draw();
        }
        private void HandlePlayerInput(ConsoleKey Input)
        {
           
            bool LockOneCheck = false;
            bool LockTwoCheck = false;
            bool LockThreeCheck = false;
         
            bool SlideBlockOneCheck = true;
            bool SlideBlockTwoCheck = true;
            
            bool ButtonOneCheck = ButtonOne.ButtonPressed;
            bool ButtonTwoCheck = ButtonTwo.ButtonPressed;
            bool ButtonThreeCheck = ButtonThree.ButtonPressed;
            bool ButtonFourCheck = ButtonFour.ButtonPressed;
            bool ButtonFiveCheck = ButtonFive.ButtonPressed;
         
            bool MoveEvaluation = false;
               
            int[] MoveReff = new int[2];

            MoveReff = GameMec.ConvertMoveMade(Input);

            int[] PreposedPlayerMove = new int[2];
            PreposedPlayerMove = GameMec.MoveLoopCheck(CurrentPlayer.x, CurrentPlayer.y, CurrentLevel, MoveReff);

            SlideBlockOneCheck = RunSlideBlockTurn(SlideBlockOne, CurrentLevel, PreposedPlayerMove, MoveReff);

            SlideBlockTwoCheck = RunSlideBlockTurn(SlideBlockTwo, CurrentLevel, PreposedPlayerMove, MoveReff);

            if (CurrentLevel.IsPositionClear(PreposedPlayerMove[0], PreposedPlayerMove[1]))
            {
                RunPlayerTurn(PreposedPlayerMove,MoveReff,MoveEvaluation,SlideBlockOneCheck,SlideBlockTwoCheck
                    ,LockOneCheck,LockTwoCheck,LockThreeCheck,ButtonOneCheck,ButtonTwoCheck,ButtonThreeCheck
                    ,ButtonFourCheck,ButtonFiveCheck);
            }


        }
        private bool EvaluateMove(bool LockOne, bool LockTwo, bool LockThree, bool BlockOne, bool BlockTwo, bool ButtonOne,bool ButtonTwo 
            ,bool ButtonThree ,bool ButtonFour ,bool ButtonFive )
        {
            bool Result = true;

            if (LockOne != false) { Result = false; }
            if (LockTwo != false) { Result = false; }
            if (LockThree != false) { Result = false; }
            if (BlockOne == false) { Result = false; }
            if (BlockTwo == false) { Result = false; }
            if (ButtonOne == true) { Result = false; }
            if (ButtonTwo == true) { Result = false; }
            if (ButtonThree == true) { Result = false; }
            if (ButtonFour == true) { Result = false; }
            if (ButtonFive == true) { Result = false; }

            return Result;
        }

        int[] ButtonOneLogic()
        {
            int[] PositionOne = new int[2] { 8, 5 };
            int[] PositionTwo = new int[2] { 12, 7 };
            
            bool ButtonPressed = false;

            if (ButtonOne.ButtonPressed == true ) { ButtonPressed = true; }
            if (ButtonSix.ButtonPressed == true )
            { ButtonPressed = true; }

            if (ButtonPressed == true)
            {
                Console.SetCursorPosition(PositionOne[0], PositionOne[1]);
                Console.WriteLine(" ");
                return PositionTwo;
            }
            else
            {
                Console.SetCursorPosition(PositionOne[0], PositionOne[1]);
                Console.WriteLine("=");
                return PositionOne;
            }
        }
        int[] ButtonTwoLogic()
        {
            int[] PositionOne = new int[] { 7, 1 };
            int[] PositionTwo = new int[] { 12, 7 };

            if (ButtonTwo.ButtonPressed == true)
            {
                Console.SetCursorPosition(6, 0);
                Console.WriteLine("|" + " " + "|");
                Console.SetCursorPosition(6, 1);
                Console.WriteLine("#" + " " + "#");
                return PositionTwo;
            }
            else
            {
                Console.SetCursorPosition(6, 0);
                Console.WriteLine(" " + " " + " ");
                Console.SetCursorPosition(6, 1);
                Console.WriteLine("=" + "=" + "=");
                return PositionOne;
            }




        }
        int[] ButtonThreeLogic()
        {
            int[] PositionOne = new int[] { 7, 13 };
            int[] PositionTwo = new int[] { 12, 7 };

            if (ButtonThree.ButtonPressed == true)
            {
                Console.SetCursorPosition(6, 13);
                Console.WriteLine("#" + " " + "#");
                Console.SetCursorPosition(6, 14);
                Console.WriteLine("|" + " " + "|");
                return PositionTwo;
            }
            else
            {
                Console.SetCursorPosition(6, 13);
                Console.WriteLine("=" + "=" + "=");
                Console.SetCursorPosition(6, 14);
                Console.WriteLine(" " + " " + " ");

                return PositionOne;
            }




        }
        int[] ButtonFourLogic()
        {
            int[] PositionOne = new int[] { 11, 10 };
            int[] PositionTwo = new int[] { 12, 7 };

            if (ButtonFour.ButtonPressed == true)
            {
                Console.SetCursorPosition(11, 10);
                Console.WriteLine(" ");


                return PositionTwo;
            }
            else
            {
                Console.SetCursorPosition(11, 10);
                Console.WriteLine("|");


                return PositionOne;
            }
        }
        int[] ButtonFiveLogic()
        {
            int[] PositionOne = new int[] { 11, 6 };
            int[] PositionTwo = new int[] { 12, 7 };

            if (ButtonFive.ButtonPressed == true)
            {
                Console.SetCursorPosition(11, 6);
                Console.WriteLine(" ");


                return PositionTwo;
            }
            else
            {
                Console.SetCursorPosition(11, 6);
                Console.WriteLine("|");


                return PositionOne;
            }
        }

        private void DrawAllButtons()
        {
            ButtonOne.Draw();
            ButtonTwo.Draw();
            ButtonThree.Draw();
            ButtonFour.Draw();
            ButtonFive.Draw();
            ButtonSix.Draw();
        }
        private void DrawAllButtonLogics()
        {
            ButtonOneLogic();
            ButtonTwoLogic();
            ButtonThreeLogic();
            ButtonFourLogic();
            ButtonFiveLogic();
        }
        private bool PlayerCheckButtonLogicWalls(int ButtonLogicReff, int[] MoveReff)
        {
            bool Result = false;
            int[] ButtonWallReff = GetButtonLogic(ButtonLogicReff);
            
            if (GameMec.ButtonWallCheck(ButtonWallReff, CurrentPlayer.x, CurrentPlayer.y, MoveReff) == true)
                { Result = true; }
            
            return Result;
        }
        private bool SlideBLockCheckButtonLogicWalls(int[] ButtonWallReff, int[] MoveReff)
        {
            bool Result = false; 

          if (GameMec.ButtonWallCheck(ButtonWallReff, SlideBlockOne.SlideBlockX, SlideBlockOne.SlideBlockY, MoveReff) == true)
                        { Result = true; }
          else if (GameMec.ButtonWallCheck(ButtonWallReff, SlideBlockTwo.SlideBlockX, SlideBlockTwo.SlideBlockY, MoveReff) == true)
                    { Result = true; }
            return Result;
        }
        private bool SlideBlockCheckAllButtonLogicWalls(int[] SlideBlockMoveReff)
        {
            bool Result = false;

            bool T1 = SlideBLockCheckButtonLogicWalls(ButtonOneLogic(), SlideBlockMoveReff);
            bool T2 = SlideBLockCheckButtonLogicWalls(ButtonTwoLogic(), SlideBlockMoveReff);
            bool T3 = SlideBLockCheckButtonLogicWalls(ButtonThreeLogic(), SlideBlockMoveReff);
            bool T4 = SlideBLockCheckButtonLogicWalls(ButtonFourLogic(), SlideBlockMoveReff);
            bool T5 = SlideBLockCheckButtonLogicWalls(ButtonFiveLogic(), SlideBlockMoveReff);

            if (T1) { Result = true;}
            if (T2) { Result = true;}
            if (T3) { Result = true;}
            if (T4) { Result = true;}
            if (T5) { Result = true;}

            return Result;
        }
        private int[] GetButtonLogic(int ButtonLogicReff)
        {
            int[] Result = new int[2];

            switch (ButtonLogicReff)
            {
                case 1: Result = ButtonOneLogic(); break;
                case 2: Result = ButtonTwoLogic(); break;
                case 3: Result = ButtonThreeLogic(); break;
                case 4: Result = ButtonFourLogic(); break;
                case 5: Result = ButtonFiveLogic(); break;
                //case 6: Result = ButtonOneLogic(); break;
            }
            return Result;
        }
        private void ButtonSetter(Button Button)
        {
            bool PlayerCheck = Button.ButtonPushedCheck(CurrentPlayer.x,CurrentPlayer.y);
            bool BlockOneCheck = Button.ButtonPushedCheck(SlideBlockOne.SlideBlockX,SlideBlockOne.SlideBlockY);
            bool BlockTwoCheck = Button.ButtonPushedCheck(SlideBlockTwo.SlideBlockX,SlideBlockTwo.SlideBlockY);

            if ( PlayerCheck == true ) { Button.ButtonPressed = true; }
            else if (BlockOneCheck == true) { Button.ButtonPressed = true; }
            else if (BlockTwoCheck == true ) { Button.ButtonPressed = true; }
            else { Button.ButtonPressed = false; }
        }
        private void SetAllButtonLogics()
        {
            ButtonSetter(ButtonOne);
            ButtonSetter(ButtonTwo);
            ButtonSetter(ButtonThree);
            ButtonSetter(ButtonFour);
            ButtonSetter(ButtonFive);
            ButtonSetter(ButtonSix);
        }
        private void SetAllLockLogics()
        {
            if (LockAndKeyBlue.IsKeyPickedUp != true) { LockAndKeyBlue.DoesPlayerHaveKey(CurrentPlayer.x, CurrentPlayer.y); }
            if (LockAndKeyBlueTwo.IsKeyPickedUp != true) { LockAndKeyBlueTwo.DoesPlayerHaveKey(CurrentPlayer.x, CurrentPlayer.y); }
            if (LockAndKeyYellow.IsKeyPickedUp != true) { LockAndKeyYellow.DoesPlayerHaveKey(CurrentPlayer.x, CurrentPlayer.y); }
        }
        private bool RunSlideBlockTurn( SlideBlock Block, LevelBuilderClass CurrentLevel, int[] PreposedPlayerMove, int[] MoveReff)
        {
            bool Result = true;

            if (Block.HasBlockBeenPushed(PreposedPlayerMove[0], PreposedPlayerMove[1]))
            {
                
                Result = Block.IsBlockFreeToMove(CurrentLevel, MoveReff);

                int[] SlideBlockMoveReff = new int[2];
                SlideBlockMoveReff[0] = Block.SlideBlockX + MoveReff[0];
                SlideBlockMoveReff[1] = Block.SlideBlockY + MoveReff[1];

                if (Result == true) { Result = SlideBlockCheckAllButtonLogicWalls(SlideBlockMoveReff); }
                
                if (LockAndKeyBlue.IsDoorLocked(SlideBlockMoveReff[0], SlideBlockMoveReff[1])) { Result = false; }
                if (LockAndKeyBlueTwo.IsDoorLocked(SlideBlockMoveReff[0], SlideBlockMoveReff[1])) { Result = false; }
                if (LockAndKeyYellow.IsDoorLocked(SlideBlockMoveReff[0], SlideBlockMoveReff[1])) { Result = false; }
               
               
            }
             return Result;
        }
        private void RunPlayerTurn(int[] PreposedPlayerMove, int[] MoveReff, bool MoveEvaluation, bool SlideBlockOneCheck, bool SlideBlockTwoCheck,
            bool LockOneCheck,bool LockTwoCheck, bool LockThreeCheck, bool ButtonOneCheck, bool ButtonTwoCheck, bool ButtonThreeCheck,
            bool ButtonFourCheck, bool ButtonFiveCheck )
        {
            if (SlideBlockOne.HasBlockBeenPushed(PreposedPlayerMove[0], PreposedPlayerMove[1]) == false)
            { SlideBlockOneCheck = true; }

            if (SlideBlockTwo.HasBlockBeenPushed(PreposedPlayerMove[0], PreposedPlayerMove[1]) == false)
            { SlideBlockTwoCheck = true; }

            LockOneCheck = LockAndKeyBlue.LockCheck(PreposedPlayerMove[0], PreposedPlayerMove[1]);
            if (LockOneCheck == true)
            {
                if (LockAndKeyBlue.IsKeyPickedUp != true)
                {
                    PreposedPlayerMove[0] = CurrentPlayer.x;
                    PreposedPlayerMove[1] = CurrentPlayer.y;
                }

            }

            LockTwoCheck = LockAndKeyBlueTwo.LockCheck(PreposedPlayerMove[0], PreposedPlayerMove[1]);
            if (LockTwoCheck == true)
            {
                PreposedPlayerMove[0] = CurrentPlayer.x;
                PreposedPlayerMove[1] = CurrentPlayer.y;
            }

            LockThreeCheck = LockAndKeyYellow.LockCheck(PreposedPlayerMove[0], PreposedPlayerMove[1]);
            if (LockOneCheck == true)
            {
                if (LockAndKeyYellow.IsKeyPickedUp != true)
                {
                    PreposedPlayerMove[0] = CurrentPlayer.x;
                    PreposedPlayerMove[1] = CurrentPlayer.y;
                }

            }

            ButtonOneCheck = PlayerCheckButtonLogicWalls(1, MoveReff);
            ButtonTwoCheck = PlayerCheckButtonLogicWalls(2, MoveReff);
            ButtonThreeCheck = PlayerCheckButtonLogicWalls(3, MoveReff);
            ButtonFourCheck = PlayerCheckButtonLogicWalls(4, MoveReff);
            ButtonFiveCheck = PlayerCheckButtonLogicWalls(5, MoveReff);

            MoveEvaluation = EvaluateMove(LockOneCheck, LockTwoCheck, LockThreeCheck, SlideBlockOneCheck, SlideBlockTwoCheck,
                ButtonOneCheck, ButtonTwoCheck, ButtonThreeCheck, ButtonFourCheck, ButtonFiveCheck);

            if (MoveEvaluation == true)
            { CurrentPlayer.DrawMove(PreposedPlayerMove); }

        }


    }
}
