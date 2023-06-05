using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.UI;
using System.Windows.Forms;

namespace EditProdProj.IMAGE
{
    internal class imagine
    {


        public Image<Bgr, byte> MyImage { get => myImage; set => myImage = value; }
        public Image<Bgr, byte> FInalImage { get; set; }
        PictureBox pictureBox;
        private Image<Bgr, byte> myImage;

        public void setPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }
        public void LoadImage(string filePath)
        {
            MyImage = new Image<Bgr, byte>(filePath);
            FInalImage = MyImage.Clone();
        }
        public Image<Gray, byte> ConvertToGray()
        {
            return MyImage.Convert<Gray, byte>();
        }

        public void ShowHistogram()
        {
            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(MyImage, 255);
            v.Show();
        }

        public void ApplyGammaCorrection(double gamma)
        {
            Image<Bgr, byte> img = MyImage.Convert<Bgr, byte>();
            img._GammaCorrect(gamma);
            pictureBox.Image = img.AsBitmap();

            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(MyImage, 255);
            v.Show();
        }

        public void RotateImage(double angle)
        {
            Bgr bgr = new Bgr();
            Image<Bgr, byte> img = MyImage.Rotate(angle, bgr);
            MyImage = img;
            pictureBox.Image = img.AsBitmap();
        }

        public void AdjustBrightness(double alpha, double beta)
        {
            Image<Bgr, byte> gray_img = MyImage.Convert<Bgr, byte>();
            pictureBox.Image = gray_img.AsBitmap();
            gray_img = gray_img.Mul(alpha + beta);
            pictureBox.Image = gray_img.AsBitmap();
        }

        public Image<Bgr ,byte> ExtractColor(Bgr color)
        {
            
            return myImage.SubR(color);
        }
    }
}
