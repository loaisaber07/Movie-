using Movie.Entity;

using Movie.Entity.MovieUserRelationships;

namespace Movie.Repository.MovieRepository
{
    public  interface IMovieRepository
    {
        IQueryable<Movie.Entity.Movie> GetAll();
        Movie.Entity.Movie GetById(int id); 
        Movie.Entity.Movie GetByTitle(string title);
    }
}
