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
    public partial class CannyOptionsForm : Form
    {
        public Bitmap image;
        private int[,] f;
        public CannyOptionsForm(int[,] f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            CannyDetector();
            Close();
        }

        private void CannyDetector()
        {
            int[,] g = f;
            double G;
            double sigma = (double)sigmaParametr.Value;
            int width = f.GetLength(0);
            int height = f.GetLength(1);
            double[,] d = new double[width, height];
            for (int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    G = (1 / (1 / (2 * Math.PI * sigma * sigma))) * Math.Exp(-(x * x + y * y) / (2 * sigma * sigma));
                    d[x, y] = (G * f[x, y]);
                    //if (g[x, y] > 255)
                    //    g[x, y] = 255;
                    //if (g[x, y] < 0)
                    //    g[x, y] = 0;

                }
            }
            image = new Bitmap(width, height);

            double Gx, Gy, E;
            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    Gx = Math.Abs(d[x + 1, y + 1] - d[x, y]);
                    Gy = Math.Abs(d[x + 1, y] - d[x, y + 1]);
                    E = Math.Sqrt(Gx * Gx + Gy * Gy);
                    if(Gy != 0)
                    {
                        if(E > Math.Atan(Gx / Gy))
                        {
                            d[x, y] = E;
                        }
                        else
                        {
                            d[x, y] = 0;
                        }
                        //g[x, y] = (E > Math.Atan(Gx / Gy)) ? (int)E :  0;
                    }
                    else
                    {
                        d[x, y] = E;
                    }
                    d[x, y] = (d[x, y] > 255) ? 255 : (d[x, y] < 0) ? 0 : d[x, y];

                    image.SetPixel(x, y, Color.FromArgb((int)d[x, y], (int)d[x, y], (int)d[x, y]));
                }
            }
        }
    }
}
