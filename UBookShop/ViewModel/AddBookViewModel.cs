using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UBookShop.Model;

namespace UBookShop.ViewModel
{
    public class AddBookViewModel : ViewModelBase
    {
        public ObservableCollection<Categori> Categories { get; set; } = new ObservableCollection<Categori>();
        private void LoadCategories()
        {
            DB.getInstance();
            string sqlExpression = "select * from Categories";

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
                        object categori = reader["CategoriName"];

                        Categories.Add(new Categori(Convert.ToInt32(id), categori.ToString()));
                    }
                }
                reader.Close();
            }
            DB.SqlConnection.Close();
        }

        public ObservableCollection<Author> Authors { get; set; } = new ObservableCollection<Author>();
        private void LoadAuthors()
        {
            DB.getInstance();
            string sqlExpression = "select * from Authors";

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
                        object lName = reader["LName"];
                        object fName = reader["FName"];
                        object mName = reader["MName"];
                        object bDate = reader["BDate"];

                        string author = lName.ToString() + " " + fName.ToString() + " " + mName.ToString();

                        Authors.Add(new Author(Convert.ToInt32(id), author, Convert.ToDateTime(bDate)));
                    }
                }
                reader.Close();
            }
            DB.SqlConnection.Close();
        }

        public ObservableCollection<Publisher> Publishers { get; set; } = new ObservableCollection<Publisher>();
        private void LoadPublishers()
        {
            DB.getInstance();
            string sqlExpression = "select * from Publisher";

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
                        object pName = reader["PName"];

                        Publishers.Add(new Publisher(Convert.ToInt32(id), pName.ToString()));
                    }
                }
                reader.Close();
            }
            DB.SqlConnection.Close();
        }

        public AddBookViewModel()
        {
            LoadCategories();
            LoadAuthors();
            LoadPublishers();
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private int selectedCategory;
        public int SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private int selectedAuthor;
        public int SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                selectedAuthor = value;
                OnPropertyChanged("SelectedAuthor");
            }
        }

        private int selectedPublisher;
        public int SelectedPublisher
        {
            get => selectedPublisher;
            set
            {
                selectedPublisher = value;
                OnPropertyChanged("SelectedPublisher");
            }
        }

        private int publYear;
        public int PublYear
        {
            get => publYear;
            set
            {
                publYear = value;
                OnPropertyChanged("PublYear");
            }
        }

        private int price;
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public ICommand AddBook => new RelayCommand(obj => AddNewBook());

        private void AddNewBook()
        {
            if (CheckFields())
            {
                DB.SqlConnection.Open();
                SqlCommand command = DB.SqlConnection.CreateCommand();
                command.CommandText = "Exec AddBook '" + Title.Trim() + "', " + selectedCategory + ", " + selectedAuthor  + ", " + selectedPublisher + ", " + publYear + ", " + price;
                command.ExecuteNonQuery();
                MessageBox.Show("Книга добавлена");
                DB.SqlConnection.Close();
                title = "";
                publYear = 0;
                price = 0;

            }

        }

        private bool CheckFields()
        {
           
            if (!Validator.CheckTitle(Title))
            {
                MessageBox.Show("Введено некорректное название");
                return false;
            }

            if (!Validator.CheckPublYear(PublYear))
            {
                MessageBox.Show("Введен некоректный год издания");
                return false;
            }

            if (!Validator.CheckPrice(Price))
            {
                MessageBox.Show("Введена некорректная цена");
                return false;
            }

            return true;
        }
    }
}
