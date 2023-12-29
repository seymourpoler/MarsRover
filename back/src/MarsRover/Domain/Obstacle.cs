namespace MarsRover.Domain
{
    public record Obstacle(int x, int y)
    {
        public bool IsEqualTo(int x, int y)
        {
            return this.x == x &&
                this.y == y;
        }
    }
}
