using Military_Project.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Military_Project.Frame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MenuVisability()
        {

            //show all buttons in menu

            if (Sesion.User != null)
            {
                //show logout button
                LogoutBtn.Visibility = Visibility.Visible;
                if (Sesion.User.IsAdmin)
                {
                    SetingsBtn.Visibility = Visibility.Visible;

                }
            }
            else
            {
                //show loginbtn
                //show sign up
                //Fix space
                //other hide

            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new RolesFrame());
        }
        private void CoursesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new CoursesFrame());
        }
        private void RoleSelectionBtn_Click(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new RoleSelectinFrame());
        }
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new HomeFrame());
        }
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new ProfileFrame());
        }
        //----------------------------------------
        private void Sign_upBtn_Click(object sender, RoutedEventArgs e)
        {
            var p = new RegistrationFrame();
            p.GoToLoginEvent += new EventHandler(MoveToLoginPage);
            p.RegistrationEvent += new EventHandler(UpdateMenu);
            this.myFrame.Navigate(p);
        }
        private void MoveToLoginPage(object? sender, EventArgs e)
        {
            this.myFrame.Navigate(new LoginFrame());
        }

        private void Sign_inBtn_Click(object sender, RoutedEventArgs e)
        {
            var p = new LoginFrame();
            p.GoToRegistrationEvent += new EventHandler(MoveToRegistrationPage);
            p.LoginEvent += new EventHandler(UpdateMenu);
            this.myFrame.Navigate(p);
        }
        private void UpdateMenu(object? sender, EventArgs e)
        {
            MenuVisability();
        }
        
        private void MoveToRegistrationPage(object? sender, EventArgs e)
        {
            this.myFrame.Navigate(new RegistrationFrame());
        }
    }
}
