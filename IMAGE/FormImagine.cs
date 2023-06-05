using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Emgu.CV.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EditProdProj.IMAGE
{
    public partial class FormImagine : Form
    {
        private imagine ImageProcessor { get; set; }

        public FormImagine()
        {
            InitializeComponent();
            ImageProcessor.setPictureBox(pictureBox1);
        }

        private void FormImagine_Load(object sender, EventArgs e)
        {

        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImageProcessor.LoadImage(filePath);
                pictureBox.Image = ImageProcessor.MyImage.ToBitmap();
            }
        }

        private void greyImage_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> grayImage = ImageProcessor.ConvertToGray();
            pictureBox1.Image = grayImage.AsBitmap();
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            ImageProcessor.ShowHistogram();
        }

        private void gamma_Click(object sender, EventArgs e)
        {
            double gamma = 0.4;
            ImageProcessor.ApplyGammaCorrection(gamma);
        }

        private void rotateImage_Click(object sender, EventArgs e)
        {
            double angle = 45.0;
            ImageProcessor.RotateImage(angle);
        }

        private void brightnes_Click(object sender, EventArgs e)
        {
            string alpha = textBoxALFA.Text;
            string beta = textBoxBETA.Text;
            double alphaValue = Double.Parse(alpha);
            double betaValue = Double.Parse(beta);
            ImageProcessor.AdjustBrightness(alphaValue, betaValue);
        }
    }
}
