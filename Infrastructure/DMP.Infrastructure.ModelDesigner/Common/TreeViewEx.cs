
using System.Windows.Forms;

namespace DMP.Infrastructure.ModelDesigner.Common
{
    public class TreeViewEx : TreeView
    {
        public TreeNode GetTreeNodeByTag(string tag)
        {
            foreach (TreeNode tn in this.Nodes)
            {
                if (tag.Equals(tn.Tag.ToString(), System.StringComparison.OrdinalIgnoreCase))
                {
                    return tn;
                }
            }
            return null;
        }

    }

    /// <summary></summary>
    public class TreeNodeModelElement : TreeNode
    {
        public string ElementType { get; set; }

        public string ElementName { get; set; }
    }

}
