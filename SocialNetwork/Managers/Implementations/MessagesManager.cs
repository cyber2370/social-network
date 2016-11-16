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

        public async Task<IEnumerable<MessageModel>> GetMessagesOf(UserModel user)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg => msg.SenderId == user.Email || msg.AddresseeId == user.Email)))
                .Select(Mapper.Map<Message, MessageModel>);

            /*string email = user.Email;;

            Dictionary<string, IEnumerable<MessageModel>> dictionary = new Dictionary<string, IEnumerable<MessageModel>>();

            var tmp1 = userMessages.Select(x => x.SenderId).Distinct();
            var tmp2 = userMessages.Select(x => x.AddresseeId).Distinct();
            var uniqueEmails = tmp1.Union(tmp2);

            foreach (var mail in uniqueEmails)
            {
                var messagesByEmail = userMessages
                    .Where(msg => msg.AddresseeId == mail || msg.SenderId == mail)
                    .Select(Mapper.Map<Message, MessageModel>);

                dictionary.Add(email, messagesByEmail);
            }

            return dictionary;*/
        }

        public async Task<IEnumerable<MessageModel>> GetUserMessagesToUser(UserModel sender, UserModel recipient)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg => msg.SenderId == sender.Email && msg.AddresseeId == recipient.Email)))
                .Select(Mapper.Map<Message, MessageModel>);
        }

        public async Task<IEnumerable<MessageModel>> GetMessagesBetween(UserModel firstUser, UserModel secondUser)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg =>
                (msg.SenderId == firstUser.Email && msg.AddresseeId == secondUser.Email)
                || (msg.SenderId == secondUser.Email && msg.AddresseeId == firstUser.Email))))
                .Select(Mapper.Map<Message, MessageModel>);
        }

        public async Task<IEnumerable<MessageModel>> GetRecievedMessagesBy(UserModel recipient)
        {
            return (await _messagesRepository.GetItemsAsync(
                x => x.Where(msg => msg.AddresseeId == recipient.Email)))
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
