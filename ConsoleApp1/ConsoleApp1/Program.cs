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
            int xPositionMove = 0;
            int yPositionMove = 0;

            while (score != 1)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Достаньте *");
                Console.SetCursorPosition(0, 0);
                char[,] map = SetMap();
                DrawMap(map);
                MoveCharacter(ref xPosition, ref yPosition, ref score, xPositionMove, yPositionMove, map);
                Console.Clear();
            }
        }

        static char[,] SetMap()
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
            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void MoveCharacter(ref int yPosition, ref int xPosition, ref int score, int xPositionMove, int yPositionMove, char[,] map)
        {
            Console.SetCursorPosition(yPosition, xPosition);
            Console.Write('@');
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:

                    if (map[xPosition - 1, yPosition] != '#')
                    {
                        xPositionMove = -1;
                    }

                    break;
                case ConsoleKey.DownArrow:

                    if (map[xPosition + 1, yPosition] != '#')
                    {
                        xPositionMove = 1;
                    }

                    break;
                case ConsoleKey.LeftArrow:

                    if (map[xPosition, yPosition - 1] != '#')
                    {
                        yPositionMove = -1;
                    }

                    break;
                case ConsoleKey.RightArrow:

                    if (map[xPosition, yPosition + 1] != '#')
                    {
                        yPositionMove = 1;
                    }
                    break;
            }
            Move(ref xPosition, ref yPosition, xPositionMove, yPositionMove);

            if (map[xPosition, yPosition] == '*')
            {
                Win(ref score);
            }
        }

        static void Move(ref int xPosition, ref int yPosition, int xPositionMove = 0, int yPositionMove = 0)
        {
            xPosition += xPositionMove;
            yPosition += yPositionMove;
        }

        static void Win(ref int score)
        {
            score++;
            Console.WriteLine("Вы победили");
        }
    }
}