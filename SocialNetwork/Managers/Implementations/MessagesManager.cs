using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models;
using Repositories.Interfaces;

namespace Managers.Implementations
{
    internal class MessagesManager : ManagerBase, IMessagesManager
    {
        private readonly IMessagesRepository _messagesRepository;

        public MessagesManager(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public async Task<IEnumerable<MessageModel>> GetAllMessages()
        {
            return (await _messagesRepository.GetItemsAsync())
                .Select(Mapper.Map<Message, MessageModel>);
        }

        public async Task<IEnumerable<MessageModel>> GetMessagesOf(int userId)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg => msg.SenderId == userId || msg.AddresseeId == userId)))
                .Select(Mapper.Map<Message, MessageModel>);
        }

        public async Task<IEnumerable<MessageModel>> GetUserMessagesToUser(int senderId, int recipientId)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg => msg.SenderId == senderId && msg.AddresseeId == recipientId)))
                .Select(Mapper.Map<Message, MessageModel>);
        }

        public async Task<IEnumerable<MessageModel>> GetMessagesBetween(int firstUserId, int secondUserId)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg =>
                (msg.SenderId == firstUserId && msg.AddresseeId == secondUserId)
                || (msg.SenderId == secondUserId && msg.AddresseeId == firstUserId))))
                .Select(Mapper.Map<Message, MessageModel>);
        }

        public async Task<IEnumerable<MessageModel>> GetRecievedMessagesBy(int recipientId)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg => msg.AddresseeId == recipientId)))
                .Select(Mapper.Map<Message, MessageModel>);
        }

        public async Task<MessageModel> GetMessageById(int id)
        {
            return Mapper.Map<Message, MessageModel>(await _messagesRepository.GetItemAsync(id));
        }

        public async Task<MessageModel> AddMessage(MessageModel message)
        {
            Message dbMessage = Mapper.Map<MessageModel, Message>(message);

            return Mapper.Map<Message, MessageModel>(await _messagesRepository.AddItemAsync(dbMessage));
        }

        public async Task<MessageModel> UpdateMessage(MessageModel message)
        {
            Message dbMessage = Mapper.Map<MessageModel, Message>(message);

            return Mapper.Map<Message, MessageModel>(await _messagesRepository.UpdateItemAsync(dbMessage));
        }

        public async Task<bool> DeleteMessage(int id)
        {
            try
            {
                await _messagesRepository.RemoveItemAsync(id);
                return true;
            }
            catch
            {
                //TODO: Handle exception
                return false;
            }
        }
    }
}
