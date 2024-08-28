
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
            return context.Movies.AsNoTracking() ; 
        }

        public Entity.Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Entity.Movie GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
