using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;
using Managers.Models.Friends;

namespace SocialNetworkApi.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IMessagesManager _messagesManager;

        public MessagesController(IMessagesManager messagesManager)
        {
            _messagesManager = messagesManager;
        }

        [HttpGet]
        [Route("api/users/{id}/messages/{opponentId}")]
        public async Task<IEnumerable<MessageModel>> GetUserMessagesWith(int id, int opponentId)
        {
            return await _messagesManager.GetMessagesBetween(id, opponentId);
        }

        [HttpPost]
        public async Task<MessageModel> SendMessage([FromBody]MessageModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException("Invalid model state");    
            }

            return await _messagesManager.AddMessage(model);
        }
        
        [HttpDelete]
        public async Task<bool> RemoveFriends(int id)
        {
            return await _messagesManager.DeleteMessage(id);
        }
    }
}