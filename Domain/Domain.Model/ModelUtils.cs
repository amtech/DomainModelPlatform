using System.Xml;
using Domain.Model.Elements;
using DMP.Infrastructure.Common;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Domain.Model
{
    public class ModelUtils
    {
        #region 模型操作

        public static T AddNewTable<T>(DataModel model) where T : Table, new()
        {
            int maxIndex = 0;
            string tblName = "NewTable";
            foreach (string key in model.Tables.Keys)
            {
                if (model.Tables[key].Name.Contains(tblName))
                {
                    if (int.Parse(model.Tables[key].Name.Replace(tblName, string.Empty)) > maxIndex)
                    {
                        maxIndex = int.Parse(model.Tables[key].Name.Replace(tblName, string.Empty));
                    }
                }
            }
            maxIndex++;
            T newTable = new T { Name = tblName + maxIndex, DisplayName = tblName + maxIndex };
            model.Tables.Add(newTable.Name, newTable);
            return newTable;
        }

        public static T AddNewColumn<T>(Table table) where T : Column, new()
        {
            int maxIndex = 0;
            string colName = "NewColumn";
            foreach (string key in table.Columns.Keys)
            {

                if (table.Columns[key].Name.Contains(colName))
                {
                    if (int.Parse(table.Columns[key].Name.Replace(colName, string.Empty)) > maxIndex)
                    {
                        maxIndex = int.Parse(table.Columns[key].Name.Replace(colName, string.Empty));
                    }
                }
            }
            maxIndex++;
            T newColumn = new T { Name = colName + maxIndex, DisplayName = colName + maxIndex };
            table.Columns.Add(newColumn.Name, newColumn);
            return newColumn;

        }

        #endregion

        /// <summary>反序列化报表模型</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static T DeserializeModel<T, T1>(FileStream file)
            where T : DataModel
            where T1 : Column
        {
            byte[] content = new byte[file.Length];

            for (int i = 0; i < content.Length; i++)
            {
                content[i] = (byte)file.ReadByte();
            }
            string xml = Encoding.UTF8.GetString(content);
            XmlDocument docXml = XmlUtils.LoadXml(xml);
            /*
            <ReportModel SourceTag="1" DocumentType="1" Name="1" DisplayName="1">
                <Table Name="NewTable1" DisplayName="NewTable1" IsMain="false" IsVirtual="false">
                    <Column Name="NewColumn1" ColumnType="String" IsKey="false" IsVirtual="false" IsSearch="false" Visible="false" DisplayName="NewColumn1">
                        <Relationship SourceTag="1" DocumentType="1" Name="1" DisplayName="1" />
                        <Items><ListItem Text="a" Value="1" IsDefault="false" /></Items>
                    </Column>
                </Table>
            </ReportModel>
            */
            T dm = XmlUtils.Deserialize<T>(xml);
            if (docXml.DocumentElement != null)
            {
                foreach (XmlNode nodeTable in docXml.DocumentElement.ChildNodes)
                {
                    Table tbl = XmlUtils.Deserialize<Table>(nodeTable.OuterXml);
                    foreach (XmlNode nodeColumn in nodeTable.ChildNodes)
                    {
                        T1 col = XmlUtils.Deserialize<T1>(nodeColumn.OuterXml);
                        tbl.Columns.Add(col.Name, col);
                        //处理选项信息
                        XmlNode nodeItems = nodeColumn.SelectSingleNode("Items");
                        if (nodeItems != null)
                        {
                            foreach (XmlNode nodeListItem in nodeItems.ChildNodes)
                            {
                                ListItem item = XmlUtils.Deserialize<ListItem>(nodeListItem.OuterXml);
                                col.Items.Add(item.Text, item);
                            }
                        }
                        //处理关联信息
                        if (col.Relationship != null)
                        {
                            XmlNode nodeRelationship = nodeColumn.SelectSingleNode("Relationship");
                            if (nodeRelationship != null && nodeRelationship.ChildNodes.Count > 0)
                            {
                                foreach (XmlNode nodeRelationColumn in nodeRelationship.ChildNodes)
                                {
                                    RelationColumn relationColumn = XmlUtils.Deserialize<RelationColumn>(nodeRelationColumn.OuterXml);
                                    col.Relationship.RelationColumns.Add(relationColumn.Name, relationColumn);
                                }

                            }
                        }
                    }
                    dm.Tables.Add(tbl.Name, tbl);
                }
            }
            return dm;
        }


        public static T DeserializeModel<T>(FileStream file)
            where T : DataModel
        {
            return DeserializeModel<T, Column>(file);
        }

        /// <summary>序列化-由于模型对象附带复杂属性</summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Serialize<T, T1>(DataModel model)
            where T : DataModel
            where T1 : Column
        {
            XmlDocument docModel = SerializeXmlDoc<T, T1>(model);
            if (docModel.DocumentElement != null)
            {
                return docModel.DocumentElement.OuterXml;
            }
            return string.Empty;
        }

        /// <summary>序列化-由于模型对象附带复杂属性</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Serialize<T>(DataModel model)
            where T : DataModel
        {
            return Serialize<T, Column>(model);
        }

        public static string SerializeJson<T>(DataModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            JObject jobjModel = JObject.Parse(json);
            JArray jarrayTables = (jobjModel["Tables"] as JArray);
            if (jarrayTables != null)
            {
                jarrayTables.Clear();
            }
            foreach (string tableName in model.Tables.AllKeys)
            {
                string jsonTable = JsonConvert.SerializeObject(model.Tables[tableName]);
                JObject jobjTable = JObject.Parse(jsonTable);
                jarrayTables.Add(jobjTable);
                JArray jarrayColumns = (jobjTable["Columns"] as JArray);
                if (jarrayColumns != null)
                {
                    jarrayColumns.Clear();
                }
                foreach (string columnName in model.Tables[tableName].Columns.AllKeys)
                {
                    Column col = model.Tables[tableName].Columns[columnName];
                    string jsonColumn = JsonConvert.SerializeObject(col);
                    JObject jobjColumn = JObject.Parse(jsonColumn);
                    jarrayColumns.Add(jobjColumn);

                    JArray jarrayListItems = (jobjColumn["Items"] as JArray);
                    if (jarrayListItems != null)
                    {
                        jarrayListItems.Clear();
                    }
                    foreach (string itemKey in col.Items.AllKeys)
                    {
                        ListItem listItem = col.Items[itemKey];
                        string jsonListItem = JsonConvert.SerializeObject(listItem);
                        JObject jobjListItem = JObject.Parse(jsonListItem);
                        jarrayListItems.Add(jobjListItem);
                    }
                    if (col.Relationship != null)
                    {
                        string jsonRelationship = JsonConvert.SerializeObject(col.Relationship);
                        JObject jobjRelationship = JObject.Parse(jsonRelationship);
                        jobjColumn["Relationship"] = jobjRelationship;

                        JArray jarrayRelationColumns = (jobjRelationship["RelationColumns"] as JArray);
                        if (jarrayRelationColumns != null)
                        {
                            jarrayRelationColumns.Clear();
                        }
                        foreach (string relationColumnsKey in col.Relationship.RelationColumns.AllKeys)
                        {
                            RelationColumn relationColumn = col.Relationship.RelationColumns[relationColumnsKey];
                            string jsonRelationColumn = JsonConvert.SerializeObject(relationColumn);
                            JObject jobjRelationColumn = JObject.Parse(jsonRelationColumn);
                            jarrayRelationColumns.Add(jobjRelationColumn);
                        }
                    }
                }
            } 
            return jobjModel.ToString();
        }


        /// <summary>序列化-由于模型对象附带复杂属性</summary>
        /// <typeparam name="T"></typeparam> 
        /// <param name="model"></param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument SerializeXmlDoc<T>(DataModel model)
            where T : DataModel
        {
            return SerializeXmlDoc<T, Column>(model);
        }

        /// <summary>序列化-由于模型对象附带复杂属性</summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="model"></param>
        /// <returns>XmlDocument</returns>
        private static XmlDocument SerializeXmlDoc<T, T1>(DataModel model)
            where T : DataModel
            where T1 : Column
        {
            string xmlModel = XmlUtils.Serialize<T>(model);
            XmlDocument docModel = XmlUtils.LoadXml(xmlModel);
            //处理表集合序列化
            foreach (string tblName in model.Tables.Keys)
            {
                Table tbl = model.Tables[tblName];
                string xmlTable = XmlUtils.Serialize<Table>(tbl);
                XmlDocument docTable = XmlUtils.LoadXml(xmlTable);
                //处理字段集合序列化
                foreach (string colName in tbl.Columns.Keys)
                {
                    T1 col = (T1)tbl.Columns[colName];
                    string xmlColumn = XmlUtils.Serialize(tbl.Columns[colName]);
                    XmlDocument docColumn = XmlUtils.LoadXml(xmlColumn);
                    if (col.Items.Count > 0)
                    {
                        XmlElement elementItems = docColumn.CreateElement("Items");
                        if (docColumn.DocumentElement != null)
                        {
                            docColumn.DocumentElement.AppendChild(elementItems);
                            //处理选项集合序列化
                            foreach (string itemKey in col.Items.Keys)
                            {
                                ListItem listItem = col.Items[itemKey];
                                string xmlListItem = XmlUtils.Serialize<ListItem>(listItem);
                                XmlDocument docListItem = XmlUtils.LoadXml(xmlListItem);
                                if (docListItem.DocumentElement != null)
                                {
                                    elementItems.InnerXml += docListItem.DocumentElement.OuterXml;
                                }
                            }
                        }
                    }

                    if (docColumn.DocumentElement != null)
                    {
                        //处理关系节点
                        XmlNode nodeRelationship = docColumn.DocumentElement.SelectSingleNode("Relationship");
                        if (nodeRelationship != null)
                        {
                            //处理关系节点-关联字段集合序列化
                            foreach (string relColKey in col.Relationship.RelationColumns.Keys)
                            {
                                RelationColumn relationColumn = col.Relationship.RelationColumns[relColKey];
                                string xmlRelationColumn = XmlUtils.Serialize<RelationColumn>(relationColumn);
                                XmlDocument docRelationColumn = XmlUtils.LoadXml(xmlRelationColumn);
                                if (docRelationColumn.DocumentElement != null)
                                {
                                    nodeRelationship.InnerXml += docRelationColumn.DocumentElement.OuterXml;
                                }
                            }
                        }
                    }
                    if (docTable.DocumentElement != null && docColumn.DocumentElement != null)
                    {
                        docTable.DocumentElement.InnerXml += docColumn.DocumentElement.OuterXml;
                    }
                }
                if (docModel.DocumentElement != null && docTable.DocumentElement != null)
                {
                    docModel.DocumentElement.InnerXml += docTable.DocumentElement.OuterXml;
                }
            }
            return docModel;
        }

    }
}
