using Model;
using System;
using System.Collections.Generic;
using System.Data;
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
        public RolesFrame(RolesList roles)
        {

            InitializeComponent();
            if (Sesion.User.IsAdmin)
            {
                AddRoleMenu.Visibility = Visibility.Collapsed;
                AddRoleBtn.Visibility = Visibility.Visible;
            }
            else
            {
                AddRoleMenu.Visibility = Visibility.Collapsed;
                AddRoleBtn.Visibility = Visibility.Collapsed;
            }
            RolesList.ItemsSource = roles;
        }

        public RolesFrame()
        {
            RolesDB db = new RolesDB();
            var roles = db.SelectALL();
            InitializeComponent();
            if (Sesion.User.IsAdmin)
            {
                AddRoleMenu.Visibility = Visibility.Collapsed;
                AddRoleBtn.Visibility = Visibility.Visible;
            }
            else
            {
                AddRoleMenu.Visibility = Visibility.Collapsed;
                AddRoleBtn.Visibility = Visibility.Collapsed;
            }
            RolesList.ItemsSource = roles;
        }

        private void OpenAddRoleMenu(object sender, RoutedEventArgs e)
        {
            AddRoleMenu.Visibility = Visibility.Visible;
            AddRoleBtn.Visibility = Visibility.Collapsed;
        }

        private void AddRole(object sender, RoutedEventArgs e)
        {
            RolesDB db = new RolesDB();           
            Role role = new Role();
            role.Name = InsertRoleName.Text;
            role.Description = InsertRoleDescription.Text;
            role.MinDapar = int.Parse(insertDapar.Text);
            role.MinProfile = int.Parse(insertProfile.Text);
            role.Requirements = new RequirementsList();
            role.Requirements.Add(new Requirement { MinGrade = int.Parse(insertCommand.Text) , Skill = Skills.Command });
            role.Requirements.Add(new Requirement { MinGrade = int.Parse(insertTeamWork.Text), Skill = Skills.Teamwork });
            role.Requirements.Add(new Requirement { MinGrade = int.Parse(insertAttentions.Text), Skill = Skills.Attention });
            role.Requirements.Add(new Requirement { MinGrade = int.Parse(insertInformationProcession.Text), Skill = Skills.InformationProcession });
            db.AddRoleWithRequierement(role);
            AddRoleMenu.Visibility = Visibility.Collapsed;
            AddRoleBtn.Visibility = Visibility.Visible;

            
            

            

            var rolesList = db.SelectALL();
            RolesList.ItemsSource = rolesList;
        }


    }
}
