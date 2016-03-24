using System.Collections.Generic;

namespace DMP.Infrastructure.Model
{
    /// <summary>报表模型</summary>
    public class ReportModel : DataModel
    {
        public ReportModel()
        {
            Tables = new List<Table>();
        }

    }
}
