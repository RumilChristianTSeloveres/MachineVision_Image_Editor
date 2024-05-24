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
    public partial class Thresholding : Form
    {
        #region Variables

        Bitmap bmp = null;
        Bitmap orig = null;
        Color pixel;
        int width, height, AreaofObject;
        int x, y;
        int left, right, top, bottom;

        #endregion
        public Thresholding()
        {
            InitializeComponent();
        }

        //Adding an Image
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("ALL files(*.*)|*.*");
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                Bitmap bmp = new Bitmap(ofd.FileName);
                pictureBox1.Image = new Bitmap(bmp);
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

        private void Thresholding_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        //Center of an Image
        private void centerOfImageToolStripMenuItem_Click(object sender, EventArgs e)
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

        //Threshold(T) button
        private void btnThres_Click(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(pictureBox1.Image);
                width = bmp.Width;
                height = bmp.Height;
                int threshold = int.Parse(textBox1.Text);
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        int avg = (int)((pixel.R) + (pixel.G) + (pixel.B)) / 3;
                        if (avg > threshold)
                        {
                            bmp.SetPixel(x, y, Color.White);
                        }
                        else
                        {
                            bmp.SetPixel(x, y, Color.Black);
                        }
                    }
                }
                pictureBox2.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        //Threshold(T1 and T2) button
        private void btnThreshold_Click(object sender, EventArgs e)
        {
            thresholding();
            pictureBox2.Image = bmp;
        }

        private void centerOfObjectToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
