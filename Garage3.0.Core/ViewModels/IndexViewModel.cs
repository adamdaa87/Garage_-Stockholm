using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Core.ViewModels
{
    public class IndexViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "Length must be 6 characters long.", MinimumLength = 6)]
        [Remote("ValidateRegNum", "Vehicle")]
        [DisplayName("Registration number")]
        public string RegNr { get; set; }

        [DisplayName("Parking started")]
        public DateTime TimeOfArrival { get; set; }/* = DateTime.Now;*/

        [Required]
        [DisplayName("Vehicle Type")]
        public string TypeName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string Fname { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string Lname { get; set; }

        [Required]
        [DisplayName("Parking Lot")]
        public int ParkingLot { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }



    }
}
