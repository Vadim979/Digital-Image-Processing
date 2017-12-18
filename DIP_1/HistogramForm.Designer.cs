namespace DIP_1
{
    partial class HistogramForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.originalHistChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.modifiedHistChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.originalHistChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedHistChart)).BeginInit();
            this.SuspendLayout();
            // 
            // originalHistChart
            // 
            chartArea1.Name = "ChartArea1";
            this.originalHistChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.originalHistChart.Legends.Add(legend1);
            this.originalHistChart.Location = new System.Drawing.Point(-1, 0);
            this.originalHistChart.Name = "originalHistChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.originalHistChart.Series.Add(series1);
            this.originalHistChart.Size = new System.Drawing.Size(460, 436);
            this.originalHistChart.TabIndex = 0;
            this.originalHistChart.Text = "Original Histogram";
            // 
            // modifiedHistChart
            // 
            chartArea2.Name = "ChartArea1";
            this.modifiedHistChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.modifiedHistChart.Legends.Add(legend2);
            this.modifiedHistChart.Location = new System.Drawing.Point(456, 0);
            this.modifiedHistChart.Name = "modifiedHistChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.modifiedHistChart.Series.Add(series2);
            this.modifiedHistChart.Size = new System.Drawing.Size(460, 436);
            this.modifiedHistChart.TabIndex = 1;
            this.modifiedHistChart.Text = "Modified Histogram";
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 436);
            this.Controls.Add(this.modifiedHistChart);
            this.Controls.Add(this.originalHistChart);
            this.Name = "HistogramForm";
            this.Text = "Histograms";
            ((System.ComponentModel.ISupportInitialize)(this.originalHistChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedHistChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart originalHistChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart modifiedHistChart;
    }
}