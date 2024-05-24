using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MachineVisionFinals
{
    public partial class FacialRecognitionForm : Form
    {
        #region Variables

        private VideoCapture capture;
        private CascadeClassifier faceCascade;
        private Image<Bgr, byte> currentFrame;
        private string registeredFacesFolder;
        private List<Image<Gray, byte>> registeredImages;
        private int currentRegisteredIndex;
        private System.Timers.Timer slideshowTimer;

        #endregion

        public FacialRecognitionForm()
        {
            InitializeComponent();

            string faceCascadePath = "haarcascade_frontalface_alt.xml";
            faceCascade = new CascadeClassifier(faceCascadePath);

            registeredImages = new List<Image<Gray, byte>>();
            currentRegisteredIndex = 0;
            slideshowTimer = new System.Timers.Timer(500); // Adjust the interval (in milliseconds) for slideshow transition
            slideshowTimer.Elapsed += SlideshowTimer_Elapsed;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();
                PwdFacialForm pwdFacialForm = new PwdFacialForm();
                pwdFacialForm.Show();
            }
        }
       
        private void FacialRecognitionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Open camera and start capturing frames
            capture = new VideoCapture();
            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();

            LoadRegisteredFaces();
            StartSlideshow();
        }

        private void LoadRegisteredFaces()
        {
            string registeredFacesFolder = @"C:\Users\rumil\OneDrive\Documents\Seloveres_MachineVisionFinals\MachineVisionFinals\MachineVisionFinals\bin\Debug\TrainedFaces";

            if (!Directory.Exists(registeredFacesFolder))
            {
                MessageBox.Show("Registered faces folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            registeredImages.Clear();
            pictureBox1.Image = null;

            string[] imageFiles = Directory.GetFiles(registeredFacesFolder, "*.bmp"); // Adjust the file extension if necessary

            if (imageFiles.Length == 0)
            {
                MessageBox.Show("No registered faces found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string file in imageFiles)
            {
                Image<Gray, byte> registeredImage = new Image<Gray, byte>(file);
                registeredImages.Add(registeredImage);
            }

            // Display the first registered face in pictureBox2
            pictureBox1.Image = registeredImages[0].ToBitmap();
        }

        private void StartSlideshow()
        {
            currentRegisteredIndex = 0;
            slideshowTimer.Start();
        }

        private void StopSlideshow()
        {
            slideshowTimer.Stop();
        }

        private void SlideshowTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            currentRegisteredIndex++;
            if (currentRegisteredIndex >= registeredImages.Count)
            {
                currentRegisteredIndex = 0;
            }

            pictureBox1.Image = registeredImages[currentRegisteredIndex].ToBitmap();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            capture.Retrieve(frame);
            currentFrame = frame.ToImage<Bgr, byte>();

            if (currentFrame != null)
            {
                Image<Bgr, byte> imageFrame = currentFrame.Clone();

                // Perform face detection on the current frame
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                // Draw rectangles around the detected faces
                DrawFaceRectangles(imageFrame, faces);

                picCapture.Image = imageFrame.ToBitmap();

                // Recognize the face if there are registered images
                if (registeredImages.Count > 0)
                {
                    var grayFrameCopy = grayFrame.Clone();

                    foreach (var face in faces)
                    {
                        // Resize the detected face region to match the size of registered faces
                        var resizedFace = grayFrameCopy.GetSubRect(face).Resize(100, 100, Inter.Cubic);

                        // Compare the detected face with registered faces
                        bool isFaceRecognized = registeredImages.Any(registeredImage => IsMatch(resizedFace, registeredImage));

                        if (faces.Length > 0)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                Dispose();
                                capture.Dispose();
                                Application.Idle -= Capture_ImageGrabbed;
                                HomePageImageEditor homePageImageEditor = new HomePageImageEditor();
                                homePageImageEditor.Show();
                            });
                        }
                    }
                }
            }
        }

        private bool IsMatch(Image<Gray, byte> face, Image<Gray, byte> registeredFace)
        {
            using (Mat faceMat = face.Mat)
            using (Mat registeredFaceMat = registeredFace.Mat)
            {
                Mat result = new Mat();
                CvInvoke.MatchTemplate(faceMat, registeredFaceMat, result, TemplateMatchingType.CcoeffNormed);
                result.MinMax(out double[] minValues, out double[] maxValues, out Point[] minLocations, out Point[] maxLocations);

                // Check if the maximum similarity score exceeds a threshold
                double similarityThreshold = 0.8; // Adjust this threshold as per your requirement
                if (maxValues[0] >= similarityThreshold)
                    return true;
                else
                    return false;
            }
        }

        private void DrawFaceRectangles(Image<Bgr, byte> image, Rectangle[] faces)
        {

            foreach (Rectangle face in faces)
            {
                image.Draw(face, new Bgr(Color.Red), 2);
            }
        }
    }
}