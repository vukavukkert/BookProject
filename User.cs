using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
{
    /// <summary>
    /// User class
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        #region Properties

        

        private int id { get; set; }
        private string name { get; set; }
        private string lastName { get; set; }
        private ObservableCollection<Book> books { get; set; }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public ObservableCollection<Book> Books
        {
            get { return books;}
            set
            {
                books = value;
                OnPropertyChanged("Books");
            }
        }
        #endregion

        /// <summary>
        /// User Constructor
        /// </summary>
        public User(string name, string lastName, int id)
        {
            Name = name;
            LastName = lastName;
            Id = id;
            Books = new ObservableCollection<Book>();
        }

        /// <summary>
        /// Add Book to User
        /// </summary>
        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public override string ToString() => $"{Name} {LastName}";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
