using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.DepthAI;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        int TotalFrame, FrameNo;
        double Fps;
        bool IsReadingFrame;
        VideoCapture capture;
        private static VideoCapture cameraCapture;
        private Image<Bgr, Byte> newBackgroundImage=new Image<Bgr, byte>(@"C:\Users\radaa\Documents\FACULTATE3\Capture.PNG");
        private static IBackgroundSubtractor fgDetector;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;




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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ButonVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new VideoCapture(ofd.FileName);
                Mat m = new Mat();
                capture.Read(m);
                Video.Image = m.ToBitmap();

                TotalFrame = (int)capture.Get(CapProp.FrameCount);
                Fps = capture.Get(CapProp.Fps);
                FrameNo = 1;
                numericUpDown1.Value = FrameNo;
                numericUpDown1.Minimum = 0;
                numericUpDown1.Maximum = TotalFrame;

            }
            if (capture == null)
            {
                return;
            }
            IsReadingFrame = true;
            ReadAllFrames();



            




        }
        private async void ProcessFrames(object sender, EventArgs e)
        {
            Mat frame = cameraCapture.QueryFrame();
            Image<Bgr, byte> frameImage = frame.ToImage<Bgr, Byte>();

            Mat foregroundMask = new Mat();
            fgDetector.Apply(frame, foregroundMask);
            var foregroundMaskImage = foregroundMask.ToImage<Gray, Byte>();
            foregroundMaskImage = foregroundMaskImage.Not();

            var copyOfNewBackgroundImage = newBackgroundImage.Resize(foregroundMaskImage.Width, foregroundMaskImage.Height, Inter.Lanczos4);
            copyOfNewBackgroundImage = copyOfNewBackgroundImage.Copy(foregroundMaskImage);

            foregroundMaskImage = foregroundMaskImage.Not();
            frameImage = frameImage.Copy(foregroundMaskImage);
            frameImage = frameImage.Or(copyOfNewBackgroundImage);

            Background.Image = frameImage.ToBitmap();

           

        }
        private async void ReadAllFrames()
        {

            Mat m = new Mat();
            while (IsReadingFrame == true && FrameNo < TotalFrame)
            {
                FrameNo += 1;
                var mat = capture.QueryFrame();
                Video.Image = mat.ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(Fps));
                label1.Text = FrameNo.ToString() + "/" + TotalFrame.ToString();
            }
        }

        private void Video_Click(object sender, EventArgs e)
        {

        }

        private void Background_Click(object sender, EventArgs e)
        {
            

        }

        private void Background_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                cameraCapture = new VideoCapture();
                fgDetector = new BackgroundSubtractorMOG2();
                System.Windows.Forms.Application.Idle += ProcessFrames;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
             string[] FileNames = Directory.GetFiles(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\foldercuPozePtBlending", "*.png");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    Background.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);

                }
            }
        }

        private void WritingToVideo_Click(object sender, EventArgs e)
        {
            VideoCapture capture = new VideoCapture(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\First Video Star Wars Reflections 4K Unreal Engine Real-Time Ray Tracing Demonstration (360).mp4");

            int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
            var Fps = capture.Get(CapProp.Fps);
            var TotalFrame = capture.Get(CapProp.FrameCount);

            Image<Bgr, byte> logo = new Image<Bgr, byte>(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\Black1.png");
            string destinationpath = @"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\PathToOutput.mp4";
            using (VideoWriter writer = new VideoWriter(destinationpath, Fourcc, Fps, new Size(Width, Height), true))
            {

                Mat m = new Mat();

                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(10, 10, logo.Width, logo.Height);
                    logo.CopyTo(img);

                    img.ROI = Rectangle.Empty;

                    writer.Write(img.Mat);
                    FrameNo++;
                }
            }



        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void buttonAudio_Click(object sender, EventArgs e)
        {
            
            
                
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += buttonAudio_Click;
            }
            if (audioFile == null)
            {

                audioFile = new AudioFileReader(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\Stuff (mp3cut.net).mp3");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();




        }

        private void buttonConversie_Click(object sender, EventArgs e)
        { string infile = @"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\Stuff (mp3cut.net).mp3";
            string outfile = @"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\ceva.wav";
            
            using (var reader = new Mp3FileReader(infile))
            {
              WaveFileWriter.CreateWaveFile(outfile, reader);
            }
            using (var reader = new MediaFoundationReader(infile))
            {
                WaveFileWriter.CreateWaveFile(outfile, reader);
            }


        }

        private void buttonMix_Click(object sender, EventArgs e)
        {
            using (var reader1 = new AudioFileReader(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\85_F_DreamStateArp_732.wav"))
            using (var reader2 = new AudioFileReader(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\100_D_DreamWoodblock_01_732.wav"))
            {
                var mixer = new MixingSampleProvider(new[] { reader1, reader2 });
                WaveFileWriter.CreateWaveFile16(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\mixed.wav", mixer);
                reader1.Volume = 0.75f;
                reader2.Volume = 0.75f;
            }

            


        }

        private void buttonMonoStereo_Click(object sender, EventArgs e)
        {
            var monoFilePath = @"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\85_F_DreamStateArp_732.wav";
            var outputFilePath = @"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\output.wav";
            using (var inputReader = new AudioFileReader(monoFilePath))
            {
                

                var mono = new StereoToMonoSampleProvider(inputReader);

                mono.LeftVolume = 0.0f; // silence in left channel
                mono.RightVolume = 1.0f; // full volume in right channel

                WaveFileWriter.CreateWaveFile16(outputFilePath, mono);
            }
           

        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            var first = new AudioFileReader(@"C:\\Users\\radaa\\Documents\\FACULTATE3\\FacultaSem2\\LabEditareVideoAudio\\FolderAudio\\85_F_DreamStateArp_732.wav");
            var second = new AudioFileReader(@"C:\\Users\\radaa\\Documents\\FACULTATE3\\FacultaSem2\\LabEditareVideoAudio\\FolderAudio\\100_D_DreamWoodblock_01_732.wav");
            var third = new AudioFileReader(@"C:\Users\radaa\Documents\FACULTATE3\FacultaSem2\LabEditareVideoAudio\FolderAudio\120_F_StringChordReverse_732.wav");

            var playlist = new ConcatenatingSampleProvider(new[] { first, second, third });
            WaveFileWriter.CreateWaveFile16(@"C:\\Users\\radaa\\Documents\\FACULTATE3\\FacultaSem2\\LabEditareVideoAudio\\FolderAudio\\playlist.wav", playlist);



        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }


}
