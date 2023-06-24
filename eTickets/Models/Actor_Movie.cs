namespace eTickets.Models
{
    public class Actor_Movie
    {
        public System.Int32 MovieId { get; set; }
        public Movie Movie { get; set; }

        public System.Int32 ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
