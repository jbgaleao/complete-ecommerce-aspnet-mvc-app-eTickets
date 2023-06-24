using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using eTickets.Data.Base;
using eTickets.Data.Enums;

namespace eTickets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        public String ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }


        //  Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //  Cinema
        [ForeignKey("CinemaId")]
        public Int32 CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        //  Producer
        [ForeignKey("ProducerId")]
        public Int32 ProducerId { get; set; }
        public Producer Producer { get; set; }


    }
}
