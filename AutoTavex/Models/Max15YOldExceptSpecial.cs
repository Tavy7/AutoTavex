using System;
using System.ComponentModel.DataAnnotations;


namespace AutoTavex.Models
{
    public class Max15YOldExceptSpecial : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DatabaseContext _context = new DatabaseContext();

            var car = (Car)validationContext.ObjectInstance;

            if (car.CylindricalCapacity >= 3000 || car.HorsePower >= 250)
            {
                return ValidationResult.Success;
            }

            if (car.YearManufactured is null)
            {
                return new ValidationResult("Model year is required.");
            }

            var carAge = DateTime.Today.Year - car.YearManufactured;

            if (carAge < 15)
            {
                return ValidationResult.Success;
            }

            foreach (var specialCar in _context.SpecialCars)
            {
                bool cond1 = car.Manufacturer == specialCar.Manufacturer;
                bool cond2 = car.Series == specialCar.Series;
                if (cond1 && cond2)
                {
                    return ValidationResult.Success;
                }
            }

            _context.Dispose();
            return new ValidationResult("Car has to have atleast a 3l engine or be on a special list ( contact Admin ) if it is older than 15 years.");
        }
    }
}