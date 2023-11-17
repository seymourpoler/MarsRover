﻿using MarsRover.Domain.Orientations;

namespace MarsRover.Domain
{
    public class Robot
    {
        private Position position;
        private Orientation orientation;

        public Robot(int x, int y, string orientation)
        {
            position = new Position(x, y);
            this.orientation = OrientationFactory.Create(orientation);
        }

        internal Situation GetSituation()
        {
            return new Situation(position.x, position.y, orientation.ToString());
        }

        public void move(string movements)
        {
            foreach(var movement in movements)
            {
                move(movement);
            }
        }

        public void move(char movement)
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

            orientation = OrientationFactory.Create(movement);
        }
    }
}
