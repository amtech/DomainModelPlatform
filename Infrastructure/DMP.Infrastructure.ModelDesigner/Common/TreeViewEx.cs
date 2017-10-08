
using System.Windows.Forms;

namespace Domain.ModelDesigner.Common
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
                foreach (TreeNode tnChilds in tn.Nodes)
                {
                    if (tnChilds is TreeNodeModelElement)
                    {
                        if (tag.Equals((tnChilds as TreeNodeModelElement).ElementName, System.StringComparison.OrdinalIgnoreCase))
                        {
                            return tnChilds;
                        }
                    }
                    else if (tag.Equals(tnChilds.Tag.ToString(), System.StringComparison.OrdinalIgnoreCase))
                    {
                        return tnChilds;
                    }
                }
            }
            return null;
        }

        /// <summary> 选中新增的 节点 </summary>
        public void SelectLastAddNode()
        {
            SelectedNode = SelectedNode.Nodes[SelectedNode.Nodes.Count - 1];
        }

    }

    /// <summary></summary>
    public class TreeNodeModelElement : TreeNode
    {
        public string ElementType { get; set; }

        public string ElementName { get; set; }
    }

}
