using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
namespace DataAccessLayer_A02
{
    public class CustomerDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();
        public Customer LoginByPhone(string phone)
        {
            return context.Customers
                          .FirstOrDefault(c => c.Phone == phone);
        }


        public void UpdateProfile(Customer updatedCustomer)
        {
            var existingCustomer = context.Customers.FirstOrDefault(c => c.CustomerId == updatedCustomer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CompanyName = updatedCustomer.CompanyName;
                existingCustomer.ContactName = updatedCustomer.ContactName;
                existingCustomer.ContactTitle = updatedCustomer.ContactTitle;
                existingCustomer.Address = updatedCustomer.Address;
                existingCustomer.Phone = updatedCustomer.Phone;

                context.SaveChanges();
            }
        }
        public List<Customer> GetAllCustomers()
        {
            return context.Customers.ToList();
        }

        // 🔍 Get by ID
        public Customer GetCustomerById(int customerId)
        {
            return context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        // ➕ Create
        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        // ✏️ Update (Admin dùng)
        public void UpdateCustomer(Customer updatedCustomer)
        {
            var existingCustomer = context.Customers.FirstOrDefault(c => c.CustomerId == updatedCustomer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CompanyName = updatedCustomer.CompanyName;
                existingCustomer.ContactName = updatedCustomer.ContactName;
                existingCustomer.ContactTitle = updatedCustomer.ContactTitle;
                existingCustomer.Address = updatedCustomer.Address;
                existingCustomer.Phone = updatedCustomer.Phone;

                context.SaveChanges();
            }
        }

        // ❌ Delete
        public void DeleteCustomer(int customerId)
        {
            var customer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
        public List<Customer> SearchCustomers(string keyword)
        {
            return context.Customers
                .Where(c =>
                    c.ContactName.Contains(keyword) ||
                    c.CompanyName.Contains(keyword) ||
                    c.Phone.Contains(keyword))
                .ToList();
        }


    }
}
