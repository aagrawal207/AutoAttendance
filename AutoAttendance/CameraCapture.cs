using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Reflection;
using System.IO;

namespace AutoAttendance
{
    public partial class CameraCapture : Form
    {
        //declaring global variables
        private Capture capture;        // takes images from camera as image frames
        private bool captureInProgress; // checks if capture is executing
        private HaarCascade haar;       // contains haar cascade file
        private float scale_speed = (float)1.2; // default scale, getting through input
        private int no_times_executed = 0; // used for folder name generation
        private int min_neighbor = 3;   // default accuracy, getting through input   
        private int scale_size = 24;    // default windw size, getting through input
        private int TotalFaces = 0;     // counting number of faces
        Bitmap[] extracted_faces;       // global array which holds extracted faces
        private int face_num = 0;       // used for image name generation

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //getting image from live feed
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame();
            if (ImageFrame != null)
            {
                //converting to grayscale
                Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();

                //getting input parameters
                scale_speed = float.Parse(scaleSpeed.Text);
                min_neighbor = int.Parse(minNeighbor.Text);
                try {
                    scale_size = int.Parse(scaleSize.Text);
                }
                catch (FormatException) {
                    scale_size = 25;
                }

                //running haar cascade detector
                var faces = grayframe.DetectHaarCascade(haar, scale_speed, min_neighbor,
                                                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                                        new Size(scale_size, scale_size))[0];


                foreach (var face in faces)
                {
                    ImageFrame.Draw(face.rect, new Bgr(Color.Green), 3);
                }
                TotalFaces = faces.Length;
                Total_faces.Text = "Total Face detected : " + TotalFaces;
            }
            CamImageBox.Image = ImageFrame;
        }

        public CameraCapture() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // loading xml files
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
                catch (IOException){
                    //MessageBox.Show("Hello");
                    file = ".\\..\\..\\..\\pic1.jpeg";
                }
            }
            //MessageBox.Show(file);
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
            Image InputImg = Image.FromFile(file);
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
                TotalFaces = faces.Length;
                Total_faces.Text = "Total Face detected : " + TotalFaces;
                extracted_faces = new Bitmap[TotalFaces];
                face_num = 0;
                if (TotalFaces > 0) {
                    Bitmap bmp_input = grayframe.ToBitmap();
                    Bitmap extracted_face;
                    Graphics face_canvas;

                    //creating folder for stroing images
                    string folderString = createFolder.createfolder(no_times_executed++);

                    foreach (var face in faces) {
                        ImageFrame.Draw(face.rect, new Bgr(Color.Green), 3);
                        extracted_face = new Bitmap(face.rect.Width, face.rect.Height);
                        face_canvas = Graphics.FromImage(extracted_face);
                        face_canvas.DrawImage(bmp_input, 0, 0, face.rect, GraphicsUnit.Pixel);
                        extracted_faces[face_num] = extracted_face;
                        

                        //storing image
                        string imagePath = System.IO.Path.Combine(folderString, face_num.ToString() + ".bmp");
                        extracted_faces[face_num].Save(imagePath);

                        face_num++;
                    }
                    extractedFace.Image = extracted_faces[0];
                    CamImageBox.Image = ImageFrame;
                    btnNext.Enabled = true;
                    btnPrev.Enabled = true;
                }
                else {
                    MessageBox.Show("No face detected.");
                    CamImageBox.Image = ImageFrame;
                }
            }
        }
        private void ReleaseData() {
            if (capture != null)
                capture.Dispose();
        }

        private void button2_Click(object sender, EventArgs e) {
            face_num++;
            if(face_num < TotalFaces)
                extractedFace.Image = extracted_faces[face_num];
            else {
                face_num = 0;
                extractedFace.Image = extracted_faces[face_num];
            }
        }

        private void btnPrev_Click(object sender, EventArgs e) {
            face_num--;
            if(face_num >= 0)
                extractedFace.Image = extracted_faces[face_num];
            else {
                face_num = TotalFaces - 1;
                extractedFace.Image = extracted_faces[face_num];
            }
        }
    }


    public class createFolder
    {
        public static string createfolder(int folderNum)
        {
            //getting current execution directory
            string currentFolder = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            //naming subfolder
            string subFolder = "Folder" + folderNum.ToString();

            //generating path for new folder
            string pathString = System.IO.Path.Combine(currentFolder, subFolder);

            System.IO.Directory.CreateDirectory(pathString);
            if (Directory.Exists(pathString))
            {
                return pathString;
            }
            else
            {
                return null;
            }
        }
    }
}