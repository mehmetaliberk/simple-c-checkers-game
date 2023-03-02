using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating game table
            Console.SetCursorPosition(3, 0);
            for (int i = 1; i <= 8; i++)
            {
                Console.Write(i + " ");
            }
            Console.SetCursorPosition(1, 1);
            Console.Write(" +----------------+");
            for (int i = 1; i <= 8; i++)
            {
                Console.SetCursorPosition(1, i + 1);
                Console.WriteLine(i + "|");
                Console.WriteLine();
            }
            for (int i = 1; i <= 8; i++)
            {
                Console.SetCursorPosition(19, i + 1);
                Console.WriteLine("|");
            }
            Console.WriteLine("  +----------------+");
            //adding o pieces
            string[,] gameBoard = new string[8, 8];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = "o";
                }
            }
            //adding x pieces
            for (int i = 5; i < 8; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    gameBoard[i, j] = "x";
                }
            }
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gameBoard[i, j] != "o" && gameBoard[i, j] != "x")
                    {
                        gameBoard[i, j] = ".";
                    }
                }
            }

            //printing table
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(3, 2 + i);
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(gameBoard[i, j] + " "); ;
                }
                Console.WriteLine();
            }

            int cursorx = 3, cursory = 2;
            ConsoleKeyInfo cki;
            string Selected_Piece = "";
            int Selected_Piecex = 0;
            int Selected_Piecey = 0;
            int move = 1;
            Console.SetCursorPosition(25, 3);
            Console.WriteLine("Round number:" +( move/2+1));
            Console.SetCursorPosition(25, 4);
            Console.WriteLine("Turn: x");
            bool x_moved=false, o_moved=false;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.RightArrow && cursorx < 17)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursorx += 2;
                    }
                    if (cki.Key == ConsoleKey.LeftArrow && cursorx > 4)
                    {
                        Console.SetCursorPosition(cursorx, cursory);

                        cursorx -= 2;
                    }
                    if (cki.Key == ConsoleKey.UpArrow && cursory > 2)
                    {
                        Console.SetCursorPosition(cursorx, cursory);

                        cursory--;
                    }
                    if (cki.Key == ConsoleKey.DownArrow && cursory < 9)
                    {
                        Console.SetCursorPosition(cursorx, cursory);

                        cursory++;
                    }
                    if (cki.Key == ConsoleKey.Z)
                    {
                        if (gameBoard[cursory - 2, cursorx / 2 - 1] == "x")
                        {
                            Console.SetCursorPosition(25, 3);
                            Selected_Piece = "x";
                            Selected_Piecex = cursorx;
                            Selected_Piecey = cursory;
                        }
                    }
                    if (cki.Key == ConsoleKey.X && x_moved == false)
                    {
                        x_moved = false;

                        if (gameBoard[cursory - 2, cursorx / 2 - 1] == "." && Selected_Piece == "x" && (Selected_Piecex == cursorx + 2 || Selected_Piecex == cursorx - 2 || Selected_Piecey == cursory + 1 || Selected_Piecey == cursory - 1))
                        {

                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                            x_moved = true;
                        }

                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" && Selected_Piecex == cursorx - 4 && gameBoard[Selected_Piecey - 2, (cursorx / 2) - 2] == "o")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                            
                        }
                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" && Selected_Piecex == cursorx + 4 && gameBoard[Selected_Piecey - 2, (cursorx / 2)] == "o")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                           
                        }
                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" && Selected_Piecey == cursory + 2 && gameBoard[cursory - 1, cursorx / 2 - 1] == "o")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                           
                        }
                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" & Selected_Piecey == cursory - 2 && gameBoard[cursory - 3, cursorx / 2 - 1] == "o")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                          
                        }


                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" && Selected_Piecex == cursorx - 4 && gameBoard[Selected_Piecey - 2, (cursorx / 2) - 2] == "x")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                         
                        }
                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" && Selected_Piecex == cursorx + 4 && gameBoard[Selected_Piecey - 2, (cursorx / 2)] == "x")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                          
                        }
                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" && Selected_Piecey == cursory + 2 && gameBoard[cursory - 1, cursorx / 2 - 1] == "x")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                        
                        }
                        if (gameBoard[cursory - 2, (cursorx / 2) - 1] == "." && Selected_Piece == "x" & Selected_Piecey == cursory - 2 && gameBoard[cursory - 3, cursorx / 2 - 1] == "x")
                        {
                            gameBoard[cursory - 2, cursorx / 2 - 1] = "x";
                            gameBoard[Selected_Piecey - 2, Selected_Piecex / 2 - 1] = ".";
                            Selected_Piece = " ";
                       
                        }
                        if (x_moved==true)
                        {
                            Console.SetCursorPosition(25, 3);
                            Console.WriteLine("Round number:" + (move / 2 + 1));
                            move++;
                            Console.SetCursorPosition(25, 4);
                            Console.WriteLine("Turn: o");
                            o_moved = false;
                        }
       
                    }
                    if (cki.Key == ConsoleKey.C&&o_moved==false)
                    {
                        string Selected_Piece_ai = "";
                        Random rnd = new Random();
                        int Selected_Piece_aix;
                        int Selected_Piece_aiy;

                        while (Selected_Piece_ai != "o")
                        {
                            int row = rnd.Next(8);
                            int column = rnd.Next(8);
                            if (gameBoard[row, column] == "o")
                            {
                                if (row < 6 && column < 7 && gameBoard[row + 1, column] == "x" && gameBoard[row + 2, column] == ".")
                                {
                                    gameBoard[row + 2, column] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                                if (row < 7 && column < 6 && gameBoard[row, column + 1] == "x" && gameBoard[row, column + 2] == ".")
                                {
                                    gameBoard[row, column + 2] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                                if (row < 6 && column < 7 && gameBoard[row + 1, column] == "o" && gameBoard[row + 2, column] == ".")
                                {
                                    gameBoard[row + 2, column] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                                if (row < 7 && column < 6 && gameBoard[row, column + 1] == "o" && gameBoard[row, column + 2] == ".")
                                {
                                    gameBoard[row, column + 2] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                                int move_direction = rnd.Next(2);
                                if (row < 7 && move_direction == 0 && gameBoard[row + 1, column] == ".")
                                {
                                    gameBoard[row + 1, column] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                                if (column < 7 && move_direction == 1 && gameBoard[row, column + 1] == ".")
                                {
                                    gameBoard[row, column + 1] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                                if (row==7&& gameBoard[row - 1, column] == ".")
                                {
                                    gameBoard[row-1, column] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                                if (column == 7&& gameBoard[row, column - 1] == ".")
                                {
                                    gameBoard[row , column-1] = "o";
                                    gameBoard[row, column] = ".";
                                    Selected_Piece_ai = "o";
                                    o_moved = true;
                                    break;
                                }
                            }

                        }
                        if (o_moved == true)
                        {
                            Console.SetCursorPosition(25, 3);
                            Console.WriteLine("Round number:" + (move / 2 + 1));
                            move++;
                            Console.SetCursorPosition(25, 4);
                            Console.WriteLine("Turn: x");
                            x_moved = false;
                        }
                        
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    Console.SetCursorPosition(3, 2 + i);
                    for (int j = 0; j < 8; j++)
                    {
                        if (gameBoard[i,j]=="x")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        if (gameBoard[i, j] == "o")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(gameBoard[i, j] + " "); ;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(cursorx, cursory);
                Thread.Sleep(100);
                if (gameBoard[0,0]=="x"&& gameBoard[0, 1] == "x" && gameBoard[0, 2] == "x" && gameBoard[1, 0] == "x" && gameBoard[1, 1] == "x" && gameBoard[1,2] == "x" && gameBoard[2, 0] == "x" && gameBoard[2, 1] == "x" && gameBoard[2, 2] == "x")
                {
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("X IS WINNER");
                    break;

                }
                if (gameBoard[7, 7] == "o" && gameBoard[7, 6] == "o" && gameBoard[7, 5] == "o" && gameBoard[6, 7] == "o" && gameBoard[6, 6] == "o" && gameBoard[6, 5] == "o" && gameBoard[5, 5] == "o" && gameBoard[5, 6] == "o" && gameBoard[5, 7] == "o")
                {
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("O IS WINNER");
                    break;

                }
            }



            Console.ReadLine();
        }
    }
}
