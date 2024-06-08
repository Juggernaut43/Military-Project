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
            this.RolesButton.Visibility = Visibility.Collapsed;
            this.CoursesBtn.Visibility = Visibility.Collapsed;
            this.RoleSelectionBtn.Visibility = Visibility.Collapsed;
            this.ProfileBtn.Visibility = Visibility.Collapsed;

            this.LogoutBtn.Visibility = Visibility.Collapsed;
            this.SetingsBtn.Visibility = Visibility.Collapsed;

            this.Sign_upBtn.Visibility = Visibility.Visible;
            this.Sign_inBtn.Visibility = Visibility.Visible;
            this.SpaceBlock.Width = 650;
            InitializeComponent();
        }

        private void RolesBtn_Click(object sender, RoutedEventArgs e)
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
        private void SetingsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new OwnerFrame());
        }
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.RolesButton.Visibility = Visibility.Collapsed;
            this.CoursesBtn.Visibility = Visibility.Collapsed;
            this.RoleSelectionBtn.Visibility = Visibility.Collapsed;
            this.ProfileBtn.Visibility = Visibility.Collapsed;

            this.LogoutBtn.Visibility = Visibility.Collapsed;
            this.SetingsBtn.Visibility = Visibility.Collapsed;
            
            this.Sign_upBtn.Visibility = Visibility.Visible;
            this.Sign_inBtn.Visibility = Visibility.Visible;
            this.SpaceBlock.Width = 650;
            this.WelcomeUserName.Text = $"Hey, nice to sea you in my application";
            this.myFrame.Navigate(new HomeFrame());

        }
        //---------------------------------------------------------------------------
        private void Sign_upBtn_Click(object sender, RoutedEventArgs e)
        {
            var p = new RegistrationFrame();
            p.GoToLoginEvent += new EventHandler(MoveToLoginPage);
            p.RegistrationEvent += new EventHandler(LoginHappend);
            this.myFrame.Navigate(p);
        }
        private void MoveToLoginPage(object? sender, EventArgs e)
        {
            var p = new LoginFrame();
            p.GoToRegistrationEvent += new EventHandler(MoveToRegistrationPage);
            p.LoginEvent += new EventHandler(LoginHappend);
            this.myFrame.Navigate(p);
        }

        private void Sign_inBtn_Click(object sender, RoutedEventArgs e)
        {
            var p = new LoginFrame();
            p.GoToRegistrationEvent += new EventHandler(MoveToRegistrationPage);
            p.LoginEvent += new EventHandler(LoginHappend);
            this.myFrame.Navigate(p);
        }
        private void LoginHappend(object? sender, EventArgs e)
        {
            this.myFrame.Navigate(new HomeFrame());
            this.WelcomeUserName.Text = $"Welcome {Sesion.User.Name}";

            this.RolesButton.Visibility = Visibility.Visible;
            this.CoursesBtn.Visibility = Visibility.Visible;
            this.RoleSelectionBtn.Visibility = Visibility.Visible;
            this.ProfileBtn.Visibility = Visibility.Visible;

            this.Sign_upBtn.Visibility = Visibility.Collapsed;
            this.Sign_inBtn.Visibility = Visibility.Collapsed;
            this.LogoutBtn.Visibility = Visibility.Visible;
            this.SpaceBlock.Width = 340;
            if (Sesion.User.IsAdmin)
            {
                this.SetingsBtn.Visibility = Visibility.Visible;
                this.SpaceBlock.Width = 250;
            }
        }
        
        private void MoveToRegistrationPage(object? sender, EventArgs e)
        {
            var p = new RegistrationFrame();
            p.GoToLoginEvent += new EventHandler(MoveToLoginPage);
            p.RegistrationEvent += new EventHandler(LoginHappend);
            this.myFrame.Navigate(p);
        }

        

        
    }
}
