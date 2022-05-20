namespace Chat_App.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public ICollection<Message> Messages { get; set; }

        public User User { get; set; }
    }
}
