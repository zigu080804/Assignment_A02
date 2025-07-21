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
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : System.Windows.Controls.UserControl
    {
        private CustomerService _customerService;
        private List<Customer> _customers;
        //private Customer _selectedCustomer;

        public CustomerManagement()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            _customers = _customerService.GetAllCustomers();
            CustomerDataGrid.ItemsSource = null;
            CustomerDataGrid.ItemsSource = _customers;
        }



       

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == true)
            {
                try
                {
                    _customerService.AddCustomer(form.Customer);
                    MessageBox.Show("Customer added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = CustomerDataGrid.SelectedItem as Customer;
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dialog = new CustomerForm(selectedCustomer); // mở dialog sửa
            if (dialog.ShowDialog() == true)
            {
                var updatedCustomer = dialog.Customer;
                _customerService.UpdateCustomer(updatedCustomer);
                LoadCustomers();
            }
        }


        // Do thiếu 1 trường để soft Delete cho Customer nên em không dám xóa thẳng 1 row data có reference key 
        // Nên em handle lỗi 
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = CustomerDataGrid.SelectedItem as Customer;
            if (selectedCustomer == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                _customerService.DeleteCustomer(selectedCustomer.CustomerId);
                MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadCustomers(); // hoặc cập nhật lại DataGrid
                
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadCustomers();
                return;
            }

            var result = _customerService.SearchCustomers(keyword);
            CustomerDataGrid.ItemsSource = null;
            CustomerDataGrid.ItemsSource = result;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            
            LoadCustomers();
        }
    }
}
