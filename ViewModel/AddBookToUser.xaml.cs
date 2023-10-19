using System.Windows.Controls;

namespace BookProject.ViewModel
{
    /// <summary>
    ///     Interaction logic for AddBookToUser.xaml
    /// </summary>
    public partial class AddBookToUser : UserControl
    {
        public AddBookToUser()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
    }
}