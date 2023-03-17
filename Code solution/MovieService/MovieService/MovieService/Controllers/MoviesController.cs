using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.Data;
using MovieService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByGenre([FromQuery] string genre)
        {
            var movies = await _context.Movies.Where(m => m.Genre == genre).ToListAsync();

            if (movies.Count == 0)
            {
                return NotFound();
            }

            return movies;
        }
    }

}
