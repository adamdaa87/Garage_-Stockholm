using Garage3._0.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3._0.Core.ViewModels
{
    public class VehicleTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Vehicle Type")]
        public string TypeName { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
