using System.Collections.Generic;

namespace DMP.Infrastructure.Model.Interface.Elements
{
    public interface ITable
    { 
        List<IColumn> Columns { get; set; } 
        string Name { get; set; } 
        string DataTableName { get; set; } 
        string DisplayName { get; set; } 
        bool IsMain { get; set; } 
        bool IsVirtual { get; set; } 
        IColumn FindColumn(string colName); 
        void RemoveColumn(string colName); 
    }
}