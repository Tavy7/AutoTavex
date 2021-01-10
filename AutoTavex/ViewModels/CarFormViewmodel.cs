using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoTavex.Models;

namespace AutoTavex.ViewModels
{
    public class CarFormViewmodel
    {
        public string Title { get; set; }
        public Car Car { get; set; }

        public const string Add = "Add";
        public const string Edit = "Edit";

        public CarFormViewmodel(int id = 0)
        {
            Title = Add;
            Car = new Car
            {
                Id = id
            };
        }
    }
}