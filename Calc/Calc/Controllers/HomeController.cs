using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calc.Models;

namespace Calc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var calc = new Calculator()
            {
                Operand1 = 0,
                Operand2 = 0,
                Result = 0,
                Operation = "+"
            };
            return View(calc);
        }

        [HttpPost]
        public IActionResult Index(Calculator calc)
        {
            switch(calc.Operation)
            {
                case "+": 
                    calc.Result = calc.Operand1 + calc.Operand2;
                    break;
                case "-":
                    calc.Result = calc.Operand1 - calc.Operand2;
                    break;
                case "*":
                    calc.Result = calc.Operand1 * calc.Operand2;
                    break;
                case "/":
                    calc.Result = calc.Operand1 / calc.Operand2;
                    break;
                default :
                    calc.Result = 0;
                    break;    
            }
            return View(calc);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
