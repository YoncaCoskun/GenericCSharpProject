using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain
{
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }
        
        public int ProductID { get; set; }
     
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Single Discount { get; set; }

    }
}
