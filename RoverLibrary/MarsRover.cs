using System.Runtime.Serialization;

namespace RoverLibrary
{
    public class MarsRover
    {
        public MarsRover(int RoverId, string RoverName)
        {
            this.RoverId = RoverId;
            this.RoverName = RoverName;
            CurrentX = 0;
            CurrentY = 0;
            RoverDirection = Direction.North;
        }
        public int RoverId;
        public string RoverName;
        public int CurrentX;
        public int CurrentY;
        [IgnoreDataMember]
        public Direction RoverDirection;
        public string CurrentDirection { get { return RoverDirection.ToString(); } }
    }
    public enum Direction
    {
        North = 0,
        East,
        South,
        West
    };
}