using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IMessagesManager
    {
        Task<IEnumerable<MessageModel>> GetAllMessages();

        Task<IEnumerable<MessageModel>> GetMessagesOf(string userId);

        Task<IEnumerable<MessageModel>> GetUserMessagesToUser(string senderId, string recipientId);

        Task<IEnumerable<MessageModel>> GetMessagesBetween(string firstUserId, string secondUserId);

        Task<IEnumerable<MessageModel>> GetRecievedMessagesBy(string recipientId);

        Task<MessageModel> GetMessageById(int id);

        Task<MessageModel> AddMessage(MessageModel message);

        Task<MessageModel> UpdateMessage(MessageModel message);

        Task<bool> DeleteMessage(int id);
    }
}
