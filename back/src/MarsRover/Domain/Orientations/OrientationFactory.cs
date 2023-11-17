namespace MarsRover.Domain.Orientations
{
    public class OrientationFactory
    {
        public static Orientation Create(string orientation)
        {
            if (orientation == "N")
                return new North();
            if (orientation == "E")
                return new East();

            throw new NotImplementedException();
        }
    }
}
