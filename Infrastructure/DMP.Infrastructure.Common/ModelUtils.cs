using DMP.Infrastructure.Common.Model;
using DMP.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.Common
{
    public class ModelUtils
    {
        public void Deserialize(string xml)
        {

        }

        public string Serializer()
        {
            return string.Empty;
        }

        public static Table AddNewTable(DataModel model)
        {
            int maxIndex = 0;
            string tblName = "NewTable";
            foreach (Table tbl in model.Tables)
            {
                if (tbl.Name.Contains(tblName))
                {
                    if (int.Parse(tbl.Name.Replace(tblName, string.Empty)) > maxIndex)
                    {
                        maxIndex = int.Parse(tbl.Name.Replace(tblName, string.Empty));
                    }
                }
            }
            maxIndex++;
            Table newTable = new Table { Name = tblName + maxIndex.ToString(), DisplayName = tblName + maxIndex.ToString() };
            model.Tables.Add(newTable);
            return newTable;

        }

        public static Column AddNewColumn(Table table)
        {
            int maxIndex = 0;
            string colName = "NewColumn";
            foreach (Column tbl in table.Columns)
            {
                if (tbl.Name.Contains(colName))
                {
                    if (int.Parse(tbl.Name.Replace(colName, string.Empty)) > maxIndex)
                    {
                        maxIndex = int.Parse(tbl.Name.Replace(colName, string.Empty));
                    }
                }
            }
            maxIndex++;
            Column newColumn = new Column { Name = colName + maxIndex.ToString(), DisplayName = colName + maxIndex.ToString() };
            table.Columns.Add(newColumn);
            return newColumn;

        }

    }
}
