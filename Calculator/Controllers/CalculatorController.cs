using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpPost]
        public IActionResult Calculator(CalculatorVals calculatorVals)
        {
            calculatorVals = new CalculatorVals();
            var ans = Convert.ToInt32(calculatorVals.FirstValue) + Convert.ToInt32(calculatorVals.SecondValue);
            // calculatorVals.Operators = "555";
            calculatorVals.Answer = ans.ToString();
            // calculatorVals.SecondValue = "asd";
            // calculatorVals.Answer = "OOOKK";
            
            return View(calculatorVals);
        }
    }
}
