using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
using ViewModel;

namespace Military_Project.Frame
{
    /// <summary>
    /// Логика взаимодействия для OwnerFrame.xaml
    /// </summary>
    public partial class OwnerFrame : Page
    {
        public ObservableCollection<User> Users { get; set; }
        public OwnerFrame()
        {
            
            UsersDB db = new UsersDB();
            Users = new ObservableCollection<User>(db.SelectALL());

            InitializeComponent();
            UserDataGrid.ItemsSource = Users;

        }
    }
}
