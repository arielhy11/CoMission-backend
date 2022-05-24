using Chat_App.Models;

namespace Chat_App.services
{
    public interface ITransferService
    {
        public Message Create(string Id, string To, string Content);
    }
}
