using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
namespace DataAccessLayer_A02
{
    public class EmployeeDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();
        public Employee Login(string username, string pwd)
        {
            return context.Employees
                          .FirstOrDefault(ac => ac.UserName == username
                                                && ac.Password == pwd);
        }
        public Employee GetEmployeeById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void UpdateEmployeeProfile(Employee employee)
        {
            var existing = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.UserName = employee.UserName;
                existing.Password = employee.Password;
                existing.JobTitle = employee.JobTitle;
                existing.BirthDate = employee.BirthDate;
                existing.HireDate = employee.HireDate;
                existing.Address = employee.Address;

                context.SaveChanges();
            }
        }


    }
}
