using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UBookShop.Model;

namespace UBookShop.ViewModel
{
    class RegisterViewModel : ViewModelBase
    {
        private string lName;
        private string fName;
        private string login;
        private string password;
        private string phone;
        private string email;

        public string LName
        {
            get => lName;
            set
            {
                lName = value;
                OnPropertyChanged("LName");
            }
        }

        public string FName
        {
            get => fName;
            set
            {
                fName = value;
                OnPropertyChanged("FName");
            }
        }

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            private get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public ICommand SignUp => new RelayCommand(obj => CanSignUp());

        private void CanSignUp()
        {
            if (CheckField())
            {
                DB.SqlConnection.Open();
                SqlCommand command = DB.SqlConnection.CreateCommand();
                command.CommandText = "Exec SignUpUser '" + LName.Trim() + "', '" + FName + "', '" + Password + "', '" + Phone + "', '" + Email + "', '" + Login + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Пользователь зарегистрирован");
                DB.SqlConnection.Close();
            }
        }


        private bool CheckField()
        {

            if(LName == null)
            {
                MessageBox.Show("Введите фамилию!");
                return false;
            } 
            else if (FName == null)
            {
                MessageBox.Show("Введите имя!");
                return false;
            } 
            else if (Login == null)
            {
                MessageBox.Show("Введите логин!");
                return false;
            }
            else if(Password == null)
            {
                MessageBox.Show("Введите пароль!");
                return false;
            } 
            else if(Phone == null)
            {
                MessageBox.Show("Введите номер телефона!");
                return false;
            } 
            else if (Email == null)
            {
                MessageBox.Show("Введите почту!");
                return false;
            }

            if(!Validator.CheckUserEmail(Email))
            {
                MessageBox.Show("Введён некорректный адрес почты");
                return false;
            }
            
            if(!Validator.CheckUserLogin(Login))
            {
                MessageBox.Show("Введён некорректный логин");
                return false;
            }
            if(!Validator.CheckUserPassword(Password))
            {
                MessageBox.Show("Введен некооректный пароль!\nПароль должен содержать символы английского алфавита или цифры.");
                return false;
            }

            return true;
        }
    }
}
