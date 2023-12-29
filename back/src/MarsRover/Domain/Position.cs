using MarsRover.Monad;

namespace MarsRover.Domain
{
    public record Position(Map map, int x, int y)
    {
        public Either<Error, Position> Up()
        {
            if(map.IsThereAnObstacle(x, y + 1))
                return Either<Error, Position>.Error(new Error());
            
            if (map.IsOutOfTheHighVerticalEdge(y + 1))
                return Either<Error, Position>.Success(new Position(map, x, map.initialPosition));
            return Either<Error, Position>.Success(new Position(map, x, y + 1));
        }

        public Either<Error, Position> Down()
        {
            if (map.IsOutOfTheLowVerticalEdge(y - 1))
                return Either<Error, Position>.Success(new Position(map, x, map.Horizontal));

            return Either<Error, Position>.Success(new Position(map, x, y-1));
        }

        public Either<Error, Position> Right()
        {
            if (map.IsOutOfTheHighHorizontalEdge(x + 1))
                return Either<Error, Position>.Success(new Position(map, map.initialPosition, y));

            return Either<Error, Position>.Success(new Position(map, x + 1, y));
        }

        public Either<Error, Position> Left()
        {
            if (map.IsOutOfTheLowHorizontalEdge(x - 1))
                return Either<Error, Position>.Success(new Position(map, map.Horizontal, y));

            return Either<Error, Position>.Success(new Position(map, x - 1, y));
        }
    }
}
