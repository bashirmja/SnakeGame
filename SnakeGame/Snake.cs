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

        public void MoveingSnake(Direction dir, PlayGround ground)
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

            if (newHead.Left == 0 || newHead.Left == ground.Width)
            {
                return;
            }
            if (newHead.Top == 0 || newHead.Top == ground.Height -1)
            {
                return;
            }

            SnakeBodyPoints.Insert(0, newHead);

            if (!EatingCheck(ground.FoodPoints))
            {
                SnakeBodyPoints.Remove(SnakeBodyPoints.Last());
            }
        }

        public bool EatingCheck(List<Point> foodPoints)
        {
            var snakeHead = SnakeBodyPoints.First();

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

        //public bool HitingWallCheck(int height, int width)
        //{
        //    var snakeHead = SnakeBodyPoints.First();

        //    if (snakeHead.Left==1 || snakeHead.Left==width)
        //    {
        //        return true;
        //    }

        //    if (snakeHead.Top == 1 || snakeHead.Top == height-1 )
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
