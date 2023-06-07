using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Application.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class Productinq
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}