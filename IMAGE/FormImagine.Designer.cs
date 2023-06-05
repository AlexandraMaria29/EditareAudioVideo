namespace EditProdProj.IMAGE
{
    partial class FormImagine
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
            this.loadImage = new System.Windows.Forms.Button();
            this.greyImage = new System.Windows.Forms.Button();
            this.histogram = new System.Windows.Forms.Button();
            this.gamma = new System.Windows.Forms.Button();
            this.rotateImage = new System.Windows.Forms.Button();
            this.brightnes = new System.Windows.Forms.Button();
            this.textBoxALFA = new System.Windows.Forms.TextBox();
            this.textBoxBETA = new System.Windows.Forms.TextBox();
            this.labelAlfa = new System.Windows.Forms.Label();
            this.labelBeta = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImage
            // 
            this.loadImage.Location = new System.Drawing.Point(848, 91);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(120, 41);
            this.loadImage.TabIndex = 0;
            this.loadImage.Text = "LOAD IMAGE";
            this.loadImage.UseVisualStyleBackColor = true;
            this.loadImage.Click += new System.EventHandler(this.loadImage_Click);
            // 
            // greyImage
            // 
            this.greyImage.Location = new System.Drawing.Point(848, 164);
            this.greyImage.Name = "greyImage";
            this.greyImage.Size = new System.Drawing.Size(120, 41);
            this.greyImage.TabIndex = 1;
            this.greyImage.Text = "GREY IMAGE";
            this.greyImage.UseVisualStyleBackColor = true;
            this.greyImage.Click += new System.EventHandler(this.greyImage_Click);
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(848, 227);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(120, 41);
            this.histogram.TabIndex = 2;
            this.histogram.Text = "HISTOGRAM";
            this.histogram.UseVisualStyleBackColor = true;
            this.histogram.Click += new System.EventHandler(this.histogram_Click);
            // 
            // gamma
            // 
            this.gamma.Location = new System.Drawing.Point(848, 283);
            this.gamma.Name = "gamma";
            this.gamma.Size = new System.Drawing.Size(120, 41);
            this.gamma.TabIndex = 3;
            this.gamma.Text = "GAMMA";
            this.gamma.UseVisualStyleBackColor = true;
            this.gamma.Click += new System.EventHandler(this.gamma_Click);
            // 
            // rotateImage
            // 
            this.rotateImage.Location = new System.Drawing.Point(848, 347);
            this.rotateImage.Name = "rotateImage";
            this.rotateImage.Size = new System.Drawing.Size(120, 41);
            this.rotateImage.TabIndex = 4;
            this.rotateImage.Text = "ROTATE IMAGE";
            this.rotateImage.UseVisualStyleBackColor = true;
            this.rotateImage.Click += new System.EventHandler(this.rotateImage_Click);
            // 
            // brightnes
            // 
            this.brightnes.Location = new System.Drawing.Point(848, 415);
            this.brightnes.Name = "brightnes";
            this.brightnes.Size = new System.Drawing.Size(120, 41);
            this.brightnes.TabIndex = 5;
            this.brightnes.Text = "BRIGHTNESS";
            this.brightnes.UseVisualStyleBackColor = true;
            this.brightnes.Click += new System.EventHandler(this.brightnes_Click);
            // 
            // textBoxALFA
            // 
            this.textBoxALFA.Location = new System.Drawing.Point(824, 500);
            this.textBoxALFA.Name = "textBoxALFA";
            this.textBoxALFA.Size = new System.Drawing.Size(62, 22);
            this.textBoxALFA.TabIndex = 6;
            // 
            // textBoxBETA
            // 
            this.textBoxBETA.Location = new System.Drawing.Point(938, 500);
            this.textBoxBETA.Name = "textBoxBETA";
            this.textBoxBETA.Size = new System.Drawing.Size(62, 22);
            this.textBoxBETA.TabIndex = 7;
            // 
            // labelAlfa
            // 
            this.labelAlfa.AutoSize = true;
            this.labelAlfa.Location = new System.Drawing.Point(842, 525);
            this.labelAlfa.Name = "labelAlfa";
            this.labelAlfa.Size = new System.Drawing.Size(40, 16);
            this.labelAlfa.TabIndex = 8;
            this.labelAlfa.Text = "ALFA";
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(956, 525);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(43, 16);
            this.labelBeta.TabIndex = 9;
            this.labelBeta.Text = "BETA";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(36, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(281, 381);
            this.pictureBox.TabIndex = 10;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(366, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 381);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // FormImagine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 561);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelBeta);
            this.Controls.Add(this.labelAlfa);
            this.Controls.Add(this.textBoxBETA);
            this.Controls.Add(this.textBoxALFA);
            this.Controls.Add(this.brightnes);
            this.Controls.Add(this.rotateImage);
            this.Controls.Add(this.gamma);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.greyImage);
            this.Controls.Add(this.loadImage);
            this.Name = "FormImagine";
            this.Text = "FormImagine";
            this.Load += new System.EventHandler(this.FormImagine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.Button greyImage;
        private System.Windows.Forms.Button histogram;
        private System.Windows.Forms.Button gamma;
        private System.Windows.Forms.Button rotateImage;
        private System.Windows.Forms.Button brightnes;
        private System.Windows.Forms.TextBox textBoxALFA;
        private System.Windows.Forms.TextBox textBoxBETA;
        private System.Windows.Forms.Label labelAlfa;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}