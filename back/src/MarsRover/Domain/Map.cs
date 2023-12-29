namespace MarsRover.Domain;

public record Map(int Horizontal, int Vertical, params Obstacle[] obstacles)
{
    public int initialPosition = 0;

    public bool IsOutOfTheLowVerticalEdge(int y)
    {
        return initialPosition > y;
    }

    public bool IsOutOfTheHighVerticalEdge(int y)
    {
        return Vertical < y;
    }

    public bool IsOutOfTheHighHorizontalEdge(int x)
    {
        return Horizontal < x;
    }

    public bool IsOutOfTheLowHorizontalEdge(int x)
    {
        return initialPosition > x;
    }

    public bool IsThereAnObstacle(int x, int y)
    {
        return obstacles.Any(position => position.IsEqualTo(x, y));
    }
}
