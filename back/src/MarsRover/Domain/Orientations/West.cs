namespace MarsRover.Domain.Orientations
{
    public class West : Orientation
    {
        public override Position Backward(Position position)
        {
            return position.Right();
        }

        public override Position Forward(Position position)
        {
            return position.Left();
        }

        public override string ToString()
        {
            return "W";
        }
    }
}
