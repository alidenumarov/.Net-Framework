using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RestrMenu.Models;

namespace RestrMenu
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
        public void initialize() {
            List<Menu> menus = new List<Menu> {
                new Menu {Id = 1, kitchen = "europian, authors", avPrice = "5000-7000 kzt", address = "Abylai Khan, 104"},
                new Menu {Id = 2, kitchen = "italian", avPrice = "5000-10000 kzt", address = "Gornii' Gigant, 11/6"},
                new Menu {Id = 3, kitchen = "europian", avPrice = "3000-5000 kzt", address = "Abdullin, 50"},
                new Menu {Id = 4, kitchen = "georgian", avPrice = "4000-8000 kzt", address = "Abylai Khan, 32"},
                new Menu {Id = 5, kitchen = "europian, italian, american ", avPrice = "3000-5000 kzt", address = "Satbayev, 30 A/1"}
            };
            List<Restraunt> restraunts = new List<Restraunt>();
            restraunts = new List<Restraunt> {
                new Restraunt {Id = 1, Name = "Rumi", Menu = new List<Menu> {menus.ElementAt(0)}},
                new Restraunt {Id = 2, Name = "Borgo Antico", Menu = new List<Menu> {menus.ElementAt(1)}},
                new Restraunt {Id = 3, Name = "Kraft Pub", Menu = new List<Menu> {menus.ElementAt(2)}},
                new Restraunt {Id = 4, Name = "Пиросмани", Menu = new List<Menu> {menus.ElementAt(3)}},
                new Restraunt {Id = 5, Name = "Om.Nom.Nom", Menu = new List<Menu> {menus.ElementAt(4)}},
            };

            for(int i = 0; i < 5; i++) {
                Console.WriteLine(string.Format("{0}    |    {1}    |    {2}    |    {3}",
                    restraunts.ElementAt(i).Name,
                    menus.ElementAt(i).kitchen,
                    menus.ElementAt(i).avPrice,
                    menus.ElementAt(i).address
                ));
            }
        }
        // public void oout() {
        //         Console.WriteLine(string.Format("{0}    |    {1}    |    {2}    |    {3}    |    {4}",
        //         restraunts.ElementAt(0).Name,
        //         restraunts.ElementAt(1).Name,
        //         restraunts.ElementAt(2).Name,
        //         restraunts.ElementAt(3).Name,
        //         restraunts.ElementAt(4).Name));
        // }
    }
}
