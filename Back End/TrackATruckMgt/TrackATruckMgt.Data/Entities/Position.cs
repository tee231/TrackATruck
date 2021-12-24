using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Data.Entities
{
   public class Position:Entity<long>
    {
        public long AgeOfReadingSeconds { get; set; }
        public string AssetId { get; set; }
        public string AltitudeMetres { get; set; }
        public string DriverId { get; set; }
        public int Heading { get; set; }
        public string Latitude { get; set; }
        public bool IsAvl { get; set; }
        public string OdometerKilometres { get; set; }
        public string Longitude { get; set; }
        public int Hdop { get; set; }
        public string PositionId { get; set; }
        public int Pdop { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Source { get; set; }
        public int SpeedKilometresPerHour { get; set; }
        public int SpeedLimit { get; set; }
        public int Vdop { get; set; }
     
    }
}
