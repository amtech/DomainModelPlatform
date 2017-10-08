using System.Collections.Generic;

using System;

namespace DMP.Infrastructure.ModelDesigner.Model
{
    /// <summary>报表模型</summary> 
    [Serializable]
    public class ReportModelEx : DataModelEx
    {
        public ReportModelEx()
        {
            Tables = new List<Table>();
        }

    }
}
