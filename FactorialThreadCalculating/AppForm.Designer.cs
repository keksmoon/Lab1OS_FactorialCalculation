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
            this.progress = new System.Windows.Forms.ProgressBar();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.listBox = new System.Windows.Forms.ListBox();
            this.trackValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(1, 63);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(583, 18);
            this.progress.TabIndex = 2;
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 1000;
            this.trackBar.Location = new System.Drawing.Point(106, 12);
            this.trackBar.Maximum = 100000;
            this.trackBar.Minimum = 10000;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(465, 45);
            this.trackBar.TabIndex = 3;
            this.trackBar.Value = 10000;
            this.trackBar.Scroll += new System.EventHandler(this.scroll);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(1, 89);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(583, 199);
            this.listBox.TabIndex = 4;
            // 
            // trackValue
            // 
            this.trackValue.AutoSize = true;
            this.trackValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackValue.Location = new System.Drawing.Point(10, 18);
            this.trackValue.Name = "trackValue";
            this.trackValue.Size = new System.Drawing.Size(25, 25);
            this.trackValue.TabIndex = 5;
            this.trackValue.Text = "0";
            this.trackValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 288);
            this.Controls.Add(this.trackValue);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.progress);
            this.Name = "AppForm";
            this.Text = "Fractal Calculation";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label trackValue;
    }
}