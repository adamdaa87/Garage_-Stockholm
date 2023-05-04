using Garage3._0.Core.Entities;
using System.ComponentModel;

namespace Garage_2._0.Models
{
    public class EditVehicleViewModel
    {
        public int Id { get; set; }

        [DisplayName("Parking Lot")]
        public int ParkingLot { get; set; }

        [DisplayName("Registration number")]
        public string RegNr { get; set; } = String.Empty;

        [DisplayName("Type of vehicle")]
        public VehicleType VehicleType { get; set; }

        [DisplayName("Make")]
        public string Make { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        [DisplayName("Wheels on vehicle")]
        public int NrOfWheels { get; set; }

        [DisplayName("Time parking started")]
        public DateTime TimeOfArrival { get; set; }

    }
}
