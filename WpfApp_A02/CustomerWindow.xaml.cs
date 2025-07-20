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
using Services_A02;
using WpfApp_A02.Control;
using WpfApp_A02.UserControl;

namespace WpfApp_A02
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private Customer _currentCustomer;
        private readonly IOrderService _orderService = new OrderService();
        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;

        }
        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

       
        private void btnOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCustomer != null)
            {
                var orders = _orderService.GetOrdersByCustomerId(_currentCustomer.CustomerId);
                MainContent.Content = new OrderHistoryControl(orders);
            }
        }

        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UpdateProfileControls(_currentCustomer);
        }

    }
}
