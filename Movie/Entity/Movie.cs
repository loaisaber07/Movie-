using Movie.Entity.Movie_RelationShips;
using Movie.Entity.MovieUserRelationships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Entity
{
    public class Movie
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
       
        public string? Title { get; set; }
        [Url]
        public string? Url { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date  { get; set; }
        [Required]
        public string Image  { get; set; }
        [Required]
        public int RunTime { get; set; }
        public DateTime DateUpload => DateTime.Now;
         [InverseProperty("Movie")]
        public virtual ICollection<Actors>? Actors { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<Rating>? Rates { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<Review>? Reviews { get; set; }

    }
}
