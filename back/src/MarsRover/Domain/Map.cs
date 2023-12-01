using System.Reflection.Metadata.Ecma335;

namespace MarsRover.Domain
{
    public record Map(int horizontal, int vertical)
    {
        public int initialPosition = 0;

        public bool IsOutOfTheLowVerticalEdge(int y)
        {
            return initialPosition > y;
        }

        public bool IsOutOfTheHighVerticalEdge(int y)
        {
            return vertical < y;
        }

        internal bool IsOutOfTheHighHorizontalEdge(int x)
        {
            return horizontal < x;
        }

        internal bool IsOutOfTheLowHorizontalEdge(int x)
        {
            return initialPosition > x;
        }
    }
}
