using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IMessagesManager
    {
        Task<IEnumerable<MessageModel>> GetAllMessages();

        Task<IEnumerable<MessageModel>> GetMessagesOf(int userId);

        Task<IEnumerable<MessageModel>> GetUserMessagesToUser(int senderId, int recipientId);

        Task<IEnumerable<MessageModel>> GetMessagesBetween(int firstUserId, int secondUserId);

        Task<IEnumerable<MessageModel>> GetRecievedMessagesBy(int recipientId);

        Task<MessageModel> GetMessageById(int id);

        Task<MessageModel> AddMessage(MessageModel message);

        Task<MessageModel> UpdateMessage(MessageModel message);

        Task<bool> DeleteMessage(int id);
    }
}
