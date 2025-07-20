using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using DataAccessLayer_A02;
namespace Repository_A02
{
    public class CustomerRepository : ICustomerRepository
    {

        CustomerDAO cusdao = new CustomerDAO();

        public void AddCustomer(Customer customer)
        {
            cusdao.AddCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            cusdao.DeleteCustomer(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return cusdao.GetAllCustomers();
        }

        public Customer GetCustomerById(int customerId)
        {
            return cusdao.GetCustomerById(customerId);
        }

        public Customer LoginByPhone(string phone)
        {
            return cusdao.LoginByPhone(phone);
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            return cusdao.SearchCustomers(keyword);
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            cusdao.UpdateCustomer(updatedCustomer);
        }

        public void UpdateProfile(Customer updatedCustomer)
        {
             cusdao.UpdateProfile(updatedCustomer);
        }

         
    }
}
