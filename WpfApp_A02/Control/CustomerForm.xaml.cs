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

namespace WpfApp_A02.Control
{
    /// <summary>
    /// Interaction logic for CustomerForm.xaml
    /// </summary>
    public partial class CustomerForm : Window
    {
        public Customer Customer { get; private set; }
        private bool isEdit;



        public CustomerForm(Customer customer = null)
        {
            InitializeComponent();
            if (customer != null)
            {
                isEdit = true;
                Customer = customer;
                txtCompanyName.Text = customer.CompanyName;
                txtContactName.Text = customer.ContactName;
                txtContactTitle.Text = customer.ContactTitle;
                txtAddress.Text = customer.Address;
                txtPhone.Text = customer.Phone;
            }
            else
            {
                Customer = new Customer();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Company Name không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtCompanyName.Focus();
                return;
            }

            // Gán lại các giá trị từ form
            Customer.CompanyName = txtCompanyName.Text.Trim();
            Customer.ContactName = txtContactName.Text?.Trim();
            Customer.ContactTitle = txtContactTitle.Text?.Trim();
            Customer.Address = txtAddress.Text?.Trim();
            Customer.Phone = txtPhone.Text?.Trim();

            this.DialogResult = true;
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }

}
