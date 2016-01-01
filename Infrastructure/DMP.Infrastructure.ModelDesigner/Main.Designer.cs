namespace ModelDesigner
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitModule = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitModel = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.treeModel = new System.Windows.Forms.TreeView();
            this.treeModule = new System.Windows.Forms.TreeView();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.splitModule.Panel1.SuspendLayout();
            this.splitModule.Panel2.SuspendLayout();
            this.splitModule.SuspendLayout();
            this.splitModel.Panel1.SuspendLayout();
            this.splitModel.Panel2.SuspendLayout();
            this.splitModel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuTop";
            // 
            // splitModule
            // 
            this.splitModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitModule.Location = new System.Drawing.Point(0, 24);
            this.splitModule.Name = "splitModule";
            // 
            // splitModule.Panel1
            // 
            this.splitModule.Panel1.Controls.Add(this.treeModule);
            // 
            // splitModule.Panel2
            // 
            this.splitModule.Panel2.Controls.Add(this.splitModel);
            this.splitModule.Size = new System.Drawing.Size(698, 390);
            this.splitModule.SplitterDistance = 232;
            this.splitModule.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusBottom";
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
            this.splitModel.Panel2.Controls.Add(this.propertyGrid1);
            this.splitModel.Size = new System.Drawing.Size(462, 390);
            this.splitModel.SplitterDistance = 154;
            this.splitModel.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(304, 390);
            this.propertyGrid1.TabIndex = 1;
            // 
            // treeModel
            // 
            this.treeModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModel.Location = new System.Drawing.Point(0, 0);
            this.treeModel.Name = "treeModel";
            this.treeModel.Size = new System.Drawing.Size(154, 390);
            this.treeModel.TabIndex = 1;
            // 
            // treeModule
            // 
            this.treeModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModule.Location = new System.Drawing.Point(0, 0);
            this.treeModule.Name = "treeModule";
            this.treeModule.Size = new System.Drawing.Size(232, 390);
            this.treeModule.TabIndex = 1;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 20);
            this.menuFile.Text = "文件(&F)";
            // 
            // menuOpen
            // 
            this.menuOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenFile,
            this.menuOpenProject});
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(152, 22);
            this.menuOpen.Text = "打开";
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Size = new System.Drawing.Size(152, 22);
            this.menuOpenFile.Text = "文件";
            this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // menuOpenProject
            // 
            this.menuOpenProject.Name = "menuOpenProject";
            this.menuOpenProject.Size = new System.Drawing.Size(152, 22);
            this.menuOpenProject.Text = "项目";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 436);
            this.Controls.Add(this.splitModule);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitModule.Panel1.ResumeLayout(false);
            this.splitModule.Panel2.ResumeLayout(false);
            this.splitModule.ResumeLayout(false);
            this.splitModel.Panel1.ResumeLayout(false);
            this.splitModel.Panel2.ResumeLayout(false);
            this.splitModel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitModule;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitModel;
        private System.Windows.Forms.TreeView treeModule;
        private System.Windows.Forms.TreeView treeModel;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpenProject;
    }
}

