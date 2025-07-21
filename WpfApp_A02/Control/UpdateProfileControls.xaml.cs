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
using Services_A02;

namespace WpfApp_A02.Control
{
    /// <summary>
    /// Interaction logic for UpdateProfileControls.xaml
    /// </summary>
    public partial class UpdateProfileControls : System.Windows.Controls.UserControl
    {
        public UpdateProfileControls()
        {
            InitializeComponent();
        }
        private Customer currentCustomer;
        private CustomerService customerService = new CustomerService();


        public UpdateProfileControls(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;

            // Hiển thị thông tin hiện tại
            txtCompanyName.Text = currentCustomer.CompanyName;
            txtContactName.Text = currentCustomer.ContactName;
            txtContactTitle.Text = currentCustomer.ContactTitle;
            txtAddress.Text = currentCustomer.Address;
            txtPhone.Text = currentCustomer.Phone;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            // Cập nhật thông tin
            currentCustomer.CompanyName = txtCompanyName.Text;
            currentCustomer.ContactName = txtContactName.Text;
            currentCustomer.ContactTitle = txtContactTitle.Text;
            currentCustomer.Address = txtAddress.Text;
            currentCustomer.Phone = txtPhone.Text;

            customerService.UpdateProfile(currentCustomer);
            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
