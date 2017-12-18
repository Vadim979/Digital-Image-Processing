using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP_1
{
    public partial class MainForm : Form
    {
        private Bitmap alteredImage;
        private Bitmap originalImage;
        public Bitmap backupImage;
        public static int width;
        public static int height;
        public static List<PointsPair> pointsList;
        public int N = 3;                                      // Размер окна для метода К-ближайших соседей
        public MainForm()
        {
            InitializeComponent();
            openFile();
            Show();
            pointsList = new List<PointsPair>();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalImage = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                    width = originalImage.Width;
                    height = originalImage.Height;
                    alteredImage = new Bitmap(originalImage);
                    originalImageBox.Image = originalImage;
                    alteredImageBox.Image = alteredImage;
                }
                catch (Exception openE)
                {
                    MessageBox.Show("Error while loading Image: \n\t" + openE.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public byte[,,] toBytes(Bitmap image)
        {
            byte[,,] res = new byte[3, height, width];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                {
                    Color color = image.GetPixel(x, y);
                    res[0, y, x] = color.R;
                    res[1, y, x] = color.G;
                    res[2, y, x] = color.B;
                }
            return res;
        }

        private int[] GetBrightness(Bitmap img)
        {
            int[] arrayOfBrightness = new int[256];

            int brightness = 0;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    brightness = (int)(img.GetPixel(i, j).GetBrightness() * 255);
                    arrayOfBrightness[brightness]++;
                }
            }
            return arrayOfBrightness;
        }

        private float[] FrequencyDistribution()
        {
            int[] brightness = GetBrightness(originalImage);
            float[] frequency = new float[256];
            int amountOfPixels = 0;
            for (int i = 0; i < 256; i++)
            {
                amountOfPixels += brightness[i];
            }
            for (int i = 0; i < 256; i++)
            {
                frequency[i] = ((float)brightness[i] / amountOfPixels);
            }
            return frequency;
        }

        public static Bitmap GetImageFromMatrix(int[,] g)
        {
            Bitmap template = new Bitmap(g.GetLength(0), g.GetLength(1));

            for (int x = 0; x < g.GetLength(0); x++)
            {
                for (int y = 0; y < g.GetLength(1); y++)
                {
                    template.SetPixel(x, y, Color.FromArgb(g[x, y], g[x, y], g[x, y]));
                }
            }

            return template;
        }

        #region Contrast
        private void invertedContrastScallingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color current = originalImage.GetPixel(i, j);
                    alteredImage.SetPixel(i, j, Color.FromArgb(255 - current.R, 255 - current.G, 255 - current.B));
                }
            }
            alteredImageBox.Image = alteredImage;
        }
        private void brightnessSliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog contrastOptions = new OptionsDialog(new string[] { "slice" });
            contrastOptions.Owner = this;
            contrastOptions.ShowDialog();
        }
        public void BrightnessSlice(int max, int min)
        {
            alteredImage = new Bitmap(originalImage);
            alteredImageBox.Image = originalImage;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    float brightness = originalImage.GetPixel(i, j).GetBrightness() * 255;

                    if ((brightness >= min) && (brightness <= max))
                    {
                        alteredImage.SetPixel(i, j, originalImage.GetPixel(i, j));
                    }
                    else
                    {
                        alteredImage.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            alteredImageBox.Image = alteredImage;
        }
        private void contrastLinearScalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog contrastOptions = new OptionsDialog(new string[] { "linear" });
            contrastOptions.Owner = this;
            contrastOptions.ShowDialog();
        }
        public void LinearContrastScaling(int max, int min)
        {
            alteredImage = new Bitmap(originalImage);
            List<double> brightness = new List<double>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    brightness.Add(255 * originalImage.GetPixel(i, j).GetBrightness());
                }
            }

            double fmax = brightness.Max(l => l);
            double fmin = brightness.Min(l => l);

            double a = (max - min) / (fmax - fmin);
            double b = (min * fmax - max * fmin) / (fmax - fmin);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color curr = alteredImage.GetPixel(x, y);
                    double correctorR = curr.R * a + b;
                    double correctorG = curr.G * a + b;
                    double correctorB = curr.B * a + b;
                    if (correctorR < min) correctorR = min;
                    if (correctorR > max) correctorR = max;
                    if (correctorG < min) correctorG = min;
                    if (correctorG > max) correctorG = max;
                    if (correctorB < min) correctorB = min;
                    if (correctorB > max) correctorB = max;
                    alteredImage.SetPixel(x, y, Color.FromArgb((int)correctorR, (int)correctorG, (int)correctorB));
                }
            }
            alteredImageBox.Image = alteredImage;
        }
        #endregion

        #region Histogram
        private void uniformHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog options = new OptionsDialog(new string[] { "histogram", "uniform" });
            options.Owner = this;
            options.ShowDialog();
        }

        public void Histogram(int gmax, int gmin, string selector)
        {
            float[] frequency = FrequencyDistribution();
            int brightness, g;
            float f;
            int count = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    brightness = (int)(originalImage.GetPixel(i, j).GetBrightness() * 255);
                    g = 0;
                    f = 0;
                    for (int k = 0; k < brightness; k++)
                    {
                        f += frequency[k];
                    }

                    switch (selector)
                    {
                        case "uniform":
                            g = (int)((gmax - gmin) * f + gmin);
                            break;
                        case "degree":
                            g = (int)(Math.Pow(((Math.Pow((double)gmax, 0.333d) - Math.Pow((double)gmin, 0.333d)) * f + Math.Pow((double)gmin, 0.333d)), 3.0d));
                            break;
                        case "hyperbolic":
                            if (gmin == 0) gmin = 1;
                            g = (int)((double)gmin * Math.Pow(((double)gmax / (double)gmin), f));
                            break;
                    }
                    if (g > 200) count++;
                    if (g < gmin) g = gmin;
                    if (g > gmax) g = gmax;
                    alteredImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }
            alteredImageBox.Image = alteredImage;
            HistogramForm hf = new HistogramForm(GetBrightness(originalImage), GetBrightness(new Bitmap(alteredImage)));
            hf.ShowDialog();
        }

        private void degree23ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog options = new OptionsDialog(new string[] { "histogram", "degree" });
            options.Owner = this;
            options.ShowDialog();
        }

        private void hyperbolicHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog options = new OptionsDialog(new string[] { "histogram", "hyperbolic" });
            options.Owner = this;
            options.ShowDialog();
        }

        private void showHistogramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramForm hf = new HistogramForm(GetBrightness(originalImage), GetBrightness(alteredImage));
            hf.ShowDialog();
        }
        #endregion

        #region Filters

        private void GenRand(int min, int max)
        {
            Random random = new Random();
            int color = random.Next(min, max);

            Bitmap timage = new Bitmap(originalImageBox.Image);

            Point A = new Point();
            Point B = new Point();

            PointsPair AnB = PointsPair.GetPoints(A, B);
            pointsList.Add(AnB);

            Thread.Sleep(20);
            for (int x = AnB.A.X; x < AnB.B.X; x++)
            {
                for (int y = AnB.A.Y; y < AnB.B.Y; y++)
                {
                    timage.SetPixel(x, y, System.Drawing.Color.FromArgb(color, color, color));
                }
            }
            originalImageBox.Image = timage;
        }

        public class PointsPair
        {
            public static int count = 0;
            int id;
            public Point A;
            public Point B;
            public PointsPair()
            {
                id = ++count;
            }
            public static Boolean IsBetween(Point Z, int count)
            {
                Boolean isBetween = false;
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        if ((Z.X >= pointsList[i].A.X) && (Z.X <= pointsList[i].B.X) || ((Z.X <= pointsList[i].A.X) && (Z.X >= pointsList[i].B.X)))
                        {
                            if (((Z.Y >= pointsList[i].A.Y) && (Z.Y <= pointsList[i].B.Y)) || ((Z.Y <= pointsList[i].A.Y) && (Z.Y >= pointsList[i].B.Y)))
                            {
                                isBetween = true;
                            }
                        }
                    }
                }
                catch { }
                return isBetween;
            }

            public static PointsPair GetPoints(Point A, Point B)
            {
                Random random = new Random();

                PointsPair AnB = new PointsPair();
                Thread.Sleep(20);
                A.X = random.Next(0, width - 1);
                Thread.Sleep(20);
                B.X = random.Next(A.X, width);
                Thread.Sleep(20);

                Thread.Sleep(20);
                A.Y = random.Next(0, height - 1);
                Thread.Sleep(20);
                B.Y = random.Next(A.Y, height);
                Thread.Sleep(20);

                AnB.A = A;
                AnB.B = B;

                if (PointsPair.count > 1)
                {
                    if (IsBetween(A, count - 1))
                    {
                        return GetPoints(A, B);
                    }
                    if (IsBetween(B, count - 1))
                    {
                        return GetPoints(A, B);
                    }
                }
                return AnB;
            }
        }

        private void generateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsPair.count = 0;
            Bitmap timage = new Bitmap(originalImageBox.Image);

            int white = 255;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    timage.SetPixel(x, y, Color.FromArgb(white, white, white));
                }
            }
            originalImageBox.Image = timage;
            GenRand(50, 100);
            GenRand(120, 170);
            GenRand(190, 240);
        }

        private void добавитьШумToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoiseForm noiseForm = new NoiseForm();
            noiseForm.Owner = this;
            noiseForm.ShowDialog();
        }

        private void LocalAveraging(int[,] f)
        {
            int[,] g = new int[originalImageBox.Image.Width - 2, originalImageBox.Image.Height - 2];
            double R;
            for (int x = 1; x < originalImageBox.Image.Width - 1; x++)
            {
                for (int y = 1; y < originalImageBox.Image.Height - 1; y++)
                {
                    R = (double)(f[x - 1, y - 1] + 2 * f[x, y - 1] + f[x + 1, y - 1] +
                               +2 * f[x - 1, y] + 4 * f[x, y] + 2 * f[x + 1, y] +
                               +f[x - 1, y + 1] + 2 * f[x, y + 1] + f[x + 1, y + 1])
                               / 16;
                    g[x - 1, y - 1] = (int)R;
                }
            }

            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private void локальноеУсреднениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            LocalAveraging(f);
        }

        private void удалитьШумToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            originalImageBox.Image = backupImage;
        }

        private void методКближайшихСоседейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNForm setN = new SetNForm();
            setN.Owner = this;
            setN.ShowDialog();

            int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            KNearestNeighbors(f);
        }

        private void KNearestNeighbors(int[,] f)
        {
            int[,] g = new int[f.GetLength(0) - 2, f.GetLength(1) - 2];
            double R;
            for (int x = 1; x < f.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < f.GetLength(1) - 1; y++)
                {
                    R = (f[x - 1, y - 1] + f[x, y - 1] + f[x + 1, y - 1] +
                       +f[x - 1, y] + f[x + 1, y] +
                       +f[x - 1, y + 1] + f[x, y + 1] + f[x + 1, y + 1]);
                    R /= (N * N - 1);
                    g[x - 1, y - 1] = (int)R;
                }
            }

            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private void SmoothingOver(int[,] f)
        {
            int[,] g = new int[f.GetLength(0) - 4, f.GetLength(1) - 4];

            for (int x = 2; x < f.GetLength(0) - 2; x++)
            {
                for (int y = 2; y < f.GetLength(1) - 2; y++)
                {
                    int[,] window = new int[5, 5] { {f[x - 2, y - 2], f[x - 1, y - 2], f[x, y - 2], f[x + 1, y - 2], f[x + 2, y - 2] },
                                                 {f[x - 2, y - 1], f[x - 1, y - 1], f[x, y - 1], f[x + 1, y - 1], f[x + 2, y - 1] },
                                                 {f[x - 2, y]    , f[x - 1 , y]   , f[x , y]   , f[x + 1, y]    , f[x + 2, y]     },
                                                 {f[x - 2, y + 1], f[x - 1, y + 1], f[x, y + 1], f[x + 1, y + 1], f[x + 2, y + 1] },
                                                 {f[x - 2, y + 2], f[x - 1, y + 2], f[x, y + 2], f[x + 1, y + 2], f[x + 2, y + 2] }};
                    g[x - 2, y - 2] = GetAverageValue(window);
                }
            }
            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private int GetAverageValue(int[,] f)
        {
            int[,] V = new int[4, 2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    V[0, 0] += f[2, 2] - f[i, j];
                    V[0, 1] += f[i, j];
                }
            }

            for (int i = 2; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    V[1, 0] += f[2, 2] - f[i, j];
                    V[1, 1] += f[i, j];
                }
            }

            for (int i = 2; i < 5; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    V[2, 0] += f[2, 2] - f[i, j];
                    V[2, 1] += f[i, j];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    V[3, 0] += f[2, 2] - f[i, j];
                    V[3, 1] += f[i, j];
                }
            }

            int N = 0;
            int min = V[0, 0];
            for (int i = 0; i < 4; i++)
            {
                if (V[i, 0] < min)
                {
                    min = V[i, 0];
                    N = i;
                }
            }

            return (int)((double)V[N, 1] / 9.0);
        }

        private void сглаживаниеПоОднороднойОкрестностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            SmoothingOver(f);
        }

        private void медианнаяФильтрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseFilterForm chff = new ChooseFilterForm(new Bitmap(originalImageBox.Image));
            chff.Owner = this;
            chff.ShowDialog();
        }
        #endregion

        #region Выделение границ





        #endregion

        private void лапласианToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);

            int width = f.GetLength(0);
            int height = f.GetLength(1);
            int[,] g = new int[width - 2, height - 2];
            int Vf = 0;
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    Vf = f[x + 1, y] + f[x, y + 1] + f[x - 1, y] + f[x, y - 1] - 4 * f[x, y];
                    g[x - 1, y - 1] = Vf;
                    if (g[x - 1, y - 1] > 255)
                        g[x - 1, y - 1] = 255;
                    if (g[x - 1, y - 1] < 0)
                        g[x - 1, y - 1] = 0;
                }
            }
            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private void филтрРобертсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);

            int width = f.GetLength(0);
            int height = f.GetLength(1);
            int[,] g = new int[width - 1, height - 1];
            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    g[x, y] = Math.Abs(f[x + 1, y + 1] - f[x, y]) + Math.Abs(f[x, y + 1] - f[x + 1, y]);
                    if (g[x, y] > 255)
                        g[x, y] = 255;
                    if (g[x, y] < 0)
                        g[x, y] = 0;
                }
            }
            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private void детекторГраницКанниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            CannyOptionsForm canny = new CannyOptionsForm(f);
            canny.ShowDialog();
            if (canny.image != null)
            {
                alteredImageBox.Image = canny.image;
            }
        }

        private void эрозияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            erosionGroup.Enabled = true;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            int k = 1;
            if (mask3x3.Checked)
            {
                k = 1;
            }
            else if (mask5x5.Checked)
            {
                k = 2;
            }
            else if (mask7x7.Checked)
            {
                k = 3;
            }
            else if (mask9x9.Checked)
            {
                k = 4;
            }
            int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            int width = f.GetLength(0), height = f.GetLength(1);
            bool flag = false;
            Bitmap image = new Bitmap(width - 2 * k, height - 2 * k);

            for (int x = k; x < width - k; x++)
            {
                for (int y = k; y < height - k; y++)
                {
                    for (int i = -k; i < k; i++)
                    {
                        for (int j = -k; j < k; j++)
                        {
                            if (f[x + i, y + j] >= 128)
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
                        }

                        if (!flag)
                            break;
                    }

                    if (flag)
                    {
                        image.SetPixel(x - k, y - k, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        image.SetPixel(x - k, y - k, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            alteredImageBox.Image = image;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            erosionGroup.Enabled = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImageBox.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        originalImageBox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void doToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int width = 256, height = 256;
            Bitmap image = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    image.SetPixel(x, y, Color.FromName("white"));
                }
            }

            for (int x = 20; x < 40; x++)
            {
                for(int y = 20; y < 25; y++)
                {
                    image.SetPixel(x, y, Color.FromName("black"));
                }
            }
            originalImageBox.Image = image;
        }

        private void выделениеКонтуровToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            originalImageBox.Image = alteredImageBox.Image;
            originalImage = (Bitmap)originalImageBox.Image;
            alteredImageBox.Image = null;
            alteredImage = null;
        }
    }
}
