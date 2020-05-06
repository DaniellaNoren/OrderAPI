using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrdersAPI.Models;

namespace OrdersAPI.Services
{
    public class OrderService
    {

        private OrdersRep OrdersRep;

        public OrderService(OrdersRep ordersRep)
        {
            OrdersRep = ordersRep;
        }


        public List<Order> GetAllOrders()
        {
            return OrdersRep.GetAllOrders();
        }

        public Order GetOrder(string orderNumber)
        {
            return OrdersRep.GetOrderByOrderNumber(orderNumber);
        }

        public void addOrder(Order order)
        {
            OrdersRep.SaveOrder(order);
        }

        public void AddOrders(List<Order> orders)
        {
            OrdersRep.SaveOrders(orders);
        }

      
    }
}