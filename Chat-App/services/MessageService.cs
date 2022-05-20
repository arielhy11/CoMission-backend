using Chat_App.Models;

namespace Chat_App.services
{
    public class MessageService
    {
        private static List<Message> messages = new List<Message>();
        public List<Message> GetAll()
        {
            return messages;
        }

        public Message Get(int id)
        {
            return messages.Find(x => x.Id == id);
        }

        //public Message Search();

        public void Create(string content, DateTime created, string status, Contact contact)
        {
            int nextId = 0;
            if (messages.Count > 0)
            {
                nextId = messages.Max(x => x.Id) + 1;
            }
            messages.Add(new Message { Id = nextId, Content = content, CreatedDate = created, Status = status, Contact = contact });
        }

        // maybe neccesery
        //public void Edit(int id, string content, DateTime created, string status, string contact);

        public void Delete(int id)
        {
            messages.Remove(messages.Find(x => x.Id == id));
        }
    }
}
