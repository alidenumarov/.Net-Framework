using System;
using Lab1.Models;
using System.Collections.Generic;

namespace Lab1.Models
{
    public class Teacher {
        
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
    }
}