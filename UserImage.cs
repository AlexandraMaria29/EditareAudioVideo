using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Emgu.CV.UI;

namespace EditProdProj
{
    internal class UserImage
    {
        Image<Bgr, byte> MyImage;
        Image<Bgr, byte> FInalImage;
        PictureBox pictureBox1;
        public double alfa,beta;

        public void setUImage(Image<Bgr,Byte>img)
        {
            this.MyImage = img;
        }

        public void LoadImage()
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.MyImage = new Image<Bgr, byte>(OpenFileDialog.FileName);
                this.FInalImage = this.MyImage.Clone();
                pictureBox1.Image = MyImage.ToBitmap(); //tobitmap copie in mem asbitmap referinta catre obj
            }
        }
        public void GrayImage() 
        {
            for (int i = 0; i < MyImage.Width; i++)
            {
                for (int j = 0; j < MyImage.Height; j++)
                {
                    MyImage[j, i] = new Bgr(Color.FromArgb(0, 255, 255, 255));
                }
            }

            Image<Gray, byte> gray_image = this.MyImage.Convert<Gray, byte>();
            pictureBox1.Image = gray_image.AsBitmap();
            gray_image[0, 0] = new Gray(200);
        }

        public void Histograma()
        {
            HistogramViewer histograma = new HistogramViewer();
            histograma.HistogramCtrl.GenerateHistograms(this.MyImage, 255);
            histograma.Show();
        }

        public void alfaBeta(TextBox alfa,TextBox beta)
        {
            this.alfa = double.Parse(alfa.Text);
            this.beta = double.Parse(beta.Text);
            
        }
        
    }
}
