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
            Customer.CompanyName = txtCompanyName.Text;
            Customer.ContactName = txtContactName.Text;
            Customer.ContactTitle = txtContactTitle.Text;
            Customer.Address = txtAddress.Text;
            Customer.Phone = txtPhone.Text;

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
