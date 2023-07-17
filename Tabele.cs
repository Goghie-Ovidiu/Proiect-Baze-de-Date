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
    public partial class Tabele : Form
    {
        OracleConnection conn;
        public Tabele()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBoxStadiuProiect.SelectedItem = comboBoxStadiuProiect.Items[0];
            this.Size = new Size(1090, 489);
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            conn = new OracleConnection(conStr);
            Select();


            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
            dataGridView1.Width = 1060;
            conn.Close();


          //  string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            comboBoxAngFuncAng.DisplayMember = "NUM";
            comboBoxAngFuncAng.ValueMember = "NUM";
            comboBoxAngFuncAng.DataSource = dt;

            OracleDataAdapter adapterr = new OracleDataAdapter("SELECT NUME_FUNCTIE FROM FUNCTIE", new OracleConnection(conStr));

            DataTable dtr = new System.Data.DataTable();
            adapterr.Fill(dtr);

            comboBoxAngFuncFunc.DisplayMember = "NUME_FUNCTIE";
            comboBoxAngFuncFunc.ValueMember = "NUME_FUNCTIE";
            comboBoxAngFuncFunc.DataSource = dtr;

            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE", new OracleConnection(conStr));

            DataTable dtrr = new System.Data.DataTable();
            adapterrr.Fill(dtrr);

            comboBoxNumeProiect.DisplayMember = "NUME_PROIECT";
            comboBoxNumeProiect.ValueMember = "NUME_PROIECT";
            comboBoxNumeProiect.DataSource = dtrr;
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
            
        }

        private void btnAngajati_Click(object sender, EventArgs e)
        {
            dataGridView1.Location = new Point(12, 12);
           groupBoxAng.Visible = true;
            groupBoxProiecte.Visible = false;
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
            dataGridView1.Width = 1060;
            conn.Close();

            groupBoxAngFunc.Visible = true;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            comboBoxAngFuncAng.DisplayMember = "NUM";
            comboBoxAngFuncAng.ValueMember = "NUM";
            comboBoxAngFuncAng.DataSource = dt;

            OracleDataAdapter adapterr = new OracleDataAdapter("SELECT NUME_FUNCTIE FROM FUNCTIE", new OracleConnection(conStr));

            DataTable dtr = new System.Data.DataTable();
            adapterr.Fill(dtr);

            comboBoxAngFuncFunc.DisplayMember = "NUME_FUNCTIE";
            comboBoxAngFuncFunc.ValueMember = "NUME_FUNCTIE";
            comboBoxAngFuncFunc.DataSource = dtr;
        }

        private void btnDepartamente_Click(object sender, EventArgs e)
        {
            groupBoxAng.Visible = false;
            groupBoxProiecte.Visible = false;
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT * FROM DEPARTAMENTE";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_DEPARTAMENT"], ListSortDirection.Ascending);
            dataGridView1.Width = 450;
            conn.Close();
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 150;
        }

        private void btnProiecte_Click(object sender, EventArgs e)
        {
            groupBoxAng.Visible = false;
            groupBoxProiecte.Visible = true;
            groupBoxProiecte.Location = new Point(180, 213);
            dataGridView1.Location = new Point(165, 12);
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT * FROM PROIECTE";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            this.dataGridView1.Sort(this.dataGridView1.Columns["ID_PROIECT"], ListSortDirection.Ascending);
            dataGridView1.Width = 660;
            conn.Close();
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";

            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE", new OracleConnection(conStr));

            DataTable dtrr = new System.Data.DataTable();
            adapterrr.Fill(dtrr);

            comboBoxNumeProiect.DisplayMember = "NUME_PROIECT";
            comboBoxNumeProiect.ValueMember = "NUME_PROIECT";
            comboBoxNumeProiect.DataSource = dtrr;

        }

        private void btnFunctie_Click(object sender, EventArgs e)
        {
            groupBoxAng.Visible = false;
            groupBoxProiecte.Visible = false;
            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT * FROM FUNCTIE";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;   
            dataGridView1.Width = 460;
            conn.Close();

           
        }

        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAngFuncAng.Visible = true;
            label1.Visible=false; label3.Visible=false;
            txtNume.Visible=false; txtPrenume.Visible=false;
            comboBoxAngFuncAng.Location=new Point(62,60);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAngFuncAng.Visible = false;
            label1.Visible=true; label3.Visible=true; txtNume.Visible=true;
            txtPrenume.Visible=true;
        }

        private void btnModificareAngFunc_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                
                if (txtNume.Text == "" || txtNume.Text.Length < 3)
                {
                    MessageBox.Show("Numele are prea putine caractere!");
                    txtNume.Focus();
                }
                else if (txtPrenume.Text == "" || txtPrenume.Text.Length < 3)
                {
                    MessageBox.Show("Prenumele are prea putine caractere!");
                    txtPrenume.Focus();
                }
                else
                {
                    int sal = salar();
                    conn.Open();
                    string x = functie();
                    int y = departament();

                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE ANGAJAT SET FUNCTIE='" + x + "' WHERE NUME='" + txtNume.Text.ToString() + "' AND PRENUME='" + txtPrenume.Text.ToString() + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    insert.CommandText = "UPDATE ANGAJAT SET DEPARTAMENT='" + y + "' WHERE NUME='" + txtNume.Text.ToString() + "' AND PRENUME='" + txtPrenume.Text.ToString() + "'";
                    insert.CommandType = CommandType.Text;
                    rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    insert.CommandText = "UPDATE ANGAJAT SET SALARIU='" + sal + "' WHERE NUME='" + txtNume.Text.ToString() + "' AND PRENUME='" + txtPrenume.Text.ToString() + "'";
                    insert.CommandType = CommandType.Text;
                    rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();
                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 1060;
                    conn.Close();

                }
            }
            if(radioButton2.Checked)
            {
                string[] nume;
                nume = comboBoxAngFuncAng.Text.ToString().Split(' ');
                conn.Open();
                int sal = salar();
                
                string x = functie();
                int y = departament();

                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE ANGAJAT SET FUNCTIE='" + x + "' WHERE NUME='" + nume[0] + "' AND PRENUME='" + nume[1] + "'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    int ok = 0;
                }
                insert.CommandText = "UPDATE ANGAJAT SET DEPARTAMENT='" + y + "' WHERE NUME='" + nume[0] + "' AND PRENUME='" + nume[1] + "'";
                insert.CommandType = CommandType.Text;
                rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    int ok = 0;
                }
                insert.CommandText = "UPDATE ANGAJAT SET SALARIU='" + sal + "' WHERE NUME='" + nume[0] + "' AND PRENUME='" + nume[1] + "'";
                insert.CommandType = CommandType.Text;
                rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                   int ok = 0;
                }
                conn.Close();
                conn.Open();
                OracleCommand selectCRUD = conn.CreateCommand();
                selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
                selectCRUD.CommandType = CommandType.Text;
                OracleDataReader empDR = selectCRUD.ExecuteReader();
                DataTable empDT = new DataTable();
                empDT.Load(empDR);
                dataGridView1.DataSource = empDT;
                this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                dataGridView1.Width = 1060;
                conn.Close();
            }
        }

        private void txtNume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != 8;
        }

        private void txtPrenume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.Handled == char.IsWhiteSpace(e.KeyChar) && e.KeyChar != Convert.ToChar("-");
        }

        private string functie()
        {
            string x = "";
            comboBox1.DisplayMember = null;
            comboBox1.ValueMember = null;
            comboBox1.DataSource = null;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE FROM FUNCTIE WHERE NUME_FUNCTIE='" +
                comboBoxAngFuncFunc.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            comboBox1.DisplayMember = "ID_FUNCTIE";
            comboBox1.ValueMember = "ID_FUNCTIE";
            comboBox1.DataSource = dt;
            x = comboBox1.Text.ToString();
            return x;
        }
        private int departament()
        {
            int x;
            comboBox.DisplayMember = null;
            comboBox.ValueMember = null;
            comboBox.DataSource = null;
            string func = functie();
            if (func == "ACC_FI" || func == "MAN_FI")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Finance and Accounting'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }
            else if (func == "MAN_MN" || func == "MED_MA" || func == "MED_CW" || func == "MED_BU" || func == "PRO_MN" || func == "PRO_WB" || func == "PRO_DA")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Marketing'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }

            else if (func == "ART_MN" || func == "ART_CO" || func == "ART_AR" || func == "ART_VE" || func == "ART_AN")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Art and Animation'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }
            else if (func == "PRG_MN" || func == "PRG_SR" || func == "PRG_EN" || func == "PRG_QA" || func == "PRG_DE")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Programming and Software Engineering'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }
            else if (func == "DSG_GA" || func == "DSG_LE" || func == "DSG_UI" || func == "DSG_SO" || func == "DSG_WR")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Game Design'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }
            else if (func == "MAN_DE")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Game Development'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }
            else if (func == "CEO")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Administration'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }
            else
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Programming and Software Engineering'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                comboBox.DisplayMember = "ID_DEPARTAMENT";
                comboBox.ValueMember = "ID_DEPARTAMENT";
                comboBox.DataSource = dt;
                x = (int)int.Parse(comboBox.Text.ToString());
            }
            return x;
        }
        private int salar()
        {
            string x = functie();
            comboBox1.DisplayMember = null;
            comboBox1.ValueMember = null;
            comboBox1.DataSource = null;
            comboBox.DisplayMember = null;
            comboBox.ValueMember = null;
            comboBox.DataSource = null;

            if (radioButton1.Checked)
            {
                string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapterr = new OracleDataAdapter("SELECT DATA_ANGAJARII FROM ANGAJAT WHERE NUME='" + txtNume.Text.ToString() + "' AND PRENUME='" + txtPrenume.Text.ToString() + "'", new OracleConnection(conStrr));

                DataTable dtr = new System.Data.DataTable();
                adapterr.Fill(dtr);
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                comboBox1.DisplayMember = "DATA_ANGAJARII";
                comboBox1.ValueMember = "DATA_ANGAJARII";
                comboBox1.DataSource = dtr;
                string date = comboBox1.Text.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(date);
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            }
            if(radioButton2.Checked) {
                string[] nume;nume=comboBoxAngFuncAng.Text.ToString().Split(' ');
                string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapterr = new OracleDataAdapter("SELECT DATA_ANGAJARII FROM ANGAJAT WHERE NUME='" + nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStrr));

                DataTable dtr = new System.Data.DataTable();
                adapterr.Fill(dtr);
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                comboBox1.DisplayMember = "DATA_ANGAJARII";
                comboBox1.ValueMember = "DATA_ANGAJARII";
                comboBox1.DataSource = dtr;
                string date = comboBox1.Text.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(date);
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            }
            string d = dateTimePicker1.Value.Date.ToString("yyyy");
            DateTime today = DateTime.UtcNow.Date;
            string s = today.ToString("yyyy");
            int dd = int.Parse(d);
            int ss = int.Parse(s);
            int cc = ss - dd;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE,SALARIU_MINIM,SALARIU_MAXIM FROM FUNCTIE WHERE ID_FUNCTIE='" + x + "'", new OracleConnection(conStr));
            comboBox1.DisplayMember = null;
            comboBox1.ValueMember = null;
            comboBox1.DataSource = null;
            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);

            comboBox1.DisplayMember = "SALARIU_MINIM";
            comboBox1.ValueMember = "SALARIU_MINIM";
            comboBox1.DataSource = dt;

            comboBox.DisplayMember = "SALARIU_MAXIM";
            comboBox.ValueMember = "SALARIU_MAXIM";
            comboBox.DataSource = dt;
            int mx = int.Parse(comboBox.Text.ToString());
            int mi = int.Parse(comboBox1.Text.ToString());
            int salariu = mx - mi;

            int c = 0;
            if (cc >= 0)
                c = int.Parse(comboBox1.Text.ToString());
            if (cc >= 2)
                c = (int)((0.2 * salariu) + mi);
            if (cc >= 4)
                c = (int)((0.4 * salariu) + mi);
            if (cc >= 6)
                c = (int)((0.6 * salariu) + mi);
            if (cc >= 8)
                c = (int)((0.8 * salariu) + mi);
            if (cc >= 10)
                c = int.Parse(comboBox.Text.ToString());
       
            return c;
        }

        private void txtNrTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void btnModificareAngNrTel_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                if (txtNrTel.Text == "" || txtNrTel.Text.Length < 10 || txtNrTel.Text.Length > 12)
                {
                    MessageBox.Show("Numarul de telefon are prea multe sau prea putine cifre!");
                    txtNrTel.Focus();
                }
                else
                {
                    conn.Open();
                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE ANGAJAT SET NR_TELEFON='" + txtNrTel.Text.ToString() + "' WHERE NUME='" + txtNume.Text.ToString() + "' AND PRENUME='" + txtPrenume.Text.ToString() + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();
                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 1060;
                    conn.Close();
                }
               
            }
            if (radioButton2.Checked)
            {
                if (txtNrTel.Text == "" || txtNrTel.Text.Length < 10 || txtNrTel.Text.Length > 12)
                {
                    MessageBox.Show("Numarul de telefon are prea multe sau prea putine cifre!");
                    txtNrTel.Focus();
                }
                else
                {
                    string[] nume;
                    nume = comboBoxAngFuncAng.Text.ToString().Split(' ');
                    conn.Open();

                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE ANGAJAT SET NR_TELEFON='" + txtNrTel.Text.ToString() + "' WHERE NUME='" + nume[0] + "' AND PRENUME='" + nume[1] + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();
                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 1060;
                    conn.Close();
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxNumeProiect.Visible=false;
            txtNumeProiect.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxNumeProiect.Visible = true;
            txtNumeProiect.Visible = false;
        }

        private void btnModificareNumeProiect_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked)
            {
                string s = ""; string ss = "";
                string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";

                OracleDataAdapter adapterrrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE WHERE NUME_PROIECT='"+txtNumeProiect.Text.ToString()+"'", new OracleConnection(conStrr));

                DataTable dtrrr = new System.Data.DataTable();
                adapterrrr.Fill(dtrrr);

                comboBox.DisplayMember = "NUME_PROIECT";
                comboBox.ValueMember = "NUME_PROIECT";
                comboBox.DataSource = dtrrr;

                OracleDataAdapter adapterrrrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE WHERE NUME_PROIECT='" + txtModificareNumeProiect.Text.ToString() + "'", new OracleConnection(conStrr));

                DataTable dtrrrr = new System.Data.DataTable();
                adapterrrrr.Fill(dtrrrr);

                comboBox1.DisplayMember = "NUME_PROIECT";
                comboBox1.ValueMember = "NUME_PROIECT";
                comboBox1.DataSource = dtrrrr;

                s = comboBox.Text.ToString();
                ss=comboBox1.Text.ToString();
                if(s!=txtNumeProiect.Text.ToString())
                {
                    MessageBox.Show("Acest proiect nu exista!");
                    txtNumeProiect.Focus();
                }
                else if (txtNumeProiect.Text == "")
                {
                    MessageBox.Show("Numele are prea putine caractere!");
                    txtNumeProiect.Focus();
                }
                else if (txtModificareNumeProiect.Text == "")
                {
                    MessageBox.Show("Numele proiectului are prea putine caractere!");
                    txtModificareNumeProiect.Focus();
                }
                else if(ss==txtModificareNumeProiect.Text.ToString())
                {
                    MessageBox.Show("Numele proiectului exista deja!");
                    txtModificareNumeProiect.Focus();
                }
                else
                {
                    string x = txtNumeProiect.Text.ToString();
                    string y = txtModificareNumeProiect.Text.ToString();

                    conn.Open();
                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE PROIECTE SET NUME_PROIECT='" + y + "' WHERE NUME_PROIECT='" + x + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();

                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM PROIECTE ";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_PROIECT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 660;
                    conn.Close();
                }
                
            }
            if(radioButton4.Checked)
            {
                string ss = "";
                string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapterrrrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE WHERE NUME_PROIECT='" + txtModificareNumeProiect.Text.ToString() + "'", new OracleConnection(conStrr));

                DataTable dtrrrr = new System.Data.DataTable();
                adapterrrrr.Fill(dtrrrr);

                comboBox1.DisplayMember = "NUME_PROIECT";
                comboBox1.ValueMember = "NUME_PROIECT";
                comboBox1.DataSource = dtrrrr;
                ss = comboBox1.Text.ToString();
                if (txtModificareNumeProiect.Text == "")
                {
                    MessageBox.Show("Numele proiectului are prea putine caractere!");
                    txtModificareNumeProiect.Focus();
                }
                else if (ss == txtModificareNumeProiect.Text.ToString())
                {
                    MessageBox.Show("Numele proiectului exista deja!");
                    txtModificareNumeProiect.Focus();
                }
                else
                {
                    string x = comboBoxNumeProiect.Text.ToString();
                    string y = txtModificareNumeProiect.Text.ToString();

                    conn.Open();
                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE PROIECTE SET NUME_PROIECT='" + y + "' WHERE NUME_PROIECT='" + x + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();

                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM PROIECTE ";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_PROIECT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 660;
                    conn.Close();
                }
            }

            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";

            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE", new OracleConnection(conStr));

            DataTable dtrr = new System.Data.DataTable();
            adapterrr.Fill(dtrr);

            comboBoxNumeProiect.DisplayMember = "NUME_PROIECT";
            comboBoxNumeProiect.ValueMember = "NUME_PROIECT";
            comboBoxNumeProiect.DataSource = dtrr;
        }

        private void btnModificareStadiuProiect_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                string s = "";
                string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";

                OracleDataAdapter adapterrrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE WHERE NUME_PROIECT='" + txtNumeProiect.Text.ToString() + "'", new OracleConnection(conStrr));

                DataTable dtrrr = new System.Data.DataTable();
                adapterrrr.Fill(dtrrr);

                comboBox.DisplayMember = "NUME_PROIECT";
                comboBox.ValueMember = "NUME_PROIECT";
                comboBox.DataSource = dtrrr;   

                s = comboBox.Text.ToString();
                if (s != txtNumeProiect.Text.ToString())
                {
                    MessageBox.Show("Acest proiect nu exista!");
                    txtNumeProiect.Focus();
                }
                else if (txtNumeProiect.Text == "")
                {
                    MessageBox.Show("Numele are prea putine caractere!");
                    txtNumeProiect.Focus();
                }
                else
                {
                    string x = txtNumeProiect.Text.ToString();

                    conn.Open();
                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE PROIECTE SET STADIU_PROIECT='" + comboBoxStadiuProiect.Text.ToString() + "' WHERE NUME_PROIECT='" + x + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();

                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM PROIECTE ";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_PROIECT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 660;
                    conn.Close();
                }

            }
            if (radioButton4.Checked)
            {
                
                    string x = comboBoxNumeProiect.Text.ToString();

                    conn.Open();
                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE PROIECTE SET STADIU_PROIECT='" + comboBoxStadiuProiect.Text.ToString() + "' WHERE NUME_PROIECT='" + x + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();

                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM PROIECTE ";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_PROIECT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 660;
                    conn.Close();
                
            }
        }

        private void btnModificareTermenProiect_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                string s = ""; string ss = "";
                string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";

                OracleDataAdapter adapterrrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE WHERE NUME_PROIECT='" + txtNumeProiect.Text.ToString() + "'", new OracleConnection(conStrr));

                DataTable dtrrr = new System.Data.DataTable();
                adapterrrr.Fill(dtrrr);

                comboBox.DisplayMember = "NUME_PROIECT";
                comboBox.ValueMember = "NUME_PROIECT";
                comboBox.DataSource = dtrrr;

                OracleDataAdapter adapterrrrr = new OracleDataAdapter("SELECT DATA_START FROM PROIECTE WHERE NUME_PROIECT='" + txtNumeProiect.Text.ToString() + "'", new OracleConnection(conStrr));

                DataTable dtrrrr = new System.Data.DataTable();
                adapterrrrr.Fill(dtrrrr);

                comboBox1.DisplayMember = "DATA_START";
                comboBox1.ValueMember = "DATA_START";
                comboBox1.DataSource = dtrrrr;

                s = comboBox.Text.ToString();
                ss = comboBox1.Text.ToString();
                DateTimePicker dateTime = new DateTimePicker();
                dateTime.Value=DateTime.Parse(ss);
                if(dateTime.Value.Date>=dateTimePicker2.Value.Date)
                    MessageBox.Show("Termenul limita nu poate sa fie mai devreme decat data de inceput a proiectului!");
                else if (s != txtNumeProiect.Text.ToString())
                {
                    MessageBox.Show("Acest proiect nu exista!");
                    txtNumeProiect.Focus();
                }
                else if (txtNumeProiect.Text == "")
                {
                    MessageBox.Show("Numele are prea putine caractere!");
                    txtNumeProiect.Focus();
                }
                else
                {
                    string x = txtNumeProiect.Text.ToString();

                    conn.Open();
                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE PROIECTE SET TERMEN_LIMITA='" + dateTimePicker2.Value.Date.ToString("d") + "' WHERE NUME_PROIECT='" + x + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();

                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM PROIECTE ";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_PROIECT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 660;
                    conn.Close();
                }

            }
            if (radioButton4.Checked)
            {
                string ss = "";
                string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapterrrrr = new OracleDataAdapter("SELECT DATA_START FROM PROIECTE WHERE NUME_PROIECT='" + comboBoxNumeProiect.Text.ToString() + "'", new OracleConnection(conStrr));

                DataTable dtrrrr = new System.Data.DataTable();
                adapterrrrr.Fill(dtrrrr);

                comboBox1.DisplayMember = "DATA_START";
                comboBox1.ValueMember = "DATA_START";
                comboBox1.DataSource = dtrrrr;

                ss = comboBox1.Text.ToString();
                DateTimePicker dateTime = new DateTimePicker();
                dateTime.Value = DateTime.Parse(ss);
                if (dateTime.Value.Date >= dateTimePicker2.Value.Date)
                    MessageBox.Show("Termenul limita nu poate sa fie mai devreme decat data de inceput a proiectului!");
                else
                {
                    string x = comboBoxNumeProiect.Text.ToString();

                    conn.Open();
                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE PROIECTE SET TERMEN_LIMITA='" + dateTimePicker2.Value.Date.ToString("d") + "' WHERE NUME_PROIECT='" + x + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();

                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM PROIECTE ";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_PROIECT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 660;
                    conn.Close();
                }
            }
        }

        private void btnModificareAngEmail_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string mail = txtAdresaEmail.Text.ToString();
                int index = mail.IndexOf("@");
                if (txtNume.Text == "" || txtNume.Text.Length < 3)
                {
                    MessageBox.Show("Numele are prea putine caractere!");
                    txtNume.Focus();
                }
                else if (txtPrenume.Text == "" || txtPrenume.Text.Length < 3)
                {
                    MessageBox.Show("Prenumele are prea putine caractere!");
                    txtPrenume.Focus();
                }
                else if (index < 0)
                {
                    MessageBox.Show("Adresa de email trebuie sa contina caracterul '@' !");
                    txtAdresaEmail.Focus();
                }
                else
                {

                    conn.Open();


                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE ANGAJAT SET EMAIL='" + txtAdresaEmail.Text.ToString() + "' WHERE NUME='" + txtNume.Text.ToString() + "' AND PRENUME='" + txtPrenume.Text.ToString() + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();
                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 1060;
                    conn.Close();

                }
            }
            if (radioButton2.Checked)
            {
                string mail = txtAdresaEmail.Text.ToString();
                int index = mail.IndexOf("@");
                if (index < 0)
                {
                    MessageBox.Show("Adresa de email trebuie sa contina caracterul '@' !");
                    txtAdresaEmail.Focus();
                }
                else
                {
                    string[] nume;
                    nume = comboBoxAngFuncAng.Text.ToString().Split(' ');
                    conn.Open();

                    OracleCommand insert = conn.CreateCommand();

                    insert.CommandText = "UPDATE ANGAJAT SET EMAIL='" + txtAdresaEmail.Text.ToString() + "' WHERE NUME='" + nume[0] + "' AND PRENUME='" + nume[1] + "'";
                    insert.CommandType = CommandType.Text;
                    int rows = insert.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        int ok = 0;
                    }
                    conn.Close();
                    conn.Open();
                    OracleCommand selectCRUD = conn.CreateCommand();
                    selectCRUD.CommandText = "SELECT * FROM ANGAJAT";
                    selectCRUD.CommandType = CommandType.Text;
                    OracleDataReader empDR = selectCRUD.ExecuteReader();
                    DataTable empDT = new DataTable();
                    empDT.Load(empDR);
                    dataGridView1.DataSource = empDT;
                    this.dataGridView1.Sort(this.dataGridView1.Columns["ID_ANGAJAT"], ListSortDirection.Ascending);
                    dataGridView1.Width = 1060;
                    conn.Close();
                }
            }
        }
    }
}
