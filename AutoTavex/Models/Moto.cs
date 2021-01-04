using System.ComponentModel.DataAnnotations;

namespace AutoTavex.Models
{
    public class Moto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Car Manufacturer")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Enter Car Series")]
        public string Series { get; set; }

        [Required(ErrorMessage = "Please enter mileage.")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be a natural number.")]
        public int TachometerValue { get; set; }

        public short? CylindricalCapacity { get; set; }

        [Range(1, 1000, ErrorMessage = "Must be a natural number.")]
        public short? HorsePower { get; set; }

        public string Caroserie { get; set; }

        public short? YearManufactured { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN needs to have 17 characthers.")]
        public string Vin { get; set; }

        public string Image { get; set; }

        public string ExtraDetails { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number.")]
        public float Price { get; set; }
    }
}