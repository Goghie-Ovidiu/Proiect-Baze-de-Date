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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProiectBd
{
    public partial class Cautare : Form
    {
        OracleConnection conn;
        public Cautare()
        {
            InitializeComponent();
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void btnCautareSalariu_Click(object sender, EventArgs e)
        {

            string ss = txtSalMin.Text.ToString();
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE SALARIU>='" + ss+"'";
            selectCRUD.CommandType = CommandType.Text;
           
            OracleDataReader empDR = selectCRUD.ExecuteReader();

            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["SALARIU"], ListSortDirection.Ascending);
            dataGridView1.Width = 760;
            conn.Close();
        }

        private void Cautare_Load(object sender, EventArgs e)
        {
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            conn = new OracleConnection(conStr);
            Select();


            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
            dataGridView1.Width = 760;

            OracleDataAdapter adapter = new OracleDataAdapter("SELECT NUME_FUNCTIE FROM FUNCTIE", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);

            CautareFunctie.DisplayMember = "NUME_FUNCTIE";
            CautareFunctie.ValueMember = "NUME_FUNCTIE";
            CautareFunctie.DataSource = dt;

            OracleDataAdapter adapterr = new OracleDataAdapter("SELECT NUME_DEPARTAMENT FROM DEPARTAMENTE", new OracleConnection(conStr));

            DataTable dtt = new System.Data.DataTable();
            adapterr.Fill(dtt);

            CautareDepartament.DisplayMember = "NUME_DEPARTAMENT";
            CautareDepartament.ValueMember = "NUME_DEPARTAMENT";
            CautareDepartament.DataSource = dtt;

            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE", new OracleConnection(conStr));

            DataTable dttr = new System.Data.DataTable();
            adapterrr.Fill(dttr);

            CautareProiect.DisplayMember = "NUME_PROIECT";
            CautareProiect.ValueMember = "NUME_PROIECT";
            CautareProiect.DataSource = dttr;

            conn.Close();
        }

        private void btnCautareFunctie_Click(object sender, EventArgs e)
        {
            string x = functie();
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE FUNCTIE='" + x + "'";
            selectCRUD.CommandType = CommandType.Text;

            OracleDataReader empDR = selectCRUD.ExecuteReader();

            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
            dataGridView1.Width = 760;
            conn.Close();
        }

        private string functie()
        {
            string x = "";
            comboCautare.DisplayMember = null;
            comboCautare.ValueMember = null;
            comboCautare.DataSource = null;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE FROM FUNCTIE WHERE NUME_FUNCTIE='" +
                CautareFunctie.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            comboCautare.DisplayMember = "ID_FUNCTIE";
            comboCautare.ValueMember = "ID_FUNCTIE";
            comboCautare.DataSource = dt;
            x = comboCautare.Text.ToString();
            return x;
        }

        private void txtSalMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void btnCautareSalFunc_Click(object sender, EventArgs e)
        {
            if (txtSalMin.Text == "" || txtSalMin.Text.Length < 3)
            {
                MessageBox.Show("Introduceti salariul minim!");
                txtSalMin.Focus();
            }
            else
            {
                string ss = txtSalMin.Text.ToString();
                string x = functie();
                conn.Open();
                OracleCommand selectCRUD = conn.CreateCommand();
                selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE FUNCTIE='" + x + "' AND SALARIU>='" + ss + "'";
                selectCRUD.CommandType = CommandType.Text;

                OracleDataReader empDR = selectCRUD.ExecuteReader();

                DataTable empDT = new DataTable();
                empDT.Load(empDR);
                dataGridView1.DataSource = empDT;
                this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                dataGridView1.Width = 760;
                conn.Close();

            }
            
        }

        private void btnCautareDepartament_Click(object sender, EventArgs e)
        {
            string x = departament();
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE DEPARTAMENT='" + x + "'";
            selectCRUD.CommandType = CommandType.Text;

            OracleDataReader empDR = selectCRUD.ExecuteReader();

            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
            dataGridView1.Width = 760;
            conn.Close();
        }

        private string departament()
        {
            string x = "";
            comboCautare.DisplayMember = null;
            comboCautare.ValueMember = null;
            comboCautare.DataSource = null;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT='" +
                CautareDepartament.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            comboCautare.DisplayMember = "ID_DEPARTAMENT";
            comboCautare.ValueMember = "ID_DEPARTAMENT";
            comboCautare.DataSource = dt;
            x = comboCautare.Text.ToString();
            return x;
        }

        private void btnCautareProiect_Click(object sender, EventArgs e)
        {
            comboCautare.DisplayMember = null;
            comboCautare.ValueMember = null;
            comboCautare.DataSource = null;
            string pr = "";
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ECHIPA FROM PROIECTE WHERE NUME_PROIECT='"+ CautareProiect.Text.ToString()+ "'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            comboCautare.DisplayMember = "ECHIPA";
            comboCautare.ValueMember = "ECHIPA";
            comboCautare.DataSource = dt;
            pr = comboCautare.Text.ToString();
            string[] ec=pr.Split(',');
            int n=ec.Length;
            int[] a=new int[n];
            for (int i = 0; i < n; i++)
                a[i] = int.Parse(ec[i]);
            conn.Open();
            DataTable empDT = new DataTable();
            OracleCommand selectCRUD = conn.CreateCommand();
            for (int i=0; i < n; i++)
            {

                selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE ID_ANGAJAT='" + a[i] + "'";
                selectCRUD.CommandType = CommandType.Text;

                OracleDataReader empDR = selectCRUD.ExecuteReader();

                
                empDT.Load(empDR);
                dataGridView1.DataSource = empDT;
                this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                dataGridView1.Width = 760;
               
            }
            conn.Close();
        }

        private void btnCautareFuncDepart_Click(object sender, EventArgs e)
        {
            string ss = departament();
            string x = functie();
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE FUNCTIE='" + x + "' AND DEPARTAMENT='" + ss + "'";
            selectCRUD.CommandType = CommandType.Text;

            OracleDataReader empDR = selectCRUD.ExecuteReader();

            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
            dataGridView1.Width = 760;
            conn.Close();
        }

        private void btnCautareSalDepart_Click(object sender, EventArgs e)
        {
            if (txtSalMin.Text == "" || txtSalMin.Text.Length < 3)
            {
                MessageBox.Show("Introduceti salariul minim!");
                txtSalMin.Focus();
            }
            else
            {
                string ss = txtSalMin.Text.ToString();
                string x = departament();
                conn.Open();
                OracleCommand selectCRUD = conn.CreateCommand();
                selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE DEPARTAMENT='" + x + "' AND SALARIU>='" + ss + "'";
                selectCRUD.CommandType = CommandType.Text;

                OracleDataReader empDR = selectCRUD.ExecuteReader();

                DataTable empDT = new DataTable();
                empDT.Load(empDR);
                dataGridView1.DataSource = empDT;
                this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                dataGridView1.Width = 760;
                conn.Close();

            }
        }

        private void btnCautareFunProiect_Click(object sender, EventArgs e)
        {
            comboCautare.DisplayMember = null;
            comboCautare.ValueMember = null;
            comboCautare.DataSource = null;
            string pr = "";
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ECHIPA FROM PROIECTE WHERE NUME_PROIECT='" + CautareProiect.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            comboCautare.DisplayMember = "ECHIPA";
            comboCautare.ValueMember = "ECHIPA";
            comboCautare.DataSource = dt;
            pr = comboCautare.Text.ToString();
            string[] ec = pr.Split(',');
            int n = ec.Length;
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = int.Parse(ec[i]);
            conn.Open();
            DataTable empDT = new DataTable();
            OracleCommand selectCRUD = conn.CreateCommand();
            string x = functie();
            for (int i = 0; i < n; i++)
            {

                selectCRUD.CommandText = "SELECT ID_ANGAJAT,NUME,PRENUME,FUNCTIE,DEPARTAMENT,PROIECTE,SALARIU FROM ANGAJAT WHERE ID_ANGAJAT='" + a[i] + "'AND FUNCTIE='" + x + "'";
                selectCRUD.CommandType = CommandType.Text;

                OracleDataReader empDR = selectCRUD.ExecuteReader();


                empDT.Load(empDR);
                dataGridView1.DataSource = empDT;
                this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                dataGridView1.Width = 760;

            }
            conn.Close();
        }
    }
}
