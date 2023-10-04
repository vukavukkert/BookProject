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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookProject.ViewModel;

namespace BookProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> books;
        private  List<User> users;

        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            

            books = new List<Book>()
            {
                new Book("Anime book about anime","Chris Chan", 111,DateTime.Now,2),
                new Book("House of leaves","Mark Danielewski", 121,DateTime.Now,5),
                new Book("Mechanics journal", "Spiffo Zomboid", 132,DateTime.Now,24),
                new Book("Cats are kinda not as cute as everybody thinks","Awful Person", 145,DateTime.Now,1),
                new Book("Boring circles", "God", 142,DateTime.Now,0)

            };
            users = new List<User>()
            {
                new User("Alex","Hist",0),
                new User("Lee","Breasts", 1),
                new User("David","Stidin", 2),
                new User("Marrow","Loomin", 3),
                new User("Goober","Fisher", 4),
            };
            SetUpUserPage();
        }

        private void Menu_Button_OnClick(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "MenuUser": 
                    SetUpUserPage();
                    return;
                case "MenuBook":
                    SetUpBookPage();
                    return;
                case "MenuUserBook": 
                    SetUpUserBookPage();
                    return;
            }
        }

        public void SetUpUserPage()
        {
            MyContentControl.Content = new UserList();
            (MyContentControl.Content as UserList).List = users;
        }

        public void SetUpBookPage()
        {
            MyContentControl.Content = new BookList();
            (MyContentControl.Content as BookList).List = books;
        }

        public void SetUpUserBookPage()
        {
            MyContentControl.Content = new AddBookToUser();
            (MyContentControl.Content as AddBookToUser).Books = books;
            (MyContentControl.Content as AddBookToUser).Users = users;
        }
    }
}
