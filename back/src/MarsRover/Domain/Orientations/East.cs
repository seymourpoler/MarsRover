using MarsRover.Monad;

namespace MarsRover.Domain.Orientations
{
    public class East : Orientation
    {
        public override Either<Error, Position> Backward(Position position)
        {
            return position.Left();
        }

        public override Either<Error, Position> Forward(Position position)
        {
            return position.Right();
        }

        public override string ToString()
        {
            return "E";
        }
    }
}
