using System;
using Lab1.Models;
using System.Collections.Generic;

namespace Lab1.Models
{
    public class Organization {
        
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }    
}