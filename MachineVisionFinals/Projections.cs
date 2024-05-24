using Emgu.CV.Structure;
using Emgu.CV;
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
     public partial class Projections : Form
     {
        #region Variables

        private Image<Bgr, byte> originalImage;
        private Image<Gray, byte> binaryImage;

        int[] horizontalProjection;
        int[] verticalProjection;

        #endregion

        public Projections()
        {
            InitializeComponent();
        }

          //Adding an Image
          private void addImageToolStripMenuItem1_Click(object sender, EventArgs e)
          {
               try
               {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                         openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.png) | *.bmp; *.jpg; *.png";
                         openFileDialog.RestoreDirectory = true;

                         if (openFileDialog.ShowDialog() == DialogResult.OK)
                         {
                        originalImage = new Image<Bgr, byte>(openFileDialog.FileName);
                              pictureBox1.Image = originalImage.ToBitmap();
                         }
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
                    using (Bitmap bitmap = new Bitmap(pictureBox2.Image))
                    {
                         bitmap.Save(save.FileName);
                    }
                    MessageBox.Show("Image saved successfully!");
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

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binaryImage = originalImage.Convert<Gray, byte>().ThresholdBinary(new Gray(190), new Gray(255));
            pictureBox2.Image = binaryImage.AsBitmap();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binaryImage = originalImage.Convert<Gray, byte>().ThresholdBinary(new Gray(190), new Gray(255));

            horizontalProjection = CalculateHorizontalProjection(binaryImage);
            DrawProjectionGraph(horizontalProjection, pictureBox2);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binaryImage = originalImage.Convert<Gray, byte>().ThresholdBinary(new Gray(190), new Gray(255));

            verticalProjection = CalculateVerticalProjection(binaryImage);
            DrawProjectionGraph(verticalProjection, pictureBox2);
        }


        private int[] CalculateHorizontalProjection(Image<Gray, byte> image)
        {
            int[] projection = new int[image.Height];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (image.Data[y, x, 0] == 255)
                    {
                        projection[y]++;
                    }
                }
            }

            return projection;
        }

        private int[] CalculateVerticalProjection(Image<Gray, byte> image)
        {
            int[] projection = new int[image.Width];

            for (int x = 0; x < image.Width; x++)
            {
                int binSize = 10; // Adjust the bin size as per your requirement
                int numBins = (int)Math.Ceiling((double)image.Height / binSize);
                int[] binCounts = new int[numBins];

                for (int y = 0; y < image.Height; y++)
                {
                    if (image.Data[y, x, 0] == 255)
                    {
                        int binIndex = y / binSize;
                        binCounts[binIndex]++;
                    }
                }

                for (int i = 0; i < numBins; i++)
                {
                    projection[x] += binCounts[i];
                }
            }

            return projection;
        }

        private void DrawProjectionGraph(int[] projection, PictureBox pictureBox)
        {
            Bitmap graph = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(graph))
            {
                g.Clear(Color.White);

                int maxProjectionValue = projection.Length > 0 ? projection.Max() : 1;
                float scaleFactor = (float)pictureBox.Height / maxProjectionValue;

                for (int i = 0; i < projection.Length; i++)
                {
                    int barHeight = (int)(projection[i] * scaleFactor);
                    g.DrawLine(Pens.Black, i, pictureBox.Height, i, pictureBox.Height - barHeight);
                }
            }

            pictureBox.Image = graph;
        }

        private void Projections_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
