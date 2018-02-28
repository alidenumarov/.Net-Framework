using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculator()
        {
            var calc = new CalculatorVals()
            {
                FirstValue = 0,
                SecondValue = 0,
                Answer = 0,
                Operator = "+"
            };
            return View(calc);
        }

        [HttpPost]
        public IActionResult Calculator(CalculatorVals vals)
        {
            if(vals.Operator == "+") {
                vals.Answer = vals.FirstValue + vals.SecondValue;
            } else if(vals.Operator == "-") {
                vals.Answer = vals.FirstValue - vals.SecondValue;                
            } else if(vals.Operator == "/") {
                vals.Answer = vals.FirstValue / vals.SecondValue;                
            } else {
                vals.Answer = vals.FirstValue * vals.SecondValue;                
            }
            return View(vals);
        }
    }
}
