using System;

namespace Helper
{
    public static class BinaryHelpers
    {
        public static bool IsBitSet(byte b, int pos)
        {
            return ((b >> pos) & 1) != 0;
        }
    }
}
