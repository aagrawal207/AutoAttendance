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
using System.IO;

namespace AutoAttendance {
    public partial class CameraCapture : Form {
        //declaring global variables
        private Capture capture;        //takes images from camera as image frames
        private bool captureInProgress; // checks if capture is executing

        private HaarCascade haar;

        private float scale_speed = (float)1.2;
        private int min_neighbor = 3;
        private int scale_size = 24;

        private void ProcessFrame(object sender, EventArgs arg) {
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame();  //line 1
            if (ImageFrame != null) {
                Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
                scale_speed = float.Parse(scaleSpeed.Text);
                min_neighbor = int.Parse(minNeighbor.Text);
                try {
                    scale_size = int.Parse(scaleSize.Text);
                }
                catch (FormatException) {
                    scale_size = 25;
                }
                var faces = grayframe.DetectHaarCascade(haar,
                                                        scale_speed,
                                                        min_neighbor,
                                                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                                        new Size(scale_size, scale_size))[0];
                foreach (var face in faces) {
                    ImageFrame.Draw(face.rect, new Bgr(Color.Green), 3);
                }
                int TotalFaces = faces.Length;
                Total_faces.Text = "Total Face detected : " + TotalFaces;
            }
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
                    btnStart.Text = "Resume"; //
                    Application.Idle -= ProcessFrame;
                }
                else {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Stop" for pausing capture
                    btnStart.Text = "Pause";
                    Application.Idle += ProcessFrame;
                }
                captureInProgress = !captureInProgress;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e) {
            int size = -1;
            var browse = new System.Windows.Forms.OpenFileDialog();
            DialogResult result = browse.ShowDialog(); // Show the dialog.
            string file = "";
            string text = "";
            if (result == DialogResult.OK) {
                file = browse.FileName;
                try {
                    text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                    file = ".\\..\\..\\..\\pic1.jpeg";
                }
            }
            // MessageBox.Show(file);
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
            Image InputImg = Image.FromFile(@file);
            Image<Bgr, byte> ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
            if (ImageFrame != null) {
                Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
                scale_speed = float.Parse(scaleSpeed.Text);
                min_neighbor = int.Parse(minNeighbor.Text);
                try {
                    scale_size = int.Parse(scaleSize.Text);
                }
                catch (FormatException) {
                    scale_size = 25;
                }
                var faces = grayframe.DetectHaarCascade(haar, 
                                                        scale_speed, 
                                                        min_neighbor, 
                                                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, 
                                                        new Size(scale_size, scale_size))[0];
                foreach (var face in faces) {
                    ImageFrame.Draw(face.rect, new Bgr(Color.Green), 3);
                }
                int TotalFaces = faces.Length;
                Total_faces.Text = "Total Face detected : " + TotalFaces;
                CamImageBox.Image = ImageFrame;
            }
        }
        private void ReleaseData() {
            if (capture != null)
                capture.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void xmlFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}