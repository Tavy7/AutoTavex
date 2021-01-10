using System.ComponentModel.DataAnnotations;

namespace AutoTavex.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Car Manufacturer")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Enter Car Series")]
        public string Series { get; set; }

        [Required(ErrorMessage = "Please enter mileage.")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be a natural number.")]
        [Display(Name = "Tachometer Value")]
        public int TachometerValue { get; set; }

        public bool HasThermalEngine { get; set; }
        public bool IsHybrid { get; set; }
        public bool IsManual { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "Must be between 3 and 10 characthers.")]
        public string Transmission { get; set; }
        [Range(500, 10000, ErrorMessage = "Must be a real engine.")]
        [Display(Name = "Cylindrical Capacity")]
        public short? CylindricalCapacity { get; set; }
        [Range(1, 1000, ErrorMessage = "Must be a natural number.")]
        public short? HorsePower { get; set; }

        // Validare custom: nu vindem masini mai vechi de 15 ani decat daca au motor mare
        [Max15YOldExceptSpecial]
        [Display(Name = "Year Manufactured")]
        public short? YearManufactured { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN needs to have 17 characthers.")]
        [Required(ErrorMessage = "VIN is mandatory.")]
        public string Vin { get; set; }

        [Display(Name = "Upload picture")]
        public string Image { get; set; }

        [Display(Name = "Extra Details")]
        public string ExtraDetails { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number.")]
        public float Price { get; set; }

        // eventual de adaugat campuri pentru transmisie, cutie de viteza, norma de poloare
    }
}

// De implementat camp pentru descriere, pret, 
// contact alea de bagat in alta clasa