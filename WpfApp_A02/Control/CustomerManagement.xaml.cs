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
        private Customer _selectedCustomer;

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
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var form = new CustomerForm(new Customer
            {
                CustomerId = _selectedCustomer.CustomerId,
                CompanyName = _selectedCustomer.CompanyName,
                ContactName = _selectedCustomer.ContactName,
                ContactTitle = _selectedCustomer.ContactTitle,
                Address = _selectedCustomer.Address,
                Phone = _selectedCustomer.Phone
            });

            if (form.ShowDialog() == true)
            {
                try
                {
                    _customerService.UpdateCustomer(form.Customer);
                    MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _customerService.DeleteCustomer(_selectedCustomer.CustomerId);
                    MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCustomers();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
