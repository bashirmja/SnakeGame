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

        public void ChangeDirection(Direction dir)
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

            BodyPoints.Remove(BodyPoints.Last());

        }

        public void EatingCheck(List<Point> foodPoints)
        {
            var snakeHead = BodyPoints.First();

            foreach (var item in foodPoints.ToList())
            {
                if (snakeHead==item)
                {
                    foodPoints.Remove(item);
                    BodyPoints.Insert(0, snakeHead);
                }

            }

        }
    }
}
