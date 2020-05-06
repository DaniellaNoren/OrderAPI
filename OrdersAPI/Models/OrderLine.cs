using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrdersAPI.Models
{
    public class OrderLine
    {
        [XmlAttribute]
        public string OrderLineNumber { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }


        public OrderLine(string orderLineNumber, Product product, int quantity)
        {
            OrderLineNumber = orderLineNumber;
            Product = product;
            Quantity = quantity;
        }

        public OrderLine()
        {
        }
    }
}

