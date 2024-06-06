using Model;
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
    /// Логика взаимодействия для RolesFrame.xaml
    /// </summary>
    public partial class RolesFrame : Page
    {
        private RolesList roles;
        public RolesFrame(RolesList roles)
        {
            this.roles = roles;
            InitializeComponent();
        }

        public RolesFrame()
        {
            RolesDB db = new RolesDB();
            this.roles = db.SelectAll();
            InitializeComponent();

        }
    }
}
