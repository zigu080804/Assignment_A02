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

    }
}
