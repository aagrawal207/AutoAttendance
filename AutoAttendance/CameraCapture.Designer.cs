namespace AutoAttendance
{
    partial class CameraCapture
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraCapture));
            this.CamImageBox = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Total_faces = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minNeighbor = new System.Windows.Forms.ComboBox();
            this.scaleSpeed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scaleSize = new System.Windows.Forms.TextBox();
            this.extractedFace = new System.Windows.Forms.PictureBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.boxExtractedFaces = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extractedFace)).BeginInit();
            this.boxExtractedFaces.SuspendLayout();
            this.SuspendLayout();
            // 
            // CamImageBox
            // 
            this.CamImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CamImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImageBox.Location = new System.Drawing.Point(12, 12);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(564, 389);
            this.CamImageBox.TabIndex = 2;
            this.CamImageBox.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(498, 407);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 26);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Webcam";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(399, 407);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(93, 26);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse Image";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Total_faces
            // 
            this.Total_faces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_faces.Location = new System.Drawing.Point(12, 410);
            this.Total_faces.Name = "Total_faces";
            this.Total_faces.Size = new System.Drawing.Size(126, 20);
            this.Total_faces.TabIndex = 5;
            this.Total_faces.Text = "Total Face detected : 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.minNeighbor);
            this.groupBox1.Controls.Add(this.scaleSpeed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(582, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DetectHaarCascade Parameters";
            // 
            // minNeighbor
            // 
            this.minNeighbor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minNeighbor.FormattingEnabled = true;
            this.minNeighbor.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.minNeighbor.Location = new System.Drawing.Point(158, 51);
            this.minNeighbor.Name = "minNeighbor";
            this.minNeighbor.Size = new System.Drawing.Size(53, 21);
            this.minNeighbor.TabIndex = 4;
            this.minNeighbor.Text = "3";
            // 
            // scaleSpeed
            // 
            this.scaleSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleSpeed.FormattingEnabled = true;
            this.scaleSpeed.Items.AddRange(new object[] {
            "1.1",
            "1.2",
            "1.3",
            "1.4"});
            this.scaleSpeed.Location = new System.Drawing.Point(158, 21);
            this.scaleSpeed.Name = "scaleSpeed";
            this.scaleSpeed.Size = new System.Drawing.Size(53, 21);
            this.scaleSpeed.TabIndex = 3;
            this.scaleSpeed.Text = "1.2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min. detection Scale :\r\n(Window Size)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Min. Neighbor Detection :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale Increase Rate :";
            // 
            // scaleSize
            // 
            this.scaleSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleSize.Location = new System.Drawing.Point(740, 91);
            this.scaleSize.Name = "scaleSize";
            this.scaleSize.Size = new System.Drawing.Size(53, 20);
            this.scaleSize.TabIndex = 7;
            this.scaleSize.Text = "25";
            // 
            // extractedFace
            // 
            this.extractedFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.extractedFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extractedFace.Location = new System.Drawing.Point(13, 21);
            this.extractedFace.Name = "extractedFace";
            this.extractedFace.Size = new System.Drawing.Size(122, 140);
            this.extractedFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.extractedFace.TabIndex = 8;
            this.extractedFace.TabStop = false;     
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(13, 167);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(56, 23);
            this.btnPrev.TabIndex = 9;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(77, 167);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 23);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // boxExtractedFaces
            // 
            this.boxExtractedFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxExtractedFaces.Controls.Add(this.extractedFace);
            this.boxExtractedFaces.Controls.Add(this.btnNext);
            this.boxExtractedFaces.Controls.Add(this.btnPrev);
            this.boxExtractedFaces.Location = new System.Drawing.Point(583, 133);
            this.boxExtractedFaces.Name = "boxExtractedFaces";
            this.boxExtractedFaces.Size = new System.Drawing.Size(150, 198);
            this.boxExtractedFaces.TabIndex = 11;
            this.boxExtractedFaces.TabStop = false;
            this.boxExtractedFaces.Text = "Extracted Faces";
            // 
            // CameraCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 442);
            this.Controls.Add(this.boxExtractedFaces);
            this.Controls.Add(this.scaleSize);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Total_faces);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.CamImageBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CameraCapture";
            this.Text = "Camera Output";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extractedFace)).EndInit();
            this.boxExtractedFaces.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox Total_faces;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox minNeighbor;
        private System.Windows.Forms.ComboBox scaleSpeed;
        private System.Windows.Forms.TextBox scaleSize;
        private System.Windows.Forms.PictureBox extractedFace;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox boxExtractedFaces;
    }
}

