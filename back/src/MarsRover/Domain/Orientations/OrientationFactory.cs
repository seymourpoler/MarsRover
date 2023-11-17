namespace MarsRover.Domain.Orientations
{
    public class OrientationFactory
    {
        public static Orientation Create(string orientation)
        {
            if (orientation == "N")
                return new North();
            throw new NotImplementedException();
        }
        public static Orientation Create(char orientation)
        {
            if (orientation == 'N')
                return new North();

            throw new NotImplementedException();
        }
    }
}
