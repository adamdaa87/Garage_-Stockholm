using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Garage3._0.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string Fname { get; set; }

        [Required]
        [Remote("ValidateName", "Users", AdditionalFields = nameof(Fname))]
        [DisplayName("Last Name")]
        public string Lname { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Length must be 12 characters long in this form 'yyyymmddxxxx'.", MinimumLength = 12)]
        [Remote("ValidatePerNum", "Users")]
        [DisplayName("Personal number")]
        public string Pnr { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
