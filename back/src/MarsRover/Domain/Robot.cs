using MarsRover.Domain.Orientations;

namespace MarsRover.Domain
{
    public class Robot
    {
        private Position position;
        private Orientation orientation;

        public Robot(Map map, int x, int y, string orientation)
        {
            position = new Position(map, x, y);
            this.orientation = OrientationFactory.Create(orientation);
        }

        internal Situation GetSituation()
        {
            return new Situation(position.x, position.y, orientation.ToString());
        }

        public void Move(string movements)
        {
            foreach(var movement in movements)
            {
                Move(movement);
            }
        }

        private void Move(char movement)
        {
            if(movement == 'F')
            {
                position = orientation.Forward(position);
                return;
            }
            if(movement == 'B')
            {
                position = orientation.Backward(position);
                return;
            }

            orientation = OrientationFactory.Create(movement.ToString());
        }
    }
}
