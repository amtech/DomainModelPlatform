using System.Collections.Generic;
using DMP.Infrastructure.Model.Elements;

namespace DMP.Infrastructure.Model.Interface.Elements
{
    public enum ColumnTypes
    {
        /// <summary>文本</summary>
        String,
        /// <summary>整型</summary>
        Int,
        /// <summary>布尔</summary>
        Bool,
        /// <summary>小数</summary>
        Decimal,
        /// <summary>日期</summary>
        Date
    }

    public interface IColumn
    {

        string Name { get; set; } 
        string FieldName { get; set; } 
        ColumnTypes ColumnType { get; set; } 
        bool IsKey { get; set; } 
        bool IsVirtual { get; set; } 
        bool IsSearch { get; set; } 
        bool Visible { get; set; } 
        string DisplayName { get; set; }
        List<IListItem> Items { get; set; }
        IRelationship Relationship { get; set; }

    }
}