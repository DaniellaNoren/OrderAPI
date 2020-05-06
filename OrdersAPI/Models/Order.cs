using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OrdersAPI.Models
{
    public class Order
    {
        [XmlAttribute]
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public Customer Customer { get; set; }

      

        public Order(string orderNumber, string orderDate, List<OrderLine> orderLines, Customer customer)
        {
           OrderNumber = orderNumber;
           OrderDate = orderDate;
           OrderLines = orderLines;
           Customer = customer;
  
                
        }
        public Order()
        {
        }

        
        
    }

}