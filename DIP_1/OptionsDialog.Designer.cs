namespace DIP_1
{
    partial class OptionsDialog
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
            this.minUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // minUpDown
            // 
            this.minUpDown.Location = new System.Drawing.Point(109, 12);
            this.minUpDown.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.minUpDown.Name = "minUpDown";
            this.minUpDown.Size = new System.Drawing.Size(120, 20);
            this.minUpDown.TabIndex = 0;
            // 
            // maxUpDown
            // 
            this.maxUpDown.Location = new System.Drawing.Point(109, 38);
            this.maxUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.maxUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxUpDown.Name = "maxUpDown";
            this.maxUpDown.Size = new System.Drawing.Size(120, 20);
            this.maxUpDown.TabIndex = 1;
            this.maxUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(154, 64);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Minimum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Maximum";
            // 
            // LinearContrastScalingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 97);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.maxUpDown);
            this.Controls.Add(this.minUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LinearContrastScalingDialog";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.LinearContrastScalingDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown minUpDown;
        private System.Windows.Forms.NumericUpDown maxUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}