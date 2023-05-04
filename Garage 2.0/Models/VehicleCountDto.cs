using Garage3._0.Core.Entities;

namespace Garage_2._0.Models
{
    public class VehicleCountDto
    {
        public string VehicleType { get; set; }

        public TimeSpan timespan { get; set; }
        public int NoOfWheels { get; set; }
        public int Total { get; set; }
    }
}