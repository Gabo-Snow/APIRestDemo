using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRestDemo.Models
{
    public class Feriados
    { 
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string date { get; set; }
        public string title { get; set; }
        public string extra { get; set; }
        public string[] law { get; set; }
        public object[] law_id { get; set; }
    }

}