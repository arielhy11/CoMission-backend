namespace Chat_App.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
