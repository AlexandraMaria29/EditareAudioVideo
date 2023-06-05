using EditProdProj.VIDEO1;
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

namespace EditProdProj
{
    public partial class Form2 : Form
    {
        public video videoInstance;
        public video videoInstance2;

        public Form2()
        {
            InitializeComponent();
            videoInstance = new video();
            videoInstance2 = new video();
        }

        private void buttonLoadVideo_Click(object sender, EventArgs e)
        {
            
                    videoInstance.LoadVideos(pictureBox1);
            videoInstance2.LoadVideos(pictureBox2);

        }

        private async void button1ProcessVideo_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCombine_Click(object sender, EventArgs e)
        {
            //videoInstance.CombineVideos();
        }
        private void UpdatePictureBox(Mat frame)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = frame.ToBitmap()));
            }
            else
            {
                pictureBox1.Image = frame.ToBitmap();
            }
        }

        private void button1PLAY_Click(object sender, EventArgs e)
        {
            videoInstance.Play();
        }

        private void button1Stop_Click(object sender, EventArgs e)
        {
            videoInstance.Stop();
        }

        private void greyScale_Click(object sender, EventArgs e)
        {
            videoInstance.GrayScale();
        }

        private void button1REDEXTRACT_Click(object sender, EventArgs e)
        {
            videoInstance.Extract(new Emgu.CV.Structure.Bgr(255,255,0));
        }

        private void button1Carusel_Click(object sender, EventArgs e)
        {
            videoInstance.Carusel();
        }

        private void button1Brightness_Click(object sender, EventArgs e)
        {

        }

        private void button1Cross_Click(object sender, EventArgs e)
        {
            videoInstance.CrossDissolveVideos(videoInstance2);
        }
    }
}
