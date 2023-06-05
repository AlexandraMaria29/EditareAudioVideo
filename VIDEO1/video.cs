using EditProdProj.IMAGE;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditProdProj.VIDEO1
{
    public partial class video : Form
    {
        public VideoCapture firstVideoCapture;
       // public VideoCapture secondVideoCapture;
        public List<Mat> firstVideoFrames;
        //public List<Mat> secondVideoFrames;
        PictureBox pictureBox12;
        double Fps;
        bool IsReadingFrame;
        int frame = 0;
        imagine imag=new imagine();



        public video()
        {
            InitializeComponent();

            firstVideoCapture = new VideoCapture();
           // secondVideoCapture = new VideoCapture();
            firstVideoFrames = new List<Mat>();
            //secondVideoFrames = new List<Mat>();

        }
      
        public void LoadVideos( PictureBox picturebox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Fps = this.firstVideoCapture.Get(CapProp.Fps);

                firstVideoCapture = new VideoCapture(ofd.FileName);
                
                this.pictureBox12 = picturebox;
                LoadVideoFrames(firstVideoCapture, firstVideoFrames);

               
                pictureBox12.Image = firstVideoFrames[0].ToBitmap();
            }
               

        }
        public void LoadVideoFrames(VideoCapture videoCapture, List<Mat> frames)
        {
            Mat frame = new Mat();
            while (videoCapture.Read(frame))
            {
                frames.Add(frame.Clone());
            }
        }
        public async Task CrossDissolveVideos(video video2)
        {
           
            int firstVideoStartFrame = firstVideoFrames.Count - 10;
           

            for (int i = 0; i < firstVideoFrames.Count; i++)
            {var img1 = firstVideoFrames[i].ToImage<Bgr,byte>();
                var img2 = video2.firstVideoFrames[i].ToImage<Bgr, byte>();

               
                if (i> firstVideoStartFrame)
                {
                    double alpha = (double)i / 10;
                    double beta = 1 - alpha;
                    CvInvoke.AddWeighted(img1, alpha, img2, beta, 0, img1);
                    
                }
                

                firstVideoFrames[i] = img1.Mat;



                await Task.Delay(1000 / (int)firstVideoCapture.Get(CapProp.Fps));
            }
        }
        /*public void CombineVideos()
        {
            int firstVideoWidth = (int)firstVideoCapture.Get(CapProp.FrameWidth);
            int firstVideoHeight = (int)firstVideoCapture.Get(CapProp.FrameHeight);
          //  int secondVideoWidth = (int)secondVideoCapture.Get(CapProp.FrameWidth);
           // int secondVideoHeight = (int)secondVideoCapture.Get(CapProp.FrameHeight);

            //int startX = firstVideoWidth - secondVideoWidth - 10;
            int startY = 10;

            Mat frame = new Mat();
            while (firstVideoCapture.Read(frame))
            {
                Mat secondVideoFrame = new Mat();
               // if (secondVideoCapture.Read(secondVideoFrame))
                {
                   
                   // CvInvoke.Resize(secondVideoFrame, secondVideoFrame, new Size(secondVideoWidth, secondVideoHeight));
                   // CvInvoke.PutText(frame, "Video in Video", new Point(startX, startY - 5), FontFace.HersheySimplex, 0.5, new MCvScalar(0, 255, 0));

                   

                    
                }
                else
                {
                    break;
                }
            }
        }*/
        public async void ReadAllFrames()
        {
            
            while ( frame < firstVideoFrames.Count && IsReadingFrame)
            {


                pictureBox12.Image = firstVideoFrames[frame].ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(Fps));
                frame++;
            }

        }

        private void buttonLoadVideo_Click(object sender, EventArgs e)
        {

        }
        public void Play()
        {
            
            
            IsReadingFrame = true;
            ReadAllFrames();

        }
        public void Stop()
        {


            IsReadingFrame = false;
            ReadAllFrames();

        }
        public void GrayScale()
        {
            for(int i = 0;i<firstVideoFrames.Count;i++)
            {
                imag.MyImage = firstVideoFrames[i].ToBitmap().ToImage<Bgr,byte>();
                var grey = imag.ConvertToGray();
                firstVideoFrames[i] = grey.Mat;
            }
            pictureBox12.Image = firstVideoFrames[0].ToBitmap();
        }
        public void Extract(Bgr color)
        {
            for (int i = 0; i < firstVideoFrames.Count; i++)
            {
                imag.MyImage = firstVideoFrames[i].ToBitmap().ToImage<Bgr, byte>();
                var red= imag.ExtractColor(color);
                firstVideoFrames[i] = red.Mat;
            }
            pictureBox12.Image = firstVideoFrames[0].ToBitmap();
        }
        public void Carusel()
        {
            for (int i = 0; i < firstVideoFrames.Count; i++)
            { if(i>=firstVideoFrames.Count)
                {
                    break;
                }
                imag.MyImage = firstVideoFrames[i].ToBitmap().ToImage<Bgr, byte>();
                var grey = imag.ConvertToGray();
                firstVideoFrames[i] = grey.Mat;
                i++;
                if (i >= firstVideoFrames.Count)
                {
                    break;
                }
                imag.MyImage = firstVideoFrames[i].ToBitmap().ToImage<Bgr, byte>();
                var red = imag.ExtractColor(new Bgr(0,0,255));
                firstVideoFrames[i] = red.Mat;
                i++;
                if (i >=firstVideoFrames.Count)
                {
                    break;
                }
                imag.MyImage = firstVideoFrames[i].ToBitmap().ToImage<Bgr, byte>();
                var blue = imag.ExtractColor(new Bgr(255, 0, 0));
                firstVideoFrames[i] = blue.Mat;
                i++;
                if (i >=firstVideoFrames.Count)
                {
                    break;
                }
                imag.MyImage = firstVideoFrames[i].ToBitmap().ToImage<Bgr, byte>();
                var green = imag.ExtractColor(new Bgr(0, 255, 0));
                firstVideoFrames[i] = green.Mat;
                i++;
                if (i >= firstVideoFrames.Count)
                {
                    break;
                }
            }
            pictureBox12.Image = firstVideoFrames[0].ToBitmap();
        }
    }
}
