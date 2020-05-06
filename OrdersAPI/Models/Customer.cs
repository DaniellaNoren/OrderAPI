using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OrdersAPI.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        [XmlAttribute]
        public string CustomerNumber { get; set; }

        public Customer(string customerName, string customerNumber)
        {
            this.CustomerName = customerName;
            this.CustomerNumber = customerNumber;
        }

        public Customer()
        {
        }
    }
}