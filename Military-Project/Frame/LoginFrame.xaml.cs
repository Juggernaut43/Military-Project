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
    /// Логика взаимодействия для LoginFrame.xaml
    /// </summary>
    public partial class LoginFrame : Page
    {
        public event EventHandler GoToRegistrationEvent;
        public event EventHandler LoginEvent;
        public LoginFrame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GoToRegistrationEvent != null)
            {
                GoToRegistrationEvent(this, e);
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            UsersDB db = new UsersDB();
            var user = db.SelectByID(int.Parse(id.Text));
            if (user != null)
            {
                if (user.Password == password.Text) 
                {
                    Sesion.User = user;
                    if (LoginEvent != null)
                    {
                        LoginEvent(this, e);
                    }
                }
                else 
                { 
                    //exeption message 
                }
            }

        }
    }
}
