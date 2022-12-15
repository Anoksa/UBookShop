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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UBookShop.Model;
using UBookShop.ViewModel;

namespace UBookShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

            if (Client.client.Flag == 1)
            {
                AddBookBT.Visibility = Visibility.Visible;
                LoginBt.Visibility = Visibility.Hidden;
                CartList.Visibility = Visibility.Hidden;
                BuyBT.Visibility = Visibility.Hidden;
                AddToCartBT.Visibility = Visibility.Hidden;
            }
            else if(Client.client.Flag == 2)
            {
                AddToCartBT.Visibility = Visibility.Visible;
                BuyBT.Visibility = Visibility.Visible;
                LoginBt.Visibility = Visibility.Hidden;
                AddBookBT.Visibility = Visibility.Hidden;
                
            }
            else
            {
                AddBookBT.Visibility = Visibility.Hidden;
                AddToCartBT.Visibility = Visibility.Hidden;
                BuyBT.Visibility = Visibility.Hidden;
                LoginBt.Visibility = Visibility.Visible;
                CartList.Visibility = Visibility.Hidden;
            }
            
        }

        private void LoginBt_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void AddBookBT_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
        }
    }
}
