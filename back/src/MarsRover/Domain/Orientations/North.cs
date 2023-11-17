namespace MarsRover.Domain.Orientations
{
    public class North : Orientation
    {
        public override Position Backward(Position position)
        {
            return position.Up();
        }

        public override Position Forward(Position position)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "N";
        }
    }
}
