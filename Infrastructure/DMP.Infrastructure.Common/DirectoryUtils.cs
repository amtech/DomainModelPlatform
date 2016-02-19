using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.Common
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

        public static string[] GetDirectories(string path)
        {
            if (!Exists(path)) return null;
            return Directory.GetDirectories(path, string.Empty, SearchOption.TopDirectoryOnly);
        }

        public static string[] GetAllDirectories(string path)
        {
            if (!Exists(path)) return null;
            return Directory.GetDirectories(path, string.Empty, SearchOption.AllDirectories);
        }

        public static string[] GetXmlFiles(string path)
        {
            return Directory.GetFiles(path, "*.xml");
        }
    }
}
