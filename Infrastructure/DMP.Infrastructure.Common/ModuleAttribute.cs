using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.Common
{
    /// <summary>模块标识属性</summary>
    public class ModuleAttribute : System.Attribute
    {
        private int id;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
