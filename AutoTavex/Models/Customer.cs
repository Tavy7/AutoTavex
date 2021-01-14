using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AutoTavex.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "ID number")]
        public string CNP { get; set; }
        public bool IsOver18 { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> CarsId { get; set; }
        public IEnumerable<int> MotosId { get; set; }
    }
}