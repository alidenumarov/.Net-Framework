using System;
using System.Collections.Generic;
using System.Linq;
using Lesson6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson6.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController: Controller 
    {
        private static List<Film> _films;

        public FilmsController()
        {
            if(_films == null)
            {
                Generate();
            }
        }

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _films;
        }

        [HttpGet("{id}")]
        public Film Get(int id)
        {
            return _films.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Film film)
        {
            film.Id = _films.Max(x => x.Id) + 1;
            _films.Add(film);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _films.First(x => x.Id == id);
            _films.Remove(item);
        }

        private void Generate()
        {
            _films = new List<Film>();
            _films.Add(new Film(){ Id = 1, Name = "aaa", Authors = "Sam", Rating = 3 });
            _films.Add(new Film(){ Id = 2, Name = "bbb", Authors = "Tom", Rating = 4 });
            _films.Add(new Film(){ Id = 3, Name = "ccc", Authors = "Smith", Rating = 2 });
        }
    }
}