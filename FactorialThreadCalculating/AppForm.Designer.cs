namespace FactorialThreadCalculating
{
    partial class AppForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.listBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(583, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(0, 78);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(583, 60);
            this.progress.TabIndex = 2;
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 1000;
            this.trackBar.Location = new System.Drawing.Point(12, 27);
            this.trackBar.Maximum = 100000;
            this.trackBar.Minimum = 10000;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(559, 45);
            this.trackBar.TabIndex = 3;
            this.trackBar.Value = 10000;
            this.trackBar.Scroll += new System.EventHandler(this.scroll);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 144);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(559, 173);
            this.listBox.TabIndex = 4;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 323);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppForm";
            this.Text = "Fractal Calculation";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.ListBox listBox;
    }
}