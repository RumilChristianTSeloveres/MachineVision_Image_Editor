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
    public partial class BinaryImage : Form
    {
        #region Variables

        Bitmap bmp = null;
        int width, height;

        #endregion

        public BinaryImage()
        {
            InitializeComponent();
        }

        //Add Image
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

        //close
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

        //Details of an Image
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int imgArea = width * height;
            String w = "Image width: ";
            String h = "Image height: ";

            MessageBox.Show(w + width + "pixel\n" +
                h + height + "pixel\n" +
                "Image Area: " + imgArea + "pixel", "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

          //Clear an Image
          private void clearToolStripMenuItem_Click(object sender, EventArgs e)
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
          private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void BinaryImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Conversion to Black and White
        private void btnBlackandWhite_Click_1(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(pictureBox1.Image);
                width = bmp.Width;
                height = bmp.Height;

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Color pixel = bmp.GetPixel(x, y);

                        int grayscale = (pixel.R + pixel.G + pixel.B) / 3;
                        if (grayscale < 180)
                            bmp.SetPixel(x, y, Color.Black);
                        else
                            bmp.SetPixel(x, y, Color.White);
                    }
                }
                pictureBox2.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
