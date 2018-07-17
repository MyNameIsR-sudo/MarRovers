using System;
using System.Collections.Generic;
using System.Text;

namespace RoverLibrary
{
    public interface IMarsRoverRepository : IEnumerable<MarsRover>
    {
        void AddMarsRover(MarsRover marsRover);
    }
}