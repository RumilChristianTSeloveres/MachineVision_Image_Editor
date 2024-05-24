using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineVisionFinals
{
    public partial class HomePageImageEditor : Form
    {
        public HomePageImageEditor()
        {
            InitializeComponent();
        }

        //Close
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();
                PwdFacialForm pwdFacialForm = new PwdFacialForm();
                pwdFacialForm.Show();
            }
        }

        //Grayscale Class or Grayscale Object
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Grayscale grayscale = new Grayscale();
            grayscale.Show();
        }

        //Binary Class or Binary Object
        private void binaryImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            BinaryImage binaryImage = new BinaryImage();
            binaryImage.Show();
        }

        //Segmentation Object
        private void segmentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Segmentation segmentation = new Segmentation();
            segmentation.Show();
        }

        //Thresholding Class or Thresholding Object
        private void thresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Thresholding thresholding = new Thresholding();
            thresholding.Show();
        }

        //Geometric Class or Geometric Object
        private void geometricPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            GeometricProperties geometricProperties = new GeometricProperties();
            geometricProperties.Show();
        }

        //Geometric Shape Recognition and Color Detection Class or Object
        private void geometricShapeRecognitionAndColorDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            GeometricShapeRecognitionandColorDetection geometricShapeRecognitionandColorDetection = new GeometricShapeRecognitionandColorDetection();
            geometricShapeRecognitionandColorDetection.Show();
        }

        //Image Orientation, Histogram and Binary Image Projection Class or Object
        private void imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            ImageOrientation imageOrientation = new ImageOrientation();
            imageOrientation.Show();
        }

        //Image Convolution and Convolution Matrix Class or Object
        private void imageConvolutionAndConvolutionMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            ImageConvolution imageConvolution = new ImageConvolution();
            imageConvolution.Show();
        }

        private void HomePageImageEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
