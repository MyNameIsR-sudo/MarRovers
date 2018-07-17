using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoverLibrary
{
    public class MarsRoverService : IMarsRoverService
    {
        private readonly IMarsRoverRepository marsRoverRepository = new MarsRoverRepository();
        public void Add(MarsRover marsRover)
        {
            marsRoverRepository.AddMarsRover(marsRover);
        }

        public MarsRover Find(int roverId)
        {
            return marsRoverRepository?.Where(rover => rover.RoverId == roverId).FirstOrDefault();
        }

        public void Move(MarsRover marsRover)
        {
            switch (marsRover.RoverDirection)
            {
                case Direction.North:
                    marsRover.CurrentY++;
                    break;
                case Direction.East:
                    marsRover.CurrentX++;
                    break;
                case Direction.South:
                    marsRover.CurrentY--;
                    break;
                case Direction.West:
                    marsRover.CurrentX--;
                    break;
            }
        }

        public void TurnLeft(MarsRover marsRover)
        {
            int currentDirection = (int)marsRover.RoverDirection;
            marsRover.RoverDirection = (Direction)(--currentDirection < 0 ? 3 : currentDirection);
        }

        public void TurnRight(MarsRover marsRover)
        {
            int currentDirection = (int)marsRover.RoverDirection;
            marsRover.RoverDirection = (Direction)((++currentDirection) % 4);
        }

        public void Update(int roverId, string roverName)
        {
            var rover = Find(roverId);
            rover.RoverName = roverName;
        }
    }
}