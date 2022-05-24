﻿using Chat_App.Models;

namespace Chat_App.services
{
    public class ContactService : IContactService
    {
        private static List<Contact> contacts = new List<Contact>() {
                        new Contact { Id = "yosef", Name = "yossi", Messages = new List<Message>(){ 
                            new Message { Id = 0, Content = "hello darkness", Created = DateTime.Now, Sent = true },
                            new Message { Id = 1, Content = "my old freind", Created = DateTime.Now, Sent = true }}},
                        new Contact { Id = "ariel", Name = "ari" , Messages = new List<Message>(){
                            new Message { Id = 0, Content = "how are you", Created = DateTime.Now, Sent = true },
                            new Message { Id = 1, Content = "good", Created = DateTime.Now, Sent = true }} }};

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public Contact Get(string id)
        {
            return contacts.Find(x => x.Id == id);
        }

        public void Create(string id, string name, string server)
        {
            contacts.Add(new Contact { Id = id, Name = name, Server = server });
        }

        public void Edit(string id, string name, string server)
        {
            Contact contact = Get(id);
            contact.Name = name;
            contact.Server = server;
        }

        public void Delete(string id)
        {
            contacts.Remove(contacts.Find(x => x.Id == id));
        }

        public List<Message> GetAllMessages(string id)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            return contact.Messages;
        }

        public Message GetMessage(string id, int messageID)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            Message message = contact.Messages.Find(c => c.Id == messageID);
            return message;
        }

        public int CreateMessage(string id, string content)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            int nextId = 0;
            if (contact.Messages.Count > 0)
            {
                nextId = contact.Messages.Max(x => x.Id) + 1;
            }
            contact.Messages.Add(new Message { Id = nextId, Content = content, Created = DateTime.Now, Sent = true });
            return nextId;
        }

        public void DeleteMessage(string id, int messageID)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            contact.Messages.Remove(contact.Messages.Find(c => c.Id == messageID));
        }

        public void EditMessage(string id, int messageID, string content)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            contact.Messages.Find(c => c.Id == messageID).Content = content;
        }
    }
}
