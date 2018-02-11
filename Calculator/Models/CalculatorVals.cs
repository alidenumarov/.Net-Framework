using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Calculator.Models
{
    public class CalculatorVals
    {   
        [Required]
        public string FirstValue { get; set; }
        public string Operator { get; set; }
        [Required]
        public string SecondValue { get; set; }

        public String Answer { get; set; }

    }
}