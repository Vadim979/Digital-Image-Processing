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
    public partial class NoiseForm : Form
    {
        MainForm mainForm;
        Random random;
        public NoiseForm()
        {
            InitializeComponent();
        }

        private void NoiseForm_Load(object sender, EventArgs e)
        {
            mainForm = this.Owner as MainForm;
            originalPictureBox.Image = mainForm.originalImageBox.Image;
            noisedPictureBox.Image = mainForm.originalImageBox.Image;
            radioButton025.Checked = true;
            additiveNoiseButton.Checked = true;
            randomRange.Value = 255;
            random = new Random();
        }

        private void addNoiseButton_Click(object sender, EventArgs e)
        {
            noisedPictureBox.Image = originalPictureBox.Image;
            double noiseLevel = 0.0;
            if(radioButton025.Checked)
            {
                noiseLevel = 0.25;
            }
            else if (radioButton050.Checked)
            {
                noiseLevel = 0.50;
            }
            else if(radioButton075.Checked)
            {
                noiseLevel = 0.75;
            }
            else
            {
                MessageBox.Show("Выберите уровень шумовой помехи!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (additiveNoiseButton.Checked)
            {
                AdditiveNoise(noiseLevel);
            }
            else if (impulsNoiseButton.Checked)
            {
                ImpulsiveNoise(noiseLevel);
            }
            else if(additiveImpulsiveNoiseButton.Checked)
            {
                AdditiveImpulsiveNoise("points");
            }
            else if (additiveImpulsiveStrNoiseButton.Checked)
            {
                AdditiveImpulsiveNoise("strings");
            }
        }

        private void ImpulsiveNoise(double noiseLevel)
        {
            int[,] randomMatrix = new int[originalPictureBox.Image.Width, originalPictureBox.Image.Height];
            int[,] originalImageBrightness = GetBrightnessMatrix(noisedPictureBox.Image);

            long pictureEnergy = 0;

            for (int x = 0; x < originalPictureBox.Image.Width; x++)
            {
                for (int y = 0; y < originalPictureBox.Image.Height; y++)
                {
                    pictureEnergy += originalImageBrightness[x, y] * originalImageBrightness[x, y];
                }
            }

            int amplitude = 50;

            int M = (int)((noiseLevel * pictureEnergy) / (double)(amplitude * amplitude));
            //if (M > originalPictureBox.Image.Width * originalPictureBox.Image.Height)
            //    M = originalPictureBox.Image.Width * originalPictureBox.Image.Height;

            for(int i = 0; i < M; i++)
            {
                int[] coordiantes = NoiseCoordinates();
                randomMatrix[coordiantes[0], coordiantes[1]] = random.Next((int)randomRange.Value);
            }

            Bitmap template = new Bitmap(originalPictureBox.Image);
            int pixel = 0;

            for (int x = 0; x < originalPictureBox.Image.Width; x++)
            {
                for (int y = 0; y < originalPictureBox.Image.Height; y++)
                {
                    pixel = originalImageBrightness[x, y] + randomMatrix[x, y];
                    if (pixel < 0)
                        pixel = 0;
                    if (pixel > 255)
                        pixel = 255;
                    template.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
                }
            }

            noisedPictureBox.Image = template;
        }

        private void AdditiveImpulsiveNoise(string type)
        {
            int[,] originalImageBrightness = GetBrightnessMatrix(noisedPictureBox.Image);
            int[,] randomMatrix = originalImageBrightness;
            long pictureEnergy = 0;

            for (int x = 0; x < originalPictureBox.Image.Width; x++)
            {
                for (int y = 0; y < originalPictureBox.Image.Height; y++)
                {
                    pictureEnergy += originalImageBrightness[x, y] * originalImageBrightness[x, y];
                }
            }

            double noisinessPercent = (double)percentOfNoisiness.Value / 100.0;
            int numOfPixels = (int)(originalPictureBox.Image.Width * originalPictureBox.Image.Height * noisinessPercent);

            for(int i = 0; i < numOfPixels; i++)
            {
                int len = random.Next(2, 5);
                int a = random.Next(0, originalPictureBox.Image.Width - len);
                int b = random.Next(0, originalPictureBox.Image.Height);
                switch (type)
                {
                    case "points":
                        len = 1;
                        break;
                    case "strings":
                        break;
                }

                if (originalImageBrightness[a, b] < 128)
                {
                    for (int j = 0; j < len; j++)
                    {
                        randomMatrix[a + j, b] = 255;
                    }
                }
                else
                {
                    for (int j = 0; j < len; j++)
                    {
                        randomMatrix[a + j, b] = 0;
                    }
                }
            }

            int pixel;
            Bitmap template = new Bitmap(originalPictureBox.Image);
            for (int x = 0; x < originalPictureBox.Image.Width; x++)
            {
                for (int y = 0; y < originalPictureBox.Image.Height; y++)
                {
                    pixel = randomMatrix[x, y];
                    template.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
                }
            }
            noisedPictureBox.Image = template;
        }
        private int[] NoiseCoordinates()
        {
            int a, b;
            a = random.Next(0, originalPictureBox.Image.Width);
            b = random.Next(0, originalPictureBox.Image.Height);
            return new int[] { a, b };
        }

        private void AdditiveNoise(double noiseLevel)
        {
            int[,] randomMatrix = GetRandomMatrix(originalPictureBox.Image.Width, originalPictureBox.Image.Height);
            int[,] originalImageBrightness = GetBrightnessMatrix(noisedPictureBox.Image);

            int noiseEnergy = 0;
            int pictureEnergy = 0;

            for (int x = 0; x < originalPictureBox.Image.Width; x++)
            {
                for (int y = 0; y < originalPictureBox.Image.Height; y++)
                {
                    noiseEnergy += randomMatrix[x, y] * randomMatrix[x, y];
                    pictureEnergy += originalImageBrightness[x, y] * originalImageBrightness[x, y];

                }
            }

            int pixel = 0;

            Bitmap template = new Bitmap(noisedPictureBox.Image);

            for (int x = 0; x < originalPictureBox.Image.Width; x++)
            {
                for (int y = 0; y < originalPictureBox.Image.Height; y++)
                {
                    pixel = (int)(originalImageBrightness[x, y] + (double)(noiseLevel * (double)randomMatrix[x, y] * ((double)pictureEnergy / (double)noiseEnergy)));
                    if (pixel > 255)
                        pixel = 255;
                    if (pixel < 0)
                        pixel = 0;
                    template.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
                }
            }

            noisedPictureBox.Image = template;
        }

        public static int[,] GetBrightnessMatrix(Image image)
        {
            int[,] matrix = new int[image.Width, image.Height];
            
            Bitmap bmp10 = new Bitmap(image);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    matrix[x, y] = (int)(bmp10.GetPixel(x, y).GetBrightness() * 255); 
                }
            }

            return matrix;
        }

        private int[,] GetRandomMatrix(int width, int height)
        {
            int[,] randomMatrix = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    randomMatrix[x, y] = random.Next((int)randomRange.Value);
                }
            }
            return randomMatrix;
        }

        private void radioButton025_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton025.Checked)
            {
                radioButton050.Checked = radioButton075.Checked = false;
            }
        }

        private void radioButton050_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton050.Checked)
            {
                radioButton025.Checked = radioButton075.Checked = false;
            }
        }

        private void radioButton075_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton075.Checked)
            {
                radioButton050.Checked = radioButton025.Checked = false;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            mainForm.originalImageBox.Image = noisedPictureBox.Image;
            mainForm.backupImage = new Bitmap(originalPictureBox.Image);
            Close();
        }

        private void additiveImpulsiveNoiseButton_CheckedChanged(object sender, EventArgs e)
        {
            if (additiveImpulsiveNoiseButton.Checked)
            {
                additiveImpulsiveStrNoiseButton.Checked = false;
                additiveNoiseButton.Checked = false;
                impulsNoiseButton.Checked = false;
            }
        }

        private void additiveImpulsiveStrNoiseButton_CheckedChanged(object sender, EventArgs e)
        {
            if (additiveImpulsiveStrNoiseButton.Checked)
            {
                additiveImpulsiveNoiseButton.Checked = false;
                additiveNoiseButton.Checked = false;
                impulsNoiseButton.Checked = false;
            }
        }
    }
}
