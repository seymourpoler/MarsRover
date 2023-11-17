namespace MarsRover.Domain.Orientations
{
    public class South : Orientation
    {
        public override Position Backward(Position position)
        {
            return position.Up();
        }

        public override Position Forward(Position position)
        {
            return position.Down();
        }

        public override string ToString()
        {
            return "S";
        }
    }
}
