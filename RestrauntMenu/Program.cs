using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RestrauntMenu.Models;

namespace RestrauntMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            var menus = new List<Menu> {
                new Menu {Id = 1, kitchen = "europian, authors", avPrice = "5000-7000 kzt", address = "Abylai Khan, 104"},
                new Menu {Id = 2, kitchen = "italian", avPrice = "5000-10000 kzt", address = "Gornii' Gigant, 11/6"},
                new Menu {Id = 3, kitchen = "europian", avPrice = "3000-5000 kzt", address = "Abdullin, 50"},
                new Menu {Id = 4, kitchen = "georgian", avPrice = "4000-8000 kzt", address = "Abylai Khan, 32"},
                new Menu {Id = 5, kitchen = "europian, italian, american ", avPrice = "3000-5000 kzt", address = "Satbayev, 30 A/1"}
            };

            var restraunts = new List<Restraunt> {
                new Restraunt {Id = 1, Name = "Rumi", Menu = new List<Menu> {menus.ElementAt(0)}},
                new Restraunt {Id = 2, Name = "Borgo Antico", Menu = new List<Menu> {menus.ElementAt(1)}},
                new Restraunt {Id = 3, Name = "Kraft Pub", Menu = new List<Menu> {menus.ElementAt(2)}},
                new Restraunt {Id = 4, Name = "Пиросмани", Menu = new List<Menu> {menus.ElementAt(3)}},
                new Restraunt {Id = 5, Name = "Om.Nom.Nom", Menu = new List<Menu> {menus.ElementAt(4)}},
            };

            Console.WriteLine("Hello World!");
        }
    }
}
