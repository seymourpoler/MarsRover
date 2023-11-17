namespace MarsRover.Domain.Orientations
{
    public class West : Orientation
    {
        public override Position Backward(Position position)
        {
            throw new NotImplementedException();
        }

        public override Position Forward(Position position)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "W";
        }
    }
}
