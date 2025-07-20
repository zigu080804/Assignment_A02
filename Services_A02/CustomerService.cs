using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_A02;
using BusinessObjects_A02;
namespace Services_A02
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository icustomerRepository;

        public CustomerService()
        {
            icustomerRepository = new CustomerRepository();
        }

        public void AddCustomer(Customer customer)
        {
            icustomerRepository.AddCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            icustomerRepository.DeleteCustomer(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return icustomerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int customerId)
        {
            return icustomerRepository.GetCustomerById(customerId);
        }

        public Customer LoginByPhone(string phone)
        {
            return icustomerRepository.LoginByPhone(phone);
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            return icustomerRepository.SearchCustomers(keyword);
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            icustomerRepository.UpdateCustomer(updatedCustomer);
        }

        public void UpdateProfile(Customer updatedCustomer)
        {
            icustomerRepository.UpdateProfile(updatedCustomer);
        }
    }
}
