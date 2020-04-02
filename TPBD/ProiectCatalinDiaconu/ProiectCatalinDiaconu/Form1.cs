using Oracle.ManagedDataAccess.Client;
using ProiectCatalinDiaconu.CrystalReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectCatalinDiaconu
{
    public partial class Form1 : Form
    {
        OracleConnection connection;
        OracleCommand query,query1;
        DataSet dataSet;
        OracleDataAdapter dataAdapter;
        BindingSource bindingSource = new BindingSource();
        OracleParameter p1, p2, p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14;

        string hashparola;
        string password_sql;
        string password;
        public Form1()
        {
            InitializeComponent();
            AllTabs.SelectedIndexChanged += new EventHandler(AllTabs_SelectedIndexChanged);
            this.KeyPreview = true;
            this.Text = "Diaconu Robert Catalin";
        }
        private void AllTabs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (AllTabs.SelectedTab == AllTabs.TabPages["iesireTab"])//your specific tabname
            {
                Application.Exit();
            }
            label21.Visible = false;
            label23.Visible = false;
            label22.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox1.Visible = false;
            textBox10.Visible = false;
            textBox2.Visible = false;
            label27.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox10.Visible = false;
            button6.Visible = false;
            button5.Visible = false;
            button10.Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataSet11BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void iesireTab_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.Visible = true;

                String str1,p1,p2,p3,p4,p5,p6;
                connection.Open();

                p1 = textBox1.Text.ToString();
                p2 = textBox2.Text.ToString();
                p3 = textBox3.Text.ToString();
                p4 = textBox4.Text.ToString();
                p5 = textBox5.Text.ToString();
                p6 = textBox6.Text.ToString();
               
                int salar, spor, premii;
                salar = Int32.Parse(p4);
                spor= Int32.Parse(p5);
                premii= Int32.Parse(p6);
                if (salar < 0)
                    label22.Visible = true;
                if (spor > 100 || spor < 0)
                    label21.Visible = true;
                if (premii < 0)
                    label23.Visible = true;

                str1 = " update angajati set PRENUME="+ "\'" + p2 + "\'"+"," +
                                             "FUNCTIE="+ "\'" + p3 + "\'" + "," +
                                             "SALAR_BAZA=" + salar + "," +
                                             "SPOR_P=" + spor + "," +
                                             "PREMII_BRUTE=" + premii +
                                             " WHERE NUME=" +"\'"+p1+"\'";
                query = new OracleCommand(str1, connection);
                    query.ExecuteNonQuery();
                /*dataAdapter = new OracleDataAdapter("select * from angajati", connection);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                         */
                connection.Close();
                MessageBox.Show("ok‐ actualizat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }        
    }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsLetter(e.KeyChar))
            {
                label22.Visible = true;

            }
            else { label22.Visible = false; }
            /* int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            */
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {        }
        int x = 0;
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            base.OnKeyPress(e);
            if (char.IsLetter(e.KeyChar))
            {
                label21.Visible = true;

            }
            else { label21.Visible = false; x++; }
            /* int isNumber = 0;
             e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);*/
            if (x>=3)
            {
                label21.Text = "dati un numar intre 0 si 100";
                label21.Visible = true;
            }
            else
            {
                label21.Visible = false;
            }
           
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsLetter(e.KeyChar))
            {
                label23.Visible = true;

            }
            else { label23.Visible = false; }
            /*int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);*/
        }
        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                String str1, p1, p2, p3, p4, p5, p6,count;
                connection.Open();

                p1 = textBox1.Text.ToString();
                p2 = textBox2.Text.ToString();

                str1 = "select count(*) from angajati WHERE NUME=" + "\'" + p1 + "\'" + " AND " + "PRENUME = " + "\'" + p2 + "\'";
                query = new OracleCommand(str1, connection);
             
                OracleDataReader reader = query.ExecuteReader();
                reader.Read();
                count = reader.GetValue(0).ToString();
                int coun1 = Int32.Parse(count);
                reader.Close();
                connection.Close();
                if (coun1 > 0)
                {
                    MessageBox.Show("ok‐ s-a gasit");
                    button10.Visible = true;
                }
                else
                { button10.Visible = false;
                    MessageBox.Show("nu s-a gasit");
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }

            try
            {
                String str1, p1, p2, p3, p4, p5, p6, count;
                connection.Open();

                p1 = textBox1.Text.ToString();
                p2 = textBox2.Text.ToString();

                str1 = "select * from angajati WHERE NUME=" + "\'" + p1 + "\'" + " AND " + "PRENUME = " + "\'" + p2 + "\'";
                query = new OracleCommand(str1, connection);

                OracleDataReader reader = query.ExecuteReader();
                reader.Read();

               textBox1.Text = reader.GetValue(1).ToString();
                textBox2.Text = reader.GetValue(2).ToString();
                textBox3.Text = reader.GetValue(3).ToString();
                textBox4.Text = reader.GetValue(4).ToString();
                textBox5.Text = reader.GetValue(5).ToString();
                textBox6.Text = reader.GetValue(6).ToString();

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }

         
}

        private void button4_Click(object sender, EventArgs e)
        {
            crvViewer.Visible = true;
            CrystalReportWork cr = new CrystalReportWork();
            //cr.Load(Server.MapPath("~/ERPSolution-NL/Admin_Reports/CR/myReport.rpt"));
            connection.Open();
            string str;
            str = "SELECT * FROM angajati";
            dataSet = new DataSet();
            dataAdapter = new OracleDataAdapter(str, connection);
            dataAdapter.Fill(dataSet, "angajati");
            cr.Load(@"D:\Desktop\TPBD\ProiectCatalinDiaconu\ProiectCatalinDiaconu\CrystalReports\CrystalReportWork.rpt");
            cr.SetDataSource(dataSet.Tables["angajati"]);
            crvViewer.ReportSource = cr;
            crvViewer.Refresh();
            connection.Close();
            frvViewer.Visible = false;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            frvViewer.Visible = true;
            FluturasiReport fr = new FluturasiReport();
            //cr.Load(Server.MapPath("~/ERPSolution-NL/Admin_Reports/CR/myReport.rpt"));
            connection.Open();
            string str;
            str = "SELECT * FROM angajati";
            dataSet = new DataSet();
            dataAdapter = new OracleDataAdapter(str, connection);
            dataAdapter.Fill(dataSet, "angajati");
            fr.Load(@"D:\Desktop\TPBD\ProiectCatalinDiaconu\ProiectCatalinDiaconu\CrystalReports\FluturasiReport.rpt");
            fr.SetDataSource(dataSet.Tables["angajati"]);
            frvViewer.ReportSource = fr;
            frvViewer.Refresh();
            connection.Close();
            crvViewer.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                String str1, p1, p2, p3, p4, p5;
                connection.Open();

                p1 = textBox7.Text.ToString();
                p2 = textBox8.Text.ToString();
                p3 = textBox9.Text.ToString();
                int cas, cass, impozit;
               cas = Int32.Parse(p2);
                cass = Int32.Parse(p3);
                impozit = Int32.Parse(p1);

                str1 = " update taxe set CAS_P=" + cas + "," +
                                             "CASS_P=" + cass + "," +
                                             "IMPOZIT_P=" + impozit;
                query = new OracleCommand(str1, connection);
                query.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("ok‐ actualizat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }
           /* connection.Open();
            string str2;
            str2 = "insert into angajati values(1, 'random_row_inserted', 'Andrei', 'cosmonaut', 2000, 10, 0, 20, 20, 10, 20, 1, 20, 40)";
            query = new OracleCommand(str2, connection);
            query.ExecuteNonQuery();
            connection.Close();
            connection.Open();
            str2 = "delete from angajati where nume='random_row_inserted'";
            query = new OracleCommand(str2, connection);
            query.ExecuteNonQuery();
            connection.Close();*/
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.angajatiTableAdapter1.FillBy(this.dataSet11.ANGAJATI);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            try
            {
                String str1, p1, p2, p3, p4, p5, p6;
                connection.Open();

                p1 = textBox1.Text.ToString();
                p2 = textBox2.Text.ToString();

                str1 = "delete from angajati WHERE NUME=" + "\'" + p1 + "\'" + " AND " + "PRENUME = " + "\'" + p2 + "\'";
                query = new OracleCommand(str1, connection);
                query.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("ok‐ sters");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //label24.Visible = true;
            //label25.Visible = true;
            MessageBox.Show("ok-modificat");

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void label10_Click(object sender, EventArgs e)
        {
        }
        private void label12_Click(object sender, EventArgs e)
        {
        }
        private void label15_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label27.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            textBox1.Visible = true;
            textBox10.Visible = true;
            textBox2.Visible = true;
            button5.Visible = true;
            label13.Visible = true;

            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button6.Visible = false;
            button5.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button7.Visible = false;
            button10.Visible = false;
        }
        private void introducereDateTab_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label27.Visible = true;
            button7.Visible = false;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button5.Visible = false;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button6.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button10.Visible = false;
            textBox10.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label27.Visible = false;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button5.Visible = false;
            label13.Visible = false;

            textBox10.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button6.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button7.Visible = true;
            button10.Visible = true;
        }
        private void modificareProcenteTab_Click(object sender, EventArgs e)
        {
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                AllTabs.SelectedTab = introducereDateTab;
                button1.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.U)
            {
                AllTabs.SelectedTab = introducereDateTab;
                button2.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                AllTabs.SelectedTab = introducereDateTab;
                button3.PerformClick();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=catalin;PERSIST SECURITY INFO=True;USER ID=TPBD");
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu se poate conecta la BD" + ex.ToString());
                this.Close();
            }
            try
            {
                connection.Open();
                string selectQuery = "Select * from taxe";
                query = new OracleCommand(selectQuery, connection);

                OracleDataReader reader = query.ExecuteReader();
                reader.Read();
                password_sql = reader.GetValue(3).ToString();
                reader.Close();
                connection.Close();
            }
            catch (Exception exa)
            {
                MessageBox.Show("nu se poate citi din BD" + exa.ToString());
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String str;
                connection.Open();
                p1 = new OracleParameter();
                p2 = new OracleParameter();
                p3 = new OracleParameter();
                p4 = new OracleParameter();
                p5 = new OracleParameter();
                p6 = new OracleParameter();
                p7 = new OracleParameter();
                p8 = new OracleParameter();
                p9 = new OracleParameter();
                p10 = new OracleParameter();
                p11 = new OracleParameter();
                p12 = new OracleParameter();
                p13 = new OracleParameter();
                p14 = new OracleParameter();

                p1.Value = textBox1.Text;
                p2.Value = textBox2.Text;
                p3.Value = textBox3.Text;
                p4.Value = textBox4.Text;
                p5.Value = textBox5.Text;
                p6.Value = textBox6.Text;
                p7.Value = 1;
                p8.Value = 1;
                p9.Value = 1;
                p10.Value = 1;
                p11.Value = 1;
                p12.Value = 1;
                p13.Value = 1;
                p14.Value = 1;
                
                str = "insert into angajati values(:1,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14)";
                query = new OracleCommand(str, connection);
                query.Parameters.Add(p7);
                query.Parameters.Add(p1);
                query.Parameters.Add(p2);
                query.Parameters.Add(p3);
                query.Parameters.Add(p4);
                query.Parameters.Add(p5);
                query.Parameters.Add(p6);
                query.Parameters.Add(p8);
                query.Parameters.Add(p9);
                query.Parameters.Add(p10);
                query.Parameters.Add(p11);
                query.Parameters.Add(p12);
                query.Parameters.Add(p13);
                query.Parameters.Add(p14);
                query.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("ok‐ adaugat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.ToString());
            }
        }
    }
}
