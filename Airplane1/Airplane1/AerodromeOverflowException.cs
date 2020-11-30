using System;

namespace Airplane1
{
    internal class AerodromeOverflowException : Exception
    {
        public AerodromeOverflowException() : base("Aerodrome overflow")
        { }
    }
}
