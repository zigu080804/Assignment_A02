using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using DataAccessLayer_A02;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer_A02
{
    public class OrderDAO
    {
        private readonly LucySalesDataContext context = new LucySalesDataContext();

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return context.Orders
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product) // nếu muốn thêm thông tin sản phẩm
                .ToList();
        }

    }
}
