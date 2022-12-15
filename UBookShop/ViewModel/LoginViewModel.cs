using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UBookShop.Model;
using UBookShop.View;

namespace UBookShop.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        private string login;
        private string password;

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

        public ICommand SignIn => new RelayCommand(obj => CanLogin());

        private void CanLogin()
        {
            DB.getInstance();
            string query = "Exec FindUser '" + Login + "', '" + Password + "'";
            DB.SqlConnection.Open();
            if (DB.SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(query, DB.SqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object ID = reader["ID"];
                        object LName = reader["LName"];
                        object FName = reader["FName"];
                        object Password = reader["Password"];
                        object Phone = reader["Phone"];
                        object Email = reader["Email"];
                        object Flag = reader["Flag"];
                        object Username = reader["Username"];

                        Client.client.ID = Convert.ToInt32(ID);
                        Client.client.LName = LName.ToString();
                        Client.client.FName = FName.ToString();
                        Client.client.Password = password.ToString();
                        Client.client.Phone = Phone.ToString();
                        Client.client.Email = Email.ToString();
                        Client.client.Flag = Convert.ToInt32(Flag);
                        Client.client.Username = Username.ToString();
                    }

                    var main = new MainWindow();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
                reader.Close();
            }
            DB.SqlConnection.Close();
            
        }

        public ICommand RegisterCommand => new RelayCommand(obj => OpenRegister());

        private void OpenRegister()
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();
            
        }
    }
}
