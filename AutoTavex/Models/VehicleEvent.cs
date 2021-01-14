using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoTavex.Models
{
    public class VehicleEvent
    {
        [Key]
        public int EventId { get; set; }
        public IEnumerable<Car> EventCars { get; set; }
        public IEnumerable<Moto> EventMoto { get; set; }
        public IEnumerable<Customer> CustomerVehicles { get; set; } 
    }
}