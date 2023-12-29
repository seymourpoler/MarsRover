using MarsRover.Domain.Orientations;
using MarsRover.Monad;

namespace MarsRover.Domain;

public class Robot
{
    private Position position;
    private Orientation orientation;

    public Robot(Map map, int x, int y, string orientation)
    {
        position = new Position(map, x, y);
        this.orientation = OrientationFactory.Create(orientation);
    }

    public Situation GetSituation()
    {
        return new Situation(position.x, position.y, orientation.ToString());
    }

    public Either<Error, Robot> Move(string movements)
    {
        var result = Either<Error, Robot>.Success(this);
        foreach (var movement in movements)
        {
            result = result.Bind(_ => Move(movement));
        }
        return result;
    }

    private Either<Error, Robot> Move(char movement)
    {
        if(movement == 'F')
        {
            return orientation.Forward(position)
            .Bind(UpdatePosition)
            .Match(
                onSuccess: _ => Either<Error, Robot>.Success(this),
                onError: Either<Error, Robot>.Error
            );

        }
        if (movement == 'B')
        {
            return orientation.Backward(position)
            .Bind(UpdatePosition)
            .Match(
                onSuccess: _ => Either<Error, Robot>.Success(this),
                onError: Either<Error, Robot>.Error
            );
        }

        orientation = OrientationFactory.Create(movement.ToString());
        return Either<Error, Robot>.Success(this);
    }

    private Either<Error, Position> UpdatePosition(Position position)
    {
        this.position = position;
        return Either<Error, Position>.Success(position);
    }
}
