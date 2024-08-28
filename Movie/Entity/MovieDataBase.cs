using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie.Entity.Movie_RelationShips;
using Movie.Entity.MovieUserRelationships;

namespace Movie.Entity
{
    public class MovieDataBase:IdentityDbContext<User>
    {
        public MovieDataBase(DbContextOptions<MovieDataBase>options):base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<FavMovie> FavMovies { get; set; }
        public DbSet<PlanToWatch> PlanToWatchMovies { get; set; }
        public DbSet<ContinueWatching> ContinueWatchingMovies { get; set; }
        public DbSet<Rating> Rates { get; set; }   
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category>Categories  { get; set; }
        public DbSet<WatchingLater> ContinueWatching { get; set; }
        public DbSet<Actors> Actors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FavMovie>().HasKey(s => new { s.MovieID, s.UserID });
            builder.Entity<PlanToWatch>().HasKey(s => new { s.MovieID, s.UserID });
            builder.Entity<ContinueWatching>().HasKey(s => new { s.MovieID, s.UserID });
            builder.Entity<Rating>().HasKey(s => new { s.MovieID, s.UserID });
            builder.Entity<Review>().HasKey(s => new { s.MovieID, s.UserID });
            builder.Entity<WatchingLater>().HasKey(s => new { s.MovieID, s.UserID }); 
            //shadow property
            builder.Entity<Movie>().Property<bool>("Deleted").IsRequired(true).HasDefaultValue(false);
            //Global Query 
            builder.Entity<Movie>().HasQueryFilter(s =>!EF.Property<bool>(s,"Deleted"));
            base.OnModelCreating(builder);
        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
           
            base.OnConfiguring(optionsBuilder);
        }


    }
}
