using System.ComponentModel;
using System.Drawing.Design;
using Domain.ModelDesigner.Editer;
using Domain.Model.Elements;
using DMP.Infrastructure.Common;
using System.Xml.Serialization;

namespace Domain.ModelDesigner.Model.Elements
{
    [XmlRoot("Column")]
    public class ColumnEx : Column
    {
        [Description("选项"), Category("数据")]
        [Editor(typeof(ListItemEditer), typeof(UITypeEditor))]
        [XmlIgnore]
        public override NameObjectCollection<ListItem> Items { get; set; }
    }
}
