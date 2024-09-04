using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYasinDemoApp.Models
{
    public class Circuit
    {
          
        public int circuitId { get; set; }
        public string circuitRef { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public double lat { get; set; }
        public double lng { get; set; }
        public int alt { get; set; }
        public string url { get; set; } = string.Empty;
    }
}

