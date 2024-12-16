namespace squareChaser
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.stopWatch = new System.Windows.Forms.Timer(this.components);
            this.p1pointsLabel = new System.Windows.Forms.Label();
            this.p2pointsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // stopWatch
            // 
            this.stopWatch.Interval = 20;
            // 
            // p1pointsLabel
            // 
            this.p1pointsLabel.AutoSize = true;
            this.p1pointsLabel.ForeColor = System.Drawing.Color.White;
            this.p1pointsLabel.Location = new System.Drawing.Point(282, 9);
            this.p1pointsLabel.Name = "p1pointsLabel";
            this.p1pointsLabel.Size = new System.Drawing.Size(14, 16);
            this.p1pointsLabel.TabIndex = 0;
            this.p1pointsLabel.Text = "0";
            // 
            // p2pointsLabel
            // 
            this.p2pointsLabel.AutoSize = true;
            this.p2pointsLabel.ForeColor = System.Drawing.Color.White;
            this.p2pointsLabel.Location = new System.Drawing.Point(469, 9);
            this.p2pointsLabel.Name = "p2pointsLabel";
            this.p2pointsLabel.Size = new System.Drawing.Size(14, 16);
            this.p2pointsLabel.TabIndex = 1;
            this.p2pointsLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(762, 547);
            this.Controls.Add(this.p2pointsLabel);
            this.Controls.Add(this.p1pointsLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer stopWatch;
        private System.Windows.Forms.Label p1pointsLabel;
        private System.Windows.Forms.Label p2pointsLabel;
    }
}

