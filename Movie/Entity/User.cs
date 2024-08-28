using Microsoft.AspNetCore.Identity;
using Movie.Entity.MovieUserRelationships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Entity
{
    public class User : IdentityUser
    {
        [Required]
        public string Image  { get; set; }
        [DataType(DataType.Date)]
        public string? BirthDay { get; set; }
        [Required]
        [MaxLength(100)]
        public string Bio { get; set; }
        public DateTime DataJoin => DateTime.Now; //ReadOnly Property  
        [InverseProperty("User")]
        public virtual ICollection<Rating>? Rates { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Review>? Reviews { get; set; }

    }
}
