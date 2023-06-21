using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profile Picture URL")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }


        //Relationships

        //  Actors_Movies
        public List<Actor_Movie> Actors_Movies { get; set; }

        //  Cinema
        //[ForeignKey("CinemaId")]
        //public int CinemaId { get; set; }
        //public Cinema Cinema { get; set; }
    }
}
