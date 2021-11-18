using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Core.Models
{

   public class CurrentLocationDto
    {
        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime LastPositionTimestamp { get; set; }
    }
}
