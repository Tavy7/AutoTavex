using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoTavex.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Car Manufacturer")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Enter Car Series")]
        public string Series { get; set; }
        public bool HasThermalEngine { get; set; }
        public bool IsHybrid { get; set; }
        public short? CylindricalCapacity { get; set; }
        [Range(1, 1000, ErrorMessage="Must be a real number.")]
        public short? HorsePower { get; set; }
        // Validare custom: nu vindem masini mai vechi de 15 ani decat daca au motor mare
        [Range(1950, 2030, ErrorMessage="Too old.")]
        public short YearManufactured { get; set; }
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN needs to have 17 characthers.")]
        [Required(ErrorMessage="VIN is mandatory.")]
        public string Vin { get; set; }
    }
}