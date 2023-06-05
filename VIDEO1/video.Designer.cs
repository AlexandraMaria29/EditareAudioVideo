namespace EditProdProj.VIDEO1
{
    partial class video
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLoadVideo = new System.Windows.Forms.Button();
            this.button1ProcessVideo = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonCombine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(46, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 199);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLoadVideo
            // 
            this.buttonLoadVideo.Location = new System.Drawing.Point(658, 62);
            this.buttonLoadVideo.Name = "buttonLoadVideo";
            this.buttonLoadVideo.Size = new System.Drawing.Size(138, 43);
            this.buttonLoadVideo.TabIndex = 2;
            this.buttonLoadVideo.Text = "LOAD VIDEO";
            this.buttonLoadVideo.UseVisualStyleBackColor = true;
            this.buttonLoadVideo.Click += new System.EventHandler(this.buttonLoadVideo_Click);
            // 
            // button1ProcessVideo
            // 
            this.button1ProcessVideo.Location = new System.Drawing.Point(658, 134);
            this.button1ProcessVideo.Name = "button1ProcessVideo";
            this.button1ProcessVideo.Size = new System.Drawing.Size(138, 43);
            this.button1ProcessVideo.TabIndex = 3;
            this.button1ProcessVideo.Text = "PROCESSING VIDEO";
            this.button1ProcessVideo.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(46, 278);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(394, 199);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // buttonCombine
            // 
            this.buttonCombine.Location = new System.Drawing.Point(658, 193);
            this.buttonCombine.Name = "buttonCombine";
            this.buttonCombine.Size = new System.Drawing.Size(138, 43);
            this.buttonCombine.TabIndex = 5;
            this.buttonCombine.Text = "COMBINE VIDEO";
            this.buttonCombine.UseVisualStyleBackColor = true;
            // 
            // video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 558);
            this.Controls.Add(this.buttonCombine);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1ProcessVideo);
            this.Controls.Add(this.buttonLoadVideo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "video";
            this.Text = "video";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLoadVideo;
        private System.Windows.Forms.Button button1ProcessVideo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonCombine;
    }
}