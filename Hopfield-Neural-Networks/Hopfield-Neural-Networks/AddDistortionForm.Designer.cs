namespace HopfieldNeuralNetworks
{
    partial class AddDistortionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericDistorionLevel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxNegative = new System.Windows.Forms.CheckBox();
            this.buttonAddDistortion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericDistorionLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distortion Level";
            // 
            // numericDistorionLevel
            // 
            this.numericDistorionLevel.Location = new System.Drawing.Point(16, 29);
            this.numericDistorionLevel.Name = "numericDistorionLevel";
            this.numericDistorionLevel.Size = new System.Drawing.Size(51, 20);
            this.numericDistorionLevel.TabIndex = 1;
            this.numericDistorionLevel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericDistorionLevel.ValueChanged += new System.EventHandler(this.numericDistorionLevel_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // checkBoxNegative
            // 
            this.checkBoxNegative.AutoSize = true;
            this.checkBoxNegative.Location = new System.Drawing.Point(16, 56);
            this.checkBoxNegative.Name = "checkBoxNegative";
            this.checkBoxNegative.Size = new System.Drawing.Size(99, 17);
            this.checkBoxNegative.TabIndex = 3;
            this.checkBoxNegative.Text = "Make Negative";
            this.checkBoxNegative.UseVisualStyleBackColor = true;
            this.checkBoxNegative.CheckedChanged += new System.EventHandler(this.checkBoxNegative_CheckedChanged);
            // 
            // buttonAddDistortion
            // 
            this.buttonAddDistortion.Location = new System.Drawing.Point(12, 96);
            this.buttonAddDistortion.Name = "buttonAddDistortion";
            this.buttonAddDistortion.Size = new System.Drawing.Size(180, 23);
            this.buttonAddDistortion.TabIndex = 4;
            this.buttonAddDistortion.Text = "Add Distortion";
            this.buttonAddDistortion.UseVisualStyleBackColor = true;
            this.buttonAddDistortion.Click += new System.EventHandler(this.buttonAddDistortion_Click);
            // 
            // AddDistortionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 131);
            this.Controls.Add(this.buttonAddDistortion);
            this.Controls.Add(this.checkBoxNegative);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericDistorionLevel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDistortionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Distortion";
            ((System.ComponentModel.ISupportInitialize)(this.numericDistorionLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericDistorionLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxNegative;
        private System.Windows.Forms.Button buttonAddDistortion;
    }
}