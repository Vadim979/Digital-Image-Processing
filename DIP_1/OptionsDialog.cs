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
    public partial class OptionsDialog : Form
    {
        MainForm mainForm;
        string[] selector;

        public OptionsDialog(string[] selector)
        {
            this.selector = selector;
            InitializeComponent();
            maxUpDown.Value = 255;
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            switch (selector[0])
            {
                case "linear":
                    mainForm.LinearContrastScaling((int)maxUpDown.Value, (int)minUpDown.Value);
                    break;
                case "slice":
                    mainForm.BrightnessSlice((int)maxUpDown.Value, (int)minUpDown.Value);
                    break;
                case "histogram":
                    switch (selector[1])
                    {
                        case "uniform":
                            mainForm.Histogram((int)maxUpDown.Value, (int)minUpDown.Value, "uniform");
                            break;
                        case "degree":
                            mainForm.Histogram((int)maxUpDown.Value, (int)minUpDown.Value, "degree");
                            break;
                        case "hyperbolic":
                            mainForm.Histogram((int)maxUpDown.Value, (int)minUpDown.Value, "hyperbolic");
                            break;
                    }
                    break;
            }
            this.Close();
        }
        private void LinearContrastScalingDialog_Load(object sender, EventArgs e)
        {
            mainForm = this.Owner as MainForm;
        }
    }
}
