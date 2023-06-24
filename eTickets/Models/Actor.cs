using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using eTickets.Data.Base;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public System.Int32 Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public System.String ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Full Name must be between 3 and 50 chars!")]
        public System.String FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public System.String Bio { get; set; }



        // Relationships Actors_Movies
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
