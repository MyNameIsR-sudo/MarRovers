using System.Collections;
using System.Collections.Generic;

namespace RoverLibrary
{
    public class MarsRoverRepository : IMarsRoverRepository
    {
        private static List<MarsRover> MarsRovers { get; set; } = new List<MarsRover>();
        public IEnumerator<MarsRover> GetEnumerator()
        {
            return MarsRovers.GetEnumerator();
        }
        public void AddMarsRover(MarsRover marsRover)
        {
            if (marsRover != null) MarsRovers.Add(marsRover);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}