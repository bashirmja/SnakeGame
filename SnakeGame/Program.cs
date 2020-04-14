using System;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        private static Snake snake;
        private static PlayGround ground;

        static async Task Main()
        {
            ground = new PlayGround(25, 50, 20);
            snake = new Snake(new Point(40, 15));
            SetupConsole();

            while (true)
            {
                DrawAllComponents();

                var key = Console.ReadKey(true).Key;
                ClearSnake();
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        snake.Move(Direction.Down, ground.FoodPoints);
                        break;
                    case ConsoleKey.UpArrow:
                        snake.Move(Direction.Up, ground.FoodPoints);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(Direction.Left, ground.FoodPoints);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(Direction.Right, ground.FoodPoints);
                        break;
                    case ConsoleKey.F1:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }

                await Task.Delay(100);

            }

        }

        private static void SetupConsole()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
        }

        private static void DrawAllComponents()
        {
            DrawVerticalBoarders();
            DrawHorisantalBoarders();
            DrawFoods();
            DrawSnake();


        }

        private static void ClearSnake()
        {
            var Last = snake.BodyPoints.ToList().Last();
            Console.SetCursorPosition(Last.X, Last.Y);
            Console.Write(" ");
        }

        private static void DrawFoods()
        {
            foreach (var item in ground.FoodPoints.ToList())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("+");
            }
        }

        private static void DrawSnake()
        {
            var list = snake.BodyPoints.ToList();
            var head = list.First();
            foreach (var item in list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(item.X, item.Y);
                if (item == head)
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
            for (int w = 1; w < ground.Width; w++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(w, 0);
                Console.Write("_");
                Console.SetCursorPosition(w, ground.Height - 1);
                Console.Write("_");
            }
        }

        private static void DrawVerticalBoarders()
        {
            for (int h = 1; h < ground.Height; h++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, h);
                Console.Write("|");
                Console.SetCursorPosition(ground.Width, h);
                Console.Write("|");
            }
        }

    }
}
