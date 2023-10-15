using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        

        private Book selectedBook;
        private User selectedUser;
        private string textBox;
        private ObservableCollection<Book> books { get; set; } 
        private ObservableCollection<User> users { get; set; }

        private string messageBox;

        public string MessageBox
        {
            get { return messageBox; }
            set 
            {
                messageBox = value;
                if (selectedBook != null)
                {
                    if (selectedBook.Amount > 0)
                    {
                        messageBox = $"Add {SelectedBook} to {SelectedUser}'s library?";
                    }
                    else
                    {
                        messageBox = "Out of stock!";
                    }
                    OnPropertyChanged("MessageBox");
                }
                

            }
        }

        public ObservableCollection<Book> Books
        {
            get
            {
                if (books == null)
                {
                    books = new ObservableCollection<Book>();
                }
                return books;
            }
            set
            {
                books = value;
                OnPropertyChanged("Books");
            }
        } //shows in the view

        public ObservableCollection<Book> constBooks { get;} // constant list of books, constant

        public ObservableCollection<User> Users
        {
            get 
            {
                if (users == null)
                {
                    users = new ObservableCollection<User>();
                }
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }

        }
        public ObservableCollection<User> constUsers { get;}

        public string TextBox
        {
            get
            {
                return textBox;
            }
            set
            {
                textBox = value;
                OnPropertyChanged("TextBox");
            }
        }
        private RelayCommand sortList;
        public RelayCommand SortList
        {
            get
            {
                return sortList ??
                       (sortList = new RelayCommand(obj =>
                           {
                               if ((obj as ObservableCollection<Book>) != null)
                               {
                                   Books = SortedList<Book>.SearchCollection(TextBox, constBooks);
                               }
                               if ((obj as ObservableCollection<User>) != null)
                               {
                                   Users = SortedList<User>.SearchCollection(TextBox, constUsers);
                               }
                           },
                           (obj) => TextBox != " "));
            }
        }

        private RelayCommand addBook;
        public RelayCommand AddBook
        {
            get
            {
                return addBook ??
                       (addBook = new RelayCommand(obj =>
                       {
                               selectedBook.Amount--;
                               selectedUser.Books.Add(selectedBook);
                               MessageBox = "";
                       },
                           (obj)=> selectedBook.Amount > 0));
            }
        }

        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set { selectedBook = value; OnPropertyChanged("SelectedBook");
                MessageBox = "";
            }
        }
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set { selectedUser = value; OnPropertyChanged("SelectedUser"); MessageBox = ""; }
        }

        public ApplicationViewModel()
        {
            constBooks = new ObservableCollection<Book>()
            {
                new Book("Anime book about anime","Chris Chan", 111,DateTime.Now,2),
                new Book("House of leaves","Mark Danielewski", 121,DateTime.Now,5),
                new Book("Mechanics journal", "Spiffo Zomboid", 132,DateTime.Now,24),
                new Book("Cats are kinda not as cute as everybody thinks","Awful Person", 145,DateTime.Now,1),
                new Book("Boring circles", "God", 142,DateTime.Now,0)

            };
            Books = constBooks;
            constUsers = new ObservableCollection<User>()
            {
                new User("Alex","Hist",0),
                new User("Lee","Breasts", 1),
                new User("David","Stidin", 2),
                new User("Marrow","Loomin", 3),
                new User("Goober","Fisher", 4),
            };
            Users = constUsers;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
