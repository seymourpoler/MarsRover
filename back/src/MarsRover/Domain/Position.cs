﻿namespace MarsRover.Domain
{
    public record Position(int x, int y)
    {
        public Position Up()
        {
            return new Position(x, y + 1);
        }
    }
}
