using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    public static class Extentions
    {
        public static int? ToInt(this string str)
        {
            try
            {
                int _str = 0;
                var isDone = int.TryParse(str, out _str);
                if (isDone)
                    return _str;
                else return null;
            }
            catch
            {
                return null;
            }
        }
        public static long? ToLong(this string str)
        {
            try
            {
                long _str = 0;
                var isDone = long.TryParse(str, out _str);
                if (isDone)
                    return _str;
                else return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
