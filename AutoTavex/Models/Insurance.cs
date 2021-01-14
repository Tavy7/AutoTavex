using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AutoTavex.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Contract duration must be specified.")]
        [Range(1, int.MaxValue, ErrorMessage = "You have to get insurance for alteast one year.")]
        [Display(Name = "Duration In Years")]
        public int DurationInYears { get; set; }
        [Required(ErrorMessage = "Customer name must be specified.")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer CNP must be specified.")]
        [Display(Name = "Customer CNP")]
        public string CustomerCNP { get; set; }
        [Required(ErrorMessage = "Car name must be specified.")]
        [Display(Name = "Car name")]
        public string CarName { get; set; }
        [Required(ErrorMessage = "VIN must be specified.")]
        [Display(Name = "VIN")]
        public string CarVIN { get; set; }
        public int CarId { get; set; }
        public float ContractValue { get; set; }
    }
}