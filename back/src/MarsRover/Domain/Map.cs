namespace MarsRover.Domain
{
    public record Map(int horizontal, int vertical)
    {
        private const int initialVerticalPosition = 0;

        public bool IsOutOfTheLowEdgeForY(int y)
        {
            return initialVerticalPosition > y;
        }
    }
}
