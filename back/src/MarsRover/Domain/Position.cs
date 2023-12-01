namespace MarsRover.Domain
{
    public record Position(Map map, int x, int y)
    {
        public Position Up()
        {
            if (map.IsOutOfTheHighVerticalEdge(y + 1))
                return new Position(map, x, map.initialPosition);
            return new Position(map, x, y + 1);
        }

        public Position Down()
        {
            if (map.IsOutOfTheLowVerticalEdge(y - 1))
                return new Position(map, x, map.horizontal);

            return new Position(map, x, y-1);
        }

        public Position Right()
        {
            if (map.IsOutOfTheHighHorizontalEdge(x + 1))
                return new Position(map, map.initialPosition, y);

            return new Position(map, x + 1, y);
        }

        internal Position Left()
        {
            if (map.IsOutOfTheLowHorizontalEdge(x - 1))
                return new Position(map, map.horizontal, y);

            return new Position(map, x - 1, y);
        }
    }
}
