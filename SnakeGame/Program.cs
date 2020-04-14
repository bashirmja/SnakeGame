using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        private static Snake snake;

        static async Task Main()
        {
            snake= new Snake(new Point(60, 15));

            _ = Task.Run(() => GetKeyAsync());
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();

                foreach (var item in snake.BodyPoints.ToList())
                {
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.Write("*");
                }



                await Task.Delay(10);
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
