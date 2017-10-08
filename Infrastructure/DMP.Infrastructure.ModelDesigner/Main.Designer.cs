namespace Domain.ModelDesigner
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
            this.menuTop = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBottom = new System.Windows.Forms.StatusStrip();
            this.lblCurrentState = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuTop.SuspendLayout();
            this.statusBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTop
            // 
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Size = new System.Drawing.Size(698, 24);
            this.menuTop.TabIndex = 0;
            this.menuTop.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuTop_ItemAdded);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 20);
            this.menuFile.Text = "文件(&F)";
            // 
            // menuNew
            // 
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewProject,
            this.menuNewFile});
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(94, 22);
            this.menuNew.Text = "新建";
            // 
            // menuNewProject
            // 
            this.menuNewProject.Name = "menuNewProject";
            this.menuNewProject.Size = new System.Drawing.Size(94, 22);
            this.menuNewProject.Text = "项目";
            this.menuNewProject.Click += new System.EventHandler(this.menuNewProject_Click);
            // 
            // menuNewFile
            // 
            this.menuNewFile.Name = "menuNewFile";
            this.menuNewFile.Size = new System.Drawing.Size(94, 22);
            this.menuNewFile.Text = "文件";
            this.menuNewFile.Click += new System.EventHandler(this.menuNewFile_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenProject,
            this.menuOpenFile});
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(94, 22);
            this.menuOpen.Text = "打开";
            // 
            // menuOpenProject
            // 
            this.menuOpenProject.Name = "menuOpenProject";
            this.menuOpenProject.Size = new System.Drawing.Size(94, 22);
            this.menuOpenProject.Text = "项目";
            this.menuOpenProject.Click += new System.EventHandler(this.menuOpenProject_Click);
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Size = new System.Drawing.Size(94, 22);
            this.menuOpenFile.Text = "文件";
            this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // statusBottom
            // 
            this.statusBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentState});
            this.statusBottom.Location = new System.Drawing.Point(0, 414);
            this.statusBottom.Name = "statusBottom";
            this.statusBottom.Size = new System.Drawing.Size(698, 22);
            this.statusBottom.TabIndex = 2;
            // 
            // lblCurrentState
            // 
            this.lblCurrentState.Name = "lblCurrentState";
            this.lblCurrentState.Size = new System.Drawing.Size(41, 17);
            this.lblCurrentState.Text = "状态栏";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 436);
            this.Controls.Add(this.menuTop);
            this.Controls.Add(this.statusBottom);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuTop;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            this.statusBottom.ResumeLayout(false);
            this.statusBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuTop;
        private System.Windows.Forms.StatusStrip statusBottom;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpenProject;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuNewProject;
        private System.Windows.Forms.ToolStripMenuItem menuNewFile;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentState;
    }
}

