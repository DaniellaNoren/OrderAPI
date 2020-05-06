using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OrdersAPI.Models;

namespace OrdersAPI.Services
{
    public class CSVOrderRep : OrdersRep
    {
        private string path = @"Order files";
        public List<Order> GetAllOrders()
        {
            var directory = Directory.GetFiles(path);
            List<Order> orders = new List<Order>();

            foreach (string csv in directory)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(csv);

                file.ReadLine();

                string[] firstLine = file.ReadLine().Split("|");

                Order order = new Order();
                order.OrderNumber = firstLine[1];
                order.OrderDate = firstLine[9];

                Customer customer = new Customer(firstLine[10], firstLine[11]);

                order.Customer = customer;

                List<OrderLine> orderLines = new List<OrderLine>();

                Product product = new Product(firstLine[3], firstLine[5], firstLine[6],
                    double.Parse(firstLine[7].Trim(), CultureInfo.InvariantCulture), firstLine[8]
                   );

                OrderLine orderLine = new OrderLine(firstLine[2], product, Int32.Parse(firstLine[4].Trim(), CultureInfo.InvariantCulture));

                orderLines.Add(orderLine);

                while ((line = file.ReadLine()) != null)
                {
                    string[] values = line.Split("|");
                    System.Diagnostics.Debug.WriteLine(line);

                    Product p = new Product(values[3], values[5], values[6], double.Parse(values[7].Trim(), CultureInfo.InvariantCulture), values[9]);

                    OrderLine ol = new OrderLine(values[2], p, Int32.Parse(values[4].Trim(), CultureInfo.InvariantCulture));
                    ol.TotalPrice = p.Price * ol.Quantity;

                    orderLines.Add(ol);

                }

                order.OrderLines = orderLines;
                orders.Add(order);
                file.Close();
            }

            return orders;
        }

        public Order GetOrderByOrderNumber(string orderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrders(List<Order> orders)
        {
            throw new NotImplementedException();
        }

        void OrdersRep.SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
