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

namespace WpfApp_A02
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();

        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string pwd = txtPassword.Password.Trim();

                // Nếu người dùng nhập cả username và password => xử lý login Employee (Admin)
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pwd))
                {
                    IEmployeeService iemployeeService = new EmployeeService();
                    Employee employee = iemployeeService.Login(username, pwd);

                    if (employee != null)
                    {
                        MessageBox.Show("Đăng nhập với vai trò Quản trị viên (Admin).", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                        var adminWindow = new AdminWindow(); // Có thể đổi tên nếu bạn tách riêng AdminWindow
                        adminWindow.Show();
                        Close();
                        return;
                    }
                }

                // Nếu chỉ nhập username (Phone), không có password => xử lý login Customer
                if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(pwd))
                {
                    ICustomerService icustomerService = new CustomerService();
                    Customer customer = icustomerService.LoginByPhone(username); // bạn phải viết hàm Login(string phone) bên Service

                    if (customer != null)
                    {
                        MessageBox.Show("Đăng nhập với vai trò Khách hàng.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                        var customerWindow = new CustomerWindow(customer); // bạn tự tạo CustomerWindow nếu chưa có
                        customerWindow.Show();
                        Close();
                        return;
                    }
                }

                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra thông tin đăng nhập!", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
