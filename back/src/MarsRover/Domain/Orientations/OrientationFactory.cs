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
            if (orientation == "S")
                return new South();
            if (orientation == "W")
                return new West();

            throw new NotImplementedException();
        }
    }
}
