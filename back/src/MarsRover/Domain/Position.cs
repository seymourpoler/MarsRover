namespace MarsRover.Domain
{
    public record Position(Map map, int x, int y)
    {
        public Position Up()
        {
            return new Position(map, x, y + 1);
        }

        public Position Down()
        {
            if (map.IsOutOfTheLowEdgeForY(y - 1))
                return new Position(map, x, map.horizontal);

            return new Position(map, x, y);
        }

        public Position Right()
        {
            return new Position(map, x + 1, y);
        }

        internal Position Left()
        {
            return new Position(map, x - 1, y);
        }
    }
}
