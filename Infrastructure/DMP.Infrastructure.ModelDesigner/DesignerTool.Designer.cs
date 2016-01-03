namespace DMP.Infrastructure.ModelDesigner
{
    partial class DesignerTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("业务功能");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("报表");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignerTool));
            this.splitModule = new System.Windows.Forms.SplitContainer();
            this.treeModule = new System.Windows.Forms.TreeView();
            this.splitModel = new System.Windows.Forms.SplitContainer();
            this.treeModel = new System.Windows.Forms.TreeView();
            this.pgridModelSetting = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.splitModule.Panel1.SuspendLayout();
            this.splitModule.Panel2.SuspendLayout();
            this.splitModule.SuspendLayout();
            this.splitModel.Panel1.SuspendLayout();
            this.splitModel.Panel2.SuspendLayout();
            this.splitModel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitModule
            // 
            this.splitModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitModule.Location = new System.Drawing.Point(0, 25);
            this.splitModule.Name = "splitModule";
            // 
            // splitModule.Panel1
            // 
            this.splitModule.Panel1.Controls.Add(this.treeModule);
            // 
            // splitModule.Panel2
            // 
            this.splitModule.Panel2.Controls.Add(this.splitModel);
            this.splitModule.Size = new System.Drawing.Size(706, 442);
            this.splitModule.SplitterDistance = 192;
            this.splitModule.TabIndex = 2;
            // 
            // treeModule
            // 
            this.treeModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModule.Location = new System.Drawing.Point(0, 0);
            this.treeModule.Name = "treeModule";
            treeNode1.Name = "treeDocuments";
            treeNode1.Tag = "documents";
            treeNode1.Text = "业务功能";
            treeNode2.Name = "treeReports";
            treeNode2.Tag = "reports";
            treeNode2.Text = "报表";
            this.treeModule.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeModule.Size = new System.Drawing.Size(192, 442);
            this.treeModule.TabIndex = 1;
            this.treeModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeModule_AfterSelect);
            this.treeModule.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeModule_NodeMouseClick);
            // 
            // splitModel
            // 
            this.splitModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitModel.Location = new System.Drawing.Point(0, 0);
            this.splitModel.Name = "splitModel";
            // 
            // splitModel.Panel1
            // 
            this.splitModel.Panel1.Controls.Add(this.treeModel);
            // 
            // splitModel.Panel2
            // 
            this.splitModel.Panel2.Controls.Add(this.pgridModelSetting);
            this.splitModel.Size = new System.Drawing.Size(510, 442);
            this.splitModel.SplitterDistance = 302;
            this.splitModel.TabIndex = 0;
            // 
            // treeModel
            // 
            this.treeModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModel.Location = new System.Drawing.Point(0, 0);
            this.treeModel.Name = "treeModel";
            this.treeModel.Size = new System.Drawing.Size(302, 442);
            this.treeModel.TabIndex = 1;
            // 
            // pgridModelSetting
            // 
            this.pgridModelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgridModelSetting.Location = new System.Drawing.Point(0, 0);
            this.pgridModelSetting.Name = "pgridModelSetting";
            this.pgridModelSetting.Size = new System.Drawing.Size(204, 442);
            this.pgridModelSetting.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(706, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSave.Image")));
            this.toolbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSave.Name = "toolbtnSave";
            this.toolbtnSave.Size = new System.Drawing.Size(33, 22);
            this.toolbtnSave.Text = "保存";
            this.toolbtnSave.ToolTipText = "保存";
            // 
            // DesignerTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 467);
            this.Controls.Add(this.splitModule);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DesignerTool";
            this.Text = "ModelDesigner";
            this.Load += new System.EventHandler(this.DesignerTool_Load);
            this.splitModule.Panel1.ResumeLayout(false);
            this.splitModule.Panel2.ResumeLayout(false);
            this.splitModule.ResumeLayout(false);
            this.splitModel.Panel1.ResumeLayout(false);
            this.splitModel.Panel2.ResumeLayout(false);
            this.splitModel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitModule;
        private System.Windows.Forms.TreeView treeModule;
        private System.Windows.Forms.SplitContainer splitModel;
        private System.Windows.Forms.TreeView treeModel;
        private System.Windows.Forms.PropertyGrid pgridModelSetting;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
    }
}