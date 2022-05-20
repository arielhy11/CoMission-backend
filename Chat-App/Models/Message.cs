namespace Chat_App.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        // Me or freind
        public string Status { get; set; }

        public Contact Contact { get; set; }
    }
}
