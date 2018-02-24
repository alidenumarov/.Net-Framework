using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Calculator.Models
{
    public class CalculatorVals
    {   
        [Required]
        public float FirstValue { get; set; }
        public string Operator { get; set; }
        [Required]
        public float SecondValue { get; set; }

        public float Answer { get; set; }

    }
}