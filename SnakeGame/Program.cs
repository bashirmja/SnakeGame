using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        private static Snake snake;

        static async Task Main()
        {
            var ground = new PlayGround(25, 100, 10);
            snake= new Snake(new Point(60, 15));

            _ = Task.Run(() => GetKeyAsync());
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();

                for (int h = 0; h < ground.Height; h++)
                {

                    Console.SetCursorPosition(0, h);
                    Console.Write("|");
                    Console.SetCursorPosition(ground.Width, h);
                    Console.Write("|");
                }

                for (int w = 1; w < ground.Width; w++)
                {
                    Console.SetCursorPosition(w, 0);
                    Console.Write("-");
                    Console.SetCursorPosition(w, ground.Height-1);
                    Console.Write("-");
                }


                foreach (var item in snake.BodyPoints)
                {
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.Write("o");
                }

                foreach (var item in ground.FoodPoints)
                {
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.Write("+");
                }



                snake.EatingCheck(ground.FoodPoints);


                await Task.Delay(50);
            }
        }

        static async Task GetKeyAsync()
        {
            while (true)
            {
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        snake.ChangeDirection(Direction.Down);
                        break;
                    case ConsoleKey.UpArrow:
                        snake.ChangeDirection(Direction.Up);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.ChangeDirection(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.ChangeDirection(Direction.Right);
                        break;
                }
            }
        }


    }
}
