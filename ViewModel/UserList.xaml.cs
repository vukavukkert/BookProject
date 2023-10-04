using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
  
    public partial class UserList : UserControl
    {
        private List<User> _list;

        public List<User> List
        {
            get { return _list; }
            set
            {
                _list = value;
                UserListView.ItemsSource = _list;
            }
        }

        public UserList()
        {
            InitializeComponent();
        }
        private void UserListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserListView.SelectedItem != null)
            {
                var user = UserListView.SelectedItem as User;
                userName.Text = user.Name;
                userLastName.Text = user.LastName;
                userId.Text = user.Id.ToString();
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
                string key = SearchBox.Text.ToLower();
                var sortedList = new List<User>();
                foreach (var user in List)
                {
                    if (user.Name.ToLower().Contains(key) || (user.LastName.ToLower().Contains(key)) || (user.Id.ToString().ToLower().Contains(key)))
                    {
                        sortedList.Add(user);
                    }
                }

                UserListView.ItemsSource = sortedList;
            }
            else
            {
                UserListView.ItemsSource = List;
            }
        }
        
    }
}
