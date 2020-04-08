using System;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static ConsoleKey _arrowkey = ConsoleKey.RightArrow;
        static int x = 60;
        static int y = 15;

        static async Task Main()
        {
            _ = Task.Run(() => GetKeyAsync());

            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                HandlePosition();
                Console.SetCursorPosition(x, y);

                Console.Write("*");

                await Task.Delay(200);
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
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        _arrowkey = key;
                        break;
                }
            }
        }

        static void HandlePosition()
        {
            switch (_arrowkey)
            {
                case ConsoleKey.DownArrow:
                    y += 1;
                    break;

                case ConsoleKey.UpArrow:
                    y -= 1;
                    break;

                case ConsoleKey.LeftArrow:
                    x -= 2;
                    break;

                case ConsoleKey.RightArrow:
                    x += 2;
                    break;

                default:
                    throw new Exception("Error in Key Handler");
            }
        }
    }
}
