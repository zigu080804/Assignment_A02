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
using BusinessObjects_A02;
namespace WpfApp_A02.UserControl
{

    public partial class OrderHistoryControl : System.Windows.Controls.UserControl
    {
        public OrderHistoryControl(List<Order> orders)
        {
            InitializeComponent();
            OrdersList.ItemsSource = orders;
        }

    }
}
