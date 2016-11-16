using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IMessagesManager
    {
        Task<IEnumerable<MessageModel>> GetAllMessages();

        Task<IEnumerable<MessageModel>> GetMessagesOf(UserModel user);

        Task<IEnumerable<MessageModel>> GetUserMessagesToUser(UserModel sender, UserModel recipient);

        Task<IEnumerable<MessageModel>> GetMessagesBetween(UserModel firstUser, UserModel secondUser);

        Task<IEnumerable<MessageModel>> GetRecievedMessagesBy(UserModel recipient);

        Task<MessageModel> GetMessageById(int id);

        Task<MessageModel> AddMessage(MessageModel message);

        Task<MessageModel> UpdateMessage(MessageModel message);

        Task<bool> DeleteMessage(int id);
    }
}
