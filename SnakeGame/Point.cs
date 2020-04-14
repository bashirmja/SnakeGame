namespace SnakeGame
{
        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int Y { get; set; }
            public int X { get; set; }

        public static bool operator ==(Point First, Point Second)
        {
            return First.X == Second.X && First.Y == Second.Y;

        }

        public static bool operator !=(Point First, Point Second)
        {
            return First.X != Second.X || First.Y != Second.Y;

        }
    }

}
