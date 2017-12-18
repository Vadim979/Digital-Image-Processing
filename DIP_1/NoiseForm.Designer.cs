namespace DIP_1
{
    partial class NoiseForm
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
            this.noisedPictureBox = new System.Windows.Forms.PictureBox();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton075 = new System.Windows.Forms.RadioButton();
            this.radioButton050 = new System.Windows.Forms.RadioButton();
            this.radioButton025 = new System.Windows.Forms.RadioButton();
            this.addNoiseButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.impulsNoiseButton = new System.Windows.Forms.RadioButton();
            this.additiveNoiseButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.randomRange = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.additiveImpulsiveNoiseButton = new System.Windows.Forms.RadioButton();
            this.noisinessLabel = new System.Windows.Forms.Label();
            this.percentOfNoisiness = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.additiveImpulsiveStrNoiseButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.noisedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentOfNoisiness)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // noisedPictureBox
            // 
            this.noisedPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.noisedPictureBox.Location = new System.Drawing.Point(445, 12);
            this.noisedPictureBox.Name = "noisedPictureBox";
            this.noisedPictureBox.Size = new System.Drawing.Size(427, 427);
            this.noisedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.noisedPictureBox.TabIndex = 2;
            this.noisedPictureBox.TabStop = false;
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.originalPictureBox.Location = new System.Drawing.Point(12, 12);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(427, 427);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPictureBox.TabIndex = 3;
            this.originalPictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton075);
            this.groupBox1.Controls.Add(this.radioButton050);
            this.groupBox1.Controls.Add(this.radioButton025);
            this.groupBox1.Location = new System.Drawing.Point(13, 446);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Уровень шумовой помехи";
            // 
            // radioButton075
            // 
            this.radioButton075.AutoSize = true;
            this.radioButton075.Location = new System.Drawing.Point(7, 66);
            this.radioButton075.Name = "radioButton075";
            this.radioButton075.Size = new System.Drawing.Size(46, 17);
            this.radioButton075.TabIndex = 2;
            this.radioButton075.TabStop = true;
            this.radioButton075.Text = "0.75";
            this.radioButton075.UseVisualStyleBackColor = true;
            this.radioButton075.CheckedChanged += new System.EventHandler(this.radioButton075_CheckedChanged);
            // 
            // radioButton050
            // 
            this.radioButton050.AutoSize = true;
            this.radioButton050.Location = new System.Drawing.Point(7, 43);
            this.radioButton050.Name = "radioButton050";
            this.radioButton050.Size = new System.Drawing.Size(46, 17);
            this.radioButton050.TabIndex = 1;
            this.radioButton050.TabStop = true;
            this.radioButton050.Text = "0.50";
            this.radioButton050.UseVisualStyleBackColor = true;
            this.radioButton050.CheckedChanged += new System.EventHandler(this.radioButton050_CheckedChanged);
            // 
            // radioButton025
            // 
            this.radioButton025.AutoSize = true;
            this.radioButton025.Location = new System.Drawing.Point(7, 20);
            this.radioButton025.Name = "radioButton025";
            this.radioButton025.Size = new System.Drawing.Size(46, 17);
            this.radioButton025.TabIndex = 0;
            this.radioButton025.TabStop = true;
            this.radioButton025.Text = "0.25";
            this.radioButton025.UseVisualStyleBackColor = true;
            this.radioButton025.CheckedChanged += new System.EventHandler(this.radioButton025_CheckedChanged);
            // 
            // addNoiseButton
            // 
            this.addNoiseButton.Location = new System.Drawing.Point(776, 459);
            this.addNoiseButton.Name = "addNoiseButton";
            this.addNoiseButton.Size = new System.Drawing.Size(100, 37);
            this.addNoiseButton.TabIndex = 5;
            this.addNoiseButton.Text = "Добавить шум";
            this.addNoiseButton.UseVisualStyleBackColor = true;
            this.addNoiseButton.Click += new System.EventHandler(this.addNoiseButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.impulsNoiseButton);
            this.groupBox2.Controls.Add(this.additiveNoiseButton);
            this.groupBox2.Location = new System.Drawing.Point(173, 446);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 98);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шум";
            // 
            // impulsNoiseButton
            // 
            this.impulsNoiseButton.AutoSize = true;
            this.impulsNoiseButton.Location = new System.Drawing.Point(7, 43);
            this.impulsNoiseButton.Name = "impulsNoiseButton";
            this.impulsNoiseButton.Size = new System.Drawing.Size(114, 17);
            this.impulsNoiseButton.TabIndex = 1;
            this.impulsNoiseButton.TabStop = true;
            this.impulsNoiseButton.Text = "Импульсный шум";
            this.impulsNoiseButton.UseVisualStyleBackColor = true;
            // 
            // additiveNoiseButton
            // 
            this.additiveNoiseButton.AutoSize = true;
            this.additiveNoiseButton.Location = new System.Drawing.Point(7, 20);
            this.additiveNoiseButton.Name = "additiveNoiseButton";
            this.additiveNoiseButton.Size = new System.Drawing.Size(111, 17);
            this.additiveNoiseButton.TabIndex = 0;
            this.additiveNoiseButton.TabStop = true;
            this.additiveNoiseButton.Text = "Аддитивный шум";
            this.additiveNoiseButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.noisinessLabel);
            this.groupBox3.Controls.Add(this.percentOfNoisiness);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.randomRange);
            this.groupBox3.Location = new System.Drawing.Point(562, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 98);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Диапазон случайных чисел";
            // 
            // randomRange
            // 
            this.randomRange.Location = new System.Drawing.Point(6, 17);
            this.randomRange.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.randomRange.Name = "randomRange";
            this.randomRange.Size = new System.Drawing.Size(44, 20);
            this.randomRange.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.applyButton.Location = new System.Drawing.Point(776, 502);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(100, 37);
            this.applyButton.TabIndex = 8;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // additiveImpulsiveNoiseButton
            // 
            this.additiveImpulsiveNoiseButton.AutoSize = true;
            this.additiveImpulsiveNoiseButton.Location = new System.Drawing.Point(6, 13);
            this.additiveImpulsiveNoiseButton.Name = "additiveImpulsiveNoiseButton";
            this.additiveImpulsiveNoiseButton.Size = new System.Drawing.Size(156, 30);
            this.additiveImpulsiveNoiseButton.TabIndex = 2;
            this.additiveImpulsiveNoiseButton.TabStop = true;
            this.additiveImpulsiveNoiseButton.Text = "Аддитивный импульсный \r\nшум (точечный)";
            this.additiveImpulsiveNoiseButton.UseVisualStyleBackColor = true;
            this.additiveImpulsiveNoiseButton.CheckedChanged += new System.EventHandler(this.additiveImpulsiveNoiseButton_CheckedChanged);
            // 
            // noisinessLabel
            // 
            this.noisinessLabel.AutoSize = true;
            this.noisinessLabel.Location = new System.Drawing.Point(56, 48);
            this.noisinessLabel.Name = "noisinessLabel";
            this.noisinessLabel.Size = new System.Drawing.Size(133, 13);
            this.noisinessLabel.TabIndex = 3;
            this.noisinessLabel.Text = "Процент зашумленности";
            // 
            // percentOfNoisiness
            // 
            this.percentOfNoisiness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.percentOfNoisiness.Location = new System.Drawing.Point(6, 43);
            this.percentOfNoisiness.Name = "percentOfNoisiness";
            this.percentOfNoisiness.Size = new System.Drawing.Size(44, 20);
            this.percentOfNoisiness.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.additiveImpulsiveStrNoiseButton);
            this.groupBox4.Controls.Add(this.additiveImpulsiveNoiseButton);
            this.groupBox4.Location = new System.Drawing.Point(342, 446);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(163, 98);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Шум";
            // 
            // additiveImpulsiveStrNoiseButton
            // 
            this.additiveImpulsiveStrNoiseButton.AutoSize = true;
            this.additiveImpulsiveStrNoiseButton.Location = new System.Drawing.Point(6, 59);
            this.additiveImpulsiveStrNoiseButton.Name = "additiveImpulsiveStrNoiseButton";
            this.additiveImpulsiveStrNoiseButton.Size = new System.Drawing.Size(156, 30);
            this.additiveImpulsiveStrNoiseButton.TabIndex = 3;
            this.additiveImpulsiveStrNoiseButton.TabStop = true;
            this.additiveImpulsiveStrNoiseButton.Text = "Аддитивный импульсный \r\nшум (строковой)";
            this.additiveImpulsiveStrNoiseButton.UseVisualStyleBackColor = true;
            this.additiveImpulsiveStrNoiseButton.CheckedChanged += new System.EventHandler(this.additiveImpulsiveStrNoiseButton_CheckedChanged);
            // 
            // NoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 556);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.addNoiseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.originalPictureBox);
            this.Controls.Add(this.noisedPictureBox);
            this.Name = "NoiseForm";
            this.Text = "NoiseForm";
            this.Load += new System.EventHandler(this.NoiseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.noisedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentOfNoisiness)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox noisedPictureBox;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton075;
        private System.Windows.Forms.RadioButton radioButton050;
        private System.Windows.Forms.RadioButton radioButton025;
        private System.Windows.Forms.Button addNoiseButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton impulsNoiseButton;
        private System.Windows.Forms.RadioButton additiveNoiseButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown randomRange;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.RadioButton additiveImpulsiveNoiseButton;
        private System.Windows.Forms.Label noisinessLabel;
        private System.Windows.Forms.NumericUpDown percentOfNoisiness;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton additiveImpulsiveStrNoiseButton;
    }
}