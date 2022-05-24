namespace Chat_App.Models
{
    public class Contact
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Server { get; set; }

        public string Last { get; set; }

        public DateTime LastDate { get; set; }

        public List<Message> Messages { get; set; }

        //public User User { get; set; }
    }
}
