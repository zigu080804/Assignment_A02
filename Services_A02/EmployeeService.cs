using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using Repository_A02;
 
namespace Services_A02
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepositoy iemployeeRepositoy;

        public EmployeeService()
            {
            iemployeeRepositoy = new EmployeeRepositoy();
            }
        public Employee Login(string username, string pwd)
        {
            return iemployeeRepositoy.Login(username, pwd);
        }
    }
}
