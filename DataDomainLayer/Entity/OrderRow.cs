using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataDomainLayer.Entity
{
    public class OrderRow:Base
    {

        public int? ORDERID { get; set; }

        public int? PRODUCTID { get; set; }

        [ForeignKey("PRODUCTID")]
        public virtual Product PRODUCT { get; set; }

        public int QUANTITY { get; set; }




    }
}
