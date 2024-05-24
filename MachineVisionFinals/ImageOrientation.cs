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
    public partial class ImageOrientation : Form
    {
        #region Variables

        private Bitmap originalImage;
        private float angle = 0.0f;

        #endregion

        public ImageOrientation()
        {
            InitializeComponent();
        }

        //Adding Image
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
               try
               {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                         openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.png) | *.bmp; *.jpg; *.png";
                         openFileDialog.RestoreDirectory = true;

                         if (openFileDialog.ShowDialog() == DialogResult.OK)
                         {
                              originalImage = new Bitmap(openFileDialog.FileName);
                              pictureBox1.Image = originalImage;
                         }
                    }
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
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
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                int width = bmp.Width;
                int height = bmp.Height;
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

        //Rotating an Image
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float rotationAngle;

            if (!float.TryParse(textBox1.Text, out rotationAngle))
            {
                MessageBox.Show("Invalid pivot point input.");
                return;
            }

            angle += rotationAngle;
            if (angle >= 360.0f)
                angle -= 360.0f;

            pictureBox2.Image = RotateImage(originalImage, angle);
        }

        //Rotation Function
        private static Image RotateImage(Image image, float angle)
        {
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                graphics.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
                graphics.DrawImage(image, new Point(0, 0));
            }
            return rotatedImage;
        }

        //Vertical Mirroring
        private void verticalMirroringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(originalImage);
            Bitmap mirrorImg = new Bitmap(bmp.Width, bmp.Height);

            for(int y = 0; y < bmp.Height; y++)
            {
                for(int x = 0; x < bmp.Width; x++)
                {
                    mirrorImg.SetPixel(x, y, bmp.GetPixel(x, bmp.Height - y - 1));
                }
            }
            pictureBox2.Image = mirrorImg;
        }

        //Horizontal Mirroring
        private void horizontalMirroringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(originalImage);
            Bitmap mirrorImg = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    mirrorImg.SetPixel(x, y, bmp.GetPixel(bmp.Width - x - 1, y));
                }
            }
            pictureBox2.Image = mirrorImg;
        }

        //Rotation Button
        private void button1_Click(object sender, EventArgs e)
        {
            float rotationAngle;

            if (!float.TryParse(textBox1.Text, out rotationAngle))
            {
                MessageBox.Show("Invalid pivot point input.");
                return;
            }

            angle += rotationAngle;
            if (angle >= 360.0f)
                angle -= 360.0f;

            pictureBox2.Image = RotateImage(originalImage, angle);
        }

        //Translation Button
        private void translationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(originalImage == null)
            {
                return;
            }

            int x, y;
            if(!int.TryParse(textBox2.Text, out x) || !int.TryParse(textBox3.Text, out y))
            {
                MessageBox.Show("Please enter valid x and y coordinates!");
                return;
            }

            pictureBox2.Image = MoveImage(originalImage, x, y);
        }

        //MoveImage button or Translation
        private static Image MoveImage(Image image, int x, int y)
        {
            Bitmap movedImage = new Bitmap(image.Width, image.Height);
            movedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(movedImage))
            {
                graphics.TranslateTransform(x, y);
                graphics.DrawImage(image, new Point(0, 0));
            }
            return movedImage;
        }

        //Translation button
        private void button2_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                return;
            }

            int x, y;
            if (!int.TryParse(textBox2.Text, out x) || !int.TryParse(textBox3.Text, out y))
            {
                MessageBox.Show("Please enter valid x and y coordinates!");
                return;
            }

            pictureBox2.Image = MoveImage(originalImage, x, y);
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

          //RGB Histogram Class or Object
          private void rGBHistogramToolStripMenuItem_Click(object sender, EventArgs e)
          {
               Dispose();
               RGBHistogram rGBHistogram = new RGBHistogram();
               rGBHistogram.Show();
          }

          //For Projections Form
          private void projectionsToolStripMenuItem_Click(object sender, EventArgs e)
          {
               Dispose();
               Projections projection = new Projections();
               projection.Show();
          }

        private void ImageOrientation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
