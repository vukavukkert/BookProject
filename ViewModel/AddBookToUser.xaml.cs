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

namespace BookProject.ViewModel
{
    /// <summary>
    /// Interaction logic for AddBookToUser.xaml
    /// </summary>
    public partial class AddBookToUser : UserControl
    {
        private List<User> users;

        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                UserComboBox.ItemsSource = users;
            }
        }
        private List<Book> books;

        public List<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                BookComboBox.ItemsSource = books;
            }
        }

        public AddBookToUser()
        {
            InitializeComponent();
            UserComboBox.SelectedIndex = 0;
            BookComboBox.SelectedIndex = 0;
            UpdateMessage();
        }

        private void UserComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserComboBox.SelectedItem is User user)
            {
                UserBookListView.ItemsSource = user.Books;
                UpdateMessage();
            }
        }

        private void BookComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookComboBox.SelectedItem is Book book)
            {
                UpdateMessage();
            }
        }

        private void GiveBook(object sender, RoutedEventArgs e)
        {
            if ((UserComboBox.SelectedItem as User) != null && (BookComboBox.SelectedItem as Book) != null)
            {
                if ((BookComboBox.SelectedItem as Book).Amount > 0)
                {
                    (UserComboBox.SelectedItem as User).Books.Add(BookComboBox.SelectedItem as Book);
                    (BookComboBox.SelectedItem as Book).Amount--;
                }
                else
                {
                    MessageBox.Text = "Book is out of stock.";
;                }
                UserBookListView.Items.Refresh();
            }
        }

        private void UpdateMessage()
        {
            if ((UserComboBox.SelectedItem as User) != null && (BookComboBox.SelectedItem as Book) != null)
            {
                MessageBox.Text =
                    $" Add {(BookComboBox.SelectedItem as Book).Title} to {(UserComboBox.SelectedItem as User).ToString()}'s library?";
            }
        }
           
    }
}
