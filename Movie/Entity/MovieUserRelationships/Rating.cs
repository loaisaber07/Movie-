using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Entity.MovieUserRelationships
{
    public class Rating
    {
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }
        [Required]
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        [Required]
        [Range(1,10)]
        public int Rationg { get; set; }
        [ForeignKey("MovieID")]
        public virtual Movie Movie { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
