namespace MachineVisionFinals
{
    partial class ImageConvolution
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bias_txtbox = new System.Windows.Forms.TextBox();
            this.factor_txtbox = new System.Windows.Forms.TextBox();
            this.botRight_txtbox = new System.Windows.Forms.TextBox();
            this.bot_txtbox = new System.Windows.Forms.TextBox();
            this.botLeft_txtbox = new System.Windows.Forms.TextBox();
            this.right_txtbox = new System.Windows.Forms.TextBox();
            this.mid_txtbox = new System.Windows.Forms.TextBox();
            this.left_txtbox = new System.Windows.Forms.TextBox();
            this.topRight_txtbox = new System.Windows.Forms.TextBox();
            this.top_txtbox = new System.Windows.Forms.TextBox();
            this.topLeft_txtbox = new System.Windows.Forms.TextBox();
            this.customFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lossyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDirectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossLaplacianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanRemovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(639, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 46);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(460, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Custom Filtering Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumOrchid;
            this.label2.Location = new System.Drawing.Point(685, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 25);
            this.label2.TabIndex = 44;
            this.label2.Text = "+";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumOrchid;
            this.label1.Location = new System.Drawing.Point(612, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "÷";
            // 
            // bias_txtbox
            // 
            this.bias_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bias_txtbox.Location = new System.Drawing.Point(716, 198);
            this.bias_txtbox.Name = "bias_txtbox";
            this.bias_txtbox.Size = new System.Drawing.Size(40, 27);
            this.bias_txtbox.TabIndex = 42;
            // 
            // factor_txtbox
            // 
            this.factor_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factor_txtbox.Location = new System.Drawing.Point(639, 198);
            this.factor_txtbox.Name = "factor_txtbox";
            this.factor_txtbox.Size = new System.Drawing.Size(40, 27);
            this.factor_txtbox.TabIndex = 41;
            // 
            // botRight_txtbox
            // 
            this.botRight_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botRight_txtbox.Location = new System.Drawing.Point(566, 198);
            this.botRight_txtbox.Name = "botRight_txtbox";
            this.botRight_txtbox.Size = new System.Drawing.Size(40, 27);
            this.botRight_txtbox.TabIndex = 40;
            // 
            // bot_txtbox
            // 
            this.bot_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bot_txtbox.Location = new System.Drawing.Point(520, 198);
            this.bot_txtbox.Name = "bot_txtbox";
            this.bot_txtbox.Size = new System.Drawing.Size(40, 27);
            this.bot_txtbox.TabIndex = 39;
            // 
            // botLeft_txtbox
            // 
            this.botLeft_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLeft_txtbox.Location = new System.Drawing.Point(474, 198);
            this.botLeft_txtbox.Name = "botLeft_txtbox";
            this.botLeft_txtbox.Size = new System.Drawing.Size(40, 27);
            this.botLeft_txtbox.TabIndex = 38;
            // 
            // right_txtbox
            // 
            this.right_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.right_txtbox.Location = new System.Drawing.Point(566, 165);
            this.right_txtbox.Name = "right_txtbox";
            this.right_txtbox.Size = new System.Drawing.Size(40, 27);
            this.right_txtbox.TabIndex = 37;
            // 
            // mid_txtbox
            // 
            this.mid_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mid_txtbox.Location = new System.Drawing.Point(520, 165);
            this.mid_txtbox.Name = "mid_txtbox";
            this.mid_txtbox.Size = new System.Drawing.Size(40, 27);
            this.mid_txtbox.TabIndex = 36;
            // 
            // left_txtbox
            // 
            this.left_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.left_txtbox.Location = new System.Drawing.Point(474, 165);
            this.left_txtbox.Name = "left_txtbox";
            this.left_txtbox.Size = new System.Drawing.Size(40, 27);
            this.left_txtbox.TabIndex = 35;
            // 
            // topRight_txtbox
            // 
            this.topRight_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topRight_txtbox.Location = new System.Drawing.Point(566, 132);
            this.topRight_txtbox.Name = "topRight_txtbox";
            this.topRight_txtbox.Size = new System.Drawing.Size(40, 27);
            this.topRight_txtbox.TabIndex = 34;
            // 
            // top_txtbox
            // 
            this.top_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top_txtbox.Location = new System.Drawing.Point(520, 132);
            this.top_txtbox.Name = "top_txtbox";
            this.top_txtbox.Size = new System.Drawing.Size(40, 27);
            this.top_txtbox.TabIndex = 33;
            // 
            // topLeft_txtbox
            // 
            this.topLeft_txtbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLeft_txtbox.Location = new System.Drawing.Point(474, 132);
            this.topLeft_txtbox.Name = "topLeft_txtbox";
            this.topLeft_txtbox.Size = new System.Drawing.Size(40, 27);
            this.topLeft_txtbox.TabIndex = 32;
            // 
            // customFilterToolStripMenuItem
            // 
            this.customFilterToolStripMenuItem.Name = "customFilterToolStripMenuItem";
            this.customFilterToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.customFilterToolStripMenuItem.Text = "Custom Filter";
            this.customFilterToolStripMenuItem.Click += new System.EventHandler(this.customFilterToolStripMenuItem_Click);
            // 
            // verticalOnlyToolStripMenuItem
            // 
            this.verticalOnlyToolStripMenuItem.Name = "verticalOnlyToolStripMenuItem";
            this.verticalOnlyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.verticalOnlyToolStripMenuItem.Text = "Vertical only";
            this.verticalOnlyToolStripMenuItem.Click += new System.EventHandler(this.verticalOnlyToolStripMenuItem_Click);
            // 
            // horizontalOnlyToolStripMenuItem
            // 
            this.horizontalOnlyToolStripMenuItem.Name = "horizontalOnlyToolStripMenuItem";
            this.horizontalOnlyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.horizontalOnlyToolStripMenuItem.Text = "Horizontal only";
            this.horizontalOnlyToolStripMenuItem.Click += new System.EventHandler(this.horizontalOnlyToolStripMenuItem_Click);
            // 
            // lossyToolStripMenuItem
            // 
            this.lossyToolStripMenuItem.Name = "lossyToolStripMenuItem";
            this.lossyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.lossyToolStripMenuItem.Text = "Lossy";
            this.lossyToolStripMenuItem.Click += new System.EventHandler(this.lossyToolStripMenuItem_Click);
            // 
            // allDirectionsToolStripMenuItem
            // 
            this.allDirectionsToolStripMenuItem.Name = "allDirectionsToolStripMenuItem";
            this.allDirectionsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.allDirectionsToolStripMenuItem.Text = "All Directions";
            this.allDirectionsToolStripMenuItem.Click += new System.EventHandler(this.allDirectionsToolStripMenuItem_Click);
            // 
            // horizontalVerticalToolStripMenuItem
            // 
            this.horizontalVerticalToolStripMenuItem.Name = "horizontalVerticalToolStripMenuItem";
            this.horizontalVerticalToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.horizontalVerticalToolStripMenuItem.Text = "Horizontal + Vertical";
            this.horizontalVerticalToolStripMenuItem.Click += new System.EventHandler(this.horizontalVerticalToolStripMenuItem_Click);
            // 
            // embossLaplacianToolStripMenuItem
            // 
            this.embossLaplacianToolStripMenuItem.Name = "embossLaplacianToolStripMenuItem";
            this.embossLaplacianToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.embossLaplacianToolStripMenuItem.Text = "Emboss Laplacian";
            this.embossLaplacianToolStripMenuItem.Click += new System.EventHandler(this.embossLaplacianToolStripMenuItem_Click);
            // 
            // embossToolStripMenuItem
            // 
            this.embossToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.embossLaplacianToolStripMenuItem,
            this.horizontalVerticalToolStripMenuItem,
            this.allDirectionsToolStripMenuItem,
            this.lossyToolStripMenuItem,
            this.horizontalOnlyToolStripMenuItem,
            this.verticalOnlyToolStripMenuItem});
            this.embossToolStripMenuItem.Name = "embossToolStripMenuItem";
            this.embossToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.embossToolStripMenuItem.Text = "Emboss";
            // 
            // meanRemovalToolStripMenuItem
            // 
            this.meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            this.meanRemovalToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.meanRemovalToolStripMenuItem.Text = "Mean Removal";
            this.meanRemovalToolStripMenuItem.Click += new System.EventHandler(this.meanRemovalToolStripMenuItem_Click);
            // 
            // sharpeningToolStripMenuItem
            // 
            this.sharpeningToolStripMenuItem.Name = "sharpeningToolStripMenuItem";
            this.sharpeningToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sharpeningToolStripMenuItem.Text = "Sharpening";
            this.sharpeningToolStripMenuItem.Click += new System.EventHandler(this.sharpeningToolStripMenuItem_Click);
            // 
            // gaussianBlurToolStripMenuItem
            // 
            this.gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            this.gaussianBlurToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.gaussianBlurToolStripMenuItem.Text = "Gaussian Blur";
            this.gaussianBlurToolStripMenuItem.Click += new System.EventHandler(this.gaussianBlurToolStripMenuItem_Click);
            // 
            // smoothingToolStripMenuItem
            // 
            this.smoothingToolStripMenuItem.Name = "smoothingToolStripMenuItem";
            this.smoothingToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.smoothingToolStripMenuItem.Text = "Smoothing";
            this.smoothingToolStripMenuItem.Click += new System.EventHandler(this.smoothingToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothingToolStripMenuItem,
            this.gaussianBlurToolStripMenuItem,
            this.sharpeningToolStripMenuItem,
            this.meanRemovalToolStripMenuItem,
            this.embossToolStripMenuItem,
            this.customFilterToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Black;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnApply.Location = new System.Drawing.Point(488, 253);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(133, 46);
            this.btnApply.TabIndex = 46;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 397);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addImageToolStripMenuItem1,
            this.clearImageToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addImageToolStripMenuItem1
            // 
            this.addImageToolStripMenuItem1.Name = "addImageToolStripMenuItem1";
            this.addImageToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.addImageToolStripMenuItem1.Text = "Add Image";
            this.addImageToolStripMenuItem1.Click += new System.EventHandler(this.addImageToolStripMenuItem1_Click);
            // 
            // clearImageToolStripMenuItem
            // 
            this.clearImageToolStripMenuItem.Name = "clearImageToolStripMenuItem";
            this.clearImageToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.clearImageToolStripMenuItem.Text = "Clear Image";
            this.clearImageToolStripMenuItem.Click += new System.EventHandler(this.clearImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // ImageConvolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MachineVisionFinals.Properties.Resources.Background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bias_txtbox);
            this.Controls.Add(this.factor_txtbox);
            this.Controls.Add(this.botRight_txtbox);
            this.Controls.Add(this.bot_txtbox);
            this.Controls.Add(this.botLeft_txtbox);
            this.Controls.Add(this.right_txtbox);
            this.Controls.Add(this.mid_txtbox);
            this.Controls.Add(this.left_txtbox);
            this.Controls.Add(this.topRight_txtbox);
            this.Controls.Add(this.top_txtbox);
            this.Controls.Add(this.topLeft_txtbox);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ImageConvolution";
            this.Text = "ImageConvolution";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageConvolution_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

          #endregion

          private System.Windows.Forms.Button btnCancel;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.TextBox bias_txtbox;
          private System.Windows.Forms.TextBox factor_txtbox;
          private System.Windows.Forms.TextBox botRight_txtbox;
          private System.Windows.Forms.TextBox bot_txtbox;
          private System.Windows.Forms.TextBox botLeft_txtbox;
          private System.Windows.Forms.TextBox right_txtbox;
          private System.Windows.Forms.TextBox mid_txtbox;
          private System.Windows.Forms.TextBox left_txtbox;
          private System.Windows.Forms.TextBox topRight_txtbox;
          private System.Windows.Forms.TextBox top_txtbox;
          private System.Windows.Forms.TextBox topLeft_txtbox;
          private System.Windows.Forms.ToolStripMenuItem customFilterToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem verticalOnlyToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem horizontalOnlyToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem lossyToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem allDirectionsToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem horizontalVerticalToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem embossLaplacianToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem embossToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem meanRemovalToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem sharpeningToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem smoothingToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
          private System.Windows.Forms.Button btnApply;
          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.MenuStrip menuStrip1;
          private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem clearImageToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem addImageToolStripMenuItem1;
          private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
     }
}