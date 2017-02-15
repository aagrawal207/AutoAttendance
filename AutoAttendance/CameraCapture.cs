using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;

namespace AutoAttendance {
    public partial class CameraCapture : Form {
        //declaring global variables
        private Capture capture;        //takes images from camera as image frames
        private bool captureInProgress; // checks if capture is executing

        private HaarCascade haar;

        private void ProcessFrame(object sender, EventArgs arg) {
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame();  //line 1
            CamImageBox.Image = ImageFrame;        //line 2
        }

        public CameraCapture() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // adjust path to find your XML file 
            haar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");
        }

        private void btnStart_Click(object sender, EventArgs e) {
            #region if capture is not created, create it now
            if (capture == null) {
                try {
                    capture = new Capture();
                }
                catch (NullReferenceException excpt) {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            if (capture != null) {
                if (captureInProgress) {  
                    //if camera is getting frames then stop the capture and set button Text
                    // "Start" for resuming capture
                    btnStart.Text = "Start!"; //
                    Application.Idle -= ProcessFrame;
                }
                else {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Stop" for pausing capture
                    btnStart.Text = "Stop";
                    Application.Idle += ProcessFrame;
                }
                captureInProgress = !captureInProgress;
            }
        }
        private void ReleaseData() {
            if (capture != null)
                capture.Dispose();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            Image InputImg = Image.FromFile(@"C:\Users\Abhishek Agrawal\Pictures\pic1.jpeg");
            Image<Bgr, byte> ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
            if (ImageFrame != null)
            {
                Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
                var faces = grayframe.DetectHaarCascade(haar, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];
                foreach (var face in faces)
                {
                    ImageFrame.Draw(face.rect, new Bgr(Color.Green), 3);
                }
                CamImageBox.Image = ImageFrame;
                int TotalFaces = faces.Length;   // you can use TotalFaces from  here on, i'll only display it:

                MessageBox.Show("Total faces detected: " + TotalFaces.ToString());
            }
        }
    }
}
