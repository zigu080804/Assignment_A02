using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using DataAccessLayer_A02;

namespace Repository_A02
{
    public interface IOrderRepository 
    {
        public List<Order> GetOrdersByCustomerId(int customerId);

    }
}
