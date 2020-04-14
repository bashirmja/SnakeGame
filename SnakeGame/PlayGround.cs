using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class PlayGround
    {
        public List<Point> FoodPoints { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public PlayGround(int height, int width, int FoodsNumber)
        {
            Height = height;
            Width = width;
            FoodPoints = new List<Point>();
            for (int i = 0; i < FoodsNumber; i++)
            {
                FoodPoints.Add(NewFood());
            }
        }

        public Point NewFood()
        {
            var random = new Random();

            var x = random.Next(1, Width - 1);
            var y = random.Next(1, Height - 1);

            return new Point(x%2!=0? x-1:x, y);

        }


    }
}
