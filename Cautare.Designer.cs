namespace ProiectBd
{
    partial class Cautare
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInapoi = new System.Windows.Forms.Button();
            this.btnCautareSalariu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalMin = new System.Windows.Forms.TextBox();
            this.CautareFunctie = new System.Windows.Forms.ComboBox();
            this.btnCautareFunctie = new System.Windows.Forms.Button();
            this.comboCautare = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCautareSalFunc = new System.Windows.Forms.Button();
            this.CautareDepartament = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCautareDepartament = new System.Windows.Forms.Button();
            this.CautareProiect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCautareProiect = new System.Windows.Forms.Button();
            this.btnCautareFuncDepart = new System.Windows.Forms.Button();
            this.btnCautareSalDepart = new System.Windows.Forms.Button();
            this.btnCautareFunProiect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnInapoi
            // 
            this.btnInapoi.Location = new System.Drawing.Point(12, 332);
            this.btnInapoi.Name = "btnInapoi";
            this.btnInapoi.Size = new System.Drawing.Size(75, 23);
            this.btnInapoi.TabIndex = 1;
            this.btnInapoi.Text = "Inapoi";
            this.btnInapoi.UseVisualStyleBackColor = true;
            this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
            // 
            // btnCautareSalariu
            // 
            this.btnCautareSalariu.Location = new System.Drawing.Point(34, 247);
            this.btnCautareSalariu.Name = "btnCautareSalariu";
            this.btnCautareSalariu.Size = new System.Drawing.Size(75, 23);
            this.btnCautareSalariu.TabIndex = 2;
            this.btnCautareSalariu.Text = "Cautare";
            this.btnCautareSalariu.UseVisualStyleBackColor = true;
            this.btnCautareSalariu.Click += new System.EventHandler(this.btnCautareSalariu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cautare dupa salariu minim";
            // 
            // txtSalMin
            // 
            this.txtSalMin.Location = new System.Drawing.Point(24, 221);
            this.txtSalMin.Name = "txtSalMin";
            this.txtSalMin.Size = new System.Drawing.Size(100, 20);
            this.txtSalMin.TabIndex = 4;
            this.txtSalMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalMin_KeyPress);
            // 
            // CautareFunctie
            // 
            this.CautareFunctie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CautareFunctie.FormattingEnabled = true;
            this.CautareFunctie.Location = new System.Drawing.Point(207, 221);
            this.CautareFunctie.Name = "CautareFunctie";
            this.CautareFunctie.Size = new System.Drawing.Size(121, 21);
            this.CautareFunctie.TabIndex = 5;
            // 
            // btnCautareFunctie
            // 
            this.btnCautareFunctie.Location = new System.Drawing.Point(227, 247);
            this.btnCautareFunctie.Name = "btnCautareFunctie";
            this.btnCautareFunctie.Size = new System.Drawing.Size(75, 23);
            this.btnCautareFunctie.TabIndex = 6;
            this.btnCautareFunctie.Text = "Cautare";
            this.btnCautareFunctie.UseVisualStyleBackColor = true;
            this.btnCautareFunctie.Click += new System.EventHandler(this.btnCautareFunctie_Click);
            // 
            // comboCautare
            // 
            this.comboCautare.FormattingEnabled = true;
            this.comboCautare.Location = new System.Drawing.Point(391, 326);
            this.comboCautare.Name = "comboCautare";
            this.comboCautare.Size = new System.Drawing.Size(121, 21);
            this.comboCautare.TabIndex = 7;
            this.comboCautare.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(212, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cautare dupa functie";
            // 
            // btnCautareSalFunc
            // 
            this.btnCautareSalFunc.Location = new System.Drawing.Point(24, 285);
            this.btnCautareSalFunc.Name = "btnCautareSalFunc";
            this.btnCautareSalFunc.Size = new System.Drawing.Size(95, 35);
            this.btnCautareSalFunc.TabIndex = 8;
            this.btnCautareSalFunc.Text = "Cautare dupa salariu si functie";
            this.btnCautareSalFunc.UseVisualStyleBackColor = true;
            this.btnCautareSalFunc.Click += new System.EventHandler(this.btnCautareSalFunc_Click);
            // 
            // CautareDepartament
            // 
            this.CautareDepartament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CautareDepartament.FormattingEnabled = true;
            this.CautareDepartament.Location = new System.Drawing.Point(408, 221);
            this.CautareDepartament.Name = "CautareDepartament";
            this.CautareDepartament.Size = new System.Drawing.Size(121, 21);
            this.CautareDepartament.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cautare dupa departament";
            // 
            // btnCautareDepartament
            // 
            this.btnCautareDepartament.Location = new System.Drawing.Point(437, 247);
            this.btnCautareDepartament.Name = "btnCautareDepartament";
            this.btnCautareDepartament.Size = new System.Drawing.Size(75, 23);
            this.btnCautareDepartament.TabIndex = 11;
            this.btnCautareDepartament.Text = "Cautare";
            this.btnCautareDepartament.UseVisualStyleBackColor = true;
            this.btnCautareDepartament.Click += new System.EventHandler(this.btnCautareDepartament_Click);
            // 
            // CautareProiect
            // 
            this.CautareProiect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CautareProiect.FormattingEnabled = true;
            this.CautareProiect.Location = new System.Drawing.Point(642, 221);
            this.CautareProiect.Name = "CautareProiect";
            this.CautareProiect.Size = new System.Drawing.Size(121, 21);
            this.CautareProiect.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(648, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cautare dupa proiect";
            // 
            // btnCautareProiect
            // 
            this.btnCautareProiect.Location = new System.Drawing.Point(666, 247);
            this.btnCautareProiect.Name = "btnCautareProiect";
            this.btnCautareProiect.Size = new System.Drawing.Size(75, 23);
            this.btnCautareProiect.TabIndex = 14;
            this.btnCautareProiect.Text = "Cautare";
            this.btnCautareProiect.UseVisualStyleBackColor = true;
            this.btnCautareProiect.Click += new System.EventHandler(this.btnCautareProiect_Click);
            // 
            // btnCautareFuncDepart
            // 
            this.btnCautareFuncDepart.Location = new System.Drawing.Point(408, 285);
            this.btnCautareFuncDepart.Name = "btnCautareFuncDepart";
            this.btnCautareFuncDepart.Size = new System.Drawing.Size(115, 35);
            this.btnCautareFuncDepart.TabIndex = 15;
            this.btnCautareFuncDepart.Text = "Cautare dupa functie si departament";
            this.btnCautareFuncDepart.UseVisualStyleBackColor = true;
            this.btnCautareFuncDepart.Click += new System.EventHandler(this.btnCautareFuncDepart_Click);
            // 
            // btnCautareSalDepart
            // 
            this.btnCautareSalDepart.Location = new System.Drawing.Point(207, 285);
            this.btnCautareSalDepart.Name = "btnCautareSalDepart";
            this.btnCautareSalDepart.Size = new System.Drawing.Size(115, 35);
            this.btnCautareSalDepart.TabIndex = 16;
            this.btnCautareSalDepart.Text = "Cautare dupa salariu si departament";
            this.btnCautareSalDepart.UseVisualStyleBackColor = true;
            this.btnCautareSalDepart.Click += new System.EventHandler(this.btnCautareSalDepart_Click);
            // 
            // btnCautareFunProiect
            // 
            this.btnCautareFunProiect.Location = new System.Drawing.Point(642, 285);
            this.btnCautareFunProiect.Name = "btnCautareFunProiect";
            this.btnCautareFunProiect.Size = new System.Drawing.Size(115, 35);
            this.btnCautareFunProiect.TabIndex = 17;
            this.btnCautareFunProiect.Text = "Cautare dupa functie si proiect";
            this.btnCautareFunProiect.UseVisualStyleBackColor = true;
            this.btnCautareFunProiect.Click += new System.EventHandler(this.btnCautareFunProiect_Click);
            // 
            // Cautare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 367);
            this.Controls.Add(this.btnCautareFunProiect);
            this.Controls.Add(this.btnCautareSalDepart);
            this.Controls.Add(this.btnCautareFuncDepart);
            this.Controls.Add(this.btnCautareProiect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CautareProiect);
            this.Controls.Add(this.btnCautareDepartament);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CautareDepartament);
            this.Controls.Add(this.btnCautareSalFunc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboCautare);
            this.Controls.Add(this.btnCautareFunctie);
            this.Controls.Add(this.CautareFunctie);
            this.Controls.Add(this.txtSalMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCautareSalariu);
            this.Controls.Add(this.btnInapoi);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Cautare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cautare";
            this.Load += new System.EventHandler(this.Cautare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnInapoi;
        private System.Windows.Forms.Button btnCautareSalariu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalMin;
        private System.Windows.Forms.ComboBox CautareFunctie;
        private System.Windows.Forms.Button btnCautareFunctie;
        private System.Windows.Forms.ComboBox comboCautare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCautareSalFunc;
        private System.Windows.Forms.ComboBox CautareDepartament;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCautareDepartament;
        private System.Windows.Forms.ComboBox CautareProiect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCautareProiect;
        private System.Windows.Forms.Button btnCautareFuncDepart;
        private System.Windows.Forms.Button btnCautareSalDepart;
        private System.Windows.Forms.Button btnCautareFunProiect;
    }
}