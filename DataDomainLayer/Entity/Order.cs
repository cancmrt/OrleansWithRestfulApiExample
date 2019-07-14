using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataDomainLayer.Entity
{
    public class Order:Base
    {
        public Order()
        {
            ORDERROW = new List<OrderRow>();
        }
        public string NAME { get; set; }
        
        public int? CUSTOMERID { get; set; }

        [ForeignKey("CUSTOMERID")]
        public virtual Customer CUSTOMER { get; set; }

        [ForeignKey("ORDERID")]
        public virtual List<OrderRow> ORDERROW { get; set; }
    }
}
