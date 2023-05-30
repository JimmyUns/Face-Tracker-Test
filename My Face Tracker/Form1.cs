using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;


namespace My_Face_Tracker
{
    public partial class Form1 : Form
    {
        bool facetrackingEnabled = false;

        Capture vidCapture = null;
        Mat frame = null;
        private Image<Bgr, Byte> currentFrame = null;

        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");

        PersonInCamera[] personInCamera = new PersonInCamera[0];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCamStart_Click(object sender, EventArgs e)
        {
            vidCapture = new Capture();
            vidCapture.Start();
            Application.Idle += CameraManager;
        }

        private void CameraManager(object sender, EventArgs e)
        {
            try
            {
                //Display Camera
                frame = vidCapture.QueryFrame();
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCamOutput.Width, picCamOutput.Height, Inter.Cubic);

                //Mirror on y axis currentFrame
                Bitmap currentFrameMirrored = currentFrame.ToBitmap();
                currentFrameMirrored.RotateFlip(RotateFlipType.Rotate180FlipY);
                currentFrame = new Image<Bgr, byte>(currentFrameMirrored);

                picCamOutput.Image = currentFrame.Bitmap;

                //Face Detection
                if (facetrackingEnabled)
                {
                    Mat grayMat = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayMat, ColorConversion.Bgr2Gray);
                    CvInvoke.EqualizeHist(grayMat, grayMat);

                    Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayMat, 1.1, 3, Size.Empty, Size.Empty);

                    if (faces.Length > 0)
                    {
                        personInCamera = new PersonInCamera[faces.Length];
                        for (int i = 0; i < personInCamera.Length; i++)
                        {
                            personInCamera[i] = new PersonInCamera();
                            personInCamera[i].name = "None";
                            personInCamera[i].posVector2[0] = faces[i].Location.X;
                            personInCamera[i].posVector2[1] = faces[i].Location.Y;
                            personInCamera[i].sizeVector2[0] = faces[i].Size.Width;
                            personInCamera[i].sizeVector2[1] = faces[i].Size.Height;
                        }
                        Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                        resultImage.ROI = faces[0];
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = resultImage.Bitmap;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                StopCamera();
            }

        }

        private void btnCamStop_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

        private void StopCamera()
        {
            Application.Idle -= CameraManager;
            vidCapture.Dispose();
            picCamOutput.Image = null;

            if(facetrackingEnabled) btnFaceTracking_Click(null, null);
        }

        private void btnFaceTracking_Click(object sender, EventArgs e)
        {
            if(facetrackingEnabled)
            {
                btnFaceTracking.Text = "Start Face Tracking";
            } else
            {
                btnFaceTracking.Text = "Stop Face Tracking";
            }
            facetrackingEnabled = !facetrackingEnabled;
        }

        private void picCamOutput_Paint(object sender, PaintEventArgs e)
        {
            if (!facetrackingEnabled) return;
            if(personInCamera.Length > 0)
            {
                for (int i = 0; i < personInCamera.Length; i++)
                {
                    int[] posVector2 = personInCamera[i].posVector2;
                    int[] sizeVector2 = personInCamera[i].sizeVector2;

                    Rectangle rectArea = new Rectangle(posVector2[0], posVector2[1], sizeVector2[0], sizeVector2[1]);


                    using (Pen pen = new Pen(Color.Red, 2))
                    {
                        e.Graphics.DrawRectangle(pen, rectArea);
                    }

                    using (Font myFont = new Font("Arial", 14))
                    {
                        e.Graphics.DrawString(personInCamera[i].name, myFont, Brushes.Green, new Point(posVector2[0], posVector2[1]));
                    }
                }
            }

        }
    }

    class PersonInCamera
    {
        public string name = "None";
        public int[] posVector2 = new int[2];
        public int[] sizeVector2 = new int[2];
    }
}
