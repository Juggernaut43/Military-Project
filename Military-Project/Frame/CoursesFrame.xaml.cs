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
    /// Логика взаимодействия для CoursesFrame.xaml
    /// </summary>
    public partial class CoursesFrame : Page
    {
        public CoursesFrame()
        {

            InitializeComponent();
            if (Sesion.User.IsAdmin)
            {
                OpenAddCourseMenuBtn.Visibility = Visibility.Visible;
                AddCourseMenu.Visibility = Visibility.Collapsed;              
            }
            else
            {
                OpenAddCourseMenuBtn.Visibility = Visibility.Collapsed;
                AddCourseMenu.Visibility = Visibility.Collapsed;
            }
            CoursesDB db = new CoursesDB();
            var courses = db.SelectALL();
            CoursesList.ItemsSource = courses;
        }

        private void AddCourse(object sender, RoutedEventArgs e)
        {
            OpenAddCourseMenuBtn.Visibility = Visibility.Visible;
            AddCourseMenu.Visibility = Visibility.Collapsed;

            CoursesDB db = new CoursesDB();
            Course course = new Course();
            course.Name = insertName.Text;
            course.Description = insertDescription.Text;
            course.Price = int.Parse(insertPrice.Text);
            course.Date = insertDate.Text;
            course.Url = insertUrl.Text;
            db.InsertCourse(course);
            
            var courses = db.SelectALL();
            CoursesList.ItemsSource = courses;
        }
        private void OpenAddCourseMenu(object sender, RoutedEventArgs e)
        {
            OpenAddCourseMenuBtn.Visibility = Visibility.Collapsed;
            AddCourseMenu.Visibility = Visibility.Visible;
        }
    }
}
