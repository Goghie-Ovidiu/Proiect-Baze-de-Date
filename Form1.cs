using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;
namespace ProiectBd
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tabele f2=new Tabele();
            f2.Show();
        }

        private void Tabel_Click(object sender, EventArgs e)
        {
            Tabele f2 = new Tabele();
            f2.Show();
            Visible = false;
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            Cautare f2 = new Cautare();
            f2.Show();
            Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAngajat_Click(object sender, EventArgs e)
        {
            Angajati f2=new Angajati();
            f2.Show();
            Visible=false;
        }

    }
}
