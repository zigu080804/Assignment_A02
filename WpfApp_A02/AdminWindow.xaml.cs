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
using System.Windows.Shapes;
using BusinessObjects_A02;
using WpfApp_A02.Control;

namespace WpfApp_A02
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private Employee _currentEmployee;

        public AdminWindow(Employee employee)
        {
            InitializeComponent();
            _currentEmployee = employee;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employeeProfileFrame.Content = new UpdatePersonalProfile(_currentEmployee);
        }


        private void btnOut_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
