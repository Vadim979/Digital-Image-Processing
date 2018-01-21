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

        private byte[,] paintedOver;

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

        public static Bitmap GetImageFromMatrix(byte[,] g)
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

        private void LocalAveraging(byte[,] f)
        {
            byte[,] g = new byte[originalImageBox.Image.Width - 2, originalImageBox.Image.Height - 2];
            double R;
            for (int x = 1; x < originalImageBox.Image.Width - 1; x++)
            {
                for (int y = 1; y < originalImageBox.Image.Height - 1; y++)
                {
                    R = (double)(f[x - 1, y - 1] + 2 * f[x, y - 1] + f[x + 1, y - 1] +
                               +2 * f[x - 1, y] + 4 * f[x, y] + 2 * f[x + 1, y] +
                               +f[x - 1, y + 1] + 2 * f[x, y + 1] + f[x + 1, y + 1])
                               / 16;
                    g[x - 1, y - 1] = (byte)R;
                }
            }

            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private void локальноеУсреднениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
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

            byte[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            KNearestNeighbors(f);
        }

        private void KNearestNeighbors(byte[,] f)
        {
            byte[,] g = new byte[f.GetLength(0) - 2, f.GetLength(1) - 2];
            double R;
            for (int x = 1; x < f.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < f.GetLength(1) - 1; y++)
                {
                    R = (f[x - 1, y - 1] + f[x, y - 1] + f[x + 1, y - 1] +
                       +f[x - 1, y] + f[x + 1, y] +
                       +f[x - 1, y + 1] + f[x, y + 1] + f[x + 1, y + 1]);
                    R /= (N * N - 1);
                    g[x - 1, y - 1] = (byte)R;
                }
            }

            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private void SmoothingOver(byte[,] f)
        {
            byte[,] g = new byte[f.GetLength(0) - 4, f.GetLength(1) - 4];

            for (int x = 2; x < f.GetLength(0) - 2; x++)
            {
                for (int y = 2; y < f.GetLength(1) - 2; y++)
                {
                    byte[,] window = new byte[5, 5] { {f[x - 2, y - 2], f[x - 1, y - 2], f[x, y - 2], f[x + 1, y - 2], f[x + 2, y - 2] },
                                                 {f[x - 2, y - 1], f[x - 1, y - 1], f[x, y - 1], f[x + 1, y - 1], f[x + 2, y - 1] },
                                                 {f[x - 2, y]    , f[x - 1 , y]   , f[x , y]   , f[x + 1, y]    , f[x + 2, y]     },
                                                 {f[x - 2, y + 1], f[x - 1, y + 1], f[x, y + 1], f[x + 1, y + 1], f[x + 2, y + 1] },
                                                 {f[x - 2, y + 2], f[x - 1, y + 2], f[x, y + 2], f[x + 1, y + 2], f[x + 2, y + 2] }};
                    g[x - 2, y - 2] = GetAverageValue(window);
                }
            }
            alteredImageBox.Image = GetImageFromMatrix(g);
        }

        private byte GetAverageValue(byte[,] f)
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

            return (byte)((double)V[N, 1] / 9.0);
        }

        private void сглаживаниеПоОднороднойОкрестностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
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
        
        private void лапласианToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);

            int width = f.GetLength(0);
            int height = f.GetLength(1);
            byte[,] g = new byte[width - 2, height - 2];
            int Vf = 0;
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    Vf = f[x + 1, y] + f[x, y + 1] + f[x - 1, y] + f[x, y - 1] - 4 * f[x, y];
                    g[x - 1, y - 1] = (byte)Vf;
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
            alteredImageBox.Image = GetImageFromMatrix(GetRobertsEdgeMatrix());
        }

        private byte[,] GetRobertsEdgeMatrix()
        {
            byte[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);

            int width = f.GetLength(0);
            int height = f.GetLength(1);
            byte[,] g = new byte[width - 1, height - 1];
            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    g[x, y] = (byte)(Math.Abs(f[x + 1, y + 1] - f[x, y]) + Math.Abs(f[x, y + 1] - f[x + 1, y]));
                    if (g[x, y] > 255)
                        g[x, y] = 255;
                    if (g[x, y] < 0)
                        g[x, y] = 0;
                }
            }
            return g;
        }

        private void детекторГраницКанниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //byte[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            ////CannyOptionsForm canny = new CannyOptionsForm(f);
            //canny.ShowDialog();
            //if (canny.image != null)
            //{
            //    alteredImageBox.Image = canny.image;
            //}
        }

        private void выделениеКонтуровToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void changeButton_Click(object sender, EventArgs e)
        {
            originalImageBox.Image = alteredImageBox.Image;
            originalImage = (Bitmap)originalImageBox.Image;
            alteredImageBox.Image = null;
            alteredImage = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            erosionGroup.Enabled = false;
            originalImageBox.Enabled = false;
            closeFillModeButton.Hide();
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
                for (int y = 20; y < 25; y++)
                {
                    image.SetPixel(x, y, Color.FromName("black"));
                }
            }
            originalImageBox.Image = image;
        }

        #region Морфологическая обработка


        private void эрозияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            erosionGroup.Enabled = true;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            alteredImageBox.Image = MakeErosion();
        }

        private Bitmap MakeErosion()
        {
            int k = 2;
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
            byte[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
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

            return image;
        }

        private void заполнениеОбластиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFillModeButton.Show();
            originalImageBox.Enabled = true;
            this.BackColor = Color.FromName("ControlDarkDark");
            originalImageBox.SizeMode = PictureBoxSizeMode.Normal;
            alteredImageBox.SizeMode = PictureBoxSizeMode.Normal;
        }
        #endregion

        private void closeFillModeButton_Click(object sender, EventArgs e)
        {
            closeFillModeButton.Hide();
            this.BackColor = Color.FromName("Control");
            originalImageBox.Enabled = false;
            originalImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            alteredImageBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void originalImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(alteredImageBox.Image != null)
            {
                paintedOver = NoiseForm.GetBrightnessMatrix(alteredImageBox.Image);
            }
            else
            {
                paintedOver = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            }
            paintedOver[e.X, e.Y] = 0;

            PaintOver(e.X, e.Y + 1);
            PaintOver(e.X + 1, e.Y);
            PaintOver(e.X - 1, e.Y);
            PaintOver(e.X, e.Y - 1);

            int width = paintedOver.GetLength(0), height = paintedOver.GetLength(1), pixel;

            for (int i = 0; i < width; i++)
                for(int j = 0; j < height; j++)
                {
                    pixel = paintedOver[i, j];
                    try
                    {
                        alteredImage.SetPixel(i, j, Color.FromArgb(pixel, pixel, pixel));
                    }
                    catch
                    {
                        alteredImage = new Bitmap(originalImageBox.Image);
                        alteredImage.SetPixel(i, j, Color.FromArgb(pixel, pixel, pixel));
                    }
                }
            alteredImageBox.Image = alteredImage;
        }

        private void PaintOver(int x, int y)
        {
            
            try
            {
                if (paintedOver[x, y] < 128)
                {
                    return;
                }
                else
                {
                    paintedOver[x, y] = 0;
                }
            }
            catch { }
            

            PaintOver(x, y + 1);
            PaintOver(x + 1, y);
            PaintOver(x, y - 1);
            PaintOver(x - 1, y);
        }

        private void выделениеГраницToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int[,] f = NoiseForm.GetBrightnessMatrix(originalImageBox.Image);
            //int[,] g = NoiseForm.GetBrightnessMatrix(MakeErosion());

            //int width = g.GetLength(0), heiht = g.GetLength(1), pixel = 0;

            //Bitmap image = new Bitmap(width, heiht);

            //for (int x = 0; x < width; x++)
            //    for(int y = 0; y < heiht; y++)
            //    {
            //        pixel = f[x + 2, y + 2];
            //        if (g[x, y] > 10)
            //            pixel = 0;
            //        image.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
            //    }

            //alteredImageBox.Image = image;
        }

        private void утончениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thinning(originalImageBox.Image as Bitmap);
        }

        private void Thinning(Bitmap b)
        {
            List<int[,]> mask = new List<int[,]>();
            int[,] x0 = { { 255, 255, 255 }, { -1, 0, -1 }, { 0, 0, 0 } };
            mask.Add(x0);
            int[,] x1 = { { -1, 255, 255 }, { 0, 0, 255 }, { 0, 0, -1 } };
            mask.Add(x1);
            int[,] x2 = { { 0, -1, 255 }, { 0, 0, 255 }, { 0, -1, 255 } };
            mask.Add(x2);
            int[,] x3 = { { 0, 0, -1 }, { 0, 0, 255 }, { -1, 255, 255 } };
            mask.Add(x3);
            int[,] x4 = { { 0, 0, 0 }, { -1, 0, -1 }, { 255, 255, 255 } };
            mask.Add(x4);
            int[,] x5 = { { -1, 0, 0 }, { 255, 0, 0 }, { 255, 255, -1 } };
            mask.Add(x5);
            int[,] x6 = { { 255, -1, 0 }, { 255, 0, 0 }, { 255, -1, 0 } };
            mask.Add(x6);
            int[,] x7 = { { 255, 255, -1 }, { 255, 0, 0 }, { -1, 0, 0 } };
            mask.Add(x7);


            Bitmap im = b;
            Bitmap imResolt = im.Clone() as Bitmap;

            alteredImageBox.Image = imResolt;
            int maskWidth, maskHeight;
            bool isChange = true;
            while (isChange)
            {
                isChange = false;
                for (int k = 0; k < mask.Count; k++)
                {
                    maskWidth = mask[k].GetLength(0);
                    maskHeight = mask[k].GetLength(1);
                    for (int j = 0; j < im.Height - 3; j++)
                    {
                        for (int i = 0; i < im.Width - 3; i++)
                        {
                            int sum = 0;
                            for (int m = 0; m < maskWidth; m++)
                            {
                                for (int n = 0; n < maskHeight; n++)
                                {
                                    int x = im.GetPixel(i + n, j + m).R;
                                    int y = mask[k][m, n];
                                    if ((y == -1) || (x == y))
                                        sum++;

                                    if (sum == 9)
                                    {
                                        imResolt.SetPixel(i + 1, j + 1, Color.White); // + 1 + 1
                                        isChange = true;

                                        //alteredImageBox.Refresh();
                                    }
                                }
                            }
                        }
                    }

                    alteredImageBox.Refresh();
                    im = imResolt.Clone() as Bitmap;
                }
            }
            MessageBox.Show("Выполнение утончения завершено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        int[,] maskIrosion = new int[3, 3] { { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 } };

        private byte[,] Erosion(byte[,] b)
        {
            byte[,] g = new byte[b.GetLength(0), b.GetLength(1)];
            for (int i = 1; i < b.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < b.GetLength(1) - 1; j++)
                {
                    if((b[i - 1, j + 1] == 255)&&(b[i - 1, j] == 255) && (b[i - 1, j - 1] == 255) && (b[i, j + 1] == 255) && (b[i, j] == 255) && (b[i, j - 1] == 255) && (b[i + 1, j + 1] == 255) && (b[i + 1, j] == 255) && (b[i+1,j-1] == 255))
                    {
                        g[i, j] = 255;
                    }
                }
            }
            return g;
        }
        private byte[,] Dilation(byte[,] b)
        {
            byte[,] g = new byte[b.GetLength(0), b.GetLength(1)];
            for (int i = 1; i < b.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < b.GetLength(1) - 1; j++)
                {
                    if ((b[i - 1, j + 1] == 255) || (b[i - 1, j] == 255) || (b[i - 1, j - 1] == 255) || (b[i, j + 1] == 255) || (b[i, j] == 255) || (b[i, j - 1] == 255) || (b[i + 1, j + 1] == 255) || (b[i + 1, j] == 255) || (b[i + 1, j - 1] == 255))
                    {
                        g[i, j] = 255;
                    }
                }
            }
            return g;
        }
        private byte[,] Opening(byte[,] f)
        {
            return Dilation(Erosion(f));
        }

        private byte[,] Skeletonization(byte[,] image)
        {
            int count = 0;
            List<byte[,]> erosions = new List<byte[,]>();
            erosions.Add(image);
            int width = image.GetLength(0), height = image.GetLength(1);
            bool flag = true;
            while (flag)
            {
                flag = false;
                count++;
                byte[,] g = new byte[width, height];
                for (int i = 1; i < width - 1; i++)
                {
                    for (int j = 1; j < height - 1; j++)
                    {
                        if ((erosions[count - 1][i - 1, j + 1] == 255) && (erosions[count - 1][i - 1, j] == 255) && (erosions[count - 1][i - 1, j - 1] == 255) && (erosions[count - 1][i, j + 1] == 255) && (erosions[count - 1][i, j] == 255) && (erosions[count - 1][i, j - 1] == 255) && (erosions[count - 1][i + 1, j + 1] == 255) && (erosions[count - 1][i + 1, j] == 255) && (erosions[count - 1][i + 1, j - 1] == 255))
                        {
                            g[i, j] = 255;
                            flag = true;
                        }
                    }
                }
                erosions.Add(g);
            }

            List<byte[,]> openings = new List<byte[,]>();
            List<byte[,]> differences = new List<byte[,]>();
            for(int i = 0; i < count; i++)
            {
                openings.Add(Opening(erosions[i]));
                differences.Add(GetDifferenceOfSets(erosions[i], openings[i]));
            }
            erosions.Clear();
            byte[,] skeleton = new byte[width, height];

            for(int i = 0; i < count; i++)
                for(int x = 0; x < width; x++)
                    for(int y = 0; y < height; y++)
                    {
                        if (skeleton[x, y] == 0)
                            skeleton[x, y] = differences[i][x, y];
                    }

            return skeleton;
            
        }

        private byte[,] GetDifferenceOfSets(byte[,] A, byte[,] B)
        {
            int width = A.GetLength(0), height = A.GetLength(1);
            byte[,] difference = new byte[width, height];

            for(int i = 0; i < width; i++)
                for(int j = 0; j < height; j++)
                {
                    if ((A[i, j] == 255) && (B[i, j] == 0))
                        difference[i, j] = 255;
                }

            return difference;
        }
        
        private byte[,] MakeBinaryImage(byte[,] f)
        {
            int width = f.GetLength(0), height = f.GetLength(1);
            byte[,] g = new byte[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    g[i, j] = f[i, j] > 128 ? (byte)255 : (byte)0;
                }
            }

            return g;
        }

        private void эрозияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            byte[,] g = MakeBinaryImage(NoiseForm.GetBrightnessMatrix(originalImage));
            byte[,] f = Erosion(g);
            alteredImageBox.Image = GetImageFromMatrix(f);
        }

        private void построениеОстоваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            byte[,] f = MakeBinaryImage(NoiseForm.GetBrightnessMatrix(originalImageBox.Image));
            alteredImageBox.Image = GetImageFromMatrix(Skeletonization(f));
            Enabled = true;
        }
    }
}
