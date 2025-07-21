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
using Services_A02;

namespace WpfApp_A02.Control
{
    /// <summary>
    /// Interaction logic for ReportControl.xaml
    /// </summary>
    public partial class ReportControl : System.Windows.Controls.UserControl
    {
        private readonly OrderService orderService = new OrderService();

        public ReportControl()
        {
            InitializeComponent();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("Please select both start and end dates!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime start = dpStartDate.SelectedDate.Value;
            DateTime end = dpEndDate.SelectedDate.Value;

            if (start > end)
            {
                MessageBox.Show("Start date cannot be after end date!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var orders = orderService.GetOrdersByDateRange(start, end);

            var reportData = orders.Select(o => new
            {
                o.OrderId,
                o.Customer,
                o.Employee,
                o.OrderDate,
                TotalAmount = o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity)
            }).ToList();

            dgReport.ItemsSource = reportData;

            decimal totalRevenue = reportData.Sum(r => r.TotalAmount);
            txtTotalRevenue.Text = $"Total Revenue: {totalRevenue:C}";
        }
    }
}
