using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            bool isWin = false;
            int xPosition = 1;
            int yPosition = 1;
            int xMoveDirection;
            int yMoveDirection;
            char[,] map = CreateMap();

            while (isWin == false)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Достаньте *");
                Console.SetCursorPosition(0, 0);
                DrawMap(map);
                Console.SetCursorPosition(yPosition, xPosition);
                Console.Write('@');
                ChooseDirection(out xMoveDirection, out yMoveDirection);
                Move(ref xPosition, ref yPosition, map,xMoveDirection,yMoveDirection);

                if (map[xPosition, yPosition] == '*')
                {
                    isWin = true;
                    ShowMessage();
                }

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

        static void ChooseDirection(out int xMoveDirection,out int yMoveDirection)
        {
            xMoveDirection = 0;
            yMoveDirection = 0;
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                xMoveDirection = -1;
                    break;
                case ConsoleKey.DownArrow:
                xMoveDirection = 1;
                    break;
                case ConsoleKey.LeftArrow:
                yMoveDirection = -1;
                    break;
                case ConsoleKey.RightArrow:
                yMoveDirection = 1;
                    break;
            }
        }

        static void Move(ref int xPosition, ref int yPosition, char[,] map, int xMoveDirection = 0, int yMoveDirection = 0)
        {
            if (map[xPosition + xMoveDirection,yPosition + yMoveDirection] != '#')
            {
                xPosition += xMoveDirection;
                yPosition += yMoveDirection;
            }
        }

        static void ShowMessage()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Вы победили");
        }
    }
}