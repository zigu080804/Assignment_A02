using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_A02;
using BusinessObjects_A02;

namespace Services_A02
{
    public class OrderService :  IOrderService
    {
        IOrderRepository iorderrepo;
        public OrderService()

        {
            iorderrepo = new OrderRepository();
        }

        public List<Order> GetAllOrders()
        {
            return iorderrepo.GetAllOrders();
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return iorderrepo.GetOrdersByCustomerId(customerId);    
        }

        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return iorderrepo.GetOrdersByDateRange(startDate, endDate);
        }
    }
}
