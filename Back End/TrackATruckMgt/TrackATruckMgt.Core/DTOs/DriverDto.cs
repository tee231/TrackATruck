using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Core.DTOs
{
    public class DriverDto:BaseModel<long>
    {
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
        public string SiteId { get; set; }
        public string DriverId { get; set; }
    }
}
