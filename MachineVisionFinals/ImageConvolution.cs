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
    public partial class ImageConvolution : Form
    {
        #region Variable

        Bitmap image;

        #endregion
        public ImageConvolution()
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
                              image = new Bitmap(openFileDialog.FileName);
                              pictureBox1.Image = image;
                         }
                    }
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Smoothing Filter
          private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int[,] filter = new int[,]
                    {
                         {1, 1, 1},
                         {1, 1, 1},
                         {1, 1, 1}
                    };

                    Bitmap processedImage = new Bitmap(image.Width, image.Height);

                    for (int y = 1; y < image.Height - 1; y++)
                    {
                         for (int x = 1; x < image.Width - 1; x++)
                         {
                              int r = 0, g = 0, b = 0;

                              for (int j = -1; j <= 1; j++)
                              {
                                   for (int i = -1; i <= 1; i++)
                                   {
                                        Color pixel = image.GetPixel(x + i, y + j);
                                        int filterValue = filter[j + 1, i + 1];

                                        r += pixel.R * filterValue;
                                        g += pixel.G * filterValue;
                                        b += pixel.B * filterValue;
                                   }
                              }

                              r /= 9;
                              g /= 9;
                              b /= 9;

                              processedImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                         }
                    }
                    pictureBox1.Image = processedImage;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Apply Convolution Class
          private void ApplyConvolution(int topLeft, int top, int topRight, int left, int mid, int right, int botLeft, int bot, int botRight, float f, float bs)
          {
               try
               {
                    float[,] filter = new float[,]
                    {
                         {topLeft, top, topRight},
                         {left, mid, right},
                         {botLeft, bot, botRight}
                    };

                    Bitmap processedImage = new Bitmap(image.Width, image.Height);

                    int filterSize = 3;
                    float factor = f;
                    float bias = bs;

                    for (int y = filterSize / 2; y < image.Height - filterSize / 2; y++)
                    {
                         for (int x = filterSize / 2; x < image.Width - filterSize / 2; x++)
                         {
                              float r = 0, g = 0, b = 0;

                              for (int j = -filterSize / 2; j <= filterSize / 2; j++)
                              {
                                   for (int i = -filterSize / 2; i <= filterSize / 2; i++)
                                   {
                                        Color pixel = image.GetPixel(x + i, y + j);
                                        float filterValue = filter[j + filterSize / 2, i + filterSize / 2];

                                        r += pixel.R * filterValue;
                                        g += pixel.G * filterValue;
                                        b += pixel.B * filterValue;
                                   }
                              }

                              r /= factor;
                              g /= factor;
                              b /= factor;

                              r += bias;
                              g += bias;
                              b += bias;

                              r = Math.Min(Math.Max(r, 0), 255);
                              g = Math.Min(Math.Max(g, 0), 255);
                              b = Math.Min(Math.Max(b, 0), 255);

                              processedImage.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                         }
                    }
                    image = processedImage;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Gaussian Blur Filter
          private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = 1,
                    top = 2,
                    topRight = 1,
                    left = 2,
                    mid = 4,
                    right = 2,
                    botLeft = 1,
                    bot = 2,
                    botRight = 1;

                    float f = 16, bs = 0;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Sharpening Filter
          private void sharpeningToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = 0,
                    top = -2,
                    topRight = 0,
                    left = -2,
                    mid = 11,
                    right = -2,
                    botLeft = 0,
                    bot = -2,
                    botRight = 0;

                    float f = 3, bs = 0;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Mean Removal Filter
          private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = -1,
                    top = -1,
                    topRight = -1,
                    left = -1,
                    mid = 9,
                    right = -1,
                    botLeft = -1,
                    bot = -1,
                    botRight = -1;

                    float f = 1, bs = 0;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Emboss Laplacian Filter
          private void embossLaplacianToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = -1,
                    top = 0,
                    topRight = -1,
                    left = 0,
                    mid = 4,
                    right = 0,
                    botLeft = -1,
                    bot = 0,
                    botRight = -1;

                    float f = 1, bs = 127;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Horizontal + Vertical Filter
          private void horizontalVerticalToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = 0,
                    top = -1,
                    topRight = 0,
                    left = -1,
                    mid = 4,
                    right = -1,
                    botLeft = 0,
                    bot = -1,
                    botRight = 0;

                    float f = 1, bs = 127;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //All Directions Filter
          private void allDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = -1,
                    top = -1,
                    topRight = -1,
                    left = -1,
                    mid = 8,
                    right = -1,
                    botLeft = -1,
                    bot = -1,
                    botRight = -1;

                    float f = 1, bs = 127;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Lossy Filter
          private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = 1,
                    top = -2,
                    topRight = 1,
                    left = -2,
                    mid = 4,
                    right = -2,
                    botLeft = -2,
                    bot = 1,
                    botRight = -2;

                    float f = 1, bs = 127;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Horizontal only Filter
          private void horizontalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = 0,
                    top = 0, 
                    topRight = 0, 
                    left = -1,
                    mid = 2,
                    right = -1,
                    botLeft = 0,
                    bot = 0,
                    botRight = 0;

                    float f = 1, bs = 127;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Vertical only Filter
          private void verticalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    int topLeft = 0,
                    top = 0,
                    topRight = 0,
                    left = -1,
                    mid = 2,
                    right = -1,
                    botLeft = 0,
                    bot = 0,
                    botRight = 0;

                    float f = 1, bs = 127;

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Custom user's Filtering value
          private void customFilterToolStripMenuItem_Click(object sender, EventArgs e)
          {
               try
               {
                    if (topLeft_txtbox.Text.Length <= 0 || topLeft_txtbox.Text.Length <= 0 || topRight_txtbox.Text.Length <= 0 ||
                                    left_txtbox.Text.Length <= 0 || mid_txtbox.Text.Length <= 0 || right_txtbox.Text.Length <= 0 ||
                                    botLeft_txtbox.Text.Length <= 0 || bot_txtbox.Text.Length <= 0 || botRight_txtbox.Text.Length <= 0)
                    {
                         MessageBox.Show("Please Specify the custom filtering value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }

                    int topLeft = int.Parse(topLeft_txtbox.Text);
                    int top = int.Parse(top_txtbox.Text);
                    int topRight = int.Parse(topRight_txtbox.Text);
                    int left = int.Parse(left_txtbox.Text);
                    int mid = int.Parse(mid_txtbox.Text);
                    int right = int.Parse(right_txtbox.Text);
                    int botLeft = int.Parse(botLeft_txtbox.Text);
                    int bot = int.Parse(bot_txtbox.Text);
                    int botRight = int.Parse(botRight_txtbox.Text);

                    int f = int.Parse(factor_txtbox.Text);
                    int bs = int.Parse(bias_txtbox.Text);

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Custom Filtering Apply Button
          private void btnApply_Click(object sender, EventArgs e)
          {
               try
               {
                    if (topLeft_txtbox.Text.Length <= 0 || topLeft_txtbox.Text.Length <= 0 || topRight_txtbox.Text.Length <= 0 ||
                                    left_txtbox.Text.Length <= 0 || mid_txtbox.Text.Length <= 0 || right_txtbox.Text.Length <= 0 ||
                                    botLeft_txtbox.Text.Length <= 0 || bot_txtbox.Text.Length <= 0 || botRight_txtbox.Text.Length <= 0)
                    {
                         MessageBox.Show("Please Specify the custom filtering value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }

                    int topLeft = int.Parse(topLeft_txtbox.Text);
                    int top = int.Parse(top_txtbox.Text);
                    int topRight = int.Parse(topRight_txtbox.Text);
                    int left = int.Parse(left_txtbox.Text);
                    int mid = int.Parse(mid_txtbox.Text);
                    int right = int.Parse(right_txtbox.Text);
                    int botLeft = int.Parse(botLeft_txtbox.Text);
                    int bot = int.Parse(bot_txtbox.Text);
                    int botRight = int.Parse(botRight_txtbox.Text);

                    int f = int.Parse(factor_txtbox.Text);
                    int bs = int.Parse(bias_txtbox.Text);

                    ApplyConvolution(topLeft, top, topRight, left, mid, right, botLeft, bot, botRight, f, bs);
                    pictureBox1.Image = image;
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

          //Clear Button
          private void btnCancel_Click(object sender, EventArgs e)
          {
               topLeft_txtbox.ResetText();
               topLeft_txtbox.ResetText();
               topRight_txtbox.ResetText();
               left_txtbox.ResetText();
               mid_txtbox.ResetText();
               right_txtbox.ResetText();
               botLeft_txtbox.ResetText();
               bot_txtbox.ResetText();
               botRight_txtbox.ResetText();
               factor_txtbox.ResetText();
               bias_txtbox.ResetText();
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

          private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
          {
               if (MessageBox.Show("Are you sure you want to close?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                    Dispose();
                    HomePageImageEditor homePageImageEditor = new HomePageImageEditor();
                    homePageImageEditor.Show();
               }
          }

        private void ImageConvolution_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
