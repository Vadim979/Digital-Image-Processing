namespace DIP_1
{
    partial class ChooseFilterForm
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
            this.firstMask = new System.Windows.Forms.RadioButton();
            this.secondMask = new System.Windows.Forms.RadioButton();
            this.thirdMask = new System.Windows.Forms.RadioButton();
            this.fourthMask = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.applyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // firstMask
            // 
            this.firstMask.AutoSize = true;
            this.firstMask.Location = new System.Drawing.Point(53, 119);
            this.firstMask.Name = "firstMask";
            this.firstMask.Size = new System.Drawing.Size(14, 13);
            this.firstMask.TabIndex = 4;
            this.firstMask.TabStop = true;
            this.firstMask.UseVisualStyleBackColor = true;
            // 
            // secondMask
            // 
            this.secondMask.AutoSize = true;
            this.secondMask.Location = new System.Drawing.Point(159, 118);
            this.secondMask.Name = "secondMask";
            this.secondMask.Size = new System.Drawing.Size(14, 13);
            this.secondMask.TabIndex = 5;
            this.secondMask.TabStop = true;
            this.secondMask.UseVisualStyleBackColor = true;
            // 
            // thirdMask
            // 
            this.thirdMask.AutoSize = true;
            this.thirdMask.Location = new System.Drawing.Point(267, 118);
            this.thirdMask.Name = "thirdMask";
            this.thirdMask.Size = new System.Drawing.Size(14, 13);
            this.thirdMask.TabIndex = 6;
            this.thirdMask.TabStop = true;
            this.thirdMask.UseVisualStyleBackColor = true;
            // 
            // fourthMask
            // 
            this.fourthMask.AutoSize = true;
            this.fourthMask.Location = new System.Drawing.Point(372, 118);
            this.fourthMask.Name = "fourthMask";
            this.fourthMask.Size = new System.Drawing.Size(14, 13);
            this.fourthMask.TabIndex = 7;
            this.fourthMask.TabStop = true;
            this.fourthMask.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(118, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(224, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(330, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 100);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(138, 137);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(162, 23);
            this.applyButton.TabIndex = 13;
            this.applyButton.Text = "Применить маску";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // ChooseFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 164);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fourthMask);
            this.Controls.Add(this.thirdMask);
            this.Controls.Add(this.secondMask);
            this.Controls.Add(this.firstMask);
            this.Name = "ChooseFilterForm";
            this.Text = "ChooseFilterForm";
            this.Load += new System.EventHandler(this.ChooseFilterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton firstMask;
        private System.Windows.Forms.RadioButton secondMask;
        private System.Windows.Forms.RadioButton thirdMask;
        private System.Windows.Forms.RadioButton fourthMask;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button applyButton;
    }
}