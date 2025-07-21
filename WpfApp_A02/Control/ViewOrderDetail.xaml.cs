using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
using BusinessObjects_A02;
using Services_A02;
namespace WpfApp_A02.Control
{
    /// <summary>
    /// Interaction logic for ViewOrderDetail.xaml
    /// </summary>
    public partial class ViewOrderDetail : System.Windows.Controls.UserControl
    {
        private readonly IOrderService _orderService;

        public ViewOrderDetail()
        {
            InitializeComponent();
            _orderService = new OrderService(); // hoặc DI nếu bạn có sẵn
            LoadOrders();
        }

        private void LoadOrders()
        {
            List<Order> orders = _orderService.GetAllOrders(); // Hàm bạn đã viết trong DAO
            dgOrders.ItemsSource = orders;
        }
        private void CloseDetails_Click(object sender, RoutedEventArgs e)
        {
            dgOrders.SelectedItem = null; // Hủy chọn => ẩn phần chi tiết
        }


    }
}
