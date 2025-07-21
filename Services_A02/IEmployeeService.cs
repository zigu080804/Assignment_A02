using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;

namespace Services_A02
{
    public interface IEmployeeService
    {
        public Employee Login(string username, string pwd);
        public void UpdateEmployeeProfile(Employee employee);
        public Employee? GetEmployeeById(int id);
    }
}
