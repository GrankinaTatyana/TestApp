using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class JsonObjectForResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public bool show_form { get; set; }
        public int unique_status { get; set; }
    }
}
