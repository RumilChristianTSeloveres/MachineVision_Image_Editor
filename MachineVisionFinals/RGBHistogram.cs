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
    public partial class RGBHistogram : Form
    {
        private Bitmap originalImage;

        public RGBHistogram()
        {
          InitializeComponent();
        }

        private void addImageToolStripMenuItem_Click(object sender, EventArgs e)
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
                ImageOrientation imageOrientation = new ImageOrientation();
                imageOrientation.Show();
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

          private Bitmap CreateHistogramImage(int[] histogram, Color graphColor)
          {
               Bitmap histogramImage = new Bitmap(256, 100);
               int maxCount = 0;

               for (int i = 0; i < 256; i++)
               {
                    if (histogram[i] > maxCount)
                         maxCount = histogram[i];
               }

               float scaleFactor = maxCount > 0 ? 100.0f / maxCount : 0;

               using (Graphics g = Graphics.FromImage(histogramImage))
               {
                    for (int i = 0; i < 256; i++)
                    {
                         int height = (int)(histogram[i] * scaleFactor);
                         Rectangle rect = new Rectangle(i, 100 - height, 1, height);
                         g.FillRectangle(new SolidBrush(graphColor), rect);
                    }
               }
               return histogramImage;
          }

          private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    if (originalImage == null)
                    {
                         MessageBox.Show("Please select an Image first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                    }

                    int[] redHistogram = new int[256];
                    int[] greenHistogram = new int[256];
                    int[] blueHistogram = new int[256];

                    //Calculate Histogram
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                         for (int x = 0; x < originalImage.Width; x++)
                         {
                              Color pixel = originalImage.GetPixel(x, y);
                              redHistogram[pixel.R]++;
                              greenHistogram[pixel.G]++;
                              blueHistogram[pixel.B]++;
                         }
                    }

                    Bitmap redHistogramImage = CreateHistogramImage(redHistogram, Color.Red);
                    pictureBox2.Image = redHistogramImage;

                    Bitmap greenHistogramImage = CreateHistogramImage(greenHistogram, Color.Green);
                    pictureBox3.Image = greenHistogramImage;

                    Bitmap blueHistogramImage = CreateHistogramImage(blueHistogram, Color.Blue);
                    pictureBox4.Image = blueHistogramImage;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

        private void RGBHistogram_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
