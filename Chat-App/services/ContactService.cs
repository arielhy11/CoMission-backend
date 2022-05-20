using Chat_App.Models;

namespace Chat_App.services
{
    public class ContactService : IContactService
    {
        private static List<Contact> contacts = new List<Contact>();

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public Contact Get(int id)
        {
            return contacts.Find(x => x.Id == id);
        }

        public void Create(string name, string nickName, List<Message> messages, User user)
        {
            int nextId = 0;
            if (contacts.Count > 0)
            {
                nextId = contacts.Max(x => x.Id) + 1;
            }
            contacts.Add(new Contact { Id = nextId, Name = name, NickName = nickName, Messages = messages, User = user });
        }

        public void Edit(int id, string name, string nickName, List<Message> messages, User user)
        {
            Contact contact = Get(id);
            contact.Name = name;
            contact.NickName = nickName;
            contact.Messages = messages;
            // the User member need to be contant and cant change
        }

        public void Delete(int id)
        {
            contacts.Remove(contacts.Find(x => x.Id == id));
        }
    }
}
