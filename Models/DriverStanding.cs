using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYasinDemoApp.Models
{
    public class DriverStanding
    {
        public int driverStandingsId { get; set; }
        public int raceId { get; set; }
        public int driverId { get; set; }
        public double points { get; set; }
        public int position { get; set; }
        public string positionText { get; set; } = string.Empty;
        public int wins { get; set; }
    }
}
