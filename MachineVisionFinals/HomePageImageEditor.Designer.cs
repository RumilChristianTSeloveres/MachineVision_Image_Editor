namespace MachineVisionFinals
{
    partial class HomePageImageEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageImageEditor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometricPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageConvolutionAndConvolutionMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometricShapeRecognitionAndColorDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 298);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(576, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.binaryImageToolStripMenuItem,
            this.thresholdingToolStripMenuItem,
            this.segmentationToolStripMenuItem,
            this.geometricPropertiesToolStripMenuItem,
            this.imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem,
            this.imageConvolutionAndConvolutionMatrixToolStripMenuItem,
            this.geometricShapeRecognitionAndColorDetectionToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // binaryImageToolStripMenuItem
            // 
            this.binaryImageToolStripMenuItem.Name = "binaryImageToolStripMenuItem";
            this.binaryImageToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.binaryImageToolStripMenuItem.Text = "Binary Image";
            this.binaryImageToolStripMenuItem.Click += new System.EventHandler(this.binaryImageToolStripMenuItem_Click);
            // 
            // thresholdingToolStripMenuItem
            // 
            this.thresholdingToolStripMenuItem.Name = "thresholdingToolStripMenuItem";
            this.thresholdingToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.thresholdingToolStripMenuItem.Text = "Thresholding";
            this.thresholdingToolStripMenuItem.Click += new System.EventHandler(this.thresholdingToolStripMenuItem_Click);
            // 
            // segmentationToolStripMenuItem
            // 
            this.segmentationToolStripMenuItem.Name = "segmentationToolStripMenuItem";
            this.segmentationToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.segmentationToolStripMenuItem.Text = "Segmentation";
            this.segmentationToolStripMenuItem.Click += new System.EventHandler(this.segmentationToolStripMenuItem_Click);
            // 
            // geometricPropertiesToolStripMenuItem
            // 
            this.geometricPropertiesToolStripMenuItem.Name = "geometricPropertiesToolStripMenuItem";
            this.geometricPropertiesToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.geometricPropertiesToolStripMenuItem.Text = "Geometric Properties (size and position)";
            this.geometricPropertiesToolStripMenuItem.Click += new System.EventHandler(this.geometricPropertiesToolStripMenuItem_Click);
            // 
            // imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem
            // 
            this.imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem.Name = "imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem";
            this.imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem.Text = "Image Orientation, Histogram and Binary Image Projection";
            this.imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem.Click += new System.EventHandler(this.imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem_Click);
            // 
            // imageConvolutionAndConvolutionMatrixToolStripMenuItem
            // 
            this.imageConvolutionAndConvolutionMatrixToolStripMenuItem.Name = "imageConvolutionAndConvolutionMatrixToolStripMenuItem";
            this.imageConvolutionAndConvolutionMatrixToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.imageConvolutionAndConvolutionMatrixToolStripMenuItem.Text = "Image Convolution and Convolution Matrix";
            this.imageConvolutionAndConvolutionMatrixToolStripMenuItem.Click += new System.EventHandler(this.imageConvolutionAndConvolutionMatrixToolStripMenuItem_Click);
            // 
            // geometricShapeRecognitionAndColorDetectionToolStripMenuItem
            // 
            this.geometricShapeRecognitionAndColorDetectionToolStripMenuItem.Name = "geometricShapeRecognitionAndColorDetectionToolStripMenuItem";
            this.geometricShapeRecognitionAndColorDetectionToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.geometricShapeRecognitionAndColorDetectionToolStripMenuItem.Text = "Geometric Shape Recognition and Color Detection";
            this.geometricShapeRecognitionAndColorDetectionToolStripMenuItem.Click += new System.EventHandler(this.geometricShapeRecognitionAndColorDetectionToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "Exit(Log-out)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(297, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(258, 298);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // HomePageImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MachineVisionFinals.Properties.Resources.Background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(576, 371);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "HomePageImageEditor";
            this.Text = "HomePageImageEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomePageImageEditor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binaryImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometricPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageOrientationHistogramAndBinaryImageProjectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageConvolutionAndConvolutionMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometricShapeRecognitionAndColorDetectionToolStripMenuItem;
    }
}