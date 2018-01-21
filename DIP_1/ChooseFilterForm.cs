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
    public partial class ChooseFilterForm : Form
    {
        MainForm mainForm;
        Bitmap image;
        public ChooseFilterForm(Bitmap image)
        {
            this.image = image;
            InitializeComponent();
        }

        private void ChooseFilterForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("Picture/1.jpg");
            pictureBox2.Image = new Bitmap("Picture/4.jpg");
            pictureBox3.Image = new Bitmap("Picture/5.jpg");
            pictureBox4.Image = new Bitmap("Picture/6.jpg");
            mainForm = this.Owner as MainForm;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (firstMask.Checked)
            {
                UseFirstMask();
            }
            else if (secondMask.Checked)
            {
                UseSecondMask();
            }
            else if(thirdMask.Checked)
            {
                UseThirdMask();
            }
            else if (fourthMask.Checked)
            {
                UseFourthMask();
            }
            else
            {
                MessageBox.Show("Выберите маску!");
                return;
            }
            Close();
        }

        private void UseFirstMask()
        {
            byte[,] imageBrightness = NoiseForm.GetBrightnessMatrix(image);

            int width = imageBrightness.GetLength(0);
            int height = imageBrightness.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    byte[] array = new byte[3] { imageBrightness[i, j - 1], imageBrightness[i, j], imageBrightness[i, j + 1] };
                    imageBrightness[i, j] = array.OrderBy(q => q).ToArray()[1];
                }
            }
            mainForm.alteredImageBox.Image = MainForm.GetImageFromMatrix(imageBrightness);
        }

        private void UseSecondMask()
        {
            byte[,] imageBrightness = NoiseForm.GetBrightnessMatrix(image);

            int width = imageBrightness.GetLength(0);
            int height = imageBrightness.GetLength(1);
            byte[,] t = new byte[width - 2, height - 2];
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    byte[] array = new byte[] {imageBrightness[i - 1, j + 1], imageBrightness[i, j + 1], imageBrightness[i + 1, j + 1],
                                                imageBrightness[i - 1, j], imageBrightness[i, j], imageBrightness[i + 1, j],
                                              imageBrightness[i - 1, j - 1], imageBrightness[i, j - 1], imageBrightness[i + 1, j - 1]};
                    t[i - 1, j - 1] = array.OrderBy(q => q).ToArray()[5];
                }
            }
            mainForm.alteredImageBox.Image = MainForm.GetImageFromMatrix(t);
        }

        private void UseThirdMask()
        {
            byte[,] br = NoiseForm.GetBrightnessMatrix(image);

            int width = br.GetLength(0);
            int height = br.GetLength(1);
            byte[,] t = new byte[width - 4, height - 4];
            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {
                    byte[] array = new byte[] {
                                                       br[i, j + 2],
                                    br[i - 1, j + 1], br[i, j + 1], br[i + 1, j + 1],
                        br[i - 2, j], br[i - 1, j], br[i, j], br[i + 1, j], br[i + 2, j],
                                    br[i - 1, j - 1], br[i, j - 1], br[i + 1, j - 1],
                                                        br[i, j - 2]
                    };
                    t[i - 2, j - 2] = array.OrderBy(q => q).ToArray()[7];
                }
            }
            mainForm.alteredImageBox.Image = MainForm.GetImageFromMatrix(t);
        }

        private void UseFourthMask()
        {
            byte[,] br = NoiseForm.GetBrightnessMatrix(image);

            int width = br.GetLength(0);
            int height = br.GetLength(1);
            byte[,] t = new byte[width - 4, height - 4];
            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {
                    byte[] array = new byte[] {
                        br[i - 2, j + 2],  br[i - 1, j + 2], br[i, j + 2], br[i + 1, j + 2], br[i + 2, j + 2],
                        br[i - 2, j + 1],  br[i - 1, j + 1], br[i, j + 1], br[i + 1, j + 1], br[i + 2, j + 1],
                        br[i - 2, j],       br[i - 1, j],    br[i, j],     br[i + 1, j],      br[i + 2, j],
                        br[i - 2, j - 1],  br[i - 1, j - 1], br[i, j - 1], br[i + 1, j - 1], br[i + 2, j - 1],
                        br[i - 2, j - 2],  br[i - 1, j - 2], br[i, j - 2], br[i + 1, j - 2], br[i + 2, j - 2],
                    };
                    t[i - 2, j - 2] = array.OrderBy(q => q).ToArray()[13];
                }
            }
            mainForm.alteredImageBox.Image = MainForm.GetImageFromMatrix(t);
        }
    }
}
