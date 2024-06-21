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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace Military_Project.Frame
{
    /// <summary>
    /// Логика взаимодействия для RoleSelectinFrame.xaml
    /// </summary>
    public partial class RoleSelectinFrame : Page
    {
        public RoleSelectinFrame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //todo add default value to proertie
            var db = new RolesDB();
            var role = db.RolesSelection(Convert.ToInt32(insertDapar.Text), Convert.ToInt32(insertProfile.Text), Convert.ToInt32(insertCommand.Text), Convert.ToInt32(insertTeamWork.Text), Convert.ToInt32(insertAttentions.Text), Convert.ToInt32(insertInformationProcession.Text));
            var roleFrame = new RolesFrame(role);
            NavigationService.Navigate(roleFrame);
        }
    }
}
