using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperPost.Models
{
    public class Reviews
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
    }
}