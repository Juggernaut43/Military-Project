using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для ProfileFrame.xaml
    /// </summary>
    public partial class ProfileFrame : Page
    {
        public ProfileFrame()
        {
            //ShowGrades();
            InitializeComponent();
            ProfileDB db = new ProfileDB();
            var p = db.SelectByID(Sesion.User.Id);
            if (p != null)
            {
                Grades.ItemsSource = CreateGrades(p);
            }
            else
            {
                //wait massage
            }
        }

        private Dictionary<string, int> CreateGrades(Profile p)
        {
            var grades = new Dictionary<string, int>();
            grades.Add("Dapar", p.Dapar);
            grades.Add("Profile", p.ProfileGrade);
            grades.Add("Command", p.Y100Grades.Command);
            grades.Add("Teamwork", p.Y100Grades.Teamwork);
            grades.Add("Attention", p.Y100Grades.Attention);
            grades.Add("Information Procession", p.Y100Grades.InformationProcession);
            return grades;
        }
    }
}
