
using System.Collections.Generic;

namespace Infrastructure.Common.Transfer
{
    public class ResponsePackage
    { 
        public int ResultState { get; set; }
        public Dictionary<string, string> Items { get; set; }

        public ResponsePackage()
        {
            Items = new Dictionary<string, string>();
        }

    }
}
