namespace GraalLevelViewer
{
    partial class WindowMain
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
            this.LevelViewerPanel = new System.Windows.Forms.Panel();
            this.LevelViewerTilesetList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LevelViewerGenerateButton = new System.Windows.Forms.Button();
            this.LevelViewerBrowseButton = new System.Windows.Forms.Button();
            this.LevelViewerProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LevelViewerPanel
            // 
            this.LevelViewerPanel.AllowDrop = true;
            this.LevelViewerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelViewerPanel.AutoScroll = true;
            this.LevelViewerPanel.Location = new System.Drawing.Point(12, 39);
            this.LevelViewerPanel.Name = "LevelViewerPanel";
            this.LevelViewerPanel.Size = new System.Drawing.Size(560, 511);
            this.LevelViewerPanel.TabIndex = 0;
            // 
            // LevelViewerTilesetList
            // 
            this.LevelViewerTilesetList.FormattingEnabled = true;
            this.LevelViewerTilesetList.Location = new System.Drawing.Point(59, 12);
            this.LevelViewerTilesetList.Name = "LevelViewerTilesetList";
            this.LevelViewerTilesetList.Size = new System.Drawing.Size(152, 21);
            this.LevelViewerTilesetList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tileset:";
            // 
            // LevelViewerGenerateButton
            // 
            this.LevelViewerGenerateButton.Location = new System.Drawing.Point(497, 10);
            this.LevelViewerGenerateButton.Name = "LevelViewerGenerateButton";
            this.LevelViewerGenerateButton.Size = new System.Drawing.Size(75, 23);
            this.LevelViewerGenerateButton.TabIndex = 3;
            this.LevelViewerGenerateButton.Text = "Generate";
            this.LevelViewerGenerateButton.UseVisualStyleBackColor = true;
            this.LevelViewerGenerateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LevelViewerBrowseButton
            // 
            this.LevelViewerBrowseButton.Location = new System.Drawing.Point(416, 10);
            this.LevelViewerBrowseButton.Name = "LevelViewerBrowseButton";
            this.LevelViewerBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.LevelViewerBrowseButton.TabIndex = 4;
            this.LevelViewerBrowseButton.Text = "Browse...";
            this.LevelViewerBrowseButton.UseVisualStyleBackColor = true;
            this.LevelViewerBrowseButton.Click += new System.EventHandler(this.LevelViewerBrowseButton_Click);
            // 
            // LevelViewerProgress
            // 
            this.LevelViewerProgress.Location = new System.Drawing.Point(217, 10);
            this.LevelViewerProgress.Maximum = 4096;
            this.LevelViewerProgress.Name = "LevelViewerProgress";
            this.LevelViewerProgress.Size = new System.Drawing.Size(193, 23);
            this.LevelViewerProgress.Step = 1;
            this.LevelViewerProgress.TabIndex = 5;
            this.LevelViewerProgress.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // WindowMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.LevelViewerProgress);
            this.Controls.Add(this.LevelViewerBrowseButton);
            this.Controls.Add(this.LevelViewerGenerateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LevelViewerTilesetList);
            this.Controls.Add(this.LevelViewerPanel);
            this.Name = "WindowMain";
            this.Text = "Graal Level Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LevelViewerGenerateButton;
        public System.Windows.Forms.ComboBox LevelViewerTilesetList;
        public System.Windows.Forms.Panel LevelViewerPanel;
        private System.Windows.Forms.Button LevelViewerBrowseButton;
        public System.Windows.Forms.ProgressBar LevelViewerProgress;
    }
}

