using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
namespace Repository_A02
{
    public interface IEmployeeRepositoy
    {
        public Employee Login(string username, string pwd);

    }
}
