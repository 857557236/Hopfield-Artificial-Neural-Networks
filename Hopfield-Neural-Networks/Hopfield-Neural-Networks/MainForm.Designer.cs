namespace HopfieldNeuralNetworks
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddDistortion = new System.Windows.Forms.Button();
            this.pixelPictureBox = new HopfieldNeuralNetworks.Controls.PixelPictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelEnergy = new System.Windows.Forms.Label();
            this.labelPatternCount = new System.Windows.Forms.Label();
            this.labelNeuronCount = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 405);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(460, 23);
            this.progressBar.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonRun
            // 
            this.buttonRun.Enabled = false;
            this.buttonRun.Location = new System.Drawing.Point(12, 376);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(460, 23);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "Run!";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddDistortion);
            this.groupBox1.Controls.Add(this.pixelPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 255);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Handdrawing Letter";
            // 
            // buttonAddDistortion
            // 
            this.buttonAddDistortion.Location = new System.Drawing.Point(6, 226);
            this.buttonAddDistortion.Name = "buttonAddDistortion";
            this.buttonAddDistortion.Size = new System.Drawing.Size(112, 23);
            this.buttonAddDistortion.TabIndex = 1;
            this.buttonAddDistortion.Text = "Add Distortion";
            this.buttonAddDistortion.UseVisualStyleBackColor = true;
            this.buttonAddDistortion.Click += new System.EventHandler(this.buttonAddDistortion_Click);
            // 
            // pixelPictureBox
            // 
            this.pixelPictureBox.BackColor = System.Drawing.Color.White;
            this.pixelPictureBox.Image = null;
            this.pixelPictureBox.Location = new System.Drawing.Point(126, 21);
            this.pixelPictureBox.Name = "pixelPictureBox";
            this.pixelPictureBox.Size = new System.Drawing.Size(200, 200);
            this.pixelPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pixelPictureBox.TabIndex = 0;
            this.pixelPictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelEnergy);
            this.groupBox2.Controls.Add(this.labelPatternCount);
            this.groupBox2.Controls.Add(this.labelNeuronCount);
            this.groupBox2.Location = new System.Drawing.Point(12, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 95);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hopfield Network";
            // 
            // labelEnergy
            // 
            this.labelEnergy.AutoSize = true;
            this.labelEnergy.Location = new System.Drawing.Point(7, 72);
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Size = new System.Drawing.Size(0, 13);
            this.labelEnergy.TabIndex = 2;
            // 
            // labelPatternCount
            // 
            this.labelPatternCount.AutoSize = true;
            this.labelPatternCount.Location = new System.Drawing.Point(7, 37);
            this.labelPatternCount.Name = "labelPatternCount";
            this.labelPatternCount.Size = new System.Drawing.Size(0, 13);
            this.labelPatternCount.TabIndex = 1;
            // 
            // labelNeuronCount
            // 
            this.labelNeuronCount.AutoSize = true;
            this.labelNeuronCount.Location = new System.Drawing.Point(7, 20);
            this.labelNeuronCount.Name = "labelNeuronCount";
            this.labelNeuronCount.Size = new System.Drawing.Size(0, 13);
            this.labelNeuronCount.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Recognition";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pixelPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddDistortion;
        private Controls.PixelPictureBox pixelPictureBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelEnergy;
        private System.Windows.Forms.Label labelPatternCount;
        private System.Windows.Forms.Label labelNeuronCount;
    }
}

