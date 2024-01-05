using MarsRover.Monads;

namespace MarsRover.Domain.Orientations;

public class North : Orientation
{
    public override Either<Error, Position> Backward(Position position)
    {
        return position.Down();
    }

    public override Either<Error, Position> Forward(Position position)
    {
        return position.Up();
    }

    public override string ToString()
    {
        return "N";
    }
}
