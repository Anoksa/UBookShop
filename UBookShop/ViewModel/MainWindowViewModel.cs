using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UBookShop.Model;
using UBookShop.View;

namespace UBookShop.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public ObservableCollection<Cart> Carts { get; set; } = new ObservableCollection<Cart>();

        private void Load()
        {
            DB.getInstance();

            string sqlExpression = "select * from BookSummary";

            if (DB.SqlConnection.State != System.Data.ConnectionState.Open)
            {
                DB.SqlConnection.Open();
            }

            if (DB.SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(sqlExpression, DB.SqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object id = reader["ID"];
                        object title = reader["Title"];
                        object categori = reader["CategoriName"];
                        object lName = reader["LName"];
                        object fName = reader["FName"];
                        object mName = reader["MName"];
                        object pName = reader["PName"];
                        object publYear = reader["Publ_Year"];
                        object price = reader["Price"];


                        string author = lName.ToString() + " " + fName.ToString() + " " + mName.ToString();

                        Books.Add(new Book(Convert.ToInt32(id), title.ToString(), categori.ToString(), author, pName.ToString(), Convert.ToInt32(publYear), float.Parse(price.ToString())));
                        
                    }
                }
                reader.Close();
            }
            DB.SqlConnection.Close();
        }

        public MainWindowViewModel()
        {
            Load();
        }

        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                
            }
        }

        public ICommand LoginCommand => new RelayCommand(obj => OpenLoginWindow());

        private void OpenLoginWindow()
        {
            var LoginW = new LoginWindow();
            LoginW.Show();
            var main = new MainWindow();
            main.Close();
        }

        public ICommand AddBookCommand => new RelayCommand(obj => OpenAddBookWindow());

        private void OpenAddBookWindow()
        {
            
            var addBook = new AddBookWindow();
            addBook.Show();
            
        }

        public ICommand AddToCart => new RelayCommand(obj => AddBookToCart());

        private void AddBookToCart()
        {
            int quantity = 1;

            foreach (var book in Carts)
            {
                if (selectedBook.ID == book.ID)
                {
                    quantity += 1;
                    Carts.Remove(book);
                    break;
                }
            }

            Carts.Add(new Cart(selectedBook.ID, selectedBook.Title, selectedBook.Categories, selectedBook.Author, selectedBook.Publish, selectedBook.PublYear, selectedBook.Price, quantity));
        }

        public ICommand BuyCommand => new RelayCommand(obj => BuyBooks());
        private void BuyBooks()
        {
            DateTime date = DateTime.Now;
            float tSum = 0;
            foreach (var book in Carts)
            {
                tSum += book.Price * book.Quantity;
            }

            try
            {
                DB.SqlConnection.Open();
                SqlCommand command = DB.SqlConnection.CreateCommand();
                command.CommandText = "Exec CreateOrder '" + date.ToString("dd/MM/yyyy hh:mm:ss") + "', " + Client.client.ID + ", '" + Convert.ToDecimal(tSum)+"'";
                command.ExecuteNonQuery();

                SqlCommand command1 = DB.SqlConnection.CreateCommand();
                command1.CommandText = "Exec FindOrderID '" + date.ToString("dd/MM/yyyy hh:mm:ss") + "'";
                var id = command1.ExecuteScalar();
                MessageBox.Show((Convert.ToInt32(id)).ToString());

                foreach (var book in Carts)
                {
                    SqlCommand command2 = DB.SqlConnection.CreateCommand();
                    command2.CommandText = "Exec CreateBookOrder " + Convert.ToInt32(id) + ", " + book.ID + ", " + book.Quantity;
                    command2.ExecuteNonQuery();
                }
                MessageBox.Show("Заказ оформлен");
                DB.SqlConnection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
