namespace MarsRover.Domain.Orientations
{
    public abstract class Orientation
    {
        public abstract Position Forward(Position position);
        public abstract Position Backward(Position position);

        public abstract string ToString();
    }
}
