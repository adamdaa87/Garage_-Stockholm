using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Core.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Vehicle Type")]
        public string TypeName { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
