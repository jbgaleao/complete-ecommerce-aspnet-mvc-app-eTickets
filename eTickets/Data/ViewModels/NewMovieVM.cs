using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using eTickets.Data.Enums;

namespace eTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency,ErrorMessage ="Format Price is wrong")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie poster URL is Required")]
        [Display(Name = "Movie Poster")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Movie Start Date is Required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Movie End Date is Required")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Select a Movie Category")]
        [Display(Name = "Movie Category")]
        public MovieCategory MovieCategory { get; set; }



        [Required(ErrorMessage = "Select the Actor(s)")]
        [Display(Name = "Movie Actors")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Select the Cinema")]
        [Display(Name = "Cinema Movie Name")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Select the Producer")]
        [Display(Name = "Producer(s) Movie Category")]
        public int ProducerId { get; set; }

    }
}
