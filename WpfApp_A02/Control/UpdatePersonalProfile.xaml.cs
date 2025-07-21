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
    /// Interaction logic for UpdatePersonalProfile.xaml
    /// </summary>
    public partial class UpdatePersonalProfile : System.Windows.Controls.UserControl
    {
        public UpdatePersonalProfile()
        {
            InitializeComponent();
            // Không load gì cả ở đây vì chưa có employee
        }
        private Employee _currentEmployee;
        private  EmployeeService _employeeService = new EmployeeService();

       

        public UpdatePersonalProfile(Employee employee)
        {
            InitializeComponent();
            _currentEmployee = employee;

            // Hiển thị thông tin ngay
            txtName.Text = _currentEmployee.Name;
            txtUsername.Text = _currentEmployee.UserName;
            txtPassword.Password = _currentEmployee.Password;
            txtJobTitle.Text = _currentEmployee.JobTitle;
            dpBirthDate.SelectedDate = _currentEmployee.BirthDate;
            dpHireDate.SelectedDate = _currentEmployee.HireDate;
            txtAddress.Text = _currentEmployee.Address;
        }
        private bool ValidateForm()
        {
            StringBuilder errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtName.Text))
                errorBuilder.AppendLine("Name is required.");

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                errorBuilder.AppendLine("Username is required.");

            if (string.IsNullOrWhiteSpace(txtPassword.Password))
                errorBuilder.AppendLine("Password is required.");

            if (dpBirthDate.SelectedDate == null)
                errorBuilder.AppendLine("Please select Birth Date.");

            if (dpHireDate.SelectedDate == null)
                errorBuilder.AppendLine("Please select Hire Date.");

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                errorBuilder.AppendLine("Address is required.");

           

            if (errorBuilder.Length > 0)
            {
                MessageBox.Show(errorBuilder.ToString(), "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm())
                return;
            try
            {  
                _currentEmployee.Name = txtName.Text;
                _currentEmployee.UserName = txtUsername.Text;
                _currentEmployee.Password = txtPassword.Password;
                _currentEmployee.JobTitle = txtJobTitle.Text;
                _currentEmployee.BirthDate = dpBirthDate.SelectedDate;
                _currentEmployee.HireDate = dpHireDate.SelectedDate;
                _currentEmployee.Address = txtAddress.Text;

                _employeeService.UpdateEmployeeProfile(_currentEmployee);
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update profile: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
