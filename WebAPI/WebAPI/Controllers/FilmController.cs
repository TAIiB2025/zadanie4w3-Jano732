using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> _filmy = new()
        {
            new Film { Id = 1, Tytul = "Incepcja", Rezyser = "Christopher Nolan", Gatunek = "Sci-Fi", Rok_wydania = 2010 },
            new Film { Id = 2, Tytul = "Parasite", Rezyser = "Bong Joon-ho", Gatunek = "Dramat", Rok_wydania = 2019 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetAll() => Ok(_filmy);

        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            var film = _filmy.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound();
            return Ok(film);
        }

        [HttpPost]
        public ActionResult Post(FilmBody body)
        {
            var film = new Film
            {
                Id = _filmy.Any() ? _filmy.Max(f => f.Id) + 1 : 1,
                Tytul = body.Tytul,
                Rezyser = body.Rezyser,
                Gatunek = body.Gatunek,
                Rok_wydania = body.Rok_wydania
            };
            _filmy.Add(film);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FilmBody body)
        {
            var film = _filmy.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound();
            film.Tytul = body.Tytul;
            film.Rezyser = body.Rezyser;
            film.Gatunek = body.Gatunek;
            film.Rok_wydania = body.Rok_wydania;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var film = _filmy.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound();
            _filmy.Remove(film);
            return NoContent();
        }
    }
}
