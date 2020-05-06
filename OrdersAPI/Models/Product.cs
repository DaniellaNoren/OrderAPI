using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OrdersAPI.Models
{
    public class Product
    {
        [XmlAttribute]
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductGroup { get; set; }
        
        public Product(string productNumber, string name, string description, double price, string productGroup)
        {
            this.ProductNumber = productNumber;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.ProductGroup = productGroup;
        }

        public Product()
        {
        }
    }
}