namespace MarsRover.Domain.Orientations
{
    public class East : Orientation
    {
        public override Position Backward(Position position)
        {
            throw new NotImplementedException();
        }

        public override Position Forward(Position position)
        {
            return position.Right();
        }

        public override string ToString()
        {
            return "E";
        }
    }
}
