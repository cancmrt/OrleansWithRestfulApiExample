using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataDomainLayer.Entity
{
    public class Stock:Base
    {
        public int QUANTITY { get; set; }
    }
}
