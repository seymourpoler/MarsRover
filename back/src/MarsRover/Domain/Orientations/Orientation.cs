using MarsRover.Monads;

namespace MarsRover.Domain.Orientations;

public abstract class Orientation
{
    public abstract Either<Error, Position> Forward(Position position);
    public abstract Either<Error, Position> Backward(Position position);

    public abstract string ToString();
}
