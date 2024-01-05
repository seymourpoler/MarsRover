using MarsRover.Monads;

namespace MarsRover.Domain.Orientations;

public class West : Orientation
{
    public override Either<Error, Position> Backward(Position position)
    {
        return position.Right();
    }

    public override Either<Error, Position> Forward(Position position)
    {
        return position.Left();
    }

    public override string ToString()
    {
        return "W";
    }
}
