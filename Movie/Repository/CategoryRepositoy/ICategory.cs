using Movie.Entity.Movie_RelationShips;

namespace Movie.Repository.CategoryRepositoy
{
    public interface ICategory
    {
        IQueryable<Category> GetAllGategoryName(); 
        
    }
}
