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
using Emgu.CV.CvEnum;

namespace MachineVisionFinals
{
    public partial class GeometricProperties : Form
    {
        #region Variables

        Bitmap bmp = null;
        Bitmap orig = null;
        Color pixel;
        int width, height, AreaofObject;
        int x, y;
        int left, right, top, bottom;
        Image<Bgr, byte> image;

        #endregion

        public GeometricProperties()
        {
            InitializeComponent();
        }

        //Adding an Image
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.png) | *.bmp; *.jpg; *.png";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    image = new Image<Bgr, byte>(openFileDialog.FileName);
                    pictureBox1.Image = image.ToBitmap();
                }
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

        //Thresholding class
        public void thresholding()
        {
            try
            {
                bmp = new Bitmap(pictureBox1.Image);
                orig = new Bitmap(pictureBox1.Image);
                width = bmp.Width;
                height = bmp.Height;
                int min = int.Parse(textBox1.Text);
                int max = int.Parse(textBox2.Text);
                int objArea = 0;

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        pixel = bmp.GetPixel(x, y);
                        double avg = ((pixel.R) + (pixel.G) + (pixel.B)) / 3;
                        if (avg >= min && avg <= max)
                        {
                            bmp.SetPixel(x, y, Color.Black);
                            objArea = objArea + 1;
                        }
                        else
                        {
                            bmp.SetPixel(x, y, Color.White);
                            orig.SetPixel(x, y, Color.White);
                        }
                    }
                }

                AreaofObject = objArea;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Centroid of an Image
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(pictureBox2.Image);
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
                pictureBox2.Image = bmp;

                MessageBox.Show("Values: (" + width1 + "," + height1 + ")", "Centroid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Centroid of an Object
        private void objectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(pictureBox2.Image);
                width = bmp.Width;
                height = bmp.Height;

                for (x = 0; x < width; x++)
                {
                    for (y = 0; y < height; y++)
                    {
                        pixel = bmp.GetPixel(x, y);

                        if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                            right = x;
                    }
                }

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        pixel = bmp.GetPixel(x, y);

                        if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                            bottom = y;
                    }
                }

                for (x = width; x-- > 0;)
                {
                    for (y = height; y-- > 0;)
                    {
                        pixel = bmp.GetPixel(x, y);

                        if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                            left = x;
                    }
                }

                for (y = height; y-- > 0;)
                {
                    for (x = width; x-- > 0;)
                    {
                        pixel = bmp.GetPixel(x, y);

                        if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                            top = y;
                    }
                }

                //enclosing the object with a box
                for (x = right + 1; x <= right + 2; x++)
                {
                    for (y = top; y <= bottom + 2; y++)
                        bmp.SetPixel(x, y, Color.Black);
                }

                for (y = bottom + 1; y <= bottom + 2; y++)
                {
                    for (x = left; x <= right + 2; x++)
                        bmp.SetPixel(x, y, Color.Black);
                }

                for (x = left - 2; x <= left - 1; x++)
                {
                    for (y = top - 2; y <= bottom + 2; y++)
                        bmp.SetPixel(x, y, Color.Black);
                }

                for (y = top - 2; y <= top - 1; y++)
                {
                    for (x = left - 2; x <= right + 2; x++)
                        bmp.SetPixel(x, y, Color.Black);
                }
                //end of closing the with the box

                int rad_y = (left + right) / 2;
                int rad_x = (top + bottom) / 2;

                for (x = rad_y - 1; x <= rad_y + 1; x++)
                {
                    for (y = rad_x - 4; y <= rad_x + 4; y++)
                        bmp.SetPixel(x, y, Color.Blue);
                }

                for (y = rad_x - 1; y <= rad_x + 1; y++)
                {
                    for (x = rad_y - 4; x <= rad_y + 4; x++)
                        bmp.SetPixel(x, y, Color.Blue);
                }
                pictureBox2.Image = bmp;
                MessageBox.Show("Values: (" + rad_y + "," + rad_x + ")", "Coordinates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GeometricProperties_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                    using (Bitmap bitmap = new Bitmap(pictureBox2.Image))
                    {
                         bitmap.Save(save.FileName);
                    }
                    MessageBox.Show("Image saved successfully!");
               }
          }

          //Thresholding
          private void btnThreshold_Click(object sender, EventArgs e)
        {
            thresholding();
            pictureBox2.Image = bmp;
        }

        //Details of an Image
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int imgArea = width * height;

            thresholding();

            String w = "Image width: ";
            String h = "Image height: ";

            MessageBox.Show(w + width + "pixel\n" +
                h + height + "pixel\n" +
                "Image Area: " + imgArea + "pixel\n" +
                "Object Area: " + AreaofObject + "pixel", "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Boxing all objects
        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                return;
            }

            try
            {
                var temp = image.SmoothGaussian(5).Convert<Gray, byte>().ThresholdBinaryInv(new Gray(200), new Gray(255));

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat m = new Mat();

                CvInvoke.FindContours(temp, contours, m, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                for (int i = 0; i < contours.Size; i++)
                {
                    double perimeter = CvInvoke.ArcLength(contours[i], true);
                    VectorOfPoint approx = new VectorOfPoint();

                    CvInvoke.ApproxPolyDP(contours[i], approx, 0.04 * perimeter, true);

                    Rectangle boundingrect = CvInvoke.BoundingRectangle(contours[i]);

                    image.Draw(boundingrect, new Bgr(Color.Blue), thickness: 8);
                    pictureBox1.Image = image.AsBitmap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Boxing the Image
        private void theImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap a = new Bitmap(pictureBox2.Image);
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
                pictureBox2.Image = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
