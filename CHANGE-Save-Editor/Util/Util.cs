using System;

namespace CHANGE_Save_Editor.Util
{
    public static class Util
    {

        public static float LongToFloat(long val)
        {
            return (float)BitConverter.Int64BitsToDouble(val);
        }

    }
}
