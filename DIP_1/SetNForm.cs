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
    public partial class SetNForm : Form
    {
        MainForm mainForm;
        public SetNForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Nlabel.Text = "Окно " + numericUpDown1.Value + "x" + numericUpDown1.Value;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value % 2 == 0)
            {
                MessageBox.Show("Окно должно иметь нечетный размер", "Внимание!", MessageBoxButtons.OK);
                return;
            }

            mainForm.N = (int)numericUpDown1.Value;
            Close();
        }

        private void SetNForm_Load(object sender, EventArgs e)
        {
            mainForm = this.Owner as MainForm;
        }
    }
}
