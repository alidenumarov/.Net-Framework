using System;
using Lab1.Models;
using System.Collections.Generic;

namespace Lab1.Models
{
    public class Course
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<Student> Students { get; set; }   
    }

}