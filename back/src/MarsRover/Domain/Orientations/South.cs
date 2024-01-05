using MarsRover.Monads;

namespace MarsRover.Domain.Orientations;

public class South : Orientation
{
    public override Either<Error, Position> Backward(Position position)
    {
        return position.Up();
    }

    public override Either<Error, Position> Forward(Position position)
    {
        return position.Down();
    }

    public override string ToString()
    {
        return "S";
    }
}
