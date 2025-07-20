using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer_A02;
using BusinessObjects_A02;

namespace Repository_A02
{
    public class OrderRepository :  IOrderRepository
    {
        OrderDAO dao = new OrderDAO();
        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return dao.GetOrdersByCustomerId(customerId);
        }

    }
}
