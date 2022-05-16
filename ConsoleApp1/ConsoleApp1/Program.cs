using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int score = 0;
            int xPosition = 1;
            int yPosition = 1;

            while (score != 1)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Достаньте *");
                Console.SetCursorPosition(0,0);
                char[,] map = DrawMap();
                MoveCharacter(ref xPosition,ref yPosition,ref score, map);
                Console.Clear();
            }
        }

        static char[,] DrawMap()
        {
            char[,] map = {
                { '#','#','#','#','#','#','#','#','#','#' },
                { '#',' ','#',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ','#',' ',' ','#',' ',' ',' ','#' },
                { '#',' ','#',' ',' ','#','#','#','#','#' },
                { '#',' ','#',' ',' ','#',' ',' ',' ','#' },
                { '#',' ','#',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ','#',' ',' ','#','#','#','#','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ','#',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ','#',' ',' ',' ',' ',' ','*','#' },
                { '#','#','#','#','#','#','#','#','#','#' }
            };

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }

            return map;
        }

        static void MoveCharacter(ref int yPosition,ref int xPosition,ref int score, char [,] map)
        {
            Console.SetCursorPosition(yPosition, xPosition);
            Console.Write('@');
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:

                    if (map[xPosition - 1, yPosition] != '#')
                    {
                        int xPositionMove = -1;
                        int yPositionMove = 0;
                        Move(map,ref xPosition,ref yPosition, xPositionMove, yPositionMove);
                    }

                    break;
                case ConsoleKey.DownArrow:

                    if (map[xPosition + 1, yPosition] != '#')
                    {
                        int xPositionMove = 1;
                        int yPositionMove = 0;
                        Move(map, ref xPosition, ref yPosition, xPositionMove, yPositionMove);
                    }

                    break;
                case ConsoleKey.LeftArrow:

                    if (map[xPosition, yPosition - 1] != '#')
                    {
                        int xPositionMove = 0;
                        int yPositionMove = -1;
                        Move(map, ref xPosition, ref yPosition, xPositionMove, yPositionMove);
                    }

                    break;
                case ConsoleKey.RightArrow:

                    if (map[xPosition, yPosition + 1] != '#')
                    {
                        int xPositionMove = 0;
                        int yPositionMove = 1;
                        Move(map, ref xPosition, ref yPosition, xPositionMove, yPositionMove);
                    }

                    break;
            }

            if (map[xPosition, yPosition] == '*')
            {
                score++;
                Console.WriteLine("Вы победили");
            }
        }

        static void Move(char [,] map,ref int xPosition, ref int yPosition, int xPositionMove,int yPositionMove)
        {
            xPosition += xPositionMove;
            yPosition += yPositionMove;
        }
    }
}