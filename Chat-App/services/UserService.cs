using Chat_App.Models;

namespace Chat_App.services
{
    public class UserService
    {
        private static List<User> users = new List<User>();
        public List<User> GetAll() {
            return users; 
        }

        public User Get(int id) { 
            return users.Find(x => x.Id == id);
        }

        public void Create(string name, string password, List<Contact> contacts) {
            int nextId = 0;
            if (users.Count > 0)
            {
                nextId = users.Max(x => x.Id) + 1;
            }
            users.Add(new User { Id = nextId, Name = name, Password = password, Contacts = contacts });
        }

        public void Edit(int id, string userName, string password, List<Contact> contacts) {
            User user = Get(id);
            user.Name = userName;
            user.Password = password;
            user.Contacts = contacts;
        }

        public void Delete(int id) { 
            users.Remove(users.Find(x => x.Id == id));
        }

    }
}
