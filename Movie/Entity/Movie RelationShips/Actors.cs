using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Entity.Movie_RelationShips
{
    public class Actors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public virtual Movie Movie { get; set; }
    }
}
