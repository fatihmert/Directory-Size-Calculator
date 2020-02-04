namespace Directory_Size_Calculator
{
    partial class Form1
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
            this.currentPath = new System.Windows.Forms.TextBox();
            this.foldersView = new System.Windows.Forms.TreeView();
            this.filesView = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // currentPath
            // 
            this.currentPath.Location = new System.Drawing.Point(13, 13);
            this.currentPath.Name = "currentPath";
            this.currentPath.ReadOnly = true;
            this.currentPath.Size = new System.Drawing.Size(609, 22);
            this.currentPath.TabIndex = 0;
            // 
            // foldersView
            // 
            this.foldersView.Location = new System.Drawing.Point(13, 42);
            this.foldersView.Name = "foldersView";
            this.foldersView.Size = new System.Drawing.Size(609, 283);
            this.foldersView.TabIndex = 1;
            this.foldersView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.foldersView_BeforeExpand);
            this.foldersView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.foldersView_NodeMouseClick);
            // 
            // filesView
            // 
            this.filesView.FormattingEnabled = true;
            this.filesView.ItemHeight = 16;
            this.filesView.Location = new System.Drawing.Point(13, 332);
            this.filesView.Name = "filesView";
            this.filesView.Size = new System.Drawing.Size(609, 276);
            this.filesView.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 618);
            this.Controls.Add(this.filesView);
            this.Controls.Add(this.foldersView);
            this.Controls.Add(this.currentPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Directory Size Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currentPath;
        private System.Windows.Forms.TreeView foldersView;
        private System.Windows.Forms.ListBox filesView;
    }
}

