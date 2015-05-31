using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain
{
    public class CustomerDemographic
    {
        [Key]
        public int CustomerTypeID { get; set; }
        public string Desc { get; set; }

    }
}
