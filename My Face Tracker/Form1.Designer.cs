namespace My_Face_Tracker
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
            this.picCamOutput = new System.Windows.Forms.PictureBox();
            this.btnCamStart = new System.Windows.Forms.Button();
            this.btnCamStop = new System.Windows.Forms.Button();
            this.btnFaceTracking = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCamOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picCamOutput
            // 
            this.picCamOutput.Location = new System.Drawing.Point(12, 90);
            this.picCamOutput.Name = "picCamOutput";
            this.picCamOutput.Size = new System.Drawing.Size(518, 348);
            this.picCamOutput.TabIndex = 0;
            this.picCamOutput.TabStop = false;
            this.picCamOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.picCamOutput_Paint);
            // 
            // btnCamStart
            // 
            this.btnCamStart.Location = new System.Drawing.Point(12, 12);
            this.btnCamStart.Name = "btnCamStart";
            this.btnCamStart.Size = new System.Drawing.Size(118, 28);
            this.btnCamStart.TabIndex = 1;
            this.btnCamStart.Text = "Start Camera";
            this.btnCamStart.UseVisualStyleBackColor = true;
            this.btnCamStart.Click += new System.EventHandler(this.btnCamStart_Click);
            // 
            // btnCamStop
            // 
            this.btnCamStop.Location = new System.Drawing.Point(12, 56);
            this.btnCamStop.Name = "btnCamStop";
            this.btnCamStop.Size = new System.Drawing.Size(118, 28);
            this.btnCamStop.TabIndex = 2;
            this.btnCamStop.Text = "Stop Camera";
            this.btnCamStop.UseVisualStyleBackColor = true;
            this.btnCamStop.Click += new System.EventHandler(this.btnCamStop_Click);
            // 
            // btnFaceTracking
            // 
            this.btnFaceTracking.Location = new System.Drawing.Point(155, 12);
            this.btnFaceTracking.Name = "btnFaceTracking";
            this.btnFaceTracking.Size = new System.Drawing.Size(119, 72);
            this.btnFaceTracking.TabIndex = 4;
            this.btnFaceTracking.Text = "Start Face Tracking";
            this.btnFaceTracking.UseVisualStyleBackColor = true;
            this.btnFaceTracking.Click += new System.EventHandler(this.btnFaceTracking_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(297, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 53);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFaceTracking);
            this.Controls.Add(this.btnCamStop);
            this.Controls.Add(this.btnCamStart);
            this.Controls.Add(this.picCamOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picCamOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCamOutput;
        private System.Windows.Forms.Button btnCamStart;
        private System.Windows.Forms.Button btnCamStop;
        private System.Windows.Forms.Button btnFaceTracking;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

