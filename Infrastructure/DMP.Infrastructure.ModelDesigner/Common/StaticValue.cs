using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.ModelDesigner.Common
{
    public class StaticValue
    {
        /// <summary>项目文件-业务单据节点名称</summary>
        public const string PrjBusinessNodeName = "Business";
        /// <summary>项目文件-业务单据节点显示名称</summary>
        public const string PrjBusinessNodeDisplayName = "业务单据";
        /// <summary>项目文件-报表节点名称</summary>
        public const string PrjReportsNodeName = "Reports";
        /// <summary>项目文件-报表元素名称</summary>
        public const string PrjReportElementName = "Report";
        /// <summary>项目文件-报表节点显示名称</summary>
        public const string PrjReportsNodeDisplayName = "报表";
        /// <summary>模型-数据表节点名称</summary>
        public const string ModelTablesNodeName = "Tables";
        /// <summary>模型-数据表节点显示名称</summary>
        public const string ModelTablesNodeDisplayName = "表";
        /// <summary>模型-数据字段节点名称</summary>
        public const string ModelColumnsNodeName = "Columns";
        /// <summary>模型-数据字段节点显示名称</summary>
        public const string ModelColumnsNodeDisplayName = "字段";

        /// <summary>模型-元素-表</summary>
        public const string Table = "table";
        /// <summary>模型-元素-字段</summary>
        public const string Column = "column";

        /// <summary>行为-</summary>
        public const string Add = "add";
        public const string Delete = "delete";

        public static Dictionary<string, string> PrjNodesNameMapping
        {
            get
            {
                Dictionary<string, string> mapping = new Dictionary<string, string>();
                mapping.Add(PrjReportsNodeName, PrjReportsNodeDisplayName);
                mapping.Add(PrjBusinessNodeName, PrjBusinessNodeDisplayName);
                return mapping;
            }
        }

    }
}
