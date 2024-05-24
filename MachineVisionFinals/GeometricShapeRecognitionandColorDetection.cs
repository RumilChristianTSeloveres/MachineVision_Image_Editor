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
using Emgu.CV.Util;

namespace MachineVisionFinals
{
    public partial class GeometricShapeRecognitionandColorDetection : Form
    {
        #region Variables

        Image<Bgr, byte> imgInput;
        Bitmap bmp = null;
        int width, height;

        #endregion

        public GeometricShapeRecognitionandColorDetection()
        {
            InitializeComponent();
        }

        //Adding an Image
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = imgInput.ToBitmap();
            }
        }

        //Close
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();
                HomePageImageEditor homePageImageEditor = new HomePageImageEditor();
                homePageImageEditor.Show();
            }
        }

        //Boxing an Image
        private void boxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap a = new Bitmap(pictureBox1.Image);
                int b = a.Width;
                int c = a.Height;
                Bitmap result = new Bitmap(b, c);
                for (int x = 0; x < b; x++)
                {
                    for (int y = 0; y < c; y++)
                    {
                        result.SetPixel(x, y, a.GetPixel(x, y));

                        if (x <= 3 || x >= (b - 3))
                        {
                            result.SetPixel(x, y, Color.DarkRed);
                        }
                        else if (y <= 3 || y >= (c - 3))
                        {
                            result.SetPixel(x, y, Color.DarkRed);
                        }
                    }
                }
                pictureBox1.Image = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Center of Image
        private void centerOfImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(pictureBox1.Image);
                width = bmp.Width;
                height = bmp.Height;
                int width1 = width / 2;
                int height1 = height / 2;

                for (int x = width1 - 10; x <= width1 + 10; x++)
                {
                    for (int y = height1 - 1; y <= height1 + 1; y++)
                        bmp.SetPixel(x, y, Color.Red);
                }

                for (int y = height1 - 10; y <= height1 + 10; y++)
                {
                    for (int x = width1 - 1; x <= width1 + 1; x++)
                        bmp.SetPixel(x, y, Color.Red);
                }
                pictureBox1.Image = bmp;

                MessageBox.Show("Values: (" + width1 + "," + height1 + ")", "Centroid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Color Detection
        private void btnColorDetection_Click(object sender, EventArgs e)
        {
            try
            {
                String input = textBox3.Text;

                if (pictureBox1.Image == null) return;

                if (input.Equals("Red") || input.Equals("red"))
                {
                    var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                    img.SmoothGaussian(5);

                    Bgr lower = new Bgr(0, 0, 150);
                    Bgr higher = new Bgr(50, 50, 255);

                    var mask = img.InRange(lower, higher).Not();
                    img.SetValue(new Bgr(0, 0, 0), mask);
                    pictureBox1.Image = img.ToBitmap();
                }

                else if (input.Equals("Green") || input.Equals("green"))
                {
                    var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                    img.SmoothGaussian(5);

                    Bgr lower = new Bgr(0, 100, 0);
                    Bgr higher = new Bgr(100, 255, 50);

                    var mask = img.InRange(lower, higher).Not();
                    img.SetValue(new Bgr(0, 0, 0), mask);
                    pictureBox1.Image = img.ToBitmap();
                }

                else if (input.Equals("Blue") || input.Equals("blue"))
                {
                    var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                    img.SmoothGaussian(5);

                    Bgr lower = new Bgr(50, 0, 0);
                    Bgr higher = new Bgr(255, 50, 100);

                    var mask = img.InRange(lower, higher).Not();
                    img.SetValue(new Bgr(0, 0, 0), mask);
                    pictureBox1.Image = img.ToBitmap();
                }

                else if (input.Equals("Yellow") || input.Equals("yellow"))
                {
                    var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                    img.SmoothGaussian(5);

                    Bgr lower = new Bgr(0, 100, 150);
                    Bgr higher = new Bgr(50, 255, 255);

                    var mask = img.InRange(lower, higher).Not();
                    img.SetValue(new Bgr(0, 0, 0), mask);
                    pictureBox1.Image = img.ToBitmap();
                }

                else
                {
                    MessageBox.Show("Please input what color to detect!y");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

          //Clear an Image
          private void clearImageToolStripMenuItem_Click(object sender, EventArgs e)
          {
               if (pictureBox1.Image == null)
               {
                    MessageBox.Show("There's no image to clear ;-;", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else
               {
                    if (MessageBox.Show("Are you sure you want to remove the selected image?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                         pictureBox1.Image = null;
                    else
                         return;
               }
          }

          //Save an Image
          private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
          {
               SaveFileDialog save = new SaveFileDialog();
               save.Filter = ("jpeg|*.jpg|png|*.png|gif|*.gif|bmp|*.bmp|ALL files(*.*)|*.*");
               if (save.ShowDialog() == DialogResult.OK)
               {
                    using (Bitmap bitmap = new Bitmap(pictureBox1.Image))
                    {
                         bitmap.Save(save.FileName);
                    }
                    MessageBox.Show("Image saved successfully!");
               }
          }

        private void GeometricShapeRecognitionandColorDetection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Geometric Shape Recognition
        private void btnGeometricShape_Click(object sender, EventArgs e)
        {
            if (imgInput == null)
            {
                return;
            }

            try
            {
                int triangle = 0;
                int square = 0;
                int rectangle = 0;
                int circle = 0;
                int pentagon = 0;
                int hexagon = 0;
                int diamond = 0;

                var temp = imgInput.SmoothGaussian(5).Convert<Gray, byte>().ThresholdBinaryInv(new Gray(230), new Gray(255));

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat m = new Mat();

                CvInvoke.FindContours(temp, contours, m, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                for (int i = 0; i < contours.Size; i++)
                {
                    double perimeter = CvInvoke.ArcLength(contours[i], true);
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contours[i], approx, 0.04 * perimeter, true);

                    CvInvoke.DrawContours(imgInput, contours, i, new MCvScalar(0, 0, 255), 2);

                    var moments = CvInvoke.Moments(contours[i]);
                    int x = (int)(moments.M10 / moments.M00);
                    int y = (int)(moments.M01 / moments.M00);

                    if (approx.Size == 3)
                        triangle = triangle + 1; //or triangle++

                    if (approx.Size == 4)
                    {
                        Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                        
                        double ar = (double)rect.Width / rect.Height;

                        if (Math.Abs(ar - 1) < 0.1)
                            square = square + 1;
                        if (Math.Abs(ar - 2) < 0.2)
                            rectangle = rectangle + 1;
                        else
                            diamond++;
                    }

                    if (approx.Size == 5)
                        pentagon = pentagon + 1;

                    if (approx.Size == 6)
                        hexagon = hexagon + 1;

                    if (approx.Size > 6)
                        circle = circle + 1;

                    textBox2.Text = "Square: " + square + "\n" +
                        "Rectangle: " + rectangle + "\n" +
                        "Triangle: " + triangle + "\n" +
                        "Circle: " + circle + "\n";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
