using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Snake
    {
        public List<Point> SnakeBodyPoints { get; set; }

        public Snake(Point firstBodyPoint)
        {
            SnakeBodyPoints = new List<Point>
            {
                firstBodyPoint
            };
        }

        public UpdateStatus MoveingSnake(Direction dir, PlayGround ground)
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

            if (newHead.Left != 0 && newHead.Left != ground.Width && newHead.Top != 0 && newHead.Top != ground.Height - 1)
            {
                SnakeBodyPoints.Insert(0, newHead);


                var flag = true;
                foreach (var item in ground.FoodPoints.ToList())
                {
                    if (newHead == item)
                    {
                        ground.FoodPoints.Remove(item);
                        flag = false;
                    }
                }

                if (flag)
                {
                    SnakeBodyPoints.Remove(SnakeBodyPoints.Last());
                }

                if (ground.FoodPoints.Count() == 0)
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
