using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class RegistrationForm : System.Windows.Forms.Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }



        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        private bool ShowError(string message)
        {
            MessageBox.Show(message);
            return false;
        }


        private bool ValidateFrom()
        {
            if (string.IsNullOrEmpty(txtB1.Text))
            {
                return ShowError("Введите логин");
            }
            if (txtB2.Text.Length < 6)
            {
                return ShowError("Пароль минимум");
            }
            if (txtB2.Text.Length != txtB3.Text.Length)
            {
                return ShowError("Пароли не совпадают");
            }
            if (!IsValidEmail(txtB4.Text))
            {
                return ShowError("Не коректный email");
            }

            return true;
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn1_Click_1(object sender, EventArgs e)
        {
            string login = txtB1.Text;
            string password = txtB2.Text;
            string email = txtB4.Text;
            if (ValidateFrom())
            {
                string responce =  Program.connection.Send($"REGISTER|{login}|{password}|{email}");
                switch (responce)
                {
                    case "SUCCESS":
                        this.Close();
                        break;
                    case "USER_EXISTS":
                        MessageBox.Show("Пользовать уже существует");
                        break;
                    default:
                        MessageBox.Show("Ошибка регистрации");
                        break;
                }
            }
        }
    }
}
