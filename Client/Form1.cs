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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.connection.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string login = txtB1.Text;
            string passwoed = txtB2.Text;

            string responce = Program.connection.Send($"LOGIN|{login}|{passwoed}");
            switch (responce) 
            {
                case "NOT_FOUND":
                    MessageBox.Show("Не введёт логин");
                    break;
                case "WRONG_PASSWORD":
                    MessageBox.Show("Не введёт пароль");
                    break;
                case "SUCCESS":
                    MessageBox.Show("Вход испешен");
                    break;
            }
        }
    }
}
