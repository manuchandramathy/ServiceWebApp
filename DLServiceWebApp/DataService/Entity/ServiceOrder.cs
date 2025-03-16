﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLServiceWebApp.DataService.Entity
{
    public class ServiceOrder
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; }
    }
}
