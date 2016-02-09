using DMP.Infrastructure.ModelDesigner.Common;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignerTool));
            this.splitModule = new System.Windows.Forms.SplitContainer();
            this.treeModule = new DMP.Infrastructure.ModelDesigner.Common.TreeViewEx();
            this.splitModel = new System.Windows.Forms.SplitContainer();
            this.treeModel = new DMP.Infrastructure.ModelDesigner.Common.TreeViewEx();
            this.pgridModelSetting = new System.Windows.Forms.PropertyGrid();
            this.menuOperator = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.nodeRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rmenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.rmenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitModule.Panel1.SuspendLayout();
            this.splitModule.Panel2.SuspendLayout();
            this.splitModule.SuspendLayout();
            this.splitModel.Panel1.SuspendLayout();
            this.splitModel.Panel2.SuspendLayout();
            this.splitModel.SuspendLayout();
            this.menuOperator.SuspendLayout();
            this.nodeRightMenu.SuspendLayout();
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
            this.treeModule.Size = new System.Drawing.Size(192, 442);
            this.treeModule.TabIndex = 1;
            this.treeModule.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewBeforeSelect);
            this.treeModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeNodeAfterSelect);
            this.treeModule.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeMouseClick);
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
            this.treeModel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeNodeAfterSelect);
            this.treeModel.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeMouseClick);
            // 
            // pgridModelSetting
            // 
            this.pgridModelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgridModelSetting.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.pgridModelSetting.Location = new System.Drawing.Point(0, 0);
            this.pgridModelSetting.Name = "pgridModelSetting";
            this.pgridModelSetting.Size = new System.Drawing.Size(204, 442);
            this.pgridModelSetting.TabIndex = 1;
            this.pgridModelSetting.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGridPropertyValueChanged);
            // 
            // menuOperator
            // 
            this.menuOperator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.menuOperator.Location = new System.Drawing.Point(0, 0);
            this.menuOperator.Name = "menuOperator";
            this.menuOperator.Size = new System.Drawing.Size(706, 25);
            this.menuOperator.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(33, 22);
            this.btnSave.Text = "保存";
            this.btnSave.ToolTipText = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nodeRightMenu
            // 
            this.nodeRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rmenuAdd,
            this.rmenuDelete});
            this.nodeRightMenu.Name = "nodeRightMenu";
            this.nodeRightMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // rmenuAdd
            // 
            this.rmenuAdd.Name = "rmenuAdd";
            this.rmenuAdd.Size = new System.Drawing.Size(152, 22);
            this.rmenuAdd.Tag = "add";
            this.rmenuAdd.Text = "新增";
            this.rmenuAdd.Click += new System.EventHandler(this.RightMenuClick);
            // 
            // rmenuDelete
            // 
            this.rmenuDelete.Name = "rmenuDelete";
            this.rmenuDelete.Size = new System.Drawing.Size(152, 22);
            this.rmenuDelete.Tag = "delete";
            this.rmenuDelete.Text = "删除";
            this.rmenuDelete.Click += new System.EventHandler(this.RightMenuClick);
            // 
            // DesignerTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 467);
            this.Controls.Add(this.splitModule);
            this.Controls.Add(this.menuOperator);
            this.Name = "DesignerTool";
            this.Text = "ModelDesigner";
            this.Load += new System.EventHandler(this.DesignerTool_Load);
            this.splitModule.Panel1.ResumeLayout(false);
            this.splitModule.Panel2.ResumeLayout(false);
            this.splitModule.ResumeLayout(false);
            this.splitModel.Panel1.ResumeLayout(false);
            this.splitModel.Panel2.ResumeLayout(false);
            this.splitModel.ResumeLayout(false);
            this.menuOperator.ResumeLayout(false);
            this.menuOperator.PerformLayout();
            this.nodeRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitModule;
        private TreeViewEx treeModule;
        private System.Windows.Forms.SplitContainer splitModel;
        private TreeViewEx treeModel;
        private System.Windows.Forms.PropertyGrid pgridModelSetting;
        private System.Windows.Forms.ToolStrip menuOperator;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ContextMenuStrip nodeRightMenu;
        private System.Windows.Forms.ToolStripMenuItem rmenuAdd;
        private System.Windows.Forms.ToolStripMenuItem rmenuDelete;
    }
}