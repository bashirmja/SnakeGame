using System;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        private static Snake snake;

        static async Task Main()
        {
            snake = new Snake(new Point(40, 15), 25, 50, 5);
            SetupConsole();

            while (true)
            {
                DrawAllComponents();

                var key = Console.ReadKey(true).Key;
                ClearSnakeTail();
                UpdateStatus? status = key switch
                {
                    ConsoleKey.DownArrow => snake.MoveingSnake(Direction.Down),
                    ConsoleKey.UpArrow => snake.MoveingSnake(Direction.Up),
                    ConsoleKey.LeftArrow => snake.MoveingSnake(Direction.Left),
                    ConsoleKey.RightArrow => snake.MoveingSnake(Direction.Right),
                    _ => null,
                };
                if (status == UpdateStatus.EndOfFoods)
                {
                    DrawSnake();
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("You are a winner! Hit Enter to finish the game.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }



                await Task.Delay(100);
            }
        }

        private static void GameSetup()
        {
        }

        private static void SetupConsole()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WindowWidth = 51;
            Console.BufferWidth = 51;
            Console.WindowHeight = 27;
            Console.BufferHeight = 35;
        }

        private static void DrawAllComponents()
        {
            DrawVerticalBoarders();
            DrawHorisantalBoarders();
            DrawFoods();
            DrawSnake();
        }

        private static void ClearSnakeTail()
        {
            var Last = snake.SnakeBodyPoints.ToList().Last();
            Console.SetCursorPosition(Last.Left, Last.Top);
            Console.Write(" ");
        }

        private static void DrawFoods()
        {
            foreach (var item in snake.FoodPoints.ToList())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(item.Left, item.Top);
                Console.Write("+");
            }
        }

        private static void DrawSnake()
        {
            var list = snake.SnakeBodyPoints.ToList();
            foreach (var item in list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(item.Left, item.Top);
                if (item == list.First())
                {
                    Console.Write("O");
                }
                else
                {
                    Console.Write("o");
                }
            }
        }

        private static void DrawHorisantalBoarders()
        {
            for (int w = 1; w < snake.PlayGroundWidth; w++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(w, 0);
                Console.Write("_");
                Console.SetCursorPosition(w, snake.PlayGroundHeight - 1);
                Console.Write("_");
            }
        }

        private static void DrawVerticalBoarders()
        {
            for (int h = 1; h < snake.PlayGroundHeight; h++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, h);
                Console.Write("|");
                Console.SetCursorPosition(snake.PlayGroundWidth, h);
                Console.Write("|");
            }
        }

    }
}
