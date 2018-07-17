using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoverLibrary
{
    public class Repository
    {
        public static Repository Of { get; } =
             new Repository() { MarsRovers = new MarsRoverRepository() };

        public IMarsRoverRepository MarsRovers { get; private set; }
    }
}