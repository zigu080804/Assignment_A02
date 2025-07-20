using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
namespace Repository_A02
{
    public interface ICustomerRepository
    {
        public Customer LoginByPhone(string phone);
        public void UpdateProfile(Customer updatedCustomer);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int customerId);

        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer updatedCustomer);
        public void DeleteCustomer(int customerId);
        public List<Customer> SearchCustomers(string keyword);

    }
}
