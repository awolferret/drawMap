using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isWin = false;
            int xPosition = 1;
            int yPosition = 1;
            char[,] map = CreateMap();

            while (isWin == false)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Достаньте *");
                Console.SetCursorPosition(0, 0);
                DrawMap(map);
                Console.SetCursorPosition(yPosition, xPosition);
                Console.Write('@');
                MoveCharacter(ref xPosition, ref yPosition, ref isWin, map);
                Console.Clear();
            }
        }

        static char[,] CreateMap()
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

        static void MoveCharacter(ref int xPosition, ref int yPosition, ref bool isWin, char[,] map )
        {
            int xPositionMove = 0;
            int yPositionMove = 0;
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                xPositionMove = -1;
                    break;
                case ConsoleKey.DownArrow:
                xPositionMove = 1;
                    break;
                case ConsoleKey.LeftArrow:
                yPositionMove = -1;
                    break;
                case ConsoleKey.RightArrow:
                yPositionMove = 1;
                    break;
            }
            Move(ref xPosition, ref yPosition, ref isWin, map, xPositionMove, yPositionMove);
        }

        static void Move(ref int xPosition, ref int yPosition,ref bool isWin, char[,] map, int xPositionMove = 0, int yPositionMove = 0)
        {
            if (map[xPosition + xPositionMove,yPosition + yPositionMove] != '#')
            {
                xPosition += xPositionMove;
                yPosition += yPositionMove;
            }
            if (map[xPosition, yPosition] == '*')
            {
                Win(ref isWin);
            }
        }

        static void Win(ref bool isWin)
        {
            isWin = true;
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Вы победили");
        }
    }
}