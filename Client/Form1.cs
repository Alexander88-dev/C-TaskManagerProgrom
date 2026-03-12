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
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
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

        private async void btn_Click(object sender, EventArgs e)
        {
            string login = txtB1.Text;
            string password = txtB2.Text;

            string response = await Program.connection.SendAsync($"LOGIN|{login}|{password}");

            switch (response)
            {
                case "NOT_FOUND":
                    MessageBox.Show("Не найден пользователь с таким логином");
                    break;
                case "WRONG_PASSWORD":
                    MessageBox.Show("Найден пользователь, но не верный пароль");
                    break;
                case "SUCCESS":
                    MainForm mainForm = new MainForm();

                    mainForm.FormClosing += (s, args) =>
                    {
                        this.Show();
                        txtB2.Clear();
                    };

                    mainForm.Show();
                    this.Hide();
                    
                    break;
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.FormClosing += (s, args) =>
            {
                this.Show();
                txtB1.Clear();
                txtB2.Clear();
            };
            registrationForm.Show();
            this.Hide();
        }
    }
}
