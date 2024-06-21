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
using Common;


namespace Military_Project.Frame
{
    /// <summary>
    /// Логика взаимодействия для Donate.xaml
    /// </summary>
    public partial class Donate : Page
    {
        public Donate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int month, year;
            bool ismonth = int.TryParse(Month.Text, out month);
            if (!ismonth)
            {
                erorMessage.Text = "month is not corect";
                return;
            }
            bool isyear = int.TryParse(Year.Text, out year);
            if (!isyear)
            {
                erorMessage.Text += "year is not corect";
                return;
            }           
            if (Apiervice.TestCreditCard(CVV.Text, CardNumber.Text, month, year))
            {
                donationBlock.Visibility = Visibility.Collapsed;
                thanksBlock.Visibility = Visibility.Visible;
            }
            else
            {
                erorMessage.Text = "card is not corect";
            }
        }
    }
}
