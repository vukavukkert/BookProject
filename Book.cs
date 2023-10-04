using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookProject
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public short Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Amount { get; set; }

        public Book(string title, string author, short id, DateTime releaseDate, int amount)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Amount = amount;
            Id = id;
        }

        public override string ToString() => $"{Title} ({Author})";
    }
}

