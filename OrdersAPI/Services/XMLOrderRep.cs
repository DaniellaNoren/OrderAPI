using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using OrdersAPI.Models;
using OrdersAPI.Services;

namespace OrdersAPI.Services
{
    public class XMLOrderRep : OrdersRep
    {
        private string path = @"orders.xml";

        public Order GetOrderByOrderNumber(string orderNumber)
        {
            XDocument doc = XDocument.Load(path);

            XElement foundOrder = doc.Descendants()
                .Where(x => (string)x.Attribute("OrderNumber") == orderNumber).FirstOrDefault();

            XmlSerializer serializer = new XmlSerializer(typeof(Order));
            StringReader stringReader = new StringReader(foundOrder.ToString());
            Order order = (Order)serializer.Deserialize(stringReader);

            return order;
        }

        public List<Order> GetAllOrders()
        {
            string xml = File.ReadAllText(path);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
            StringReader stringReader = new StringReader(xml);
            List<Order> orders = (List<Order>)serializer.Deserialize(stringReader);

            return orders;
        }

        public void SaveOrder(Order order)
        {
            var path = @order.OrderNumber + ".xml";
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Order));
            TextWriter filestream = new StreamWriter(path);
            xsSubmit.Serialize(filestream, order);
            filestream.Close();
            
        }

        public void SaveOrders(List<Order> orders)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Order>));
            TextWriter filestream = new StreamWriter(path);
            xsSubmit.Serialize(filestream, orders);
            filestream.Close();
        }
    }
}
