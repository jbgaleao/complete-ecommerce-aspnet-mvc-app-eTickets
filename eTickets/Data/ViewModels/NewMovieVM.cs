using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using eTickets.Data.Base;
using eTickets.Data.Enums;
using eTickets.Models;

namespace eTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        [Required(ErrorMessage ="Name is Required")]
        [Display(Name ="Movie Name")]
        public String Name { get; set; }
        
        [Required(ErrorMessage = "Description is Required")]
        [Display(Name = "Description")]
        public String Description { get; set; }
        
        [Required(ErrorMessage = "Price is Required")]
        [Display(Name = "Price")]
        public Double Price { get; set; }
        
        [Required(ErrorMessage ="Movie poster URL is Required")]
        [Display(Name ="Movie Poster")]
        public String ImageURL { get; set; }
        
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
        public List<Int32> ActorIds { get; set; }

        [Required(ErrorMessage = "Select the Cinema")]
        [Display(Name = "Cinema Movie Name")]
        public Int32 CinemaId { get; set; }

        [Required(ErrorMessage = "Select the Producer")]
        [Display(Name = "Producer(s) Movie Category")]
        public Int32 ProducerId { get; set; }

    }
}
