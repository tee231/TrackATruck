using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Core.DTOs
{
    public class TruckDto:BaseModel<long>
    {
        public string SiteId { get; set; }
        public string AssetId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime LastPositionTimestamp { get; set; }
        public string Latitude { get; set; }
        public string Longitute { get; set; }
        public string CurrentAddress { get; set; }

    }
}
