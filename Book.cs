using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookProject
{
    public class Book : INotifyPropertyChanged
    {
        private string title { get; set; }
        private string author { get; set; }
        private short id { get; set; }
        private DateTime releaseDate { get; set; }
        private int amount { get; set; }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        public short Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public Book(string title, string author, short id, DateTime releaseDate, int amount)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Amount = amount;
            Id = id;
        }

        public override string ToString() => $"{Title} ({Author})";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

