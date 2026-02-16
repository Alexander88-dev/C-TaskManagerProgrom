using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
            //switch () 
            //{
            //    case 1:
                    
            //    case 2:
                    
            //    case 3:
                    
            //        break;
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestAddForm requestAddForm = new RequestAddForm();

            requestAddForm.FormClosing += (s, args) =>
            {
                this.Show();
            };

            requestAddForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestStatus requestStatus = new RequestStatus();

            requestStatus.FormClosing += (s, args) =>
            {
                this.Show();
            };

            requestStatus.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditingAccountForm editingAccountForm = new EditingAccountForm();

            editingAccountForm.FormClosing += (s, args) =>
            {
                this.Show();
            };

            editingAccountForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QueriesForm queriesForm = new QueriesForm();

            queriesForm.FormClosing += (s, args) =>
            {
                this.Show();
            };

            queriesForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditingAccountForm editingAccountForm = new EditingAccountForm();
             
            editingAccountForm.FormClosing += (s, args) =>
            {
                this.Show();
            };

            editingAccountForm.Show();
            this.Hide();
        }
    }
}
