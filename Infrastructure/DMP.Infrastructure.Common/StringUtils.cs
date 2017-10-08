using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Common
{
    public static class StringUtils
    {
        public static string ToStr(this object obj)
        {
            if (obj is string)
            {
                return obj as string;
            }
            if (obj != null && obj != DBNull.Value)
            {
                return obj.ToString();
            }
            return string.Empty;
        }
    }
}
