using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;
namespace ProiectBd
{
    public partial class Angajati : Form
    {
        OracleConnection conn;
        public Angajati()
        {
            InitializeComponent();
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void Angajati_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) -50,
                           (Screen.PrimaryScreen.WorkingArea.Height - this.Height) +100);
            // TODO: This line of code loads data into the 'dataSet3.FUNCTIE' table. You can move, or remove it, as needed.
            //  this.fUNCTIETableAdapter1.Fill(this.dataSet3.FUNCTIE);
            // TODO: This line of code loads data into the 'dataSet2.FUNCTIE' table. You can move, or remove it, as needed.
            //  this.fUNCTIETableAdapter1.Fill(this.dataSet2.FUNCTIE);
            // TODO: This line of code loads data into the 'dataSet1.FUNCTIE' table. You can move, or remove it, as needed.
            this.txtFunctie.DropDownStyle = ComboBoxStyle.DropDownList;
            this.txtExperientaFunctie.DropDownStyle = ComboBoxStyle.DropDownList;
            this.txtLimbaj.DropDownStyle = ComboBoxStyle.DropDownList;
            this.txtNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.stergereIdFunctie.DropDownStyle= ComboBoxStyle.DropDownList;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            this.fUNCTIETableAdapter.Fill(this.dataSet1.FUNCTIE);
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            conn = new OracleConnection(conStr);
            Select();

            this.Size = new Size(1112, 540);

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
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT NUME_FUNCTIE FROM FUNCTIE",new OracleConnection(conStr));
           
            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);

            txtFunctie.DisplayMember = "NUME_FUNCTIE";
            txtFunctie.ValueMember = "NUME_FUNCTIE";
            txtFunctie.DataSource = dt;

            OracleDataAdapter adapterr = new OracleDataAdapter("SELECT NUME_FUNCTIE FROM FUNCTIE", new OracleConnection(conStr));

            DataTable dtt = new System.Data.DataTable();
            adapter.Fill(dtt);

            txtExperientaFunctie.DisplayMember = "NUME_FUNCTIE";
            txtExperientaFunctie.ValueMember = "NUME_FUNCTIE";
            txtExperientaFunctie.DataSource = dtt;


            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE", new OracleConnection(conStr));

            DataTable dttr = new System.Data.DataTable();
            adapterrr.Fill(dttr);

            stergereNumeProiect.DisplayMember = "NUME_PROIECT";
            stergereNumeProiect.ValueMember = "NUME_PROIECT";
            stergereNumeProiect.DataSource = dttr;

            conn.Close();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            
            string mail = emailtxt.Text.ToString();
            int index= mail.IndexOf("@");
            string num = nume_prenume();
            string[] num2=num.Split(',');
            if (num2[0] == numeTxt.Text.ToString() && num2[1] == prenumeTxt.Text.ToString())
            { MessageBox.Show("Aceasta persoana este deja angajata!"); }
            else if (numeTxt.Text == "" || numeTxt.Text.Length < 3)
            {
                MessageBox.Show("Numele are prea putine caractere!");
                numeTxt.Focus();
            }
            else if (prenumeTxt.Text == "" || prenumeTxt.Text.Length < 3)
            {
                MessageBox.Show("Prenumele are prea putine caractere!");
                prenumeTxt.Focus();
            }
            else if (nrTelefonTxt.Text == "" || nrTelefonTxt.Text.Length < 10 || nrTelefonTxt.Text.Length > 12)
            {
                MessageBox.Show("Numarul de telefon are prea multe sau prea putine cifre!");
                nrTelefonTxt.Focus();
            }
            else if (txtLimbaj.Text == "")
            {
                MessageBox.Show("Selectati limbajul de programare!");
                txtLimbaj.Focus();
            }
            else if (txtNivel.Text == "")
            {
                MessageBox.Show("Selectati nivelul de programare!");
                txtNivel.Focus();
            }
            else if (index < 0)
            {
                MessageBox.Show("Adresa de email trebuie sa contina caracterul '@' !");
                emailtxt.Focus();
            }
            else if(CNPtxt.Text.Length>13)
            {
                MessageBox.Show("CNP ul are prea multe cifre!");
                CNPtxt.Focus();
            }
            else if (CNPtxt.Text.Length < 13)
            {
                MessageBox.Show("CNP ul are prea putine cifre!");
                CNPtxt.Focus();
            }
            else
            {
                // int cnpp=int.Parse(CNPtxt.Text.ToString());
                // Int32 cnp = cnpp;
                long cnp = Convert.ToInt64(CNPtxt.Text);
                int sal = salar();
                //    dateTimePicker1.Value.ToString("dd-MM-yyyy");
                //   string MyString = dateTimePicker1.Value.Date;
                conn.Open();
                OracleCommand insertCRUD = conn.CreateCommand();
                string ex = txtLimbaj.Text.ToString() + "," + txtNivel.Text.ToString() + "," + txtExperientaFunctie.Text.ToString();
                string x = functie();
                int y = departament();//fun2();

                insertCRUD.CommandText = "INSERT INTO ANGAJAT (NUME,PRENUME,FUNCTIE,DEPARTAMENT,EXPERIENTA,DATA_ANGAJARII,NR_TELEFON,SALARIU,EMAIL,CNP) VALUES(\'" +
               numeTxt.Text.ToString() + "\',\'" + prenumeTxt.Text.ToString() + "\',\'" + x + "\',\'" + y + "\',\'" + ex +
               "\',\'" + dateTimePicker1.Value.Date.ToString("d") + "\',\'" + nrTelefonTxt.Text.ToString() + "\',\'" + sal + "\',\'" + emailtxt.Text.ToString() + 
                "\',\'" + cnp +"\')";

                insertCRUD.CommandType = CommandType.Text;
                int rows = insertCRUD.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
                dep();
                updateDatagrid();
            }
        }

        private void updateDatagrid()
        {
            if (btnAdauga != null)
            {
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

     

        private void dep()
        {
            string x=functie();
            string yy = numeTxt.Text.ToString();
            if (x == "DSG_GA")
            {
                conn.Open();
                
                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE DEPARTAMENTE SET MANAGER_DEPARTAMENT='" +yy  + "' WHERE NUME_DEPARTAMENT='Game Design'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
               if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
            }

            if (x == "PRG_MN")
            {
                conn.Open();

                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE DEPARTAMENTE SET MANAGER_DEPARTAMENT='" + yy + "' WHERE NUME_DEPARTAMENT='Programming and Software Engineering'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
            }

            if (x == "MAN_DE")
            {
                conn.Open();

                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE DEPARTAMENTE SET MANAGER_DEPARTAMENT='" + yy + "' WHERE NUME_DEPARTAMENT='Game Development'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
            }

            if (x == "ART_MN")
            {
                conn.Open();

                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE DEPARTAMENTE SET MANAGER_DEPARTAMENT='" + yy + "' WHERE NUME_DEPARTAMENT='Art and Animation'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
            }

            if (x == "MAN_MN")
            {
                conn.Open();

                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE DEPARTAMENTE SET MANAGER_DEPARTAMENT='" + yy + "' WHERE NUME_DEPARTAMENT='Marketing'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
            }

            if (x == "MAN_FI")
            {
                conn.Open();

                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE DEPARTAMENTE SET MANAGER_DEPARTAMENT='" + yy + "' WHERE NUME_DEPARTAMENT='Finance and Accounting'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
            }

            if (x == "CEO")
            {
                conn.Open();

                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE DEPARTAMENTE SET MANAGER_DEPARTAMENT='" + yy + "' WHERE NUME_DEPARTAMENT='Administration'";
                insert.CommandType = CommandType.Text;
                int rows = insert.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
            }
        }

 
        private int departament()
        {
            int x = 0;
            salarMaxim.DisplayMember = null;
            salarMaxim.ValueMember = null;
            salarMaxim.DataSource = null;
            string func = functie();
            if (func == "ACC_FI" || func == "MAN_FI")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Finance and Accounting'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }
            else if (func == "MAN_MN" || func == "MED_MA" || func == "MED_CW" || func == "MED_BU" || func == "PRO_MN" || func == "PRO_WB" || func == "PRO_DA")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Marketing'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }

            else if (func == "ART_MN" || func == "ART_CO" || func == "ART_AR" || func == "ART_VE" || func == "ART_AN")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Art and Animation'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }
            else if (func == "PRG_MN" || func == "PRG_SR" || func == "PRG_EN" || func == "PRG_QA" || func == "PRG_DE")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Programming and Software Engineering'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }
            else if (func == "DSG_GA" || func == "DSG_LE" || func == "DSG_UI" || func == "DSG_SO" || func == "DSG_WR")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Game Design'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }
            else if (func == "MAN_DE")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Game Development'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }
            else if (func == "CEO")
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Administration'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }
            else
            {
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_DEPARTAMENT FROM DEPARTAMENTE WHERE NUME_DEPARTAMENT = 'Programming and Software Engineering'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMaxim.DisplayMember = "ID_DEPARTAMENT";
                salarMaxim.ValueMember = "ID_DEPARTAMENT";
                salarMaxim.DataSource = dt;
                x = (int)int.Parse(salarMaxim.Text.ToString());
            }
            return x;
        }

        private string functie()
        {
            string x = "";
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE FROM FUNCTIE WHERE NUME_FUNCTIE='" +
                txtFunctie.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            salarMinim.DisplayMember = "ID_FUNCTIE";
            salarMinim.ValueMember = "ID_FUNCTIE";
            salarMinim.DataSource = dt;
            x = salarMinim.Text.ToString();
            return x;
        }

        private string nume_prenume()
        {
            string x="";
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            salarMaxim.DisplayMember = null;
            salarMaxim.ValueMember = null;
            salarMaxim.DataSource = null;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT NUME,PRENUME FROM ANGAJAT WHERE NUME='" +
                numeTxt.Text.ToString() + "' AND PRENUME='"+prenumeTxt.Text.ToString()+"'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            salarMinim.DisplayMember = "NUME";
            salarMinim.ValueMember = "NUME";
            salarMinim.DataSource = dt;
            salarMaxim.DisplayMember = "PRENUME";
            salarMaxim.ValueMember = "PRENUME";
            salarMaxim.DataSource = dt;
            x=salarMinim.Text.ToString()+","+salarMaxim.Text.ToString();
            return x;
        }

        private int salar()
        {
            string x = functie();
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember=null;
            salarMinim.DataSource= null;
            salarMaxim.DisplayMember = null;
            salarMaxim.ValueMember=null;
            salarMaxim.DataSource= null;
           
            string d = dateTimePicker1.Value.Date.ToString("yyyy");
            DateTime today = DateTime.UtcNow.Date;
            string s = today.ToString("yyyy");
            int dd=int.Parse(d);
            int ss=int.Parse(s);
            int cc = ss - dd;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE,SALARIU_MINIM,SALARIU_MAXIM FROM FUNCTIE WHERE ID_FUNCTIE='"+x+"'", new OracleConnection(conStr));
            
            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);

            salarMinim.DisplayMember = "SALARIU_MINIM";
            salarMinim.ValueMember = "SALARIU_MINIM";
            salarMinim.DataSource = dt;

            salarMaxim.DisplayMember = "SALARIU_MAXIM";
            salarMaxim.ValueMember = "SALARIU_MAXIM";
            salarMaxim.DataSource = dt;
            int mx = int.Parse(salarMaxim.Text.ToString());
            int mi = int.Parse(salarMinim.Text.ToString());
            int salariu=mx-mi;

            int c = 0;
            if(cc>=0)
                c = int.Parse(salarMinim.Text.ToString());
            if (cc >= 2)
                c = (int)((0.2 * salariu) + mi);
            if (cc >= 4)
                c = (int)((0.4 * salariu) + mi);
            if (cc >= 6)
                c = (int)((0.6 * salariu) + mi);
            if (cc >= 8)
                c = (int)((0.8 * salariu) + mi);
            if (cc >= 10)
                c = int.Parse(salarMaxim.Text.ToString());
            /*
            if (dd >= ss - 5)
            {
                salarMinim.DisplayMember = "SALARIU_MINIM";
                salarMinim.ValueMember = "SALARIU_MINIM";
                salarMinim.DataSource = dt;
            }
            else
            {
                salarMinim.DisplayMember = "SALARIU_MAXIM";
                salarMinim.ValueMember = "SALARIU_MAXIM";
                salarMinim.DataSource = dt;
            }*/
            //int c=int.Parse(salarMinim.Text.ToString());
            return c;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand deleteCRUD = conn.CreateCommand();
            deleteCRUD.CommandText = "DELETE FROM ANGAJAT WHERE NUME = '" +sterNumeTxt.Text.ToString()+"' AND PRENUME= '"+sterPrenumeTxt.Text.ToString()+"'";
            deleteCRUD.CommandType = CommandType.Text;
            int rows = deleteCRUD.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("Angajatul a fost sters din baza de date!");
            }
            else
            {
                MessageBox.Show("Aceasta persoana nu este angajata!");
            }
            conn.Close();
            updateDatagrid();
        }

        private void nrTelefonTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void prenumeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.Handled ==char.IsWhiteSpace(e.KeyChar) && e.KeyChar!=Convert.ToChar("-");
        }

        private void numeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != 8;
        }

        private void sterNumeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != 8;
        }

        private void sterPrenumeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != 8;
        }

        private void btnAngajati_Click(object sender, EventArgs e)
        {
            groupBoxAng.Visible = true;
            groupBoxFunc.Visible = false;
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
            dataGridView1.Width =1060;
            conn.Close();
        }

        private void btnFunctie_Click(object sender, EventArgs e)
        {
            groupBoxAng.Visible=false;
            groupBoxProiecte.Visible=false;
            groupBoxFunc.Visible = true;
            groupBoxFunc.Location = new Point(4, 210);

            conn.Open();
            OracleCommand selectCRUD = conn.CreateCommand();
            selectCRUD.CommandText = "SELECT * FROM FUNCTIE";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            dataGridView1.Width = 460 ;
            conn.Close();

            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE FROM FUNCTIE",new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            stergereIdFunctie.DisplayMember = "ID_FUNCTIE";
            stergereIdFunctie.ValueMember = "ID_FUNCTIE";
            stergereIdFunctie.DataSource = dt;

        }

        private void btnProiecte_Click(object sender, EventArgs e)
        {

            groupBoxAng.Visible = false;
            groupBoxFunc.Visible = false;
            groupBoxProiecte.Visible = true;
            groupBoxProiecte.Location = new Point(4, 210);
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
            // Designer
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE "+
                "FROM FUNCTIE WHERE ID_FUNCTIE='DSG_LE')", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            proiectDesignerTxt.DisplayMember = "NUM";
            proiectDesignerTxt.ValueMember = "NUM";
            proiectDesignerTxt.DataSource = dt;

            OracleDataAdapter adapterr = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
               "FROM FUNCTIE WHERE ID_FUNCTIE='DSG_UI')", new OracleConnection(conStr));

            DataTable dtt = new System.Data.DataTable();
            adapterr.Fill(dtt);
            proiectUITxt.DisplayMember = "NUM";
            proiectUITxt.ValueMember = "NUM";
            proiectUITxt.DataSource = dtt;

            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
               "FROM FUNCTIE WHERE ID_FUNCTIE='DSG_SO')", new OracleConnection(conStr));

            DataTable dttt = new System.Data.DataTable();
            adapterrr.Fill(dttt);
            proiectSoundTxt.DisplayMember = "NUM";
            proiectSoundTxt.ValueMember = "NUM";
            proiectSoundTxt.DataSource = dttt;

            OracleDataAdapter adapterrrr = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
               "FROM FUNCTIE WHERE ID_FUNCTIE='DSG_WR')", new OracleConnection(conStr));

            DataTable dtttt = new System.Data.DataTable();
            adapterrrr.Fill(dtttt);
            proiectWriterTxt.DisplayMember = "NUM";
            proiectWriterTxt.ValueMember = "NUM";
            proiectWriterTxt.DataSource = dtttt;
            //Programmin
            OracleDataAdapter adapterR = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
               "FROM FUNCTIE WHERE ID_FUNCTIE='PRG_SR')", new OracleConnection(conStr));
            DataTable dtT = new System.Data.DataTable();
            adapterR.Fill(dtT);
            proiectProgTxt.DisplayMember = "NUM";
            proiectProgTxt.ValueMember = "NUM";
            proiectProgTxt.DataSource = dtT;

            OracleDataAdapter adapterRe = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
              "FROM FUNCTIE WHERE ID_FUNCTIE='PRG_EN')", new OracleConnection(conStr));
            DataTable dtTe = new System.Data.DataTable();
            adapterRe.Fill(dtTe);
            proiectEngineTxt.DisplayMember = "NUM";
            proiectEngineTxt.ValueMember = "NUM";
            proiectEngineTxt.DataSource = dtTe;

            OracleDataAdapter adapterReqa = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
              "FROM FUNCTIE WHERE ID_FUNCTIE='PRG_QA')", new OracleConnection(conStr));
            DataTable dtTeqa = new System.Data.DataTable();
            adapterReqa.Fill(dtTeqa);
            proiectQATxt.DisplayMember = "NUM";
            proiectQATxt.ValueMember = "NUM";
            proiectQATxt.DataSource = dtTeqa;

            OracleDataAdapter adapterReqad = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
              "FROM FUNCTIE WHERE ID_FUNCTIE='PRG_DE')", new OracleConnection(conStr));
            DataTable dtTeqad = new System.Data.DataTable();
            adapterReqad.Fill(dtTeqad);
            proiectDevelopTxt.DisplayMember = "NUM";
            proiectDevelopTxt.ValueMember = "NUM";
            proiectDevelopTxt.DataSource = dtTeqad;

            //Art
            OracleDataAdapter adapterRr = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
              "FROM FUNCTIE WHERE ID_FUNCTIE='ART_CO')", new OracleConnection(conStr));
            DataTable dtTt = new System.Data.DataTable();
            adapterRr.Fill(dtTt);
            proiectArtTxt.DisplayMember = "NUM";
            proiectArtTxt.ValueMember = "NUM";
            proiectArtTxt.DataSource = dtTt;

            OracleDataAdapter adapterRra = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
              "FROM FUNCTIE WHERE ID_FUNCTIE='ART_AR')", new OracleConnection(conStr));
            DataTable dtTta = new System.Data.DataTable();
            adapterRra.Fill(dtTta);
            proiect3DTxt.DisplayMember = "NUM";
            proiect3DTxt.ValueMember = "NUM";
            proiect3DTxt.DataSource = dtTta;

            OracleDataAdapter adapterRrav = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
              "FROM FUNCTIE WHERE ID_FUNCTIE='ART_VE')", new OracleConnection(conStr));
            DataTable dtTtav = new System.Data.DataTable();
            adapterRrav.Fill(dtTtav);
            proiectVisualTxt.DisplayMember = "NUM";
            proiectVisualTxt.ValueMember = "NUM";
            proiectVisualTxt.DataSource = dtTtav;

            OracleDataAdapter adapterRrava = new OracleDataAdapter("SELECT NUME || ' ' || PRENUME AS NUM FROM ANGAJAT WHERE FUNCTIE=(SELECT ID_FUNCTIE " +
              "FROM FUNCTIE WHERE ID_FUNCTIE='ART_AN')", new OracleConnection(conStr));
            DataTable dtTtava = new System.Data.DataTable();
            adapterRrava.Fill(dtTtava);
            proiectAnimTxt.DisplayMember = "NUM";
            proiectAnimTxt.ValueMember = "NUM";
            proiectAnimTxt.DataSource = dtTtava;
        }

        private void updateDatagridFunctie()
        {
            if (btnAdaugaFunctie != null)
            {
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
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE FROM FUNCTIE", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            stergereIdFunctie.DisplayMember = "ID_FUNCTIE";
            stergereIdFunctie.ValueMember = "ID_FUNCTIE";
            stergereIdFunctie.DataSource = dt;
        }
        private void btnAdaugaFunctie_Click(object sender, EventArgs e)
        {
            idFunctieTxt.Text = idFunctieTxt.Text.ToUpper();
            string id=idFunctieTxt.Text.ToString();
            int ok = 0;
            if (idFunctieTxt.Text.Length > 3)
            {
                for (int i = 0; i < id.Length; i++)
                {
                    if (id[3] == '_')
                        ok = 1;
                }
            }
            int sMIN= int.Parse(SalariuMinimtxt.Text.ToString());
            int sMax=int.Parse(salariuMaximTxt.Text.ToString());
            string x = id_nume_functie();
            string[] y=x.Split(',');
            if (y[0] == idFunctieTxt.Text.ToString())
            { MessageBox.Show("Aceast ID este deja folosit!"); }
            else if (y[1] == numeFunctieTxt.Text.ToString())
            { MessageBox.Show("Numele functiei este deja folosit!"); }
            else if (idFunctieTxt.Text == "" || idFunctieTxt.Text.Length > 6 || idFunctieTxt.Text.Length<3)
            {
                MessageBox.Show("ID-ul functiei are prea putine sau prea multe caractere!");
                idFunctieTxt.Focus();
            }
            else if(idFunctieTxt.Text.Length>3 && ok==0)
            {
                MessageBox.Show("ID-ul functiei trebuie sa contina caracterul _ dupa primele trei caractere!");
                idFunctieTxt.Focus();
            }
            else if(idFunctieTxt.Text.Length==4 || idFunctieTxt.Text.Length==5)
            {
                MessageBox.Show("Dupa caracterul _ ID-ul functiei trebuie sa contina doua caractere!");
                idFunctieTxt.Focus();
            }
            else if (numeFunctieTxt.Text == "" || numeFunctieTxt.Text.Length < 3 || numeFunctieTxt.Text.Length>30)
            {
                MessageBox.Show("Numele functiei are prea putine sau prea multe caractere!");
                numeFunctieTxt.Focus();
            }
            else if((int)sMIN<2000)
            { MessageBox.Show("Salariul minim este prea mic!"); }
            else if((int)sMIN>=(int)sMax)
            {
                MessageBox.Show("Salariul minim este mai mare sau egal decat salariul maxim!");
            }
            else
            {
                
                conn.Open();
                OracleCommand insertCRUD = conn.CreateCommand();

                insertCRUD.CommandText = "INSERT INTO FUNCTIE (ID_FUNCTIE,NUME_FUNCTIE,SALARIU_MINIM,SALARIU_MAXIM) VALUES(\'" +
               idFunctieTxt.Text.ToString() + "\',\'" + numeFunctieTxt.Text.ToString() + "\',\'" + SalariuMinimtxt.Text.ToString() + "\',\'" + salariuMaximTxt.Text.ToString() + "\')";
                insertCRUD.CommandType = CommandType.Text;
                int rows = insertCRUD.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
                updateDatagridFunctie();
            }
            
        }

        private string id_nume_functie()
        {
            string x = "";
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            salarMaxim.DisplayMember = null;
            salarMaxim.ValueMember = null;
            salarMaxim.DataSource = null;
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_FUNCTIE FROM FUNCTIE WHERE ID_FUNCTIE='" +
                idFunctieTxt.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            salarMinim.DisplayMember = "ID_FUNCTIE";
            salarMinim.ValueMember = "ID_FUNCTIE";
            salarMinim.DataSource = dt;

            OracleDataAdapter adapterR = new OracleDataAdapter("SELECT NUME_FUNCTIE FROM FUNCTIE WHERE NUME_FUNCTIE='" +
                numeFunctieTxt.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dTt = new System.Data.DataTable();
            adapterR.Fill(dTt);

            salarMaxim.DisplayMember = "NUME_FUNCTIE";
            salarMaxim.ValueMember = "NUME_FUNCTIE";
            salarMaxim.DataSource = dTt;
            x = salarMinim.Text.ToString() + "," + salarMaxim.Text.ToString();
            return x;
        }
        
        private void idFunctieTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar("_");
        }

        private void numeFunctieTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.Handled == char.IsWhiteSpace(e.KeyChar);
        }

        private void SalariuMinimtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void salariuMaximTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void btnStergereIdFun_Click(object sender, EventArgs e)
        {
            conn.Open();

            OracleCommand insert = conn.CreateCommand();
            int ok = 0;
            insert.CommandText = "UPDATE ANGAJAT SET FUNCTIE='PRG_QA' WHERE FUNCTIE='" + stergereIdFunctie.Text.ToString() + "'";
            insert.CommandType = CommandType.Text;
            int rows = insert.ExecuteNonQuery();
            if (rows > 0)
            {
                ok = 1;
            }
            conn.Close();

            conn.Open();
            OracleCommand deleteCRUD = conn.CreateCommand();
            deleteCRUD.CommandText = "DELETE FROM FUNCTIE WHERE ID_FUNCTIE = '" + stergereIdFunctie.Text.ToString() + "'";
            deleteCRUD.CommandType = CommandType.Text;
            rows = deleteCRUD.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("Functia cu ID-ul selectat a fost sters din baza de date!");
            }
            conn.Close();
            updateDatagridFunctie();
        }

        private void btnAdaugaProiect_Click(object sender, EventArgs e)
        {
            string x = "";
            salarMaxim.DisplayMember = null;
            salarMaxim.ValueMember = null;
            salarMaxim.DataSource = null;
            string conStrr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
            OracleDataAdapter adapterr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE WHERE NUME_PROIECT='" +
                numeProiectTxt.Text.ToString() + "'", new OracleConnection(conStrr));

            DataTable dtr = new System.Data.DataTable();
            adapterr.Fill(dtr);
            salarMaxim.DisplayMember = "NUME_PROIECT";
            salarMaxim.ValueMember = "NUME_PROIECT";
            salarMaxim.DataSource = dtr;
            x =salarMaxim.Text.ToString();
            if(x==numeProiectTxt.Text.ToString())
                MessageBox.Show("Numele proiectului este deja folosit!");
            else if (dateTimePicker2.Value.Date > dateTimePicker3.Value.Date)
                MessageBox.Show("Termenul limita nu poate sa fie mai devreme decat data de inceput a proiectului!");
            else if (dateTimePicker2.Value.Date == dateTimePicker3.Value.Date)
                MessageBox.Show("Termenul limita nu poate sa fie acelasi ca data de inceput a proiectului!");
            else if (proiectStadiuTxt.Text.ToString().Length < 1)
                MessageBox.Show("Selectati stadiul proiectului!");
            else
            {
                conn.Open();
                OracleCommand insertCRUD = conn.CreateCommand();
                string echip = echipa();
                insertCRUD.CommandText = "INSERT INTO PROIECTE (NUME_PROIECT,ECHIPA,DATA_START,TERMEN_LIMITA,STADIU_PROIECT) VALUES(\'" +
               numeProiectTxt.Text.ToString() + "\',\'" + echip + "\',\'" + dateTimePicker2.Value.Date.ToString("d") + "\',\'"
               + dateTimePicker3.Value.Date.ToString("d") + "\',\'" + proiectStadiuTxt.Text.ToString() + "\')";
                insertCRUD.CommandType = CommandType.Text;
                int rows = insertCRUD.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                }
                conn.Close();
                updateDatagridproiect();

                salarMinim.DisplayMember = null;
                salarMinim.ValueMember = null;
                salarMinim.DataSource = null;

                string[] ec=echip.Split(',');
                int n = ec.Length;
                int[] a= new int[n];
                for(int i=0;i<n;i++)
                    a[i] = int.Parse(ec[i]);
                conn.Open();
                OracleCommand insert = conn.CreateCommand();
                int ok = 0;    
                for(int i=0; i<n;i++)
                {
                    string pr = "";
                    string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                    OracleDataAdapter adapter = new OracleDataAdapter("SELECT PROIECTE FROM ANGAJAT WHERE ID_ANGAJAT='" +
                    a[i] +  "'", new OracleConnection(conStr));

                    DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    salarMinim.DisplayMember = "PROIECTE";
                    salarMinim.ValueMember = "PROIECTE";
                    salarMinim.DataSource = dt;
                    pr = salarMinim.Text.ToString();
                    if(pr.Length>0)
                    {
                        insert.CommandText = "UPDATE ANGAJAT SET PROIECTE='" + numeProiectTxt.Text.ToString() +","+pr +"'WHERE ID_ANGAJAT='" + a[i] + "'";
                        insert.CommandType = CommandType.Text;
                        rows = insert.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            ok = 1;
                        }
                    }
                    else
                    {
                        insert.CommandText = "UPDATE ANGAJAT SET PROIECTE='" + numeProiectTxt.Text.ToString() + "' WHERE ID_ANGAJAT='" + a[i] + "'";
                        insert.CommandType = CommandType.Text;
                        rows = insert.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            ok = 1;
                        }
                    }
                    
                }
                
                conn.Close();
            }
            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE", new OracleConnection(conStrr));

            DataTable dttr = new System.Data.DataTable();
            adapterrr.Fill(dttr);

            stergereNumeProiect.DisplayMember = "NUME_PROIECT";
            stergereNumeProiect.ValueMember = "NUME_PROIECT";
            stergereNumeProiect.DataSource = dttr;
        }
        private void updateDatagridproiect()
        {
            if (btnAdauga != null)
            {
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
            }
        }

        private string echipa()
        {
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            string[] nume;
            string echipa = "";
            if(proiectDesignerTxt.Text.ToString().Length>1)
            {
                nume = proiectDesignerTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectUITxt.Text.ToString().Length>=1)
            {
                nume = proiectUITxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if(echipa.Length>1)
                {
                    echipa=echipa +","+ salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectSoundTxt.Text.ToString().Length >= 1)
            {
                nume = proiectSoundTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectWriterTxt.Text.ToString().Length >= 1)
            {
                nume = proiectWriterTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectProgTxt.Text.ToString().Length >= 1)
            {
                nume = proiectProgTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectEngineTxt.Text.ToString().Length >= 1)
            {
                nume = proiectEngineTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectQATxt.Text.ToString().Length >= 1)
            {
                nume = proiectQATxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectDevelopTxt.Text.ToString().Length >= 1)
            {
                nume = proiectDevelopTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectArtTxt.Text.ToString().Length >= 1)
            {
                nume = proiectArtTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiect3DTxt.Text.ToString().Length >= 1)
            {
                nume = proiect3DTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectVisualTxt.Text.ToString().Length >= 1)
            {
                nume = proiectVisualTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            if (proiectAnimTxt.Text.ToString().Length >= 1)
            {
                nume = proiectAnimTxt.Text.ToString().Split(' ');
                string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT ID_ANGAJAT,NUME,PRENUME AS NUM FROM ANGAJAT WHERE NUME='" +
                    nume[0] + "' AND PRENUME='" + nume[1] + "'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                salarMinim.DisplayMember = "ID_ANGAJAT";
                salarMinim.ValueMember = "ID_ANGAJAT";
                salarMinim.DataSource = dt;
                if (echipa.Length > 1)
                {
                    echipa = echipa + "," + salarMinim.Text.ToString();
                }
                else echipa = salarMinim.Text.ToString();
            }
            salarMinim.DisplayMember = null;
            salarMinim.ValueMember = null;
            salarMinim.DataSource = null;
            return echipa;
        }

        private void CNPtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
        }

        private void btnStergereNumeProiect_Click(object sender, EventArgs e)
        {
            string conStr = "DATA SOURCE=localhost:1521/proiect;PASSWORD=hr;USER ID=HR";

            OracleDataAdapter adapterr = new OracleDataAdapter("SELECT ECHIPA FROM PROIECTE WHERE NUME_PROIECT = '" + stergereNumeProiect.Text.ToString() + "'", new OracleConnection(conStr));

            DataTable dtt = new System.Data.DataTable();
            adapterr.Fill(dtt);

            salarMinim.DisplayMember = "ECHIPA";
            salarMinim.ValueMember = "ECHIPA";
            salarMinim.DataSource = dtt;
            string ec=salarMinim.Text.ToString();
            string[] echipa=ec.Split(',');
            int[] a=new int[echipa.Length];
            for (int i = 0; i < echipa.Length; i++)
                a[i] = int.Parse(echipa[i]);
            for (int i=0; i<echipa.Length; i++)
            {
                salarMinim.DisplayMember = null;
                salarMinim.ValueMember = null;
                salarMinim.DataSource = null;
                string pr = "";
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT PROIECTE FROM ANGAJAT WHERE ID_ANGAJAT='" + a[i] +"'", new OracleConnection(conStr));

                DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);

                salarMinim.DisplayMember = "PROIECTE";
                salarMinim.ValueMember = "PROIECTE";
                salarMinim.DataSource = dt;
                pr= salarMinim.Text.ToString();
                List<string> values = pr.Split(',').ToList();
                values.Remove(stergereNumeProiect.Text.ToString());
                string result=String.Join(",", values);

                conn.Open();
                OracleCommand insert = conn.CreateCommand();

                insert.CommandText = "UPDATE ANGAJAT SET PROIECTE='" + result + "' WHERE ID_ANGAJAT='" + a[i] + "'";
                insert.CommandType = CommandType.Text;
                int rowss = insert.ExecuteNonQuery();
                if (rowss > 0)
                {
                    int ok = 0;
                }
                conn.Close();
            }

            conn.Open();
            OracleCommand deleteCRUD = conn.CreateCommand();
            deleteCRUD.CommandText = "DELETE FROM PROIECTE WHERE NUME_PROIECT = '" + stergereNumeProiect.Text.ToString() + "'";
            deleteCRUD.CommandType = CommandType.Text;
           int rows = deleteCRUD.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("Proiectul selectat a fost sters din baza de date!");
            }
            conn.Close();

           
            OracleDataAdapter adapterrr = new OracleDataAdapter("SELECT NUME_PROIECT FROM PROIECTE", new OracleConnection(conStr));

            DataTable dttr = new System.Data.DataTable();
            adapterrr.Fill(dttr);

            stergereNumeProiect.DisplayMember = "NUME_PROIECT";
            stergereNumeProiect.ValueMember = "NUME_PROIECT";
            stergereNumeProiect.DataSource = dttr;

            updateDatagridproiect();
        }
    }
}
