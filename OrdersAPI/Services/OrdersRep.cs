using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI.Services
{
    public interface OrdersRep
    {
        Order GetOrderByOrderNumber(string orderNumber);

        List<Order> GetAllOrders();

        void SaveOrder(Order order);

        void SaveOrders(List<Order> orders);
    }
}
