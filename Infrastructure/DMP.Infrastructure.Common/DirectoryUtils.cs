using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure.Common
{
    public class DirectoryUtils
    {
        public static bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        public static void Create(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static string[] GetDirectories(string path, string subKey = "")
        {
            if (!Exists(path)) return null;
            if (!string.IsNullOrEmpty(subKey))
            {
                return Directory.GetDirectories(path, subKey);
            }
            return Directory.GetDirectories(path);
        }

        public static string[] GetAllDirectories(string path, string subKey)
        {
            if (!Exists(path)) return null;
            return Directory.GetDirectories(path, subKey, SearchOption.AllDirectories);
        }

        public static string[] GetXmlFiles(string path)
        {
            return Directory.GetFiles(path, "*.xml");
        }
    }
}
