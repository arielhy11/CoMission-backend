using Chat_App.Models;

namespace Chat_App.services
{
    public interface IUserService
    {
        public List<User> GetAll(); 

        public User Get(int id);

        public void Create(string userName, string password, List<Contact> contacts);

        public void Edit(int id, string userName, string password, List<Contact> contacts);

        public void Delete(int id);

    }
}
