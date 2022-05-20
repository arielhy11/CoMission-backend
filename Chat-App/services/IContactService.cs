using Chat_App.Models;

namespace Chat_App.services
{
    public interface IContactService
    {
        public List<Contact> GetAll();

        public Contact Get(int id);

        public void Create(string name, string nickName, List<Message> messages, User user);

        public void Edit(int id, string name, string nickName, List<Message> messages, User user);

        public void Delete(int id);
    }
}
