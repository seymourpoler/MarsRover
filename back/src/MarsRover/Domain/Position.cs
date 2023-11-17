﻿namespace MarsRover.Domain
{
    public record Position(int x, int y)
    {
        public Position Up()
        {
            return new Position(x, y + 1);
        }

        public Position Down()
        {
            return new Position(x, y - 1);
        }

        public Position Right()
        {
            return new Position(x + 1, y);
        }

        internal Position Left()
        {
            return new Position(x - 1, y);
        }
    }
}
