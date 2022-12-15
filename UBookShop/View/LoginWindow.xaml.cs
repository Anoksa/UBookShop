using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UBookShop.ViewModel;
using UBookShop.Model;

namespace UBookShop.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
                if (DataContext != null)
                { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }

        private void RegisterBt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow window = new RegisterWindow();
            window.Show();
        }

        private void RegisterBt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow w = new RegisterWindow();
            w.Show();
        }

        private void SignInBT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
