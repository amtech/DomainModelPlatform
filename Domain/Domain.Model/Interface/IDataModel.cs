using System.Collections.Generic;
using DMP.Infrastructure.Model.Interface.Elements;

namespace DMP.Infrastructure.Model.Interface
{
    public interface IDataModel
    {
        int SourceTag { set; get; }
        int DocumentType { set; get; }
        string Name { set; get; }
        string DisplayName { set; get; }

        List<ITable> Tables { get; set; }
        ITable FindTable(string tableName);
        void RemoveTable(string key);

    }
}