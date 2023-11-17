namespace MarsRover.Domain
{
    public class Situation
    {
        public int X { get; }
        public int Y { get; }
        public string Orientation { get; }

        public Situation(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}
