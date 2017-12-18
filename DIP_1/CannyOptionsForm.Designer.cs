namespace DIP_1
{
    partial class CannyOptionsForm
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
            this.sigmaParametr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sigmaParametr)).BeginInit();
            this.SuspendLayout();
            // 
            // sigmaParametr
            // 
            this.sigmaParametr.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.sigmaParametr.Location = new System.Drawing.Point(12, 12);
            this.sigmaParametr.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sigmaParametr.Name = "sigmaParametr";
            this.sigmaParametr.Size = new System.Drawing.Size(73, 20);
            this.sigmaParametr.TabIndex = 0;
            this.sigmaParametr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Укажите параметр сглаживания \r\nсигма";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(193, 41);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // CannyOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 70);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sigmaParametr);
            this.Name = "CannyOptionsForm";
            this.Text = "CannyOptionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.sigmaParametr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown sigmaParametr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button applyButton;
    }
}