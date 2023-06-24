namespace eTickets.Models
{
    public class ErrorViewModel
    {
        public System.String RequestId { get; set; }

        public System.Boolean ShowRequestId => !System.String.IsNullOrEmpty(RequestId);
    }
}
