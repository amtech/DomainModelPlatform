
using System.Text;
using System.IO;

namespace Infrastructure.Common
{
    public class FileUtils
    {
        public static string ReadTextFile(string path)
        {
            StreamReader myFile = new StreamReader(path, Encoding.Default);
            string myString = myFile.ReadToEnd();//myString是读出的字符串
            myFile.Close();
            return myString;
        }


    }
}
