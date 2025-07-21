using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using Repository_A02;
namespace Services_A02
{
    public interface IOrderService
    {
        public List<Order> GetOrdersByCustomerId(int customerId);
        public List<Order> GetAllOrders();
        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);


    }
}
