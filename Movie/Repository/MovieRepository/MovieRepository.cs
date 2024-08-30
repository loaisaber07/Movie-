
using Microsoft.EntityFrameworkCore;
using Movie.Entity;

namespace Movie.Repository.MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDataBase context;

        public MovieRepository(MovieDataBase context)
        {
            this.context = context;
        }
        public  IQueryable<Entity.Movie> GetAll()
        {
            return context.Movies.Include(s =>s.Rates).Include(s=>s.Reviews).Include(s=>s.Actors)
                .AsNoTracking(); 
        }

        public Entity.Movie? GetById(int id)
        {
           return context.Movies.AsNoTracking()
                .Include(s => s.Rates).Include(s => s.Reviews).Include(s => s.Actors)
                .FirstOrDefault(s=>s.ID == id);
        }

        public Entity.Movie? GetByTitle(string title)
        {
            return context.Movies.AsNoTracking()
              .Include(s => s.Rates).Include(s => s.Reviews).Include(s => s.Actors)
              .FirstOrDefault(s => s.Name ==title);

        }
    }
}
