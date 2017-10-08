using DMP.Infrastructure.Model;
using DMP.Infrastructure.Model.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;



namespace DMP.Infrastructure.ModelDesigner.Model
{
    /// <summary>数据源模型</summary>
    [Serializable]
    public class DataModelEx : DataModel
    {
         
        [Browsable(false), DefaultValue(false)]
        public List<Table> Tables { get; set; }

        public Table FindTable(string tableName)
        {
            foreach (Table tbl in Tables)
            {
                if (tbl.Name == tableName)
                {
                    return tbl;
                }
            }
            return null;
        }

        public void RemoveTable(string key)
        {
            foreach (Table tbl in Tables)
            {
                if (tbl.Name == key)
                {
                    Tables.Remove(tbl);
                    return;
                }
            }
        }

    }
}
