using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectCatalinDiaconu
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
            this.Text = "Diaconu Robert Catalin";
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.CompareTo("parola") == 0)
            {
                label2.Visible = true;
                label3.Visible = false;

                Form1 frm = new Form1();
                frm.Show();

            }
            else
            {
                label3.Visible = true;
                label2.Visible = false;
            }
        }
    }
}
