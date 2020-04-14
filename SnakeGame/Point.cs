namespace SnakeGame
{
    public class Point
    {
        public int Top { get; set; }
        public int Left { get; set; }

        public Point(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public static bool operator ==(Point First, Point Second)
        {
            return First.Left == Second.Left && First.Top == Second.Top;

        }

        public static bool operator !=(Point First, Point Second)
        {
            return First.Left != Second.Left || First.Top != Second.Top;

        }
    }

}
