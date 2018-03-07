using System;
using System.Collections.Generic;

namespace RestrauntMenu.Models
{
    public class Restraunt
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Menu> Menu {get; set;}
    }
}
