using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using DataAccessLayer_A02;

namespace Repository_A02
{
    public class EmployeeRepositoy : IEmployeeRepositoy
    {   
        EmployeeDAO employeedao = new EmployeeDAO();
        public Employee Login(string username, string pwd)
        {
            return employeedao.Login(username, pwd);
        }
    }
}
