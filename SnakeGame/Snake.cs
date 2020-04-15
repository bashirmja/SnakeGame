using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Snake
    {
        public List<Point> SnakeBodyPoints { get; set; }
        public List<Point> FoodPoints { get; set; }

        public int PlayGroundWidth { get; set; }
        public int PlayGroundHeight { get; set; }


        public Snake(Point firstBodyPoint, int height, int width, int FoodsNumber)
        {
            SnakeBodyPoints = new List<Point>
            {
                firstBodyPoint
            };
            PlayGroundHeight = height;
            PlayGroundWidth = width;
            FoodPoints = new List<Point>();

            for (int i = 0; i < FoodsNumber; i++)
            {
                var random = new Random();

                var top = random.Next(2, PlayGroundHeight - 1);
                var left = random.Next(2, PlayGroundWidth - 1);
                left = left % 2 != 0 ? left - 1 : left;

                FoodPoints.Add(new Point(left, top));
            }
        }


        public UpdateStatus MoveingSnake(Direction dir)
        {
            var snakeHead = SnakeBodyPoints.First();

            Point newHead = dir switch
            {
                Direction.Up => new Point(snakeHead.Left, snakeHead.Top - 1),
                Direction.Down => new Point(snakeHead.Left, snakeHead.Top + 1),
                Direction.Left => new Point(snakeHead.Left - 2, snakeHead.Top),
                Direction.Right => new Point(snakeHead.Left + 2, snakeHead.Top),
                _ => null,
            };

            if (newHead.Left != 0 && newHead.Left != PlayGroundWidth && newHead.Top != 0 && newHead.Top != PlayGroundHeight - 1)
            {
                SnakeBodyPoints.Insert(0, newHead);


                var flag = true;
                foreach (var item in FoodPoints.ToList())
                {
                    if (newHead == item)
                    {
                        FoodPoints.Remove(item);
                        flag = false;
                    }
                }

                if (flag)
                {
                    SnakeBodyPoints.Remove(SnakeBodyPoints.Last());
                }

                if (FoodPoints.Count() == 0)
                {
                    return UpdateStatus.EndOfFoods;
                }
                return UpdateStatus.ateFood;
            }
            else
            {
                return UpdateStatus.BoardersHited;
            }
        }



    }
}
