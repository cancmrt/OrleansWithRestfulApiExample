using System;
using System.Collections.Generic;
using System.Text;

namespace DataDomainLayer.Entity
{
    public class Customer:Base
    {
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string TELEPHONE { get; set; }

    }
}
