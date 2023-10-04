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
    /// Interaction logic for BookList.xaml
    /// </summary>
    public partial class BookList : UserControl
    {
        private List<Book> _list;

        public List<Book> List
        {
            get { return _list; }
            set
            {
                _list = value;
                BookListView.ItemsSource = _list;
            }
        }

        public BookList()
        {
            InitializeComponent();
        }

        private void BookListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookListView.SelectedItem != null)
            {
                var book = BookListView.SelectedItem as Book;
                BookTitle.Text = book.Title;
                BookAuthor.Text = book.Author;
                BookDate.Text = book.ReleaseDate.ToString();
                BookAmount.Text = book.Amount.ToString();
                BookId.Text = book.Id.ToString();
            }
        }

        private void SearchBox_Enter(object sender, KeyEventArgs e)
        {
                SearchBoxResult();
        }

        private void SearchBoxResult()
        {
            if (SearchBox.Text.Length != 0)
            {
                string key  = SearchBox.Text.ToLower();
                var sortedList = new List<Book>();
                foreach (var book in List)
                {
                    if (book.Title.ToLower().Contains(key) || (book.Author.ToLower().Contains(key)) || (book.Id.ToString().ToLower().Contains(key)))
                    {
                        sortedList.Add(book);
                    }
                }

                BookListView.ItemsSource = sortedList;
            }
            else
            {
                BookListView.ItemsSource = List;
            }
        }
    }
}
