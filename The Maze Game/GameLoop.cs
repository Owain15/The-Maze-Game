using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
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

            string[,] LvThree =
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

            CurrentLevel = new LevelBilder(LvThree);
            CurrentPlayer = new Player(4, 4);
            CurrentFinishPoint = new FinishPoint(14, 4);
            LockAndKey BlueLockAndKey = new LockAndKey(12, 4, 10, 2, ConsoleColor.Blue);

            GameLoopLvThree();

            Console.Clear();

            LevelFour();

            void GameLoopLvThree()
            {
                bool HasPlayerReachedFinish = false;
                while (HasPlayerReachedFinish != true)
                {
                    DrawFrame();
                    BlueLockAndKey.Draw();
                    LvThreeHandlePlayerInput(BlueLockAndKey,GetInput());
                    Delay();
                    LockAndKeyCheck(BlueLockAndKey, CurrentPlayer);

                    HasPlayerReachedFinish = HasPlayerReachedGoal();
                }




            }

        }

        public void LevelFour()
        {
            string[,] LvFour =
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

            CurrentLevel = new LevelBilder(LvFour);
            CurrentPlayer = new Player(2, 7);
            CurrentFinishPoint = new FinishPoint(6, 11);

            LockAndKey BlueLockAndKey = new LockAndKey(4, 9, 6, 7, ConsoleColor.Blue);
            LockAndKey YellowLockAndKey = new LockAndKey(8, 5, 6, 3, ConsoleColor.Yellow);

            SlideBlock SlideBlockOne = new SlideBlock(6, 9);
            SlideBlock SlideBlockTwo = new SlideBlock(6, 5);

            GameLoopLvFour();



            Console.Clear();
            HomePage TheMazeGame = new HomePage();

            TheMazeGame.RunMainMenu();

            void GameLoopLvFour()
            {
                bool HasPlayerReachedFinish = false;
                while (HasPlayerReachedFinish != true)
                {
                    DrawFrame();
                    BlueLockAndKey.Draw();
                    YellowLockAndKey.Draw();
                    SlideBlockOne.Draw();
                    SlideBlockTwo.Draw();

                    LvFourHandlePlayerInput(BlueLockAndKey, YellowLockAndKey, SlideBlockOne, SlideBlockTwo ,GetInput());
                    Delay();
                    LockAndKeyCheck(BlueLockAndKey, CurrentPlayer);
                    LockAndKeyCheck(YellowLockAndKey, CurrentPlayer);

                    HasPlayerReachedFinish = HasPlayerReachedGoal();
                }




            }
        }

        public void LevelFive()
        {
            string[,] LvFive =
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

            CurrentLevel = new LevelBilder(LvFive);
            CurrentPlayer = new Player(4, 2); 
            CurrentFinishPoint = new FinishPoint(5,12);

           

            SlideBlock SlideBlockOne = new SlideBlock(11, 6);
            SlideBlock SlideBlockTwo = new SlideBlock(1, 1);

            LockAndKey LockAndKeyBlue = new LockAndKey(1,3,1,4,ConsoleColor.Blue);
           
            Button ButtonOne = new Button(6, 4);
           
            Button ButtonTwo = new Button(4, 7);
            Button ButtonThree = new Button(4,7);

            Button ButtonFour = new Button(8,10);
            Button ButtonFive = new Button(10,6);

            GameLoopLvFive();

            void GameLoopLvFive()
            {
                bool HasPlayerReachedFinish = false;
                
                DrawFrame();

                while (HasPlayerReachedFinish != true)
                {
                   

                    
                    ButtonOne.Draw();
                    ButtonTwo.Draw();
                    ButtonThree.Draw();
                    ButtonFour.Draw();
                    ButtonFive.Draw();
                    ButtonOneLogic(ButtonOne);
                    ButtonTwoLogic(ButtonTwo);
                    ButtonThreeLogic(ButtonThree);
                    ButtonFourLogic(ButtonFour);
                    ButtonFiveLogic(ButtonFive);
                    SlideBlockOne.Draw();
                    CurrentPlayer.Draw();

                    //LvFiveHandlePlayerInput(SlideBlockOne, GetInput());
                    
                    HanddlePlayerInput(LvFive, CurrentPlayer, SlideBlockOne,GetInput());
                    Delay();

                    CheckButton(ButtonOne);
                    CheckButton(ButtonTwo);
                    CheckButton(ButtonThree);
                    CheckButton(ButtonFour);
                    CheckButton(ButtonFive);
                    
                    HasPlayerReachedFinish = HasPlayerReachedGoal();
                }

                void LvFiveHandlePlayerInput(SlideBlock BlockOne, ConsoleKey Move)
                {
                    //bool CheckForLock = true;
                    bool CheckForSlideBlock = false;
                    bool CheckForButtonOneBlock = false;
                    bool CheckForButtonTwoBlock = false;
                    bool CheckMoveIsFree = false;
                    


                    switch (Move)
                    {
                        //int[] PreposedMove;
                        case ConsoleKey.UpArrow:
                            {
                                MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y - 1, ConvertMoveMade(Move));

                                if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y - 1))
                                {

                                    CheckForSlideBlock = SlideBlockLogic(BlockOne, CurrentPlayer.x, CurrentPlayer.y - 1);
                                    
                                    //CheckForButtonOneBlock = ButtonBlockLogic
                                    //    (CurrentPlayer,SlideBlockOne,ButtonOneLogic(ButtonOne), ConvertMoveMade(Move));

                                    //CheckForButtonTwoBlock = ButtonBlockLogic
                                    //    (CurrentPlayer, SlideBlockOne, ButtonTwoLogic(ButtonTwo), ConvertMoveMade(Move));

                                    CheckMoveIsFree = LvFiveEvaluateMove(CheckForSlideBlock,CheckForButtonOneBlock,CheckForButtonTwoBlock);
                                    if (CheckMoveIsFree == false) { CurrentPlayer.y -= 1; }

                                }

                                if (CurrentPlayer.y < 0)
                                {
                                    CurrentPlayer.y = CurrentLevel.GetRows() - 1;
                                    MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y, ConvertMoveMade(Move));
                                    
                                }

                                break;
                            }

                        case ConsoleKey.DownArrow:
                            {
                                MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y + 1, ConvertMoveMade(Move));


                                if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y + 1))
                                {

                                    CheckForSlideBlock = SlideBlockLogic(BlockOne, CurrentPlayer.x, CurrentPlayer.y + 1);

                                    //CheckForButtonOneBlock = ButtonBlockLogic
                                    //   (CurrentPlayer, SlideBlockOne, ButtonOneLogic(ButtonOne), ConvertMoveMade(Move));
                                    //CheckForButtonTwoBlock = ButtonBlockLogic
                                    //   (CurrentPlayer, SlideBlockOne, ButtonTwoLogic(ButtonTwo), ConvertMoveMade(Move));

                                    CheckMoveIsFree = LvFiveEvaluateMove(CheckForSlideBlock, CheckForButtonOneBlock, CheckForButtonTwoBlock);
                                    if (CheckMoveIsFree == false) { CurrentPlayer.y += 1; }

                                }

                                if (CurrentPlayer.y + 1 > CurrentLevel.GetRows())
                                {
                                    CurrentPlayer.y = 0;
                                    MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y, ConvertMoveMade(Move));
                                }

                            }
                            break;

                        case ConsoleKey.LeftArrow:

                            MoveSlideBlock(BlockOne, CurrentPlayer.x - 1, CurrentPlayer.y, ConvertMoveMade(Move));


                            if (CurrentLevel.IsPositionClear(CurrentPlayer.x - 1, CurrentPlayer.y))
                            {

                                CheckForSlideBlock = SlideBlockLogic(BlockOne, CurrentPlayer.x - 1, CurrentPlayer.y);

                                //CheckForButtonOneBlock = ButtonBlockLogic
                                //       (CurrentPlayer, SlideBlockOne, ButtonOneLogic(ButtonOne), ConvertMoveMade(Move));
                                //CheckForButtonTwoBlock = ButtonBlockLogic
                                //       (CurrentPlayer, SlideBlockOne, ButtonTwoLogic(ButtonTwo), ConvertMoveMade(Move));

                                CheckMoveIsFree = LvFiveEvaluateMove(CheckForSlideBlock, CheckForButtonOneBlock, CheckForButtonTwoBlock);
                                if (CheckMoveIsFree == false) { CurrentPlayer.x -= 1; }

                            }

                            if (CurrentPlayer.x < 0)
                            {
                                CurrentPlayer.x = CurrentLevel.GetCols() - 1;
                                MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y, ConvertMoveMade(Move));

                            }

                            break;

                        case ConsoleKey.RightArrow:

                            MoveSlideBlock(BlockOne, CurrentPlayer.x + 1, CurrentPlayer.y, ConvertMoveMade(Move));


                            if (CurrentLevel.IsPositionClear(CurrentPlayer.x + 1, CurrentPlayer.y))
                            {

                                CheckForSlideBlock = SlideBlockLogic(BlockOne, CurrentPlayer.x + 1, CurrentPlayer.y);

                               // CheckForButtonOneBlock = ButtonBlockLogic
                                //       (CurrentPlayer, SlideBlockOne, ButtonOneLogic(ButtonOne), ConvertMoveMade(Move));
                                //CheckForButtonTwoBlock = ButtonBlockLogic
                                  //     (CurrentPlayer, SlideBlockOne, ButtonTwoLogic(ButtonTwo), ConvertMoveMade(Move));

                                CheckMoveIsFree = LvFiveEvaluateMove(CheckForSlideBlock, CheckForButtonOneBlock, CheckForButtonTwoBlock);
                                if (CheckMoveIsFree == false) { CurrentPlayer.x += 1; }

                            }

                            if (CurrentPlayer.x + 1 > CurrentLevel.GetCols())
                            {
                                CurrentPlayer.x = 0;
                                MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y, ConvertMoveMade(Move));
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

                    CurrentPlayer.DrawMove(Move);

                }



                bool LvFiveEvaluateMove(bool CheckForSlideBlock, bool CheckForButtonOneBlock, bool CheckForButtonTwoBlock)
                {
                    bool MoveEvaluation = false;
                    // if (CheckForLock == true) { MoveEvaluation = true; }
                    if (CheckForButtonOneBlock == true) {MoveEvaluation = true;}
                    if(CheckForButtonTwoBlock == true) {  MoveEvaluation = true;}
                    if (CheckForSlideBlock == true) { MoveEvaluation = true; }
                    return MoveEvaluation;
                }
                void CheckButton(Button Button)
                {
                    
                    if (Button.ButtonPushedCheck(CurrentPlayer.x, CurrentPlayer.y) == true) { Button.ButtonPressed = true; } 
                    else if (Button.ButtonPushedCheck(SlideBlockOne.SlideBlockX, SlideBlockOne.SlideBlockY) == true) { Button.ButtonPressed = true; }
                    else { Button.ButtonPressed = false; } 
                    
                }
                int[] ButtonOneLogic(Button Button)
                {
                    int[] PositionOne = new int[2] { 6, 5 };
                    int[] PositionTwo = new int[2] { 10, 7 };

                    if(Button.ButtonPressed == true) 
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
                int[] ButtonTwoLogic(Button Button)
                {
                    int[] PositionOne = new int[] { 5, 1 };
                    int[] PositionTwo = new int[] {10, 7 };

                    if (Button.ButtonPressed == true)
                    {
                        Console.SetCursorPosition(4, 0);
                        Console.WriteLine("|" + " " + "|");
                        Console.SetCursorPosition(4,1);
                        Console.WriteLine("#"+" "+"#");
                        return PositionTwo;
                    }
                    else
                    {
                        Console.SetCursorPosition(4, 0);
                        Console.WriteLine(" " + " " + " ");
                        Console.SetCursorPosition(4,1);
                        Console.WriteLine("="+"="+"=");
                        return PositionOne;
                    }




                }
                int[] ButtonThreeLogic(Button Button)
                {
                    int[] PositionOne = new int[] { 5, 13 };
                    int[] PositionTwo = new int[] { 10, 7 };

                    if (Button.ButtonPressed == true)
                    {
                        Console.SetCursorPosition(4, 13);
                        Console.WriteLine("#" + " " + "#");
                        Console.SetCursorPosition(4, 14);
                        Console.WriteLine("|" + " " + "|");
                        return PositionTwo;
                    }
                    else
                    {
                        Console.SetCursorPosition(4,13);
                        Console.WriteLine("="+"="+"=");
                        Console.SetCursorPosition(4,14);
                        Console.WriteLine(" " + " " + " ");
                       
                        return PositionOne;
                    }




                }
                int[] ButtonFourLogic(Button Button) 
                {
                    int[] PositionOne = new int[] { 9, 10 };
                    int[] PositionTwo = new int[] {10, 7 };

                    if (Button.ButtonPressed == true)
                    {
                        Console.SetCursorPosition(9, 10);
                        Console.WriteLine(" ");
                    

                        return PositionTwo;
                    }
                    else
                    {
                        Console.SetCursorPosition(9, 10);
                        Console.WriteLine("|");
                     

                        return PositionOne;
                    }
                }
                int[] ButtonFiveLogic(Button Button) 
                {
                    int[] PositionOne = new int[] { 9, 6 };
                    int[] PositionTwo = new int[] { 10, 7 };

                    if (Button.ButtonPressed == true)
                    {
                        Console.SetCursorPosition(9, 6);
                        Console.WriteLine(" ");


                        return PositionTwo;
                    }
                    else
                    {
                        Console.SetCursorPosition(9, 6);
                        Console.WriteLine("|");


                        return PositionOne;
                    }
                }


                bool ButtonBlockLogic(Player Player, SlideBlock Block, int[] ButtonBlock, int[] MoveMade)
                {
                    bool Result = false;
                    if (Player.x + MoveMade[0] == ButtonBlock[0])
                    { if(Player.y+ MoveMade[1] == ButtonBlock[1]) { Result = true; } }
                    else if(Block.BlockBeenPushed == true)
                    {   if (Block.SlideBlockX + MoveMade[0] == ButtonBlock[0])
                        { if (Block.SlideBlockY + MoveMade[1] == ButtonBlock[1]) { Result = true; } }
                    }
                    else { Result = false; }
                    return Result;
                }
               
            }

        }

        public void RunGameLoop()
        {
            bool HasPlayerReachedFinish = false;

            while (HasPlayerReachedFinish != true)
            {

                DrawFrame();

                HandlePlayerInput();

                Delay();

                HasPlayerReachedFinish = HasPlayerReachedGoal();

            }



        }

        private void Delay()
        { Thread.Sleep(50); }
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
        private void LvThreeHandlePlayerInput(LockAndKey Lock, ConsoleKey Move)
        {

            switch (Move)
            {
                case ConsoleKey.UpArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y - 1))
                    {
                        if (CurrentLevel.LockCheck(Lock, CurrentPlayer.x, CurrentPlayer.y - 1) == false)
                        { CurrentPlayer.y -= 1; }
                        else if (Lock.IsKeyPickedUp == true)
                        { CurrentPlayer.y -=1; }

                    }
                    if (CurrentPlayer.y < 0)
                    {
                        CurrentPlayer.y = CurrentLevel.GetRows() - 1;

                    }

                    break;

                case ConsoleKey.DownArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y + 1))
                    {
                        if (CurrentLevel.LockCheck(Lock, CurrentPlayer.x, CurrentPlayer.y + 1) == false)
                        { CurrentPlayer.y += 1; }
                        else if (Lock.IsKeyPickedUp == true)
                        { CurrentPlayer.y += 1; }
                    }
                    if (CurrentPlayer.y + 1 > CurrentLevel.GetRows())
                    {
                        CurrentPlayer.y = 0;

                    }
                    break;

                case ConsoleKey.LeftArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x - 1, CurrentPlayer.y))
                    {
                        if (CurrentLevel.LockCheck(Lock, CurrentPlayer.x - 1, CurrentPlayer.y) == false)
                        { CurrentPlayer.x -= 1; }
                        else if (Lock.IsKeyPickedUp == true)
                        { CurrentPlayer.x -= 1; }
                    }
                    if (CurrentPlayer.x < 0)
                    {
                        CurrentPlayer.x = CurrentLevel.GetCols() - 1;

                    }
                    break;

                case ConsoleKey.RightArrow:

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x + 1, CurrentPlayer.y))
                    {

                        if (CurrentLevel.LockCheck(Lock, CurrentPlayer.x + 1, CurrentPlayer.y) == false)
                        { CurrentPlayer.x += 1; }
                        else if(Lock.IsKeyPickedUp == true)
                        { CurrentPlayer.x += 1; }
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
     
        private void LvFourHandlePlayerInput
            (LockAndKey LockOne, LockAndKey LockTwo,
            SlideBlock BlockOne, SlideBlock BlockTwo
            , ConsoleKey Move)
        {
            bool CheckForLock = true;
            bool CheckForSlideBlock = false;
            bool CheckMoveIsFree = false;

            switch (Move)
            {
                //int[] PreposedMove;
                case ConsoleKey.UpArrow:
                    {
                        MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y - 1, ConvertMoveMade(Move));
                        MoveSlideBlock(BlockTwo, CurrentPlayer.x, CurrentPlayer.y - 1, ConvertMoveMade(Move));

                        if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y - 1))
                        {
                            CheckForLock = TwoLockCheck(LockOne, LockTwo, CurrentPlayer.x - 1, CurrentPlayer.y);
                            CheckForSlideBlock = TwoSlideBlockCheck(BlockOne, BlockTwo, CurrentPlayer.x, CurrentPlayer.y - 1);

                            CheckMoveIsFree = EvaluateMove(CheckForLock, CheckForSlideBlock);
                            if (CheckMoveIsFree == false) { CurrentPlayer.y -= 1; }

                        }

                        if (CurrentPlayer.y < 0)
                        {
                            CurrentPlayer.y = CurrentLevel.GetRows() - 1;

                        }

                        break;
                    }

                case ConsoleKey.DownArrow:
                    {
                        MoveSlideBlock(BlockOne, CurrentPlayer.x, CurrentPlayer.y + 1, ConvertMoveMade(Move));
                        MoveSlideBlock(BlockTwo, CurrentPlayer.x, CurrentPlayer.y + 1, ConvertMoveMade(Move));

                        if (CurrentLevel.IsPositionClear(CurrentPlayer.x, CurrentPlayer.y + 1))
                        {
                            CheckForLock = TwoLockCheck(LockOne, LockTwo, CurrentPlayer.x, CurrentPlayer.y + 1);
                            CheckForSlideBlock = TwoSlideBlockCheck(BlockOne, BlockTwo, CurrentPlayer.x, CurrentPlayer.y + 1);

                            CheckMoveIsFree = EvaluateMove(CheckForLock, CheckForSlideBlock);
                            if (CheckMoveIsFree == false) { CurrentPlayer.y += 1; }

                        }

                        if (CurrentPlayer.y + 1 > CurrentLevel.GetRows())
                        {
                            CurrentPlayer.y = 0;

                        }

                    }
                    break;
            
                case ConsoleKey.LeftArrow:

                    MoveSlideBlock(BlockOne, CurrentPlayer.x - 1, CurrentPlayer.y , ConvertMoveMade(Move));
                    MoveSlideBlock(BlockTwo, CurrentPlayer.x - 1, CurrentPlayer.y , ConvertMoveMade(Move));

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x - 1, CurrentPlayer.y ))
                    {
                        CheckForLock = TwoLockCheck(LockOne, LockTwo, CurrentPlayer.x - 1, CurrentPlayer.y);
                        CheckForSlideBlock = TwoSlideBlockCheck(BlockOne, BlockTwo, CurrentPlayer.x - 1, CurrentPlayer.y);

                        CheckMoveIsFree = EvaluateMove(CheckForLock, CheckForSlideBlock);
                        if (CheckMoveIsFree == false) { CurrentPlayer.x -= 1; }

                    }

                    if (CurrentPlayer.x < 0)
                    {
                        CurrentPlayer.x = CurrentLevel.GetCols() - 1;
                       
                        
                    }
                    break;

                case ConsoleKey.RightArrow:

                    MoveSlideBlock(BlockOne, CurrentPlayer.x + 1, CurrentPlayer.y, ConvertMoveMade(Move));
                    MoveSlideBlock(BlockTwo, CurrentPlayer.x + 1, CurrentPlayer.y, ConvertMoveMade(Move));

                    if (CurrentLevel.IsPositionClear(CurrentPlayer.x + 1, CurrentPlayer.y))
                    {
                        CheckForLock = TwoLockCheck(LockOne, LockTwo, CurrentPlayer.x + 1, CurrentPlayer.y);
                        CheckForSlideBlock = TwoSlideBlockCheck(BlockOne, BlockTwo, CurrentPlayer.x + 1, CurrentPlayer.y);

                        CheckMoveIsFree = EvaluateMove(CheckForLock, CheckForSlideBlock);
                        if (CheckMoveIsFree == false) { CurrentPlayer.x += 1; }

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
       
        private ConsoleKey GetInput()
        {
            ConsoleKey Move;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Move = keyInfo.Key;
            } while (Console.KeyAvailable);

            return Move;
        }
        private int GetMoveInt(ConsoleKey Move)
        {
            switch(Move)
            {
                case ConsoleKey.UpArrow:
                    { return CurrentPlayer.y -1 ; }
                case ConsoleKey.DownArrow:
                    { return CurrentPlayer.y + 1 ; }
                case ConsoleKey.LeftArrow:
                    { return CurrentPlayer.x - 1; }
                case ConsoleKey.RightArrow:
                    { return CurrentPlayer.x + 1; }
            }

            return CurrentPlayer.x;
        }
        private void LockAndKeyCheck(LockAndKey CurrentLockAndKey,Player CurrentPlayer)
        {
            CurrentLockAndKey.DoesPLayerHaveKey(CurrentLockAndKey,CurrentPlayer.x,CurrentPlayer.y);
            CurrentLockAndKey.UseKeyOnDoor(CurrentLockAndKey, CurrentPlayer.x, CurrentPlayer.y);
        }
        private bool HasPlayerReachedGoal()
        {
            string elimentAtPlayePos = CurrentLevel.GetElementAt(CurrentPlayer.x, CurrentPlayer.y);
            if (elimentAtPlayePos == "X")
            {
                return true;
            }
            return false;
        }
        private bool LockAndKeyLogic(LockAndKey Lock, int PreposedX, int PreposedY)
        {
            if (Lock.LockX==PreposedX)
            {
                if (Lock.LockY == PreposedY)
                {
                    if (Lock.IsKeyPickedUp==true)
                    { return false; }
                    return true;
                }
            }
            return false;
        }
        private bool LockAndKeyLogicTwoLocks(LockAndKey LockOne, LockAndKey LockTwo, int PreposedX, int PreposedY)
        {
            
            if (LockAndKeyLogic(LockOne,PreposedX,PreposedY) == true) { return true; }
            if (LockAndKeyLogic(LockTwo, PreposedX, PreposedY) == true) { return true; }
            
            return false;
        }
        private bool SlideBlockLogic(SlideBlock Block, int PreposedX,int PreposedY)
        {
            if ( Block.SlideBlockX == PreposedX)
            {
                if (Block.SlideBlockY ==PreposedY)
                { return true; }
            }
            return false;
        }
        private bool SlideBlockLogicTwoLocks(SlideBlock BlockOne, SlideBlock BlockTwo, int PreposedX, int PreposedY) 
        {
            if (SlideBlockLogic(BlockOne,PreposedX,PreposedY) == true) { return true; }
            if (SlideBlockLogic(BlockTwo,PreposedX,PreposedY) == true) { return true; }
            return false;
        }
        private bool EvaluateMove( bool CheckForLock, bool CheckForSlideBlock)
        {
            bool MoveEvaluation = false;
            if (CheckForLock == true) { MoveEvaluation = true; }
            if (CheckForSlideBlock == true) { MoveEvaluation = true;}
            return MoveEvaluation;
        }
        private bool TwoSlideBlockCheck(SlideBlock BlockOne, SlideBlock BlockTwo, int PreposedPlayerX, int PreposedPlayerY)
        { 
            if (SlideBlockLogicTwoLocks(BlockOne, BlockTwo, PreposedPlayerX, PreposedPlayerY) == false)
            { return false; }
            else { return true; }

        }
        private bool TwoLockCheck(LockAndKey LockOne, LockAndKey LockTwo, int PreposedPlayerX, int PreposedPlayerY)
        {
            if (LockAndKeyLogicTwoLocks(LockOne, LockTwo, PreposedPlayerX, PreposedPlayerY) == false)
            { return false; }
            else { return true; }
        }
        private void MoveSlideBlock(SlideBlock Block,int PreposedPlayerX, int PreposedPlayerY, int[] MoveMade )
        {
            if (Block.HasBlockBeenPushed( PreposedPlayerX, PreposedPlayerY) == true)
            {
                int PreposedBlockX = Block.SlideBlockX + MoveMade[0];
                int PreposedBlockY = Block.SlideBlockY + MoveMade[1];
               
                if (PreposedBlockX < 0){PreposedBlockX = CurrentLevel.GetCols() -1 ;}
                if (PreposedBlockX > CurrentLevel.GetCols()-1 ) { PreposedBlockX = 0; }

                if ( PreposedBlockY < 0){ PreposedBlockY = CurrentLevel.GetRows() - 1; }
                if (PreposedBlockY > CurrentLevel.GetRows()-1 ) {  PreposedBlockY = 0; }

                if (CurrentLevel.IsPositionClear(PreposedBlockX, PreposedBlockY))
                { Block.SlideBlockX = PreposedBlockX; Block.SlideBlockY = PreposedBlockY; }

            }
        }
        public int[] ConvertMoveMade(ConsoleKey MoveMade)
        {
            int[] Reff = new int[2] {0,0};

            switch (MoveMade)
            {
                case ConsoleKey.UpArrow:    { Reff[1] = - 1; }
                    break;
                case ConsoleKey.DownArrow:  { Reff[1] = + 1; }
                    break;
                case ConsoleKey.LeftArrow:  { Reff[0] = - 1; }
                    break;
                case ConsoleKey.RightArrow: { Reff[0] = + 1; }
                    break;
            }

            return Reff;
        }
        private int[] GetNextPlayerLocation(Player CurrentPlayer, ConsoleKey Input)
        {
            int[] Move = new int[2];
            Move = ConvertMoveMade(Input);
            int[] PreposedPlayerReff = new int[2] { CurrentPlayer.x + Move[0], CurrentPlayer.y + Move[1] };
            return PreposedPlayerReff;
        }
        private void HanddlePlayerInput
            (string[,] Level,Player CurrentPlayer,SlideBlock BlockOne,ConsoleKey Input)
        {
            //bool CheckForLock = true;
            bool CheckForSlideBlock = false;
            bool CheckForButtonOneBlock = false;
            bool CheckForButtonTwoBlock = false;
            bool CheckForButtonThreeBlock = false;
            bool CheckForButtonFourBlock = false;
            bool CheckForButtonFiveBlock = false;
            bool CheckMoveIsFree = false;

            int[] Move = new int[2];
            Move = ConvertMoveMade(Input);
            int[] PreposedPlayerMove = new int[2] { CurrentPlayer.x + Move[0], CurrentPlayer.y + Move[1] };
           

          
                        MoveSlideBlock(BlockOne, PreposedPlayerMove[0],PreposedPlayerMove[1], ConvertMoveMade(Input));

                        if (CurrentLevel.IsPositionClear(PreposedPlayerMove[0], PreposedPlayerMove[1]))
                        {

                            CheckForSlideBlock = SlideBlockLogic(BlockOne, PreposedPlayerMove[0], PreposedPlayerMove[1]);
                            CheckForButtonOneBlock = ButtonBlockLogic(CurrentPlayer,BlockOne,But);
                            CheckMoveIsFree = EvaluateMoveTest(CheckForSlideBlock,CheckForButtonOneBlock,CheckForButtonTwoBlock);
                            if (CheckMoveIsFree == true) 
                            {
                                CurrentPlayer.DrawMove(Input);
                                
                            }

                        }

            LoopLogic(PreposedPlayerMove,Level,BlockOne,Input);


        }
        private void LoopLogic(int[] PreposedPlayerMove, string[,] Level,SlideBlock BlockOne,ConsoleKey Input)
        {
            if (PreposedPlayerMove[0] < 0)
            {
                PreposedPlayerMove[0] = Level.GetLength(0)- 1;
                MoveSlideBlock(BlockOne, PreposedPlayerMove[0], PreposedPlayerMove[1], ConvertMoveMade(Input));
            }
            if (PreposedPlayerMove[0] > Level.GetLength(0) - 1)
            {
                PreposedPlayerMove[0] = 0;
                MoveSlideBlock(BlockOne, PreposedPlayerMove[0], PreposedPlayerMove[1], ConvertMoveMade(Input));
            }
            if (PreposedPlayerMove[1] < 0)
            {
                PreposedPlayerMove[1] = Level.GetLength(1) - 1;
                MoveSlideBlock(BlockOne, PreposedPlayerMove[0], PreposedPlayerMove[1], ConvertMoveMade(Input));
            }
            if (PreposedPlayerMove[1] > Level.GetLength(1) - 1)
            {
                PreposedPlayerMove[1] = 0;
                MoveSlideBlock(BlockOne, PreposedPlayerMove[0], PreposedPlayerMove[1], ConvertMoveMade(Input));
            }

        }
        private bool EvaluateMoveTest
        
           (bool CheckForSlideBlock, bool CheckForButtonOneBlock, bool CheckForButtonTwoBlock)
            {
                bool MoveEvaluation = false;
                // if (CheckForLock == true) { MoveEvaluation = true; }
                if (CheckForButtonOneBlock == true) { MoveEvaluation = true; }
                if (CheckForButtonTwoBlock == true) { MoveEvaluation = true; }
                if (CheckForSlideBlock == true) { MoveEvaluation = true; }
                return MoveEvaluation;
            
        }
        private bool ButtonBlockLogic(Player Player, SlideBlock Block, int[] ButtonBlock, int[] MoveMade)
        {
            bool Result = false;
            if (Player.x + MoveMade[0] == ButtonBlock[0])
            { if (Player.y + MoveMade[1] == ButtonBlock[1]) { Result = true; } }
            else if (Block.BlockBeenPushed == true)
            {
                if (Block.SlideBlockX + MoveMade[0] == ButtonBlock[0])
                { if (Block.SlideBlockY + MoveMade[1] == ButtonBlock[1]) { Result = true; } }
            }
            else { Result = false; }
            return Result;
        }




    }
     

}


