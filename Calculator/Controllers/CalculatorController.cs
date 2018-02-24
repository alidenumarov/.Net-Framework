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
        [HttpGet]
        public IActionResult Index()
        {
            var vals = new CalculatorVals()
            {
                FirstValue = 0,
                SecondValue = 0,
                Answer = 0,
                Operator = "+"
            };
            return View(vals);
        }

        [HttpPost]
        public IActionResult Index(CalculatorVals vals)
        {
            switch(vals.Operator)
            {
                case "+": 
                    vals.Answer = vals.FirstValue + vals.SecondValue;
                    break;
                case "-":
                    vals.Answer = vals.FirstValue - vals.SecondValue;
                    break;
                case "*":
                    vals.Answer = vals.FirstValue * vals.SecondValue;
                    break;
                case "/":
                    vals.Answer = vals.FirstValue / vals.SecondValue;
                    break;
                default :
                    vals.Answer = 0;
                    break;    
            }
            return View(vals);
        }
    }
}
