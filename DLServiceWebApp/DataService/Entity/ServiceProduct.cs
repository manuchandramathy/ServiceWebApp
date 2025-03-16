using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLServiceWebApp.DataService.Entity
{
    public class ServiceProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
    }
}
