using System;

namespace Airplane1
{
    internal class AerodromeNotFoundException : Exception
    {
        public AerodromeNotFoundException(int i) : base("Not found airplane number " + i)
        { }
    }
}
