using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }

        public User(string name, string lastName, int id)
        {
            Name = name;
            LastName = lastName;
            Id = id;
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public override string ToString() => $"{Name} {LastName}";

    }
}
