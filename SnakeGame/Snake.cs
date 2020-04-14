using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Snake
    {
        public List<Point> BodyPoints { get; set; }

        public Snake(Point startingPoint)
        {
            BodyPoints = new List<Point>
            {
                startingPoint
            };
        }

        public void Move(Direction dir, List<Point> foodPoints)
        {
            var snakeHead = BodyPoints.First();

            switch (dir)
            {
                case Direction.Up:
                    BodyPoints.Insert(0, new Point(snakeHead.X, snakeHead.Y - 1));
                    break;
                case Direction.Down:
                    BodyPoints.Insert(0, new Point(snakeHead.X, snakeHead.Y + 1));
                    break;
                case Direction.Left:
                    BodyPoints.Insert(0, new Point(snakeHead.X - 2, snakeHead.Y));
                    break;
                case Direction.Right:
                    BodyPoints.Insert(0, new Point(snakeHead.X + 2, snakeHead.Y));
                    break;
            }

            if (!EatingCheck(foodPoints))
            {
                BodyPoints.Remove(BodyPoints.Last());

            }



        }

        public bool EatingCheck(List<Point> foodPoints)
        {
            var snakeHead = BodyPoints.First();

            foreach (var item in foodPoints.ToList())
            {
                if (snakeHead == item)
                {
                    foodPoints.Remove(item);
                    return true;

                }
            }
            return false;
        }
    }
}
