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
        private int width;
        private int height;
        public CannyOptionsForm(int[,] f)
        {
            this.f = f;
            width = f.GetLength(0);
            height = f.GetLength(1);
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Canny();
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

        private void Canny()
        {
            int[,] g = new int[width - 2, height - 2];
            double[,] d = new double[width, height];

            double sigma = (double)sigmaParametr.Value;
            double K1 = 1.0D / (2.0D * Math.PI * sigma * sigma);
            double K2;
            for (int x = 0; x < width; x++)
                for(int y = 0; y < height; y++)
                {
                    K2 = Math.Exp((x * x + y * y) / (2 * sigma * sigma));
                    if (K2 > 255) K2 = 255;
                    if (K2 < 0) K2 = 0;
                    d[x, y] = f[x, y] * K1 * K2;
                }
            image = new Bitmap(width - 2, height - 2);
            for (int x = 1; x < width - 1; x++)
                for (int y = 1; y < height - 1; y++)
                {
                    double Gx = Math.Abs(d[x + 1, y + 1] - d[x, y]);
                    double Gy = Math.Abs(d[x, y + 1] - d[x + 1, y]);
                    double E = Math.Sqrt(Gx * Gx + Gy * Gy);
                    g[x - 1, y - 1] = (int)E;
                    if (g[x - 1, y - 1] > 255) g[x - 1, y - 1] = 255;
                    if (g[x - 1, y - 1] < 0) g[x - 1, y - 1] = 0;
                    image.SetPixel(x - 1, y - 1, Color.FromArgb(g[x - 1, y - 1], g[x - 1, y - 1], g[x - 1, y - 1]));
                }
        }
    }
}
