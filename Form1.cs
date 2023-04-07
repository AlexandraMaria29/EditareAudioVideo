using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.DepthAI;
using Emgu.CV.Structure;
using Emgu.CV.UI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EditProdProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image<Bgr, byte> MyImage;
        Image<Bgr, byte> FInalImage;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                MyImage = new Image<Bgr, byte>(OpenFileDialog.FileName);
                FInalImage = MyImage.Clone();
                pictureBox1.Image = MyImage.ToBitmap(); //tobitmap copie in mem asbitmap referinta catre obj
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HistogramViewer v=new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(MyImage, 255);
            v.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> gray_img = MyImage.Convert<Gray, byte>();
            pictureBox2.Image = gray_img.AsBitmap();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> gray_img = MyImage.Convert<Bgr, byte>();
            pictureBox2.Image = gray_img.AsBitmap();
            string alpha = textBox1.Text;
            string beta=textBox2.Text;
            gray_img = gray_img.Mul(Double.Parse(alpha)+Double.Parse(beta));
            pictureBox2.Image= gray_img.AsBitmap() ;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            double gamma = 0.4;
            Image<Bgr, byte> img = MyImage.Convert<Bgr, byte>();
            img._GammaCorrect(gamma);
            pictureBox2.Image = img.AsBitmap();

            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(MyImage, 255);
            v.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Image<Bgr, byte> img = MyImage.Convert<Bgr, byte>();

            //MyImage.Resize(0.50,Emgu.CV.CvEnum.Inter.Cubic);
            // Image<Bgr, byte> img = MyImage.Convert<Bgr, byte>();
            Image<Bgr, byte> img = MyImage.Resize(0.25, Emgu.CV.CvEnum.Inter.Cubic);
            //  MyImage.Resize(0.50,Emgu.CV.CvEnum.Inter.Cubic);
            pictureBox2.Image = img.AsBitmap();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // MyImage.Rotate()
            Bgr bgr = new Bgr();
            Image<Bgr, byte> img = MyImage.Rotate(45.0, bgr);
            pictureBox2.Image = img.AsBitmap();
            //comentariu

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }
       
        
        
        
        
        
        
        Rectangle rect; Point StartROI; bool MouseDown;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                return;
            }

            int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
            int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
            rect = new Rectangle(Math.Min(StartROI.X, e.X),
                Math.Min(StartROI.Y, e.Y),
                width,
                height);
            Refresh();

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
            if (pictureBox1.Image == null || rect == Rectangle.Empty)
            { return; }

            var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
            img.ROI = rect;
            var imgROI = img.Copy();
            FInalImage = img.Copy();

            pictureBox2.Image = imgROI.ToBitmap();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }


}
