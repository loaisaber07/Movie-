using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Entity;
using Movie.Repository.MovieRepository;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository movie;

        public MovieController(IMovieRepository movie)
        {
            this.movie = movie;
        }
        [HttpGet]
        public ActionResult GetAllMovie() {
            IQueryable<Movie.Entity.Movie> movies = movie.GetAll();
            if (movies is null) {
                return NotFound();
            }
            return Ok(movies.ToList());          
        
        }
    }
}
