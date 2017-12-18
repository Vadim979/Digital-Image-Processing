using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP_1
{
    public partial class HistogramForm : Form
    {
        int[] originalImageBrightness;
        int[] alteredImageBrightness;

        public HistogramForm(int[] originalImageBrightness, int[] alteredImageBrightness)
        {
            this.originalImageBrightness = originalImageBrightness;
            this.alteredImageBrightness = alteredImageBrightness;
            InitializeComponent();
            ShowAlteredHist();
            ShowOriginalHist();
        }

        private void ShowOriginalHist()
        {
            originalHistChart.Series[0].Points.DataBindY(originalImageBrightness);
            originalHistChart.Series[0].Name = "Brightness";
            originalHistChart.Show();
        }

        private void ShowAlteredHist()
        {
            modifiedHistChart.Series[0].Points.DataBindY(alteredImageBrightness);
            modifiedHistChart.Series[0].Name = "Brightness";
            modifiedHistChart.Show();
            
        }
    }
}
