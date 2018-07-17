namespace RoverLibrary
{
    public interface IMarsRoverService
    {
        void Add(MarsRover marsRover);
        MarsRover Find(int roverId);
        void Update(int roverId, string roverName);
        void TurnRight(MarsRover marsRover);
        void TurnLeft(MarsRover marsRover);
        void Move(MarsRover marsRover);
    }
}