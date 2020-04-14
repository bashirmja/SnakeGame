using System;
using System.Collections.Generic;

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
            
            var top = random.Next(2, Height - 1);
            var left = random.Next(2, Width - 1);
            left = left % 2 != 0 ? left - 1 : left;

            return new Point(left, top);
        }


    }
}
