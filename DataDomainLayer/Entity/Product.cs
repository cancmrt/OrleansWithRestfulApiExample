using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataDomainLayer.Entity
{
    public class Product:Base
    {
        
        public string NAME { get; set; }

        public string PROPERTIES { get; set; }
        public int STOCKID { get; set; }

        [ForeignKey("STOCKID")]
        public virtual Stock STOCK { get; set; }
    }
}
