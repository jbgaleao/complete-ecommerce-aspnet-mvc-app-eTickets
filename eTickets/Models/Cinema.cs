using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using eTickets.Data.Base;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public System.Int32 Id { get; set; }

        [Display(Name = "Logo Picture")]
        [Required(ErrorMessage = "Logo Picture is required")]
        public System.String Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Cinema Name must be between 3 and 50 chars!")]
        public System.String Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema Description is required")]
        public System.String Description { get; set; }


        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
