using System;

namespace LevenshteinDistance
{
    internal static class MathHelper
    {

        public static int Min(int arg1, int arg2, int arg3)
        {
            return Math.Min(arg1, Math.Min(arg2, arg3));
        }

        public static int Min(int arg1, int arg2, int arg3, int arg4)
        {
            return Math.Min(arg1, Math.Min(arg2, Math.Min(arg3, arg4)));
        }

    }

}
