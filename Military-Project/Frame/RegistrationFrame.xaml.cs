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
    /// Логика взаимодействия для RegistrationFrame.xaml
    /// </summary>
    public partial class RegistrationFrame : Page
    {
        public event EventHandler GoToLoginEvent;
        public event EventHandler RegistrationEvent;
        public RegistrationFrame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GoToLoginEvent != null)
            {
                GoToLoginEvent(this, e);
            }
        }

        private void RegBtn(object sender, RoutedEventArgs e)
        {
            if(password.Text == confirm.Text)
            {
                erorMessage.Text = "";
                erorMessage.Visibility = Visibility.Collapsed;
                var db = new UsersDB();
                var eitingUer = db.SelectByID(int.Parse(id.Text));
                if (eitingUer == null)
                {
                    User u = new User();
                    u.Name = firstName.Text;
                    u.LastName = lastName.Text;
                    u.Password = password.Text;
                    u.Id = int.Parse(id.Text);
                    u.Birthday = birthday.Text;

                    db.InsertUser(u);
                    erorMessage.Visibility = Visibility.Collapsed;
                }
                else
                {
                    erorMessage.Visibility= Visibility.Visible;
                    erorMessage.Text += "person with this id registrated";
                }
            }
            else
            {
                erorMessage.Visibility = Visibility.Visible;
                erorMessage.Text = "confirm password is not corect ";
                var db = new UsersDB();
                var eitingUer = db.SelectByID(int.Parse(id.Text));
                if (eitingUer != null)
                {
                    erorMessage.Text += "person with this id registrated";
                }
            }
            

        }
    }
}
