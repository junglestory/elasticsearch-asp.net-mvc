using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elasticsearch_asp.net_mvc.Models
{
    public class Search
    {
        public string title { get; set; }

        public string desc { get; set; }

        public string url { get; set; }

        public string author { get; set; }

        public string date { get; set; }

        public string category { get; set; }
    }
}