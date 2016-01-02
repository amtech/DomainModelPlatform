using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.Common.Model
{
    public abstract class ModelBase
    {
        public int SourceTag { set; get; }
        public int DocumentType { set; get; }
    }
}
