﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane1
{
    class AerodromeOccupiedPlaceException : Exception
    {
        public AerodromeOccupiedPlaceException() : base("Place is occupied ")
        { }
    }   
}
