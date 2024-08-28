using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie.Entity.MovieUserRelationships
{
    public class FavMovie
    {
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }
        [Required]
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
       
        [ForeignKey("MovieID")]
        public virtual Movie Movie { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
