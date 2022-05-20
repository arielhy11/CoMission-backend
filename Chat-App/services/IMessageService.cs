using Chat_App.Models;

namespace Chat_App.services
{
    public interface IMessageService
    {
        public List<Message> GetAll();

        public Message Get(int id);

        //public Message Search();

        public void Create(string content, DateTime created, string status, string contact);
        
        // maybe neccesery
        //public void Edit(int id, string content, DateTime created, string status, string contact);

        public void Delete(int id);
    }
}
