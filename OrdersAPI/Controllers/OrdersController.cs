using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrdersAPI.Models;
using OrdersAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private OrderService orderService;
        


        public OrdersController(OrderService orderService)
        {
            this.orderService = orderService;
        
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }

        [HttpGet("{orderNumber}")]
        public Order Get(string orderNumber)
        {
            return orderService.GetOrder(orderNumber);
        }

    }
}