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
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
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
        }

        public void SetUpBookPage()
        {
            MyContentControl.Content = new BookList();
        }

        public void SetUpUserBookPage()
        {
            MyContentControl.Content = new AddBookToUser();
        }
    }
}
