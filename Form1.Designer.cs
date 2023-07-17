namespace ProiectBd
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAngajat = new System.Windows.Forms.Button();
            this.btnCautare = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Tabel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAngajat
            // 
            this.btnAngajat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAngajat.Location = new System.Drawing.Point(26, 36);
            this.btnAngajat.Name = "btnAngajat";
            this.btnAngajat.Size = new System.Drawing.Size(80, 42);
            this.btnAngajat.TabIndex = 1;
            this.btnAngajat.TabStop = false;
            this.btnAngajat.Text = "Adaugare Stergere";
            this.btnAngajat.UseVisualStyleBackColor = true;
            this.btnAngajat.Click += new System.EventHandler(this.btnAngajat_Click);
            // 
            // btnCautare
            // 
            this.btnCautare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCautare.Location = new System.Drawing.Point(26, 84);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(80, 42);
            this.btnCautare.TabIndex = 2;
            this.btnCautare.TabStop = false;
            this.btnCautare.Text = "Cautare";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(26, 198);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 42);
            this.btnExit.TabIndex = 4;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "logo-usv-25mm-300dpi_0.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProiectBd.Properties.Resources.logo_usv_25mm_300dpi_0;
            this.pictureBox1.Location = new System.Drawing.Point(463, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 275);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Tabel
            // 
            this.Tabel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Tabel.Location = new System.Drawing.Point(26, 132);
            this.Tabel.Name = "Tabel";
            this.Tabel.Size = new System.Drawing.Size(80, 42);
            this.Tabel.TabIndex = 3;
            this.Tabel.TabStop = false;
            this.Tabel.Text = "Modificare";
            this.Tabel.UseVisualStyleBackColor = true;
            this.Tabel.Click += new System.EventHandler(this.Tabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.btnAngajat);
            this.Controls.Add(this.Tabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baze de date";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAngajat;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Tabel;
    }
}

